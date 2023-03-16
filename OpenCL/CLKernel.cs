using System.Runtime.InteropServices;

namespace PrairieCL.OpenCL
{
    /// <summary>
    /// A CLKernel is a reference to a function that can be executed on 
    /// the GPU. This class stores information about the kernel including its name
    /// and arguments.
    /// </summary>
    public class CLKernel
    {
        public CLKernelPtr Handle;

        #region GetKernelInfo

        /// <summary>
        /// Return the kernel function name.
        /// </summary>
        public string FunctionName { get; private set; }

        /// <summary>
        /// Return the number of arguments to kernel.
        /// </summary>
        public int NumberOfArguments { get; private set; }

        /// <summary>
        /// Return the kernel reference count.
        /// 
        /// The reference count returned should be considered immediately stale.
        /// It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </summary>
        public int ReferenceCount { get
            {
                IntPtr data = Marshal.AllocHGlobal(4);
                CLResult result = CL.GetKernelInfo(Handle,
                     CLKernelInfo.ReferenceCount,
                                    4,
                                    data,
                                    out _);

                int val = Marshal.ReadInt32(data);

                Marshal.FreeHGlobal(data);

                return val;

            }
        }

        /// <summary>
        /// Return the context associated with kernel.
        /// </summary>
        public CLContextPtr Context { get; private set; }

        /// <summary>
        /// Return the program object associated with kernel.
        /// </summary>
        public CLProgramPtr Program { get; private set; }

        /// <summary>
        /// Returns any attributes specified using the __attribute__ 
        /// qualifier with the kernel function declaration in the program source. 
        /// These attributes include those on the __attribute__ page and other attributes supported by an implementation.
        /// 
        /// Attributes are returned as they were declared inside __attribute__((...)), with any surrounding whitespace and 
        /// embedded newlines removed. When multiple attributes are present, they are returned as a single, space delimited string.
        /// </summary>
        public string[] Attributes { get; private set; }

        #endregion

        /// <summary>
        /// Information about this kernels arguments in order from left to right.
        /// </summary>
        public readonly CLKernelArgInfo[] Arguments;

        /// <summary>
        /// Information about the kernel object using the default device in the context.
        /// </summary>
        public readonly CLKernelWorkgroupInfo WorkgroupInfo;
        
