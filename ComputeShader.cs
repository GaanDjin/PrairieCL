using PrairieCL.OpenCL;
using System.Runtime.InteropServices;
using System.Numerics;
using System;

namespace PrairieCL
{
    /// <summary>
    /// Compute shader wrapper to use OpenCL compute shaders to run code on the GPU :-)
    /// 
    /// This class is thread safe and can be instantiated by many threads. 
    /// <code>
    /// ComputeShader testShader = new ComputeShader(
    /// @"
    ///    __kernel void helloworld(__global int* BufferData) {
    /// 
    ///     const int index_x = get_global_id(0);
    ///    const int index_y = get_global_id(1);
    ///    const int index_z = get_global_id(2);
    ///    const int X = get_global_size(0);
    ///    const int Y = get_global_size(1);
    ///    const int Z = get_global_size(2);
    ///    const int index_here = X*(Y*index_z + index_y) + index_x;
    /// 
    ///    BufferData[index_here] = index_x + index_y + index_z;
    /// }
    /// ");
    /// ComputeShaderParameter parameter = new ComputeShaderParameter();
    /// parameter.BufferSize = 64;
    /// parameter.Data = new int[parameter.BufferSize];
    ///
    /// int session = testShader.ExecuteKernel("helloworld", new Vector3i(4, 4, 4), new ComputeShaderParameter[] { parameter });
    /// testShader.Wait(session);
    /// int[] result = testShader.GetParameterAsIntArray(parameter, session);
    ///
    /// Console.WriteLine(" " + result[1]);
    /// </code>
    /// </summary>
    public class ComputeShader : IDisposable
    {
        private bool _disposed = false;

        //private static object lockObj = new object();

        /// <summary>
        /// A library of include directives that have been added for the compute 
        /// shader to use. This allows us to break up a compute shader into smaller
        /// files and include them as needed.
        /// The key should be the name of the include without brackets or quotes.
        /// The value will be the source code or file path to read.
        /// </summary>
        private static Dictionary<string, string> IncludeLibrary = new Dictionary<string, string>();

        /// <summary>
        /// The name of the selected OpenCL Device (The selected GPU Card)
        /// </summary>
        public string SelectedPlatformName { get; } = null;

        private static CLContext context;

        /// <summary>
        /// The Physical device (GPU hardware) on this machaine.
        /// </summary>
        public static CLContext Context
        {
            get
            {
                //lock (lockObj)
                {
                 
                if (context != null && context.Handle.Handle != IntPtr.Zero)
                    return context;

                   GetPlatformAndDevice(null, out _, out device_ids);
                    context = CL.CreateContext(CLContextProperties.None, device_ids, IntPtr.Zero, IntPtr.Zero, out _);
                    Commands = CL.CreateCommandQueueWithProperties(context, device_ids[0], null, out _);
                }
                return context;
            }
            set
            {
                context = value;
            }
        }

        /// <summary>
        /// The Physical compute devices on this GPU.
        /// Prefer in order of nvidia --> amd --> whatever else card there is.
        /// </summary>
        internal static CLDevice[] device_ids;

        /// <summary>
        /// The OpenCL functions are submitted to the command queue for execution 
        /// on the GPU. Only one instance is needed to handle all Kernel calls from
        /// many compute shaders across threads. 
        /// </summary>
        internal static CLCommandQueue Commands;

        /// <summary>
        /// A handle to the compiled program on the GPU.
        /// </summary>
        private CLProgram Program;

        /// <summary>
        /// Not really sure what the waitlist is for but we need them for getting data back from the gpu. ;-)
        /// </summary>
        private List<CLEventPtr> Waitlist = new List<CLEventPtr>();
        //private Dictionary<int, CLEventPtr[]> Waitlist = new Dictionary<int, CLEventPtr[]>();

        /// <summary>
        /// The Kernels in the Compute Shader.
        /// This isn't loaded from the shader as meta data but rather a cache of kernels that have been called by <see cref="ExecuteKernel(string, Vector3i, ComputeShaderParameter[])"/>. This lets us call the same kernel each time without recompiling it every time.
        /// </summary>
        Dictionary<string, CLKernel> Kernels = new Dictionary<string, CLKernel>();

