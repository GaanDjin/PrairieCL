using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrairieCL.OpenCL
{
    /// <summary>
    /// This class handles compiling the compute shader, sending data (arguments), and execution requests to the GPU.
    /// </summary>
    public class CLProgram : IDisposable
    {
        /// <summary>
        /// A pointer to the actual program in GPU memory.
        /// </summary>
        public CLProgramPtr Handle;

        /// <summary>
        /// The functions that can be executed on the GPU by this program.
        /// </summary>
        public CLKernel[] Kernels { get; private set; }

        #region Info Properties

        /// <summary>
        /// What type of executable this program is.
        /// </summary>
        public CLProgramBinaryType BinaryType { get; private set; }

        /// <summary>
        /// How much memory this program takes up on the GPU.
        /// </summary>
        public int GlobalVariableTotalSize { get; private set; }

        /// <summary>
        /// Return the program reference count.
        /// 
        /// The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </summary>
        public int ReferenceCount
        {
            get
            {
                IntPtr data = Marshal.AllocHGlobal(4);


                CLResult result = CL.GetProgramInfo(Handle,
                     CLProgramInfo.ReferenceCount,
                     4,
                     data,
                      out _);
                int val = Marshal.ReadInt32(data);

                Marshal.FreeHGlobal(data);

                return val;
            }
        }

        /// <summary>
        /// Return the context specified when the program object is created
        /// </summary>
        public CLContextPtr Context { get; private set; }

        private CLDevicePtr[] devices = null;

        /// <summary>
        /// Return the list of devices associated with the program object. This can be the devices associated with context on which the program object has been created or can be a subset of devices that are specified when a progam object is created using CreateProgramWithBinary.
        /// </summary>
        public CLDevicePtr[] Devices
        {
            get
            {
                if (devices != null)
                    return devices;

                CLResult result;
                int param_value_size = 4;
                IntPtr data = Marshal.AllocHGlobal(param_value_size);

                result = CL.GetProgramInfo(Handle,
                     CLProgramInfo.NumberOfDevices,
                     param_value_size,
                     data,
                      out param_value_size);

                int numDevices = Marshal.ReadInt32(data);

                Marshal.FreeHGlobal(data);
                data = Marshal.AllocHGlobal(param_value_size);


                result = CL.GetProgramInfo(Handle,
                     CLProgramInfo.Devices,
                     numDevices * 8,
                     data,
                      out _);

                devices = new CLDevicePtr[numDevices];

                for (int i = 0; i < numDevices; i++)
                {
                    ///TODO: Verify 4 byte handles.
                    devices[i] = new CLDevicePtr();
                    devices[i].Handle = new IntPtr(Marshal.ReadInt64(data, i * 8));
                }

                Marshal.FreeHGlobal(data);

                return devices;
            }
        }

        private string sourcecode = null;

        /// <summary>
        /// Return the program source code specified by CreateProgramWithSource.
        /// The source string returned is a concatenation of all source strings specified to CreateProgramWithSource. 
        /// The concatenation strips any nulls in the original source strings.
        /// 
        /// If program is created using CreateProgramWithBinary or clCreateProgramWithBuiltInKernels, 
        /// an empty string or the appropriate program source code is returned depending on whether or not the program source code 
        /// is stored in the binary. AKA if created using binary there will be no source code string.
        /// </summary>
        public string Source
        {
            get
            {
                if (sourcecode != null)
                    return sourcecode;

                CLResult result;
                int param_value_size = 4;
                IntPtr data = Marshal.AllocHGlobal(param_value_size);

                result = CL.GetProgramInfo(Handle,
                     CLProgramInfo.Source,
                     param_value_size,
                     data,
                      out param_value_size);

                if (param_value_size > 0)
                    sourcecode = Marshal.PtrToStringUTF8(data);
                else
                    sourcecode = "";

                Marshal.FreeHGlobal(data);

                return sourcecode;
            }

        }

        private byte[][] binaries = null;
        
        /// <summary>
        /// Return the program binaries (could be an executable binary, compiled binary or library binary) for all devices associated with program. For each device in program, the binary returned can be the binary specified for the device when program is created with CreateProgramWithBinary or it can be the executable binary generated by BuildProgram or clLinkProgram. If program is created with CreateProgramWithSource, the binary returned is the binary generated by BuildProgram, CompileProgram, or clLinkProgram. The bits returned can be an implementation-specific intermediate representation (a.k.a. IR) or device specific executable bits or both. The decision on which information is returned in the binary is up to the OpenCL implementation.
        /// 
        /// param_value points to an array of n pointers allocated by the caller, where n is the number of devices associated with program. The buffer sizes needed to allocate the memory that these n pointers refer to can be queried using the BinarySizes query as described in this table.
        /// 
        /// Each entry in this array is used by the implementation as the location in memory where to copy the program binary for a specific device, if there is a binary available.To find out which device the program binary in the array refers to, use the Devices query to get the list of devices. There is a one-to-one correspondence between the array of n pointers returned by Binaries and array of devices returned by Devices.
        /// 
        /// If an entry value in the array is NULL, the implementation skips copying the program binary for the specific device identified by the array index.
        /// </summary>
        public byte[][] Binaries
        {
            get
            {
                if (binaries != null)
                    return binaries;

                CLResult result;
                int param_value_size = 0;

                IntPtr data = Marshal.AllocHGlobal(Devices.Length * 8);

                result = CL.GetProgramInfo(Handle,
                     CLProgramInfo.BinarySizes,
                     param_value_size,
                     data,
                      out param_value_size);

                binaries = new byte[param_value_size / 8][];
                //int[] sizes = new byte[param_value_size / 4];
                int totalSize = 0;

                for (int i = 0; i < param_value_size / 8; i++)
                {
                    long sz = Marshal.ReadInt64(data, i);
                    binaries[i] = new byte[sz];
                    totalSize += (int)sz;
                }
                Marshal.FreeHGlobal(data);

                data = Marshal.AllocHGlobal(Devices.Length * 8);

                IntPtr[] pointers = new IntPtr[Devices.Length];
                for (int i = 0; i < binaries.Length; i++)
                {
                    pointers[i] = Marshal.AllocHGlobal(binaries[i].Length);
                    Marshal.WriteIntPtr(data, i * 8, pointers[i]);
                }
                    result = CL.GetProgramInfo(Handle,
                         CLProgramInfo.Binaries,
                         totalSize,
                         data,
                         out param_value_size);
                

                for (int i = 0; i < binaries.Length; i++)
                {
                    Marshal.Copy(pointers[i], binaries[i], 0, binaries[i].Length);

                    Marshal.FreeHGlobal(pointers[i]);
                }

                return binaries;
            }
        }

        /// <summary>
        /// Returns the number of kernels declared in program that can be created with CreateKernel. This information is only available after a successful program executable has been built for at least one device in the list of devices associated with program.
        /// </summary>
        //public int NumberOfKernels { get; private set; }

        /// <summary>
        /// Returns a semi-colon separated list of kernel names in program that can be created with CreateKernel. This information is only available after a successful program executable has been built for at least one device in the list of devices associated with program.
        /// </summary>
        //public string[] KernelNames { get; private set; }

        #endregion


        public CLProgram(CLProgramPtr program)
        {
            Handle = program;
        }

        public CLProgram(IntPtr program)
        {
            Handle = new CLProgramPtr();
            Handle.Handle = program;
        }


        /// <summary>
        /// Builds and compiles the program on the specified context.
        /// </summary>
        /// <param name="result">A verbose output of the build operation.</param>
        /// <param name="context">The context to use to build the program.</param>
        /// <param name="sourceCode">The program source code</param>
        /// <param name="buildForDevices">
        /// The device(s) to build this program under. 
        /// If no devices are specified then the default devices bound to the Context will be used.
        /// </param>
        /// <param name="options">Build options. See the remarks under CL.BuildProgram</param>
        /// <returns>A compiled program if successfully built; Otherwise null</returns>
        /// <exception cref="Exception">Throws if CreateProgramWithSource fails and a Program could not be allocated on the GPU.</exception>
        public static CLProgram Create(
            out string result,
            CLContext context,
            string sourceCode,
            CLDevice[] buildForDevices = null,
            string options = null)
        {
            return Create(out result, context, new string[] { sourceCode }, buildForDevices, options);
        }

        /// <summary>
        /// Builds and compiles the program on the specified context.
        /// </summary>
        /// <param name="result">A verbose output of the build operation.</param>
        /// <param name="context">The context to use to build the program.</param>
        /// <param name="sourceCode">The program source code</param>
        /// <param name="buildForDevices">
        /// The device(s) to build this program under. 
        /// If no devices are specified then the default devices bound to the Context will be used.
        /// </param>
        /// <param name="options">Build options. See the remarks under CL.BuildProgram</param>
        /// <returns>A compiled program if successfully built; Otherwise null</returns>
        /// <exception cref="Exception">Throws if CreateProgramWithSource fails and a Program could not be allocated on the GPU.</exception>
        public static CLProgram Create(
            out string result,
            CLContext context,
            string[] sourceCode,
            CLDevice[] buildForDevices = null,
            string options = null)
        {
            CLProgram program = null;
            int[] lengths = new int[sourceCode.Length];

            for(int i = 0; i < lengths.Length; i++)
                lengths[i] = sourceCode[i]!.Length;

            CLProgramPtr handle = CL.CreateProgramWithSource(context,
                                      sourceCode.Length,
                                      sourceCode,
                                      lengths,
                                      out CLResult errcode_ret);

            if (errcode_ret != CLResult.Success)
            {
                throw new Exception("Call to CreateProgramWithSource Failed with error: " + errcode_ret);
            }

            program = new CLProgram(handle);
            program.Context = context;
            result = "Create Program Result: " + errcode_ret;

            bool buildFailed = DoBuildProgram(
                program,
            handle,
            context,
            buildForDevices,
            options,
            out string buildresult);

            result += buildresult;

            if (buildFailed)
            {
                program.Dispose();
                return null;
            }

            program.PopulateKernels();

            return program;
        }

        /// <summary>
        /// Builds and compiles the program on the specified context.
        /// </summary>
        /// <param name="result">A verbose output of the build operation.</param>
        /// <param name="context">The context to use to build the program.</param>
        /// <param name="binaryData">
        /// An array of pointers to program binaries to be loaded for devices specified by device_list. For each device given by device_list[i], the pointer to the program binary for that device is given by binaries[i] and the length of this corresponding binary is given by lengths[i]. lengths[i] cannot be zero and binaries[i] cannot be a NULL pointer.
        /// 
        /// The program binaries specified by binaries contain the bits that describe one of the following:
        /// 
        /// a program executable to be run on the device(s) associated with context,
        /// a compiled program for device(s) associated with context, or
        /// a library of compiled programs for device(s) associated with context.
        /// 
        /// The program binary can consist of either or both of device-specific code and/or implementation-specific intermediate representation(IR) which will be converted to the device-specific code.
        /// </param>
        /// <param name="buildForDevices">
        /// The device(s) to build this program under. 
        /// If no devices are specified then the default devices bound to the Context will be used.
        /// </param>
        /// <param name="options">Build options. See the remarks under CL.BuildProgram</param>
        /// <returns>A compiled program if successfully built; Otherwise null</returns>
        /// <exception cref="Exception">Throws if CreateProgramWithSource fails and a Program could not be allocated on the GPU.</exception>
        public static CLProgram Create(
            out string result,
            CLContext context,
            byte[][] binaryData,
            CLDevice[] buildForDevices = null,
            string options = null)
        {
            CLProgram program = null;
            int[] lengths = new int[binaryData.Length];
            for (int i = 0; i < binaryData.Length; i++)
            {
                lengths[i] = binaryData[i].Length;
            }

            CLProgramPtr handle = CL.CreateProgramWithBinary(context,
                                  context.Devices.Length, context.Devices,
                                  lengths,
                                  binaryData,
                                  out CLResult[] binary_status,
                                  out CLResult errcode_ret);


            if (errcode_ret != CLResult.Success)
            {
                throw new Exception("Call to CreateProgramWithSource Failed with error: " + errcode_ret);
            }

            program = new CLProgram(handle);
            program.Context = context;
            result = "Create Program Result: " + errcode_ret;

            for (int i = 0; i < binary_status.Length; i++)
            {
                result = "\nBinary " + i + " Result: " + binary_status[i];
            }

            bool buildFailed = DoBuildProgram(
                program,
            handle,
            context,
            buildForDevices,
            options,
            out string buildresult);

            result += buildresult;

            if (buildFailed)
            {
                program.Dispose();
                return null;
            }

            program.PopulateKernels();

            return program;
        }

        /// <summary>
        /// Builds the program against the GPU and outputs the result.
        /// </summary>
        /// <param name="program">The program being compiled</param>
        /// <param name="handle">The program handle (redundant as it lives in program)</param>
        /// <param name="context">The context under the GPU to use.</param>
        /// <param name="buildForDevices">The device(s) to build this program for.</param>
        /// <param name="options">Build options. <see cref="CL.BuildProgram(CLProgramPtr, int, CLDevicePtr[], string, CL.pfn_BuildProgramNotifyDelegate, IntPtr)"/></param>
        /// <param name="result">The verbose output of the build.</param>
        /// <returns>True if the build was successful; Otherwise false.</returns>
        private static bool DoBuildProgram(
            CLProgram program,
            CLProgramPtr handle,
            CLContext context,
            CLDevice[] buildForDevices,
            string options,
            out string result)
        {
            CLResult errcode_ret;

            if (options == null)
                options = "-cl-kernel-arg-info";
            else if (!options.Contains("-cl-kernel-arg-info"))
                options += " -cl-kernel-arg-info";

            if (buildForDevices == null)
            {
                errcode_ret = CL.BuildProgram(handle, context.Devices.Length, context.Devices, options, null, IntPtr.Zero);
            }
            else
            {
                CLDevicePtr[] device_list = new CLDevicePtr[buildForDevices.Length];
                for (int i = 0; i < device_list.Length; i++)
                {
                    device_list[i] = buildForDevices[i].Handle;
                }
                errcode_ret = CL.BuildProgram(handle,
                                   device_list.Length,
                                   device_list,
                                   options,
                                   null,
                                   IntPtr.Zero);
            }

            result = "\nBuild Program Result: " + errcode_ret;

            bool buildFailed = errcode_ret != CLResult.Success;

            CLDevicePtr dev = buildForDevices != null && buildForDevices.Length > 0 ? buildForDevices[0] : context.Devices[0];

            string buildlog = "";

            foreach (CLProgramBuildInfo param_name in Enum.GetValues(typeof(CLProgramBuildInfo)))
            {
                int param_value_size = 0;
                IntPtr data;

                errcode_ret = CL.GetProgramBuildInfo(handle,
                                  dev,
                                  param_name,
                                  param_value_size,
                                  IntPtr.Zero,
                                  out param_value_size);

                data = Marshal.AllocHGlobal(param_value_size);

                errcode_ret = CL.GetProgramBuildInfo(handle,
                                  dev,
                                  param_name,
                                  param_value_size,
                                  data,
                                  out param_value_size);


                switch (param_name)
                {
                    case CLProgramBuildInfo.BinaryType:
                        result = "\nBinary Type: " + (CLProgramBinaryType)Marshal.ReadInt32(data);
                        program.BinaryType = (CLProgramBinaryType)Marshal.ReadInt32(data);
                        break;
                    case CLProgramBuildInfo.GlobablVariableTotalSize:
                        if (param_value_size > 1)
                        {
                            result = "\nGlobal Variable Total Size: " + Marshal.ReadInt32(data);
                            program.GlobalVariableTotalSize = Marshal.ReadInt32(data);
                        }
                        else
                            result = "\nGlobal Variable Total Size: 0";
                        break;
                    case CLProgramBuildInfo.Log:
                        if (param_value_size > 1)
                            buildlog = Marshal.PtrToStringUTF8(data);
                        else
                            buildlog = "";
                        break;
                    case CLProgramBuildInfo.Options:
                        if (param_value_size > 1)
                            result = "\nBuild Options: " + Marshal.PtrToStringUTF8(data);
                        else
                            result = "\nBuild Options: None";
                        break;
                    case CLProgramBuildInfo.Status:
                        result = "\nBuild Status: " + (CLBuildStatus)Marshal.ReadInt32(data);
                        break;
                }

                Marshal.FreeHGlobal(data);
            }

            result += result = "\n\nBuild Log: " + buildlog;

            return buildFailed;
        }

        private void PopulateKernels()
        {
            int num_kernels = 0;

            CLResult result = CL.CreateKernelsInProgram(Handle, num_kernels, null, out num_kernels);

            if (result != CLResult.Success)
            {
                throw new Exception("Failed to fetch Kernels for program! Handle: " + Handle + " Result: " + result);
            }

            if (num_kernels == 0)
            {
                Kernels = new CLKernel[0];
                return;
            }

            CLKernelPtr[] kernels = new CLKernelPtr[num_kernels];


            result = CL.CreateKernelsInProgram(Handle, num_kernels, kernels, out num_kernels);

            Kernels = new CLKernel[num_kernels];

            for (int i = 0; i < num_kernels; i++)
            {
                Kernels[i] = new CLKernel(kernels[i]);
            }

        }

        /// <summary>
        /// Finds the kernel with the given function name.
        /// </summary>
        /// <param name="kernelName">The name of the Kernel to find</param>
        /// <param name="functionNameComparisonType">By Default searching kernel names is case insensitive. 
        /// If you have more than one kernel with the same name (bad bad bad) but a different CaSe you can defice case specific searching here.</param>
        /// <returns>The Kernel with the specified function name if found. Otherwise Null if not found.</returns>
        public CLKernel Find(string kernelName, StringComparison functionNameComparisonType = StringComparison.InvariantCultureIgnoreCase)
        {
            foreach(CLKernel k in Kernels)
            {
                if (k.FunctionName.Equals(kernelName, functionNameComparisonType))
                    return k;
            }

            return null;
        }

        private bool _disposed = false;
        public void Dispose()
        {
            if (_disposed) return;

            CLResult result = CL.Release(Handle);

            if (result != CLResult.Success)
            {
                ///TODO: Silent fail or throw?
                Console.WriteLine("Failed to release Program from GPU! " + result);
            }

            _disposed = true;
        }

        ~CLProgram() { Dispose(); }

        public static implicit operator CLProgramPtr(CLProgram from)
            => from.Handle;

        public static explicit operator CLProgram(CLProgramPtr from)
            => new(from);
    }
}