        public CLKernel(CLKernelPtr handle) {
            Handle = handle;

            CLResult result;
            IntPtr data;
            int param_value_size = 0;

            foreach (CLKernelInfo param_name in Enum.GetValues(typeof(CLKernelInfo)))
            {
                result = CL.GetKernelInfo(Handle,
                    param_name,
                                    param_value_size,
                                    IntPtr.Zero,
                                    out param_value_size);

                data = Marshal.AllocHGlobal(param_value_size);

                result = CL.GetKernelInfo(Handle,
                    param_name,
                                    param_value_size,
                                    data,
                                    out param_value_size);

                if (param_value_size > 0)
                {
                    switch (param_name)
                    {
                        case CLKernelInfo.Attributes:
                            if (param_value_size > 1)
                            {
                                string attrs = Marshal.PtrToStringUTF8(data);

                                if (attrs != null)
                                    Attributes = attrs.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            }
                            else
                                Attributes = new string[0];
                            break;
                        case CLKernelInfo.Context:
                            CLContextPtr ctx = new CLContextPtr();
                            ctx.Handle = new IntPtr(Marshal.ReadInt64(data));
                            Context = ctx;
                            break;
                        case CLKernelInfo.FunctionName:
                            FunctionName = Marshal.PtrToStringUTF8(data);
                            break;
                        case CLKernelInfo.NumberOfArguments:
                            NumberOfArguments = Marshal.ReadInt32( data);
                            break;
                        case CLKernelInfo.Program:
                            CLProgramPtr program = new CLProgramPtr();
                            program.Handle = new IntPtr(Marshal.ReadInt64(data));
                            Program = program;
                            break;
                        case CLKernelInfo.ReferenceCount:
                            break; //Do Nothing. This is handles on a per request basis
                    }
                }
                Marshal.FreeHGlobal(data);
            }

            CLKernelArgInfo[] args = new CLKernelArgInfo[NumberOfArguments];

            for (int i =0; i < NumberOfArguments; i++)
            {
                CLKernelArgumentAccessQualifier access = CLKernelArgumentAccessQualifier.None;
                CLKernelArgumentAddressQualifier addr = CLKernelArgumentAddressQualifier.Private;
                string name = "";
                CLKernelArgumentTypeQualifier typ = CLKernelArgumentTypeQualifier.None;
                string typename = "";

                foreach (CLKernelArgumentInfo param_name in Enum.GetValues(typeof(CLKernelArgumentInfo)))
                {

                    result = CL.GetKernelArgInfo(Handle,
                               i,
                               param_name,
                               param_value_size,
                               IntPtr.Zero,
                               out param_value_size);

                    data = Marshal.AllocHGlobal(param_value_size);

                    result = CL.GetKernelArgInfo(Handle,
                               i,
                               param_name,
                               param_value_size,
                               data,
                               out param_value_size);

                    switch (param_name)
                    {
                        case CLKernelArgumentInfo.AccessQualifier:
                            access = (CLKernelArgumentAccessQualifier)Marshal.ReadInt32(data);
                            break;
                        case CLKernelArgumentInfo.AddressQualifier:
                            addr = (CLKernelArgumentAddressQualifier)Marshal.ReadInt32(data);
                            break;
                        case CLKernelArgumentInfo.Name:
                            if (param_value_size > 1)
                                name = Marshal.PtrToStringUTF8(data);
                            else
                                name = "";
                            break;
                        case CLKernelArgumentInfo.TypeQualifier:
                            typ = (CLKernelArgumentTypeQualifier)Marshal.ReadInt64(data);
                            break;
                        case CLKernelArgumentInfo.TypeName:
                            if (param_value_size > 1) 
                                typename = Marshal.PtrToStringUTF8(data);
                            else
                                typename = "";
                            break;
                    }
                }

                CLKernelArgInfo arg = new CLKernelArgInfo(i, access, addr, name, typ, typename);

                args[i] = arg;
            }
            Arguments = args;

            WorkgroupInfo = GetDeviceWorkgroupInfo(new CLDevicePtr());
        }

        /// <summary>
        /// Used to set the argument value for a specific argument of a kernel.
        /// Ie. the value to pass to a kernel function given its parameter number starting at 0 on the left 
        /// </summary>
        /// <param name="index">
        /// The argument index.
        /// Arguments to the kernel are referred by indices that go from 0 for the leftmost argument to n - 1, 
        /// where n is the total number of arguments declared by a kernel.</param>
        /// <param name="value">
        /// The Value to pass to the kernel function.
        /// </param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        public CLResult SetArg(int index, CLBuffer value) 
        {

            CLResult retult = CL.SetKernelArg(Handle,
                                   index,
                                   Marshal.SizeOf(value.Handle), //value.Size / 4,
                                   ref value.Handle);
            return retult;
        }


        /// <summary>
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="device">The device to query</param>
        /// <returns>information about the kernel object that may be specific to the specified device.</returns>
        public CLKernelWorkgroupInfo GetDeviceWorkgroupInfo(CLDevice device)
        {
            return GetDeviceWorkgroupInfo(device.Handle);
        }