        /// <summary>
        /// When <see cref="ExecuteKernel(string, Vector3i, ComputeShaderParameter[])"/> is called its assigned a session. 
        /// This helps us keep track of which internal waitlist should be used when <see cref="Wait(int)"/> and getting data back from parameters (for eg <see cref="GetParameterAsFloatArray(ComputeShaderParameter, int)"/>)
        /// </summary>
        int KernelSessionIDIndex = 0;

        /// <summary>
        /// 
        /// </summary>
        public string LastError { get; private set; } = "";

        /// <summary>
        /// Cache GPU Cards by Name.
        /// If we can change these at runtime last time I checked we can't add/remove graphics cards while the computer is running so if we can I'm super impressed!
        /// </summary>
        private static readonly Dictionary<string, CLPlatform> gpuPlatforms = new Dictionary<string, CLPlatform>();

        /// <summary>
        /// Cache GPU Devices by GPU Name
        /// </summary>
        private static readonly Dictionary<string, CLDevice[]> gpuDevices = new Dictionary<string, CLDevice[]>();

        /// <summary>
        /// Get a list of available GPU Cards.
        /// </summary>
        public static List<string> GPUPlatforms
        {
            get
            {
                //lock (lockObj)
                {
                    if (gpuPlatforms.Count > 0)
                        return gpuPlatforms.Keys.ToList();

                    //Get GPU Cards
                    CLResult err = CL.GetPlatformIDs(out CLPlatform[] platforms);

                    if (err != CLResult.Success)
                    {
                        throw new Exception("Unable to get a list of GPUs! " + err);
                    }

                    foreach (CLPlatform platform in platforms)
                    {
                        //The name of the OpenGL Graphivs Card Processor
                        err = CL.GetPlatformInfo(platform, CLPlatformInfo.Name, out byte[] platformName);

                        if (err != CLResult.Success)
                        {
                            ///TODO: Fail here or just assume the GPU isn't availiable?
                            continue;
                        }

                        //Get Gpu Devices on this card. 
                        err = CL.GetDeviceIDs(platform, CLDeviceType.GPU, out CLDevice[] device_ids);

                        if (err != CLResult.Success)
                        {
                            ///TODO: Fail here or just assume the GPU isn't availiable?
                            continue;
                        }

                        if (device_ids == null || device_ids.Length == 0)
                            continue; //No gpu devices on this graphics card for some reason.

                        string strPlatformName = ""; // new string((char[])platformName);

                        foreach (byte c in platformName)
                            strPlatformName += (char)c;

                        gpuPlatforms.Add(strPlatformName, platform);
                        gpuDevices.Add(strPlatformName, device_ids); ///TODO: Is there ever more than one device?
                    }

                    return gpuPlatforms.Keys.ToList();
                }
            }
        }

        /// <summary>
        /// Gets the GPU OpenCL platform and devices for the specified GPU Card.
        /// </summary>
        /// <param name="name">The name of the GPU card. <see cref="GPUPlatforms">GPUPlatforms</see></param>
        /// <param name="platform">Outputs the OpenCL Platform.</param>
        /// <param name="device">Outputs the OpenCL Devices for the Platform.</param>
        /// <returns>True if the name correctly corrisponds to an OpenCL capable GPU; Otherwise false.</returns>
        private static bool GetPlatformAndDevice(string name, out CLPlatform platform, out CLDevice[] device)
        {
            //Call GPUPlatforms just to make sure gpuPlatforms and gpuDevices is populated
            List<string> platforms = GPUPlatforms;

            if (name != null && gpuPlatforms.ContainsKey(name))
            {
                platform = gpuPlatforms[name];
                device = gpuDevices[name];
                return true;
            }
            else if (name == null || name.Length == 0)
            {
                CLResult err;
                //get Platforms (GPU Cards). We're assuming the computer has more than one.

                platform = gpuPlatforms.Last().Value;

                string SelectedPlatformName = null;

                //Loop through each card and get name + CLPlatform and CLDevices
                foreach (string strPlatformName in platforms)
                {

                    //Once we have the name of the ard select the best gpu we can. 
                    //Prefer in order of nvidia --> amd --> whatever else card there is. 
                    if (strPlatformName.ToLower().Contains("nvidia"))
                    {
                        platform = gpuPlatforms[strPlatformName];
                        SelectedPlatformName = strPlatformName;
                        break;
                    }
                    else if (strPlatformName.ToLower().Contains("amd"))
                    {
                        platform = gpuPlatforms[strPlatformName];
                        SelectedPlatformName = strPlatformName;
                    }
                    else if (SelectedPlatformName == null)
                    {
                        platform = gpuPlatforms[strPlatformName];
                        SelectedPlatformName = strPlatformName;
                    }
                }

                //get Devices for selected GPU
                err = CL.GetDeviceIDs(platform, CLDeviceType.GPU, out device);

                //if (err != CLResult.Success)
                //{
                //    throw new 
                //}
                return true;
            }
            else
            {
                ///TODO: Hrm Don't like this...
                platform = new CLPlatform(IntPtr.Zero);
                device = new CLDevice[0];
            }

            return false;

        }

        /// <summary>
        /// The maximum number of workers per job.
        /// </summary>
        public long MaxGroupSize { get; set; }

        /// <summary>
        /// The number of dimensions the device has. S/B: 3
        /// </summary>
        public long MaxGroupDimensions { get; set; }

        /// <summary>
        /// The maximum number of each workgroup. (Well the first 3)
        /// The multiplication of each dimension cannot exceed MaxGroupSize.
        /// </summary>
        public Vector3i MaxWorkgroupsSize { get; set; }

        /// <summary>
        /// Maximum number of compute shaders that can run at the same time.
        /// </summary>
        public long MaxComputeUnits { get; set; }

        /// <summary>
        /// The Maximum amount of memory this device can allocate. (In Bytes)
        /// </summary>
        public long MaxMemory { get; set; }

        /// <summary>
        /// Query the GPU to get specs about the compute shader
        /// </summary>
        private void GetDeviceInfo()
        {
            //string MaxWorkGroupSize = "";

            CL.GetDeviceInfo(device_ids[0], CLDeviceInfo.MaxWorkItemDimensions, out byte[] maxDimsDevInfodata);
            CL.GetDeviceInfo(device_ids[0], CLDeviceInfo.MaxWorkGroupSize, out byte[] maxGroupSizeDevInfodata);
            CL.GetDeviceInfo(device_ids[0], CLDeviceInfo.MaxWorkGroupItemSizes, out byte[] maxItemSizesDevInfodata);

            CL.GetDeviceInfo(device_ids[0], CLDeviceInfo.MaxComputeUnits, out byte[] maxComputeUnitsdata);
            CL.GetDeviceInfo(device_ids[0], CLDeviceInfo.MaxMemoryAllocationSize, out byte[] maxmemdata);

            //foreach (byte c in maxItemSizesDevInfodata)
            //    MaximumWorkItemSizes += (char)c;


            long maxGroupSizeDevInfo = BitConverter.ToInt64(maxGroupSizeDevInfodata, 0);
            int maxDimsDevInfo = BitConverter.ToInt32(maxDimsDevInfodata, 0);
            long maxItemSizesDevInfo1 = BitConverter.ToInt64(maxItemSizesDevInfodata, 0);
            long maxItemSizesDevInfo2 = BitConverter.ToInt64(maxItemSizesDevInfodata, 8);
            long maxItemSizesDevInfo3 = BitConverter.ToInt64(maxItemSizesDevInfodata, 16);

            int maxComputeUnits = BitConverter.ToInt32(maxComputeUnitsdata, 0);
            long maxmem = BitConverter.ToInt64(maxmemdata, 0);

            MaxGroupSize = (int)maxGroupSizeDevInfo;
            MaxGroupDimensions = maxDimsDevInfo;
            MaxWorkgroupsSize = new Vector3i((int)maxItemSizesDevInfo1, (int)maxItemSizesDevInfo2, (int)maxItemSizesDevInfo3);
            MaxComputeUnits = maxComputeUnits;
            MaxMemory = maxmem;
        }