        /// <summary>
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="device">The device to query</param>
        /// <returns>information about the kernel object that may be specific to the specified device.</returns>
        public CLKernelWorkgroupInfo GetDeviceWorkgroupInfo(CLDevicePtr device)
        {
            int wgSz = 0; // new Vector3i();
            Vector3i compileWgSz = new Vector3i();
            ulong locmemSz = 0;
            int preferredWgSz = 0;
            ulong prefMemSz = 0;
            int gblWgSz = 0;

            foreach (CLKernelWorkGroupInfo param_name in Enum.GetValues(typeof(CLKernelWorkGroupInfo)))
            {
                int param_value_size = 0;
                IntPtr data;

                CLResult result = CL.GetKernelWorkGroupInfo(Handle,
                                             device,
                                             param_name,
                                             param_value_size,
                                             IntPtr.Zero,
                                             out param_value_size);

                data = Marshal.AllocHGlobal(param_value_size);


                result = CL.GetKernelWorkGroupInfo(Handle,
                                             device,
                                             param_name,
                                             param_value_size,
                                             data,
                                             out param_value_size);

                switch (param_name)
                {
                    case CLKernelWorkGroupInfo.CompileWorkGroupSize:
                        //compileWgSz = Marshal.ReadInt32(data);
                        compileWgSz = new Vector3i(); // Marshal.PtrToStructure<Vector3i>(data);
                        if (param_value_size >= 8)
                            compileWgSz.X = (int)Marshal.ReadInt64(data);
                        if (param_value_size >= 16)
                            compileWgSz.Y = (int)Marshal.ReadInt64(data, 8);
                        if (param_value_size >= 24)
                            compileWgSz.Z = (int)Marshal.ReadInt64(data, 16);
                        break;
                    case CLKernelWorkGroupInfo.GlobalWorkSize:
                        if (param_value_size > 0)
                            gblWgSz = (int)Marshal.ReadInt32(data);
                        break;
                    case CLKernelWorkGroupInfo.LocalMemorySize:
                        if (param_value_size > 0)
                            locmemSz = (ulong)Marshal.ReadInt64(data);
                        break;
                    case CLKernelWorkGroupInfo.PreferredWorkGroupSizeMultiple:
                        if (param_value_size > 0)
                            preferredWgSz = (int)Marshal.ReadInt64(data);
                        break;
                    case CLKernelWorkGroupInfo.PrivateMemorySize:
                        if (param_value_size > 0)
                            prefMemSz = (ulong)Marshal.ReadInt64(data);
                        break;
                    case CLKernelWorkGroupInfo.WorkGroupSize:
                        if (param_value_size > 0)
                            wgSz = (int)Marshal.ReadInt64(data); // new Vector3i(); // Marshal.PtrToStructure<Vector3i>(data);
                        //if (param_value_size >= 4)
                        //    wgSz.X = Marshal.ReadInt32(data);
                        //if (param_value_size >= 8)
                        //    wgSz.Y = Marshal.ReadInt32(data, 4);
                        //if (param_value_size >= 12)
                        //    wgSz.Z = Marshal.ReadInt32(data, 8);
                        break;
                }
                Marshal.FreeHGlobal(data);
            }

            return new CLKernelWorkgroupInfo(wgSz, compileWgSz, locmemSz, preferredWgSz, prefMemSz, gblWgSz);
        }

        private bool _disposed = false;

        public void Dispose()
        {
            if (_disposed)
                return;

            CLResult result = CL.Release(Handle);

            if (result != CLResult.Success)
            {
                ///TODO: Silent fail or throw?
                Console.WriteLine("Failed to release Kernel from GPU! " + result);
            }

            _disposed = true;
        }

        ~CLKernel() { Dispose(); }

        public static implicit operator CLKernelPtr(CLKernel from)
            => from.Handle;

        public static explicit operator CLKernel(CLKernelPtr from)
            => new(from);
    }

    /// <summary>
    /// Contains information about a Kernel argument. 
    /// </summary>
    public class CLKernelArgInfo
    {
        /// <summary>
        /// The index (starting at 0) of this argument.
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// Returns the address qualifier specified for the argument given by arg_indx.
        /// 
        /// If no address qualifier is specified, the default address qualifier which is Private is returned.
        /// </summary>
        public readonly CLKernelArgumentAddressQualifier AddressQualifier;

        /// <summary>
        /// Returns the access qualifier specified for the argument given by arg_indx.
        /// 
        /// If argument is not an image type and is not declared with the pipe qualifier, None is returned. 
        /// If argument is an image type, the access qualifier specified or the default access qualifier is returned.
        /// </summary>
        public readonly CLKernelArgumentAccessQualifier AccessQualifier;

        /// <summary>
        /// Returns the type name specified for the argument given by arg_indx. 
        /// The type name returned will be the argument type name as it was declared with any whitespace removed. 
        /// If argument type name is an unsigned scalar type (i.e. unsigned char, unsigned short, unsigned int, unsigned long), 
        /// uchar, ushort, uint and ulong will be returned. The argument type name returned does not include any type qualifiers.
        /// </summary>
        public readonly string TypeName;

        /// <summary>
        /// Returns the type qualifier specified for the argument given by arg_indx.
        /// 
        /// NOTE: Volatile is returned if the argument is a pointer and the pointer 
        /// is declared with the volatile qualifier. 
        /// For example, a kernel argument declared as global int volatile *x returns Volatile 
        /// but a kernel argument declared as global int * volatile x does not. 
        /// Similarly, Restrict or Const is returned if the argument is a 
        /// pointer and the referenced type is declared with the restrict or const qualifier.
        /// For example, a kernel argument declared as global int const *x returns Const 
        /// but a kernel argument declared as global int * const x does not.
        /// 
        /// If the argument is declared with the constant address space qualifier, 
        /// the Const type qualifier will be set.
        /// </summary>
        public readonly CLKernelArgumentTypeQualifier TypeQualifier;

        /// <summary>
        /// Returns the name specified for the argument given by arg_indx.
        /// </summary>
        public readonly string Name;

        public CLKernelArgInfo(int i, CLKernelArgumentAccessQualifier access, CLKernelArgumentAddressQualifier addr, string name, CLKernelArgumentTypeQualifier typ, string typename)
        {
            Index = i;
            AccessQualifier = access;
            AddressQualifier = addr;
            Name = name;
            TypeQualifier = typ;
            TypeName = typename;
        }

        internal CLKernelArgInfo() { }
    }

    /// <summary>
    /// Information about a kernel object that may be specific to a device.
    /// </summary>
    public class CLKernelWorkgroupInfo
    {
        /// <summary>
        /// This provides a mechanism for the application to query the maximum global size that can be used to execute a kernel (i.e. global_work_size argument to EnqueueNDRangeKernel) on a custom device given by device or a built-in kernel on an OpenCL device given by device.
        /// If device is not a custom device or kernel is not a built-in kernel, GetKernelArgInfo returns the error InvalidValue.
        /// Type: Vector3i
        /// </summary>
        public readonly int WorkGroupSize;
        /// <summary>
        /// This provides a mechanism for the application to query the maximum work-group size that can be used to execute a kernel on a 
        /// specific device given by device. 
        /// The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this 
        /// work-group size should be.
        /// </summary>
        public readonly Vector3i CompileWorkGroupSize;
        /// <summary>
        /// Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with SetKernelArg.
        /// 
        /// If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </summary>
        public readonly ulong LocalMemorySize;
        /// <summary>
        /// Returns the preferred multiple of workgroup size for launch. This is a performance hint. 
        /// Specifying a workgroup size that is not a multiple of the value returned by this query as the value of the local work size 
        /// argument to EnqueueNDRangeKernel will not fail to enqueue the kernel for execution unless the work-group size specified 
        /// is larger than the device maximum.
        /// </summary>
        public readonly int PreferredWorkGroupSizeMultiple;
        /// <summary>
        /// Returns the minimum amount of private memory, in bytes, used by each workitem in the kernel. 
        /// This value may include any private memory needed by an implementation to execute the kernel, 
        /// including that used by the language built-ins and variable declared inside the kernel with the __private qualifier.
        /// </summary>
        public readonly ulong PrivateMemorySize;
        /// <summary>
        /// This provides a mechanism for the application to query the maximum work-group size that can be used to execute a 
        /// kernel on a specific device given by device. 
        /// The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this 
        /// work-group size should be.
        /// </summary>
        public readonly int GlobalWorkSize;

        public CLKernelWorkgroupInfo(int wgSz, Vector3i compileWgSz, ulong locmemSz, int preferredWgSz, ulong prefMemSz, int gblWgSz)
        {
            WorkGroupSize = wgSz;
            CompileWorkGroupSize = compileWgSz;
            LocalMemorySize = locmemSz;
            PreferredWorkGroupSizeMultiple = preferredWgSz;
            PrivateMemorySize = prefMemSz;
            GlobalWorkSize = gblWgSz;
    }
    }
}