        /// <summary>
        /// Instantiates a new Compute Shader Class using the specified shader code.
        /// The GPU can be specified. If gpu is omitted a GPU is selected in the order of NVIDIA --> AMD --> Other
        /// </summary>
        /// <param name="shaderCode">The shader code to be executed.</param>
        /// <param name="gpu">Optional: The GPU to use. <see cref="GPUPlatforms">GPUPlatforms</see>.</param>
        public ComputeShader(string shaderCode, string gpu = null)
        {

            CLResult err;

            if (device_ids == null || device_ids.Length == 0)
                //lock (lockObj)
                {
                    GetPlatformAndDevice(gpu, out _, out device_ids);
                }

            //if (Context.Handle.Handle != IntPtr.Zero)
            {
                GetDeviceInfo();
            }

            if (Commands == null)
            {
                GetPlatformAndDevice(null, out _, out device_ids);
                if (context == null || context.Handle.Handle == IntPtr.Zero)
                    context = CL.CreateContext(CLContextProperties.None, device_ids, IntPtr.Zero, IntPtr.Zero, out _);
                Commands = CL.CreateCommandQueueWithProperties(context, device_ids[0], null, out _);
            }

            if (Commands.Handle.Handle == IntPtr.Zero)
            {
                //lock (lockObj)
                {
                    //Get Command Queue for whatever lol.
                    Commands = CL.CreateCommandQueueWithProperties(Context, device_ids[0], null, out err);
                }

                if (err != CLResult.Success)
                {
                    throw new Exception("Failed to create command queue: " + err);
                }
            }

            string shaderSrc = ReplaceIncludes(shaderCode);

            //Load the program from the passed source code. 
            Program = new CLProgram( CL.CreateProgramWithSource(Context, shaderSrc, out err));

            //Program = CLProgram.Create(out string result, Context, shaderCode, device_ids);

            //Compile the program for actual execution.
            err = CL.BuildProgram(Program, 1, device_ids, "", null, IntPtr.Zero);
            //err = CL.BuildProgram(program, 1, device_ids, "", 1, null, out IntPtr headerIncludeNames, IntPtr.Zero, IntPtr.Zero);

            //If the shader doesn't compile then give a more meaningful error.
            if (err != CLResult.Success)
            {
                string strLog = "";

                for(int i = 0; i < device_ids.Length; i++)
                {
                    strLog += "\n";
                    err = CL.GetProgramBuildInfo(Program, device_ids[i], out string logData);

                    strLog += logData;
                    //foreach (byte c in logData)
                    //{
                    //    if (c!= 0)  
                    //        strLog += (char)c;
                    //}
                }

                throw new Exception("Compute Shader Program build failed." + strLog);
            }

            ListKernels();
        }

        /// <summary>
        /// Query the compute shader for the kernels (functions) that 
        /// can be executed.
        /// </summary>
        void ListKernels()
        {
            CLResult err = CL.CreateKernelsInProgram(Program,
                                0,
                                null,
                                out int num_kernels_ret);

            if (err != CLResult.Success)
                return;

            CLKernelPtr[] kernels = new CLKernelPtr[num_kernels_ret];

            err = CL.CreateKernelsInProgram(Program,
                                num_kernels_ret,
                                kernels,
                                out num_kernels_ret);

            if (err != CLResult.Success)
                return;

            foreach (CLKernelPtr kernel in kernels)
            {
                CLKernel k = new CLKernel(kernel);
                Kernels.Add(k.FunctionName, k);
            }
        }

        /// <summary>
        /// Run a kernel (function) in the compute shader. A session is returned for getting data back from the gpu.
        /// </summary>
        /// <param name="kernelName">The name of the Kernel to call.</param>
        /// <param name="globalworkgroups">
        /// The number of global workgroups to run. we use a Vector3 because we assuming we're running in 3D space most often. For lower dimensions you can just set Z and Y to 1. 
        /// </param>
        /// <param name="kernelParameters">The offset that our workgroups will be adjusted by.</param>
        /// <returns>The session ID of this call.</returns>
        public int ExecuteKernel(string kernelName, Vector3i globalworkgroups, CLBuffer[] kernelParameters = null)
        {
            return ExecuteKernel(kernelName, globalworkgroups, new Vector3i(1, 1, 1), Vector3i.Zero, kernelParameters);
        }

        /// <summary>
        /// Run a kernel (function) in the compute shader. A session is returned for getting data back from the gpu.
        /// </summary>
        /// <param name="kernelName">The name of the Kernel to call.</param>
        /// <param name="globalworkgroups">
        /// The number of global workgroups to run. we use a Vector3 because we assuming we're running in 3D space most often. For lower dimensions you can just set Z and Y to 1. 
        /// </param>
        /// <param name="localworkgroups">
        /// The number of local workgroups to run. we use a Vector3 because we assuming we're running in 3D space most often. For lower dimensions you can just set Z and Y to 1. 
        /// </param>
        /// <param name="kernelParameters">The offset that our workgroups will be adjusted by.</param>
        /// <returns>The session ID of this call.</returns>
        public int ExecuteKernel(string kernelName, Vector3i globalworkgroups, Vector3i localworkgroups, CLBuffer[] kernelParameters = null)
        {
            return ExecuteKernel(kernelName, globalworkgroups, localworkgroups, Vector3i.Zero, kernelParameters);
        }

        /// <summary>
        /// Run a kernel (function) in the compute shader. A session is returned for getting data back from the gpu.
        /// </summary>
        /// <param name="kernelName">The name of the Kernel to call.</param>
        /// <param name="globalworkgroups">
        /// The number of workgroups to run. we use a Vector3 because we assuming we're running in 3D space most often. For lower dimensions you can just set Z and Y to 1. 
        /// </param>
        /// <param name="localworkgroups">
        /// The number of workgroups to run. we use a Vector3 because we assuming we're running in 3D space most often. For lower dimensions you can just set Z and Y to 1. 
        /// </param>
        /// <param name="workgroupOffset">
        /// The offset that our workgroups will be adjusted by.
        /// </param>
        /// <param name="kernelParameters">The parameters to pass to the function. Must match the shader code kernel paraeters.</param>
        /// <returns>The session ID of this call.</returns>
        public int ExecuteKernel(string kernelName, Vector3i globalworkgroups, Vector3i localworkgroups, Vector3i workgroupOffset, CLBuffer[] kernelParameters = null)
        {
            //lock (lockObj)
            //{
            //    //Increment this function call session refernce number.
            //    KernelSessionIDIndex++;
            //}

            CLResult err;

            CLKernel kernel;
            //lock (lockObj)
            {
                if (!Kernels.ContainsKey(kernelName))
                {
                    //Create a link to the shader kernel to call. 
                    //Remember we can have more than one kernel in our compute shader.
                    kernel = new CLKernel(CL.CreateKernel(Program, kernelName, out err));

                    if (err != CLResult.Success)
                    {
                        throw new Exception("Failed to create kernel! " + err);
                    }

                    Kernels.Add(kernelName, kernel);
                }
                else //If the Kernel has already been compiled lets re-use it.
                    kernel = Kernels[kernelName];
            }

            CL.GetKernelWorkGroupInfo(kernel, device_ids[0], CLKernelWorkGroupInfo.PreferredWorkGroupSizeMultiple, out byte[] wgSizeData);
            long maxComputeUnits = BitConverter.ToInt64(wgSizeData, 0);

            if (kernelParameters != null)
            {
                int paramNumber = 0;
                foreach (CLBuffer param in kernelParameters)
                {
                    if (param == null)
                    {
                        paramNumber++;
                        continue;
                    }
                    //Loop through the list of parameters and send the data to the gpu. 
                    //Create the buffer on the gpu.
                    err = CL.SetKernelArg(kernel, paramNumber++, Marshal.SizeOf(typeof(IntPtr)), ref param.Handle);
                    if (err != CLResult.Success)
                    {
                        throw new Exception("Parameter " + (paramNumber - 1) + " Not Valid: " + err);
                    }
                }
            }
            //err = CL.GetKernelWorkGroupInfo(kernelMain, device_ids[0], KernelWorkGroupInfo.GlobalWorkSize, out byte[] workerSize);

            CLEventPtr evt;
            //Actually execute the kernel (function) on the gpu.
            err = CL.EnqueueNDRangeKernel(
                Commands,
                kernel,
                3,
                new ulong[] {  ((uint)workgroupOffset.X), ((uint)workgroupOffset.Y), ((uint)workgroupOffset.Z) },
                new ulong[] {  ((uint)globalworkgroups.X),((uint)globalworkgroups.Y), ((uint)globalworkgroups.Z) },
                new ulong[] {  ((uint)localworkgroups.X), ((uint)localworkgroups.Y), ((uint)localworkgroups.Z) },
                //new UIntPtr[] { new UIntPtr((uint)workgroups.X), new UIntPtr((uint)workgroups.Y), new UIntPtr((uint)workgroups.Z) },
                0,
                null,
                out evt);


            if (err != CLResult.Success)
            {
                throw new Exception("Failed to Execute Kernel: " + err);
            }

            //This is the wait event that is needed for waiting for long running code and for getting data back from the kernel parameters. 
            //CLEventPtr[] waitevent = new CLEventPtr[] { evt };

            //lock (lockObj)
            {
                KernelSessionIDIndex++;
                //Save for future reference in other calls. 
                Waitlist.Add(evt); // Waitlist.Add(KernelSessionIDIndex, waitevent);
            }
            //Return the session id for recalling in Wait and GetParameter calls
            return KernelSessionIDIndex;

        }

        /// <summary>
        /// Wait for the specified kernel call to finish executing before getting data back from the GPU.
        /// This will block the current thread from continuing until the GPU call is complete.
        /// </summary>
        /// <param name="session">The reference to the Execute call that was made. Depreciated.</param>
        public void Wait(int session = 0)
        {
            //lock (lockObj)
            {
                CLResult err = CL.Finish(Commands);
                //if (Waitlist.ContainsKey(session))
                //    CL.WaitForEvents(0, Waitlist[session]);

                if(Waitlist.Count > 0)
                    CL.WaitForEvents(Waitlist.Count, Waitlist.ToArray());
            }
        }

        /// <summary>
        /// Clear the session waitlists. 
        /// Removes any events that may be waiting or finished.
        /// </summary>
        /// <param name="session">The reference to the Execute call that was made. Depreciated.</param>
        public void ClearSession(int session)
        {
            //lock (lockObj)
            {
                //if (Waitlist.ContainsKey(session))
                //{
                //    CLEventPtr[] waitevent = Waitlist[session];
                //    Waitlist.Remove(session);
                //    foreach (CLEventPtr w in waitevent)
                //        CL.Release(w);
                //}

                while (Waitlist.Count > 0)
                {
                    CL.Release(Waitlist[0]);
                    Waitlist.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// Queries the compute shader to find out if a kernel is running.
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool IsRunning(int session)
        {
            if(Waitlist.Count == 0)
                return false;

            //if (!Waitlist.ContainsKey(session))
            //    return false;
            //lock (lockObj)
            {
            CLResult err = CL.GetEventInfo(Waitlist[0], CLEventInfo.CommandExecutionStatus, out byte[] result);

            if (result == null || err != CLResult.Success)
            {
                return false;
            }

            if (result[0] == 0)
                return false;
 }
            /*
#define CL_COMPLETE                                 0x0
#define CL_RUNNING                                  0x1
#define CL_SUBMITTED                                0x2
#define CL_QUEUED                                   0x3
            */
            return true;
        }

        /// <summary>
        /// Read a value from the compute shader.
        /// </summary>
        /// <typeparam name="T">The unmanaged object type (bittable struct, float, int, Vector3, etc.</typeparam>
        /// <param name="buf">The buffer to read.</param>
        /// <returns>The value from the compute shader. If the buffer is an array
        /// then only the first element will be returned.</returns>
        public T ReadBufferValue<T>(CLBuffer buf) where T : unmanaged
        {
            //lock (lockObj)
            {
                CLResult err = CL.EnqueueReadBuffer(Commands, buf, true, 0, buf.Size, buf.GlobalDataPointer.AddrOfPinnedObject(), Waitlist.Count, Waitlist.ToArray(), out _); //(int)Waitlist[session].Length, Waitlist[session]
            }
                return Marshal.PtrToStructure<T>(buf.GlobalDataPointer.AddrOfPinnedObject());

        }

        /// <summary>
        /// Reads an array of data from the compute shader 
        /// </summary>
        /// <typeparam name="T">An unmanaged data type like a bittable struct, float, int, Vector3, etc.</typeparam>
        /// <param name="buf">The buffer to read</param>
        /// <param name="session">The kernel session. Depreciated. Unused.</param>
        /// <param name="length">The number of elements to read from the buffer.
        /// If -1 is passed the whole array will be ready.</param>
        /// <returns>An array of "length" elements read from the GPU.</returns>
        public Span<T> ReadBufferData<T>(CLBuffer buf, int session = 0, long length = -1) where T : unmanaged
        {
            int tSize = Marshal.SizeOf(typeof(T));

            //lock (lockObj)
            {

                if (length == -1 || length > buf.Size / tSize)
                    length = buf.Size / tSize;
                //else
                //    length *= tSize;

            CLResult err = CL.EnqueueReadBuffer(Commands, buf, true, 0, length * tSize, buf.GlobalDataPointer.AddrOfPinnedObject(), Waitlist.Count, Waitlist.ToArray(), out _);
 }


            if (typeof(float) == typeof(T))
            {
                float[] data = new float[length];
                Array.Copy((float[])buf.GlobalDataPointer.Target, data, data.Length);
                return MemoryMarshal.Cast<float, T>(data.AsSpan());
            }
            else if (typeof(int) == typeof(T))
            {
                int[] data = new int[length];
                Array.Copy((int[])buf.GlobalDataPointer.Target, data, data.Length);
                return MemoryMarshal.Cast<int, T>(data.AsSpan());
            }
            else if (typeof(Vector3) == typeof(T))
            {
                Vector3[] data = new Vector3[length];
                Array.Copy((Vector3[])buf.GlobalDataPointer.Target, data, data.Length);
                return MemoryMarshal.Cast<Vector3, T>(data.AsSpan());
            }
            else if (typeof(Vector2) == typeof(T))
            {
                Vector2[] data = new Vector2[length];
                Array.Copy((Vector2[])buf.GlobalDataPointer.Target, data, data.Length);
                return MemoryMarshal.Cast<Vector2, T>(data.AsSpan());
            }
            else if (typeof(Vector4) == typeof(T))
            {
                Vector4[] data = new Vector4[length];
                Array.Copy((Vector4[])buf.GlobalDataPointer.Target, data, data.Length);
                return MemoryMarshal.Cast<Vector4, T>(data.AsSpan());
            }
            else if (typeof(byte) == typeof(T))
            {
                byte[] data = new byte[length];
                Array.Copy((byte[])buf.GlobalDataPointer.Target, data, data.Length);
                return MemoryMarshal.Cast<byte, T>(data.AsSpan());
            }

            T[] arr = new T[buf.Size / tSize];

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = Marshal.PtrToStructure<T>(buf.GlobalDataPointer.AddrOfPinnedObject() + (i * tSize));
            }


            return arr;
        }

        /// <summary>
        /// Looks at the shader code and replaces any #include <...> directives 
        /// with the associated code in the <see cref="IncludeLibrary"/>.
        /// This is recursive and will add includes found in the included code
        /// but will only add the code once if more than one include points to
        /// the same place.
        /// If an include directive points to a tag that isn't in the library 
        /// it will not be replaced (And the compute shader likely won't compile)
        /// </summary>
        /// <param name="shaderCode">The shader code to replace include directives</param>
        /// <param name="includes">Any include directives that have already been 
        /// replaced. Used for recursive lookups to ensure an include isn't added twice.
        /// Leave null on initial call.</param>
        /// <returns>The shader code with included code injected at include directive lines.</returns>
        private static string ReplaceIncludes(string shaderCode, List<string > includes = null)
        {
            if (includes == null)
                includes = new List<string>();

            string src = "";

            foreach (string line in shaderCode.Split("\n"))
            {
                if (line.Trim().StartsWith("#include <"))
                {
                    if (includes.Contains(line.Trim()))
                        continue; //If we've already added the include then don't add it again!

                    includes.Add(line.Trim());
                    string inc = GetInclude(line.Trim());
                    if (inc.Contains("#include <")) ReplaceIncludes(inc, includes);
                    src += inc + "\n";
                }
                else
                    src += line + "\n";
            }

            return src;
        }

        /// <summary>
        /// Adds an include code snippet to the library.
        /// The source code can contain include directives that will be replaced
        /// when added to a compute shader. (If the include exists in the library)
        /// If an include with the same name already exists then it will be replaced.
        /// The name will be made lower case so beware that include directives are
        /// case insensitive. (MyInclude == myinclude)
        /// source may be either source code or a file path to the source code in a file. 
        /// Note if using file paths the path isn't validated and 
        /// if it is a file that doesn't exist the path will be returned instead of 
        /// the file contents. 
        /// (We assume if it doesn't exist as a file it might be a one line peice of code)
        /// </summary>
        /// <param name="name">The name of the include code. This should match 
        /// the name in the include directive 
        /// eg. #include <myCode> ==> "mycode"</param>
        /// <param name="source">The source code or file path of the snippet.</param>
        /// <returns>True if the include was added. 
        /// False if the name or source is null</returns>
        public static bool AddInclude(string name, string source)
        {
            if (name == null) return false;
            if (source == null) return false;

            string n = name.Trim().ToLower();

            if (name.Length == 0) return false;

            n = n.Replace("#include <", "");
            n = n.Replace("#include", "");
            n = n.Replace(">", "");

            if (!IncludeLibrary.ContainsKey(n))
            {
                IncludeLibrary.Add(n, source);
                return true;
            }
            else
            {
                IncludeLibrary[n] = source;
                return true;
            }
        }

        /// <summary>
        /// Gets the source code in the library for the given include name
        /// </summary>
        /// <param name="name">The nae of the snippet to get.</param>
        /// <returns>The source code for the snippet or an empty string "" if 
        /// not found.</returns>
        public static string GetInclude(string name)
        {
            if (name == null) return "";

            string n = name.Trim().ToLower();

            if (n.Length == 0) return "";

            n = n.Replace("#include <", "");
            n = n.Replace("#include", "");
            n = n.Replace(">", "");

            if (IncludeLibrary.ContainsKey(n))
            {
                //Test to see if this snippet is actually a file path. 
                //If it is a path and the file exists then read the file contents.
                bool possiblePath = IncludeLibrary[n].IndexOfAny(Path.GetInvalidPathChars()) == -1;
                possiblePath |= IncludeLibrary[n].IndexOfAny(new char[] { '\n', '\r' }) == -1;
                if (possiblePath && File.Exists(IncludeLibrary[n]))
                    return File.ReadAllText(IncludeLibrary[n]);
                return IncludeLibrary[n];
            }

            return "";
        }

        /// <summary>
        /// Cleanup all GPU data pointers.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return ;

            //Keep devices between object instances.
            //foreach (CLDevice dev in Devices)
            //{
            //    CL.ReleaseDevice(dev);
            //}

            foreach (CLKernel kernel in Kernels.Values)
                kernel.Dispose(); // CL.Release();

            foreach (CLEventPtr evt in Waitlist)
            {
                //foreach (CLEvent evt in evts)
                    CL.Release(evt); //evt.Dispose(); //
            }

            //CL.ReleaseMemObject(output);
            Program.Dispose(); //CL.Release();
            //Commands.Dispose(); //CL.Release();
            //Context.Dispose(); //CL.Release();

            //foreach(KeyValuePair<string, CLPlatform> platforms in GPUPlatforms)
            //{
            //    platforms.Value.Dispose();
            //}

            _disposed = true;
        }

        ~ComputeShader()
        {
            Dispose();
        }

    }

}