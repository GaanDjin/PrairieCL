using System.Runtime.InteropServices;

namespace PrairieCL.OpenCL
{
    public class CL
    {

        /// <summary>
        /// Obtain the list of platforms available.
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetPlatformIDs.html
        /// </summary>
        /// <param name="num_entries">The number of CLPlatformPtr entries that can be added to platforms. If platforms is not NULL, the num_entries must be greater than zero.</param>
        /// <param name="platforms">Returns a list of OpenCL platforms found. The CLPlatformPtr values returned in platforms can be used to identify a specific OpenCL platform. If platforms argument is NULL, this argument is ignored. The number of OpenCL platforms returned is the mininum of the value specified by num_entries or the number of OpenCL platforms available.</param>
        /// <param name="num_platforms">Returns the number of OpenCL platforms available. If num_platforms is NULL, this argument is ignored.</param>
        /// <returns>
        /// Returns Success - if the function is executed successfully. 
        /// If the cl_khr_icd extension is enabled, GetPlatformIDs returns Success if the function is executed successfully and there are a non zero number of platforms available.
        /// Otherwise it returns one of the following errors:
        /// InvalidValue - if num_entries is equal to zero and platforms is not NULL or if both num_platforms and platforms are NULL.
        /// OutOfHostMemory - if there is a failure to allocate resources required by the OpenCL implementation on the host.
        /// CL_PLATFORM_NOT_FOUND_KHR - if the cl_khr_icd extension is enabled and no platforms are found.
        /// </returns>
        [DllImport("opencl.dll", EntryPoint = "clGetPlatformIDs", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetPlatformIDs(int num_entries, [In, Out] CLPlatformPtr[] platforms, out int num_platforms);

        /// <summary>
        /// Obtain the list of platforms available.
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetPlatformIDs.html
        /// </summary>
        /// <param name="platforms">Returns a list of OpenCL platforms found. The CLPlatformPtr values returned in platforms can be used to identify a specific OpenCL platform. If platforms argument is NULL, this argument is ignored. The number of OpenCL platforms returned is the mininum of the value specified by num_entries or the number of OpenCL platforms available.</param>
        /// <returns>
        /// Returns Success - if the function is executed successfully. 
        /// If the cl_khr_icd extension is enabled, GetPlatformIDs returns Success if the function is executed successfully and there are a non zero number of platforms available.
        /// Otherwise it returns one of the following errors:
        /// InvalidValue - if num_entries is equal to zero and platforms is not NULL or if both num_platforms and platforms are NULL.
        /// OutOfHostMemory - if there is a failure to allocate resources required by the OpenCL implementation on the host.
        /// CL_PLATFORM_NOT_FOUND_KHR - if the cl_khr_icd extension is enabled and no platforms are found.
        /// </returns>
        public static CLResult GetPlatformIDs(out CLPlatform[] platforms)
        {
            int num_entries = 0;
            CLPlatformPtr[] platformPtrs = null;
            CLResult result = GetPlatformIDs(num_entries, platformPtrs, out num_entries);
            if (result != CLResult.Success)
            {
                platforms = null;
                return result;
            }
            platformPtrs = new CLPlatformPtr[num_entries];
            result = GetPlatformIDs(num_entries, platformPtrs, out _);
            if (result != CLResult.Success)
            {
                platforms = null;
                return result;
            }
            platforms = new CLPlatform[num_entries];
            for (int i = 0; i < num_entries; i++) {
                platforms[i] = new CLPlatform(platformPtrs[i]);
            }

            return result;
        }

        /// <summary>
        /// Get specific information about the OpenCL platform.
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetPlatformInfo.html
        /// </summary>
        /// <param name="platform">The platform ID returned by GetPlatformIDs or can be NULL. If platform is NULL, the behavior is implementation-defined.</param>
        /// <param name="param_name">An enumeration constant that identifies the platform information being queried. It can be one of the values specified in the table below.</param>
        /// <param name="param_value_size">A pointer to memory location where appropriate values for a given param_name will be returned. Possible param_value values returned are listed in the table below. If param_value is NULL, it is ignored.</param>
        /// <param name="param_value">Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be ≥ size of return type specified in the table below.</param>
        /// <param name="param_value_size_ret">Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored</param>
        /// <returns></returns>
        /// 
        ///TODO: Replace byte[] with IntPtr to use Marshal to conver to string rather than looping chars?
        [DllImport("opencl.dll", EntryPoint = "clGetPlatformInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetPlatformInfo(CLPlatformPtr platform,
                  CLPlatformInfo param_name,
                  int param_value_size,
                  [In, Out] byte[] param_value,
                  [Out] out int param_value_size_ret);

        /// <summary>
        /// Get specific information about the OpenCL platform.
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetPlatformInfo.html
        /// </summary>
        /// <param name="platform">The platform ID returned by GetPlatformIDs or can be NULL. If platform is NULL, the behavior is implementation-defined.</param>
        /// <param name="param_name">An enumeration constant that identifies the platform information being queried. It can be one of the values specified in the table below.</param>
        /// <param name="platformName">Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be ≥ size of return type specified in the table below.</param>
        /// <returns></returns>
        public static CLResult GetPlatformInfo(CLPlatformPtr platform, CLPlatformInfo param_name, out byte[] platformName)
        {
            int num_entries = 0;
            platformName = null;
            CLResult result = GetPlatformInfo(platform, param_name, num_entries, platformName, out num_entries);
            if (result != CLResult.Success)
            {
                return result;
            }
            platformName = new byte[num_entries];
            result = GetPlatformInfo(platform, param_name, num_entries, platformName, out _);
            if (result != CLResult.Success)
            {
                platformName = null;
                return result;
            }
            return result;
        }

        /// <summary>
        /// Get specific information about the OpenCL platform.
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetPlatformInfo.html
        /// </summary>
        /// <param name="platform">The platform ID returned by GetPlatformIDs or can be NULL. If platform is NULL, the behavior is implementation-defined.</param>
        /// <param name="param_name">An enumeration constant that identifies the platform information being queried. It can be one of the values specified in the table below.</param>
        /// <param name="platformName">Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be ≥ size of return type specified in the table below.</param>
        /// <returns></returns>
        public static CLResult GetPlatformInfo(CLPlatformPtr platform, CLPlatformInfo param_name, out string strPlatformName)
        {

            int num_entries = 0;
            byte[] platformName = null;
            CLResult result = GetPlatformInfo(platform, param_name, num_entries, platformName, out num_entries);
            if (result != CLResult.Success)
            {
                strPlatformName = "";
                return result;
            }
            platformName = new byte[num_entries];
            result = GetPlatformInfo(platform, param_name, num_entries, platformName, out _);
            if (result != CLResult.Success)
            {
                strPlatformName = "";
                return result;
            }

            strPlatformName = ""; // new string((char[])platformName);

            foreach (byte c in platformName)
                strPlatformName += (char)c;

            return result;
        }

        /* Device APIs */
        /// <summary>
        /// Obtain the list of devices available on a platform.
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetDeviceIDs.html
        /// </summary>
        /// <param name="platform">Refers to the platform ID returned by GetPlatformIDs or can be NULL. If platform is NULL, the behavior is implementation-defined.</param>
        /// <param name="device_type"></param>
        /// <param name="num_entries"></param>
        /// <param name="devices"></param>
        /// <param name="num_devices"></param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clGetDeviceIDs", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetDeviceIDs(CLPlatformPtr platform,
                   CLDeviceType device_type,
               int num_entries,
               [In, Out] CLDevicePtr[] devices,
               [Out] out int num_devices);

        /// <summary>
        /// Obtain the list of devices available on a platform.
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetDeviceIDs.html
        /// </summary>
        /// <param name="platform">Refers to the platform ID returned by GetPlatformIDs or can be NULL. If platform is NULL, the behavior is implementation-defined.</param>
        /// <param name="device_type"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        public static CLResult GetDeviceIDs(CLPlatform platform,
                   CLDeviceType device_type,
               out CLDevice[] devices)
        {

            int num_entries = 0;
            CLDevicePtr[] devicePtrs = null;
            CLResult result = GetDeviceIDs(platform, device_type, num_entries, devicePtrs, out num_entries);
            if (result != CLResult.Success)
            {
                devices = new CLDevice[0];
                return result;
            }
            devicePtrs = new CLDevicePtr[num_entries];
            result = GetDeviceIDs(platform, device_type, num_entries, devicePtrs, out _);
            if (result != CLResult.Success)
            {
                devices = new CLDevice[0];
                return result;
            }

            devices = new CLDevice[num_entries]; // new string((char[])platformName);

            for (int i = 0; i < devicePtrs.Length; i++)
                devices[i] = new CLDevice(devicePtrs[i]);

            return result;
        }

        /// <summary>
        /// Get information about an OpenCL device.
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetDeviceInfo.html
        /// </summary>
        /// <param name="device">May be a device returned by GetDeviceIDs or a sub-device created by clCreateSubDevices. If device is a sub-device, the specific information for the sub-device will be returned. The information that can be queried using GetDeviceInfo is specified in the table below (Table 4.3).</param>
        /// <param name="param_name">An enumeration constant that identifies the device information being queried.</param>
        /// <param name="param_value_size">Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be ≥ size of return type specified in the table below.</param>
        /// <param name="param_value">A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.</param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clGetDeviceInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetDeviceInfo(CLDevicePtr device,
                CLDeviceInfo param_name,
                int param_value_size,
                [In, Out] byte[] param_value,
                [Out] out int param_value_size_ret);

        /// <summary>
        /// Get information about an OpenCL device.
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetDeviceInfo.html
        /// </summary>
        /// <param name="device">May be a device returned by GetDeviceIDs or a sub-device created by clCreateSubDevices. If device is a sub-device, the specific information for the sub-device will be returned. The information that can be queried using GetDeviceInfo is specified in the table below (Table 4.3).</param>
        /// <param name="param_name">An enumeration constant that identifies the device information being queried.</param>
        /// <param name="param_value">A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.</param>
        /// <returns></returns>
        public static CLResult GetDeviceInfo(CLDevicePtr device,
                   CLDeviceInfo param_name,
               out byte[] param_value)
        {
            param_value = null;
            int num_entries = 0;
            CLResult result = GetDeviceInfo(device, param_name, num_entries, param_value, out num_entries);
            if (result != CLResult.Success)
            {
                param_value = new byte[0];
                return result;
            }
            param_value = new byte[num_entries];
            result = GetDeviceInfo(device, param_name, num_entries, param_value, out _);
            if (result != CLResult.Success)
            {
                param_value = new byte[0];
                return result;
            }

            //param_value = new byte[num_entries]; // new string((char[])platformName);

            return result;
        }


        /// <summary>
        /// A callback function that can be registered by the application. 
        /// This callback function will be used by the OpenCL implementation to report information on errors during context creation 
        /// as well as errors that occur at runtime in this context. 
        /// This callback function may be called asynchronously by the OpenCL implementation. 
        /// It is the application's responsibility to ensure that the callback function is thread-safe. 
        /// If pfn_notify is NULL, no callback function is registered.
        /// </summary>
        /// <param name="errinfo">An error string</param>
        /// <param name="private_info">binary data that is returned by the OpenCL implementation that can be used to log additional information helpful in debugging the error.</param>
        /// <param name="cb">binary data that is returned by the OpenCL implementation that can be used to log additional information helpful in debugging the error.</param>
        /// <param name="user_data">user supplied data.</param>
        /// <returns></returns>
        public delegate bool pfn_notifyDelegate(string errinfo,
                                                byte[] private_info,
                                                uint cb,
                                                byte[] user_data);

        /* Context APIs */

        /// <summary>
        /// An OpenCL context is created with one or more devices. 
        /// Contexts are used by the OpenCL runtime for managing objects such as command-queues, memory, program and kernel objects 
        /// and for executing kernels on one or more devices specified in the context.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateContext.html
        /// </summary>
        /// <param name="properties">
        /// Specifies a list of context property names and their corresponding values. Each property name is immediately followed by the corresponding desired value. The list is terminated with 0. properties can be NULL in which case the platform that is selected is implementation-defined. The list of supported properties is described in the table below.
        /// 
        /// If the extension cl_khr_dx9_media_sharing is enabled, then properties specifies a list of context property names and their corresponding values.Each property is followed immediately by the corresponding desired value.The list is terminated with zero.If a property is not specified in properties, then its default value(listed in the table below) is used(it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default values.
        /// 
        /// If the extension cl_khr_d3d10_sharing is enabled, then properties specifies a list of context property names and their corresponding values.Each property is followed immediately by the corresponding desired value.The list is terminated with zero. if a property is not specified in properties, then its default value is used(it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default value.
        /// 
        /// If the extension cl_khr_d3d11_sharing is enabled, then properties specifies a list of context property names and their corresponding values.Each property is followed immediately by the corresponding desired value.The list is terminated with zero.If a property is not specified in properties, then its default value is used(it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default value.
        /// 
        /// If the extension cl_khr_gl_sharing is enabled, then properties points to an attribute list, which is a array of ordered<attribute name, value> pairs terminated with zero. If an attribute is not specified in properties, then its default value is used (it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default values.
        /// </param>
        /// <param name="num_devices">The number of devices specified in the devices argument.</param>
        /// <param name="devices">A pointer to a list of unique devices returned by GetDeviceIDs or sub-devices created by clCreateSubDevices for a platform. Duplicate devices specified in devices are ignored.</param>
        /// <param name="pfn_notify">
        /// A callback function that can be registered by the application. 
        /// This callback function will be used by the OpenCL implementation to report information on errors during context creation as 
        /// well as errors that occur at runtime in this context. 
        /// This callback function may be called asynchronously by the OpenCL implementation. 
        /// It is the application's responsibility to ensure that the callback function is thread-safe. 
        /// If pfn_notify is NULL, no callback function is registered.
        /// 
        /// NOTE: There are a number of cases where error notifications need to be delivered due to an error that occurs outside a context. 
        /// Such notifications may not be delivered through the pfn_notify callback. Where these notifications go is implementation-defined.
        /// </param>
        /// <param name="user_data">Passed as the user_data argument when pfn_notify is called. user_data can be NULL.</param>
        /// <param name="errcode_ret">Returns an appropriate error code.</param>
        /// <returns>An OpenCL context.</returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLContextPtr CreateContext(CLContextProperties properties,
                int num_devices,
                [In] CLDevicePtr[] devices,
                pfn_notifyDelegate pfn_notify,
                [In] byte[] user_data,
                [Out] out CLResult errcode_ret);

        /// <summary>
        /// An OpenCL context is created with one or more devices. 
        /// Contexts are used by the OpenCL runtime for managing objects such as command-queues, memory, program and kernel objects 
        /// and for executing kernels on one or more devices specified in the context.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateContext.html
        /// </summary>
        /// <param name="properties">
        /// Specifies a list of context property names and their corresponding values. Each property name is immediately followed by the corresponding desired value. The list is terminated with 0. properties can be NULL in which case the platform that is selected is implementation-defined. The list of supported properties is described in the table below.
        /// 
        /// If the extension cl_khr_dx9_media_sharing is enabled, then properties specifies a list of context property names and their corresponding values.Each property is followed immediately by the corresponding desired value.The list is terminated with zero.If a property is not specified in properties, then its default value(listed in the table below) is used(it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default values.
        /// 
        /// If the extension cl_khr_d3d10_sharing is enabled, then properties specifies a list of context property names and their corresponding values.Each property is followed immediately by the corresponding desired value.The list is terminated with zero. if a property is not specified in properties, then its default value is used(it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default value.
        /// 
        /// If the extension cl_khr_d3d11_sharing is enabled, then properties specifies a list of context property names and their corresponding values.Each property is followed immediately by the corresponding desired value.The list is terminated with zero.If a property is not specified in properties, then its default value is used(it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default value.
        /// 
        /// If the extension cl_khr_gl_sharing is enabled, then properties points to an attribute list, which is a array of ordered<attribute name, value> pairs terminated with zero. If an attribute is not specified in properties, then its default value is used (it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default values.
        /// </param>
        /// <param name="num_devices">The number of devices specified in the devices argument.</param>
        /// <param name="devices">A pointer to a list of unique devices returned by GetDeviceIDs or sub-devices created by clCreateSubDevices for a platform. Duplicate devices specified in devices are ignored.</param>
        /// <param name="pfn_notify">
        /// A callback function that can be registered by the application. 
        /// This callback function will be used by the OpenCL implementation to report information on errors during context creation as 
        /// well as errors that occur at runtime in this context. 
        /// This callback function may be called asynchronously by the OpenCL implementation. 
        /// It is the application's responsibility to ensure that the callback function is thread-safe. 
        /// If pfn_notify is NULL, no callback function is registered.
        /// 
        /// NOTE: There are a number of cases where error notifications need to be delivered due to an error that occurs outside a context. 
        /// Such notifications may not be delivered through the pfn_notify callback. Where these notifications go is implementation-defined.
        /// </param>
        /// <param name="user_data">Passed as the user_data argument when pfn_notify is called. user_data can be NULL.</param>
        /// <param name="errcode_ret">Returns an appropriate error code.</param>
        /// <returns>An OpenCL context.</returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLContextPtr CreateContext(CLContextProperties properties,
            int num_devices,
            [In] CLDevicePtr[] devices,
            IntPtr pfn_notify,
            [In] IntPtr user_data,
            [Out] out CLResult errcode_ret);


        /// <summary>
        /// An OpenCL context is created with one or more devices. 
        /// Contexts are used by the OpenCL runtime for managing objects such as command-queues, memory, program and kernel objects 
        /// and for executing kernels on one or more devices specified in the context.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateContext.html
        /// </summary>
        /// <param name="properties">
        /// Specifies a list of context property names and their corresponding values. Each property name is immediately followed by the corresponding desired value. The list is terminated with 0. properties can be NULL in which case the platform that is selected is implementation-defined. The list of supported properties is described in the table below.
        /// 
        /// If the extension cl_khr_dx9_media_sharing is enabled, then properties specifies a list of context property names and their corresponding values.Each property is followed immediately by the corresponding desired value.The list is terminated with zero.If a property is not specified in properties, then its default value(listed in the table below) is used(it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default values.
        /// 
        /// If the extension cl_khr_d3d10_sharing is enabled, then properties specifies a list of context property names and their corresponding values.Each property is followed immediately by the corresponding desired value.The list is terminated with zero. if a property is not specified in properties, then its default value is used(it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default value.
        /// 
        /// If the extension cl_khr_d3d11_sharing is enabled, then properties specifies a list of context property names and their corresponding values.Each property is followed immediately by the corresponding desired value.The list is terminated with zero.If a property is not specified in properties, then its default value is used(it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default value.
        /// 
        /// If the extension cl_khr_gl_sharing is enabled, then properties points to an attribute list, which is a array of ordered<attribute name, value> pairs terminated with zero. If an attribute is not specified in properties, then its default value is used (it is said to be specified implicitly). If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default values.
        /// </param>
        /// <param name="devices">A pointer to a list of unique devices returned by GetDeviceIDs or sub-devices created by clCreateSubDevices for a platform. Duplicate devices specified in devices are ignored.</param>
        /// <param name="pfn_notify">
        /// A callback function that can be registered by the application. 
        /// This callback function will be used by the OpenCL implementation to report information on errors during context creation as 
        /// well as errors that occur at runtime in this context. 
        /// This callback function may be called asynchronously by the OpenCL implementation. 
        /// It is the application's responsibility to ensure that the callback function is thread-safe. 
        /// If pfn_notify is NULL, no callback function is registered.
        /// 
        /// NOTE: There are a number of cases where error notifications need to be delivered due to an error that occurs outside a context. 
        /// Such notifications may not be delivered through the pfn_notify callback. Where these notifications go is implementation-defined.
        /// </param>
        /// <param name="user_data">Passed as the user_data argument when pfn_notify is called. user_data can be NULL.</param>
        /// <param name="errcode_ret">Returns an appropriate error code.</param>
        /// <returns>An OpenCL context.</returns>
        public static CLContext CreateContext(CLContextProperties properties, [In] CLDevice[] devices, IntPtr pfn_notify, [In] IntPtr user_data, [Out] out CLResult errcode_ret)
        {
            CLDevicePtr[] devicesPtr = new CLDevicePtr[devices.Length];

            for (int i = 0; i < devices.Length; i++)
                devicesPtr[i] = devices[i].Handle;

            return new CLContext( CreateContext(properties, devices.Length, devicesPtr, pfn_notify, user_data, out errcode_ret));
        }

        /// <summary>
        /// Create an OpenCL context from a device type that identifies the specific device(s) to use.
        /// Only devices that are returned by GetDeviceIDs for device_type are used to create the context. 
        /// The context does not reference any sub-devices that may have been created from these devices.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateContextFromType.html
        /// </summary>
        /// <param name="properties">Specifies a list of context property names and their corresponding values.</param>
        /// <param name="device_type">A bit-field that identifies the type of device</param>
        /// <param name="pfn_notify">A callback function that can be registered by the application. 
        /// This callback function will be used by the OpenCL implementation to report information on errors during 
        /// context creation as well as errors that occur at runtime in this context. 
        /// This callback function may be called asynchronously by the OpenCL implementation. 
        /// It is the application's responsibility to ensure that the callback function is thread-safe. 
        /// If pfn_notify is NULL, no callback function is registered.</param>
        /// <param name="user_data">Passed as the user_data argument when pfn_notify is called. user_data can be NULL.</param>
        /// <param name="errcode_ret">Return an appropriate error code. If errcode_ret is NULL, no error code is returned.</param>
        /// <returns>returns a valid non-zero context and errcode_ret is set to Success if the context is created successfully. 
        /// Otherwise, it returns a NULL value with the following error values returned in errcode_ret</returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateContextFromType", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLContextPtr CreateContextFromType(CLContextProperties properties,
                        CLDeviceType device_type,
                        pfn_notifyDelegate pfn_notify,
                        [In] byte[] user_data,
                        [Out] out CLResult errcode_ret);

        /// <summary>
        /// Increment the context reference count.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Retain.html
        /// </summary>
        /// <param name="context">The context to retain.</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clRetainContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult Retain(CLContextPtr context);

        /// <summary>
        /// Decrement the context reference count.
        /// 
        /// After the context reference count becomes zero and all the objects attached to context 
        /// (such as memory objects, command-queues) are released, the context is deleted.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Release.html
        /// </summary>
        /// <param name="context">The context to release.</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clReleaseContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult Release(CLContextPtr context);

        /// <summary>
        /// Query information about a context.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetContextInfo.html
        /// </summary>
        /// <param name="context"Specifies the OpenCL context being queried.></param>
        /// <param name="param_name">An enumeration constant that specifies the information to query.</param>
        /// <param name="param_value_size">Specifies the size in bytes of memory pointed to by param_value. 
        /// This size must be greater than or equal to the size of return type as described in the table above.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. 
        /// If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">Returns the actual size in bytes of data being queried by param_value. 
        /// If param_value_size_ret is NULL, it is ignored.</param>
        /// <returns>Returns Success if the function executed successfully</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetContextInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetContextInfo(CLContextPtr context,
                 CLContextInfo param_name,
                 int param_value_size,
                 [Out] byte[] param_value,
                 [Out] out int param_value_size_ret);

        /* Command Queue APIs */

        /// <summary>
        /// Create a host or device command-queue on a specific device.
        /// 
        /// Notes
        /// 
        /// OpenCL objects such as memory, program and kernel objects are created using a context.Operations on these objects are 
        /// performed using a command-queue.
        /// The command-queue can be used to queue a set of operations (referred to as commands) in order.
        /// Having multiple command-queues allows applications to queue multiple independent commands without requiring 
        /// synchronization.
        /// Note that this should work as long as these objects are not being shared. 
        /// Sharing of objects across multiple command-queues will require the application to perform appropriate synchronization.
        /// This is described in Appendix A of the specification.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateCommandQueueWithProperties.html
        /// </summary>
        /// <param name="context"></param>
        /// <param name="device"></param>
        /// <param name="properties">Specifies a list of properties for the command-queue and their corresponding values. 
        /// Each property name is immediately followed by the corresponding desired value. 
        /// The list is terminated with 0.
        /// The list of supported properties is described in the table below. 
        /// If a supported property and its value is not specified in properties, its default value will be used.
        /// properties can be NULL in which case the default values for supported command-queue properties will be used.</param>
        /// <param name="errcode_ret">Returns an appropriate error code.</param>
        /// <returns>CreateCommandQueueWithProperties returns a valid non-zero command-queue and errcode_ret is set to Success if the command-queue is created successfully. Otherwise, it returns a NULL value</returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateCommandQueueWithProperties", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLCommandQueuePtr CreateCommandQueueWithProperties(CLContextPtr context,
                                   CLDevicePtr device,
                                   CLCommandQueueProperties[] properties,
                                   [Out] out CLResult errcode_ret);

        /// <summary>
        /// Increments the command_queue reference count.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Retain.html
        /// </summary>
        /// <param name="command_queue">Specifies the command-queue to retain.</param>
        /// <returns>Returns Success if the function executed successfully</returns>
        [DllImport("opencl.dll", EntryPoint = "clRetainCommandQueue", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult Retain(CLCommandQueuePtr command_queue);

        /// <summary>
        /// Decrements the command_queue reference count.
        /// 
        /// Notes
        /// After the command_queue reference count becomes zero and all commands queued to command_queue have finished
        /// (e.g., kernel executions, memory object updates, etc.), the command-queue is deleted.
        /// Release performs an implicit flush to issue any previously queued OpenCL commands in command_queue.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Release.html
        /// </summary>
        /// <param name="command_queue">Specifies the command-queue to release.</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clReleaseCommandQueue", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult Release(CLCommandQueuePtr command_queue);

        /// <summary>
        /// Query information about a command-queue.
        /// 
        /// Notes
        /// It is possible that a device(s) becomes unavailable after a context and command-queues that use this device(s) 
        /// have been created and commands have been queued to command-queues.
        /// In this case the behavior of OpenCL API calls that use this context (and command-queues) are considered to be 
        /// implementation-defined. 
        /// The user callback function, if specified, when the context is created can be used to record appropriate information 
        /// in the errinfo, private_info arguments passed to the callback function when the device becomes unavailable.
        /// 
        /// CLCommandQueueInfo	Return Type and Information returned in param_value
        /// Context Return type: CLContextPtr
        ///  Return the context specified when the command-queue is created.
        ///
        /// Device Return type: CLDevicePtr
        ///  Return the device specified when the command-queue is created.
        ///
        ///  ReferenceCount Return type: cl_uint
        /// Return the command-queue reference count.
        ///
        /// The reference count returned with ReferenceCount should be considered immediately stale.It is unsuitable for general use in applications.This feature is provided for identifying memory leaks.
        ///
        ///  Properties Return type: CLCommandQueueProperties
        /// Return the currently specified properties for the command-queue.These properties are specified by the value associated with the CL_COMMAND_QUEUE_PROPERTIES passed in properties argument in CreateCommandQueueWithProperties.
        ///
        /// Size Return type: cl_uint
        /// Return the currently specified size for the device command-queue.This query is only supported for device command queues.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetCommandQueueInfo.html
        /// </summary>
        /// <param name="command_queue">Specifies the command-queue being queried.</param>
        /// <param name="param_name">Specifies the information to query.</param>
        /// <param name="param_value_size">Specifies the size in bytes of memory pointed to by param_value. This size must be ≥ size of return type as described in the table below. If param_value is NULL, it is ignored.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.</param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clGetCommandQueueInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetCommandQueueInfo(CLCommandQueuePtr command_queue,
                      CLCommandQueueInfo param_name,
                      int param_value_size,
                      [In, Out] IntPtr param_value, ///TODO: Split this function into many for the right return type.
                     [Out] out int param_value_size_ret);

        /* Memory Object APIs */

        /// <summary>
        /// Creates a buffer object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Create.html
        /// </summary>
        /// <param name="context">A valid OpenCL context used to create the buffer object.</param>
        /// <param name="flags">
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to 
        /// allocate the buffer object and how it will be used. 
        /// The default is used which is ReadWrite.</param>
        /// <param name="size">The size in bytes of the buffer memory object to be allocated.</param>
        /// <param name="host_ptr">
        /// A pointer to the buffer data that may already be allocated by the application. 
        /// The size of the buffer that host_ptr points to must be ≥ size bytes.
        /// 
        /// Use: 
        /// GCHandle dataPointer = GCHandle.Alloc(data, GCHandleType.Pinned);
        /// dataPointer.AddrOfPinnedObject();
        /// 
        /// to pass the data in a safe manner!
        /// </param>
        /// <param name="errcode_ret">Returns an appropriate error code.</param>
        /// <returns>Returns a valid non-zero buffer object and errcode_ret is set to Success if the buffer object is created successfully. Otherwise, it returns a NULL value</returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateBuffer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLMemoryPtr CreateBuffer(CLContextPtr context,
               CLMemoryFlags flags,
               long size,
               IntPtr host_ptr,
               [Out] out CLResult errcode_ret);

        /// <summary>
        /// Increments the memory object reference count.
        /// 
        /// Notes
        /// Create, clCreateSubBuffer, CreateImage, and clCreatePipe perform an implicit retain.
        /// 
        /// After the memobj reference count becomes zero and commands queued for execution on a command-queue(s) 
        /// that use memobj have finished, the memory object is deleted.
        /// If memobj is a buffer object, memobj cannot be deleted until all sub-buffer objects associated with memobj are deleted.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Retain.html
        /// </summary>
        /// <param name="memobj">A valid memory object.</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clRetainMemObject", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult Retain(CLMemoryPtr memobj);

        /// <summary>
        /// Decrements the memory object reference count.
        /// 
        /// Notes
        /// After the memobj reference count becomes zero and commands queued for execution on a command-queue(s) 
        /// that use memobj have finished, the memory object is deleted. 
        /// If memobj is a buffer object, memobj cannot be deleted until all sub-buffer objects associated with memobj are deleted.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Release.html
        /// </summary>
        /// <param name="memobj">A valid memory object.</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clReleaseMemObject", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult Release(CLMemoryPtr memobj);

        /// <summary>
        /// Get the list of image formats supported by an OpenCL implementation.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetSupportedImageFormats.html
        /// </summary>
        /// <param name="context">A valid OpenCL context on which the image object(s) will be created.</param>
        /// <param name="flags">
        /// A bit-field that is used to specify allocation and usage information about the image memory object being queried. 
        /// To get a list of supported image formats that can be read from or written to by a kernel, 
        /// flags must be set to 
        /// ReadWrite (get a list of images that can be read from or written to by a kernel), 
        /// ReadOnly (list of images that can be read from by a kernel) or 
        /// WriteOnly (list of images that can be written to by a kernel). 
        /// 
        /// To get a list of supported image formats that can be both read from and written to by a kernel, flags must be set to 
        /// CL_MEM_KERNEL_READ_AND_WRITE.
        /// </param>
        /// <param name="Type">
        /// Describes the image type and must be either Image1D, Image1DBuffer, Image2D, 
        /// Image3D, Image1DArray or Image2DArray.
        /// </param>
        /// <param name="num_entries">
        /// Specifies the number of entries that can be returned in the memory location given by image_formats.
        /// </param>
        /// <param name="image_formats">
        /// A pointer to a memory location where the list of supported image formats are returned. 
        /// Each entry describes a CLImageFormat structure supported by the OpenCL implementation. 
        /// If image_formats is NULL, it is ignored.
        /// </param>
        /// <param name="num_image_formats">
        /// The actual number of supported image formats for a specific context and values specified by flags. 
        /// If num_image_formats is NULL, it is ignored.
        /// </param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetSupportedImageFormats", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetSupportedImageFormats(CLContextPtr context,
                           CLMemoryFlags flags,
                           CLMemoryObjectType Type,
                           int num_entries,
                           [In, Out] CLImageFormat[] image_formats,
                           [Out] out int num_image_formats);

        /// <summary>
        /// Get information that is common to all memory objects (buffer and image objects).
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetMemObjectInfo.html
        /// </summary>
        /// <param name="memobj">Specifies the memory object being queried.</param>
        /// <param name="param_name">Specifies the information to query.</param>
        /// <param name="param_value_size">Used to specify the size in bytes of memory pointed to by param_value. This size must be ≥ size of return type as described in the table above.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetMemObjectInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetMemObjectInfo(CLMemoryPtr memobj,
                   CLMemoryInfo param_name,
                   int param_value_size,
                   IntPtr param_value,
                   [Out] out int param_value_size_ret);

        /// <summary>
        /// Get information specific to an image object created with CreateImage.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetImageInfo.html
        /// </summary>
        /// <param name="image">Specifies the image object being queried.</param>
        /// <param name="param_name">
        /// Specifies the information to query. 
        /// The list of supported param_name types and the information returned in param_value by GetImageInfo
        /// </param>
        /// <param name="param_value_size">Used to specify the size in bytes of memory pointed to by param_value. This size must be ≥ size of return type</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.</param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clGetImageInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetImageInfo(CLMemoryPtr image,
               CLImageInfo param_name,
               int param_value_size,
               IntPtr param_value,
               [Out] out int param_value_size_ret);

        /// <summary>
        /// Creates a sampler object.
        /// 
        /// Notes
        /// A sampler object describes how to sample an image when the image is read in the kernel.
        /// The built-in functions to read from an image in a kernel take a sampler as an argument. 
        /// The sampler arguments to the image read function can be sampler objects created using OpenCL 
        /// functions and passed as argument values to the kernel or can be samplers declared inside a kernel.
        /// In this section we discuss how sampler objects are created using OpenCL functions.
        ///
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/CreateSampler.html
        /// </summary>
        /// <param name="context">Must be a valid OpenCL context.</param>
        /// <param name="normalized_coords">
        /// Determines if the image coordinates specified are normalized 
        /// (if normalized_coords is true) or not (if normalized_coords is false).</param>
        /// <param name="addressing_mode">Specifies how out-of-range image coordinates are handled when reading from an image. 
        /// This can be set to Repeat, ClampToEdge, Clamp, and None.
        /// </param>
        /// <param name="filter_mode">
        /// Specifies the type of filter that must be applied when reading an image. 
        /// This can be Nearest or Linear.
        /// </param>
        /// <param name="errcode_ret">Returns an appropriate error code. </param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("opencl.dll", EntryPoint = "clCreateSampler", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLSamplerPtr CreateSampler(CLContextPtr context,
                        bool normalized_coords,
                        CLAddressingMode addressing_mode,
                        CLFilterMode filter_mode,
                        [Out] out CLResult errcode_ret);


        /// <summary>
        /// Increments the sampler reference count.
        /// 
        /// Notes
        /// Retain performs an implicit retain.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Retain.html
        /// </summary>
        /// <param name="sampler">Specifies the sampler being retained.</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clRetainSampler", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult Retain(CLSamplerPtr sampler);

        /// <summary>
        /// Decrements the sampler reference count.
        /// 
        /// Notes
        /// The sampler object is deleted after the reference count becomes zero and commands queued for execution on a command-queue(s) that use sampler have finished.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Release.html
        /// </summary>
        /// <param name="sampler">Specifies the sampler being retained.</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clReleaseSampler", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult Release(CLSamplerPtr sampler);

        /// <summary>
        /// Returns information about the sampler object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetSamplerInfo.html
        /// </summary>
        /// <param name="sampler">Specifies the sampler being queried.</param>
        /// <param name="param_name">Specifies the information to query. </param>
        /// <param name="param_value_size">Specifies the size in bytes of memory pointed to by param_value. This size must be ≥ size of return type as described in the table above.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetSamplerInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetSamplerInfo(CLSamplerPtr sampler,
                 CLSamplerInfo param_name,
                 int param_value_size,
                 IntPtr param_value,
                 [Out] out uint param_value_size_ret);

        /* Program Object APIs */

        /// <summary>
        /// Creates a program object for a context, and loads the source code specified by the text strings in the strings array into the program object.
        /// 
        /// Description
        /// This function creates a program object for a context, and loads the source code specified by the text strings in the strings array into the program object. The devices associated with the program object are the devices associated with context.The source code specified by strings is either an OpenCL C program source, header or implementation-defined source for custom devices that support an online compiler.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateProgramWithSource.html
        /// </summary>
        /// <param name="context">Must be a valid OpenCL context.</param>
        /// <param name="count">Number of string pointers in strings</param>
        /// <param name="lengths">An array of count pointers to optionally null-terminated character strings that make up the source code.</param>
        /// <param name="strings">
        /// An array with the number of chars in each string (the string length). 
        /// If an element in lengths is zero, its accompanying string is null-terminated. 
        /// If lengths is NULL, all strings in the strings argument are considered null-terminated. 
        /// Any length value passed in that is greater than zero excludes the null terminator in its count.</param>
        /// <param name="errcode_ret">Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.</param>
        /// <returns>returns a valid non-zero program object</returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateProgramWithSource", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLProgramPtr CreateProgramWithSource(CLContextPtr context,
                          int count,
                          string[] strings,
                          int[] lengths,
                          [Out] out CLResult errcode_ret);

        /// <summary>
        /// Creates a program object for a context, and loads the source code specified by the text strings in the strings array into the program object.
        /// 
        /// Description
        /// This function creates a program object for a context, and loads the source code specified by the text strings in the strings array into the program object. The devices associated with the program object are the devices associated with context.The source code specified by strings is either an OpenCL C program source, header or implementation-defined source for custom devices that support an online compiler.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateProgramWithSource.html
        /// </summary>
        /// <param name="context">Must be a valid OpenCL context.</param>
        /// <param name="shaderCode">The shader code to compile</param>
        /// <param name="errcode_ret">Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.</param>
        /// <returns>returns a valid non-zero program object</returns>
        public static CLProgramPtr CreateProgramWithSource(CLContext context,
                   string shaderCode,
               [Out] out CLResult errcode_ret)
        {
            int count = 1;
            string[] strings = new string[] { shaderCode };
            int[] lengths = new int[] { shaderCode.Length };

            return CreateProgramWithSource(context, count, strings, lengths, out errcode_ret);
        }

        /// <summary>
        /// Creates a program object for a context, and loads the binary bits specified by binary into the program object.
        /// 
        /// Notes
        /// OpenCL allows applications to create a program object using the program source or binary and build appropriate 
        /// program executables.
        /// This can be very useful as it allows applications to load program source and then compile and link to generate a 
        /// program executable online on its first instance for appropriate OpenCL devices in the system.
        /// These executables can now be queried and cached by the application. 
        /// Future instances of the application launching will no longer need to compile and link the program executables.
        /// The cached executables can be read and loaded by the application, which can help significantly reduce the application 
        /// initialization time.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateProgramWithBinary.html
        /// </summary>
        /// <param name="context">Must be a valid OpenCL context.</param>
        /// <param name="num_devices">
        /// The number of devices listed in device_list.
        /// 
        /// The devices associated with the program object will be the list of devices specified by device_list.
        /// The list of devices specified by device_list must be devices associated with context.</param>
        /// <param name="device_list">
        /// A pointer to a list of devices that are in context. device_list must be a non-NULL value. 
        /// The binaries are loaded for devices specified in this list.</param>
        /// <param name="lengths">
        /// An array of the size in bytes of the program binaries to be loaded for devices specified by device_list.
        /// </param>
        /// <param name="binaries">
        /// n array of pointers to program binaries to be loaded for devices specified by device_list. 
        /// For each device given by device_list[i], the pointer to the program binary for that device is given by 
        /// binaries[i] and the length of this corresponding binary is given by lengths[i]. 
        /// lengths[i] cannot be zero and binaries[i] cannot be a NULL pointer.
        /// 
        /// The program binaries specified by binaries contain the bits that describe one of the following:
        /// 
        /// a program executable to be run on the device(s) associated with context,
        /// a compiled program for device(s) associated with context, or
        /// a library of compiled programs for device(s) associated with context.
        /// The program binary can consist of either or both of device-specific code and/or 
        /// implementation-specific intermediate representation(IR) which will be converted to the device-specific code.
        /// </param>
        /// <param name="binary_status">
        /// Returns whether the program binary for each device specified in device_list was loaded successfully or not. 
        /// It is an array of num_devices entries and returns Success in binary_status[i] if binary was successfully 
        /// loaded for device specified by device_list[i]; 
        /// otherwise returns InvalidValue if lengths[i] is zero or if binaries[i] is a NULL value 
        /// or InvalidBinary in binary_status[i] if program binary is not a valid binary for the specified device. 
        /// If binary_status is NULL, it is ignored.
        /// </param>
        /// <param name="errcode_ret"></param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateProgramWithBinary", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLProgramPtr CreateProgramWithBinary(CLContextPtr context,
                          int num_devices,
                          CLDevicePtr[] device_list,
                          int[] lengths,
                          byte[][] binaries,
                          [Out] out CLResult[] binary_status,
                          [Out] out CLResult errcode_ret);


        /// <summary>
        /// Increments the program reference count.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/Retain.html
        /// </summary>
        /// <param name="program">The program to retain</param>
        /// <returns>returns Success if the function is executed successfully. It returns InvalidProgram if program is not a valid program object.</returns>
        [DllImport("opencl.dll", EntryPoint = "clRetainProgram", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult Retain(CLProgramPtr program);

        /// <summary>
        /// Decrements the program reference count.
        /// 
        /// Notes:
        /// The program object is deleted after all kernel objects associated with program have been deleted and the program 
        /// reference count becomes zero.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/Release.html
        /// </summary>
        /// <param name="program">The program to release</param>
        /// <returns>returns Success if the function is executed successfully. It returns InvalidProgram if program is not a valid program object.</returns>
        [DllImport("opencl.dll", EntryPoint = "clReleaseProgram", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult Release(CLProgramPtr program);

        /// <summary>
        /// TODO: Validate me. 
        /// According to Mcrosoft passing deligates is a bad idea. 
        /// For now pass null.
        /// </summary>
        /// <param name="program"></param>
        /// <param name="user_data"></param>
        public delegate void pfn_BuildProgramNotifyDelegate(CLProgramPtr program,
                                                IntPtr user_data);

        /// <summary>
        /// Builds (compiles and links) a program executable from the program source or binary.
        /// 
        /// Notes
        /// Builds (compiles & links) a program executable from the program source or binary for all the 
        /// devices or a specific device(s) in the OpenCL context associated with program.
        /// OpenCL allows program executables to be built using the source or the binary.
        /// BuildProgram must be called for program created using either CreateProgramWithSource or CreateProgramWithBinary 
        /// to build the program executable for one or more devices associated with program.
        /// If program is created with CreateProgramWithBinary, then the program binary must be an executable binary
        /// (not a compiled binary or library).
        /// 
        /// The executable binary can be queried using GetProgramInfo(program, Binaries, ...) 
        /// and can be specified to CreateProgramWithBinary to create a new program object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/BuildProgram.html
        /// </summary>
        /// <param name="program">The program object.</param>
        /// <param name="num_devices">The number of devices listed in device_list.</param>
        /// <param name="device_list">
        /// A pointer to a list of devices associated with program. 
        /// If device_list is NULL value, the program executable is built for all devices associated with program for which a 
        /// source or binary has been loaded. 
        /// If device_list is a non-NULL value, the program executable is built for devices specified in this list for which a 
        /// source or binary has been loaded.
        /// </param>
        /// <param name="options">
        /// A pointer to a null-terminated string of characters that describes the 
        /// build options to be used for building the program executable. 
        /// The list of supported options is described in the remarks.
        /// </param>
        /// <param name="pfn_notify">
        /// A function pointer to a notification routine. 
        /// The notification routine is a callback function that an application can register and which will be called when 
        /// the program executable has been built (successfully or unsuccessfully). 
        /// If pfn_notify is not NULL, BuildProgram does not need to wait for the build to complete and can return immediately 
        /// once the build operation can begin. 
        /// The build operation can begin if the context, program whose sources are being compiled and linked, 
        /// list of devices and build options specified are all valid and appropriate host and device resources needed 
        /// to perform the build are available. 
        /// If pfn_notify is NULL, BuildProgram does not return until the build has completed. 
        /// This callback function may be called asynchronously by the OpenCL implementation. 
        /// It is the application’s responsibility to ensure that the callback function is thread-safe.
        /// </param>
        /// <param name="user_data">Passed as an argument when pfn_notify is called. user_data can be NULL.</param>
        /// <returns>returns Success if the function is executed successfully.</returns>
        /// <remarks>
        /// Compiler Options
        /// The compiler options are categorized as pre-processor options, options for math intrinsics, options that control optimization and miscellaneous options.This specification defines a standard set of options that must be supported by the OpenCL C compiler when building program executables online or offline.These may be extended by a set of vendor- or platform specific options.
        /// 
        /// 
        /// Preprocessor Options
        /// These options control the OpenCL C preprocessor which is run on each program source before actual compilation.
        /// 
        /// -D options are processed in the order they are given in the options argument to BuildProgram or CompileProgram.
        ///         
        /// -D name
        /// Predefine name as a macro, with definition 1.
        /// 
        /// -D name = definition
        /// The contents of definition are tokenized and processed as if they appeared during translation phase three in a '#define' directive.In particular, the definition will be truncated by embedded newline characters.
        ///         
        /// -I dir
        /// Add the directory dir to the list of directories to be searched for header files.
        /// 
        /// 
        /// Math Intrinsics Options
        /// These options control compiler behavior regarding floating-point arithmetic. These options trade off between speed and correctness.
        /// -cl-single-precision-constant
        /// Treat double precision floating-point constant as single precision constant.
        ///         
        /// -cl-denorms-are-zero
        /// This option controls how single precision and double precision denormalized numbers are handled. If specified as a build option, the single precision denormalized numbers may be flushed to zero; double precision denormalized numbers may also be flushed to zero if the optional extension for double precsion is supported.This is intended to be a performance hint and the OpenCL compiler can choose not to flush denorms to zero if the device supports single precision(or double precision) denormalized numbers.
        /// 
        /// This option is ignored for single precision numbers if the device does not support single precision denormalized numbers i.e.Denorm bit is not set in SingleFPConfig.
        /// 
        /// This option is ignored for double precision numbers if the device does not support double precision or if it does support double precison but not double precision denormalized numbers i.e.Denorm bit is not set in DoubleFPConfig.
        /// 
        /// This flag only applies for scalar and vector single precision floating-point variables and computations on these floating-point variables inside a program.It does not apply to reading from or writing to image objects.
        /// 
        /// -cl-fp32-correctly-rounded-divide-sqrt
        /// The -cl-fp32-correctly-rounded-divide-sqrt build option to BuildProgram or CompileProgram allows an application to specify that single precision floating-point divide (x/y and 1/x) and sqrt used in the program source are correctly rounded.If this build option is not specified, the minimum numerical accuracy of single precision floating-point divide and sqrt are as defined in section 7.4 of the OpenCL specification.
        /// 
        /// 
        /// This build option can only be specified if the CorrectlyRoundedDivideAndSqrt is set in SingleFPConfig (as defined in in the table of allowed values for param_name for GetDeviceInfo) for devices that the program is being build.BuildProgram or CompileProgram will fail to compile the program for a device if the -cl-fp32-correctly-rounded-divide-sqrt option is specified and CorrectlyRoundedDivideAndSqrt is not set for the device.
        /// 
        /// 
        /// Optimization Options
        /// These options control various sorts of optimizations.Turning on optimization flags makes the compiler attempt to improve the performance and/or code size at the expense of compilation time and possibly the ability to debug the program.
        ///       
        /// -cl-opt-disable
        /// This option disables all optimizations. The default is optimizations are enabled.
        /// 
        /// The following options control compiler behavior regarding floating-point arithmetic. These options trade off between performance and correctness and must be specifically enabled.These options are not turned on by default since it can result in incorrect output for programs which depend on an exact implementation of IEEE 754 rules/specifications for math functions.
        /// 
        /// -cl-mad-enable
        /// Allow a* b + c to be replaced by a mad.The mad computes a * b + c with reduced accuracy. For example, some OpenCL devices implement mad as truncate the result of a* b before adding it to c.
        ///       
        /// -cl-no-signed-zeros
        /// Allow optimizations for floating-point arithmetic that ignore the signedness of zero. IEEE 754 arithmetic specifies the distinct behavior of +0.0 and -0.0 values, which then prohibits simplification of expressions such as x+0.0 or 0.0*x (even with -clfinite-math only). This option implies that the sign of a zero result isn't significant.
        /// 
        /// -cl-unsafe-math-optimizations
        /// Allow optimizations for floating-point arithmetic that(a) assume that arguments and results are valid, (b) may violate IEEE 754 standard and(c) may violate the OpenCL numerical compliance requirements as defined in section 7.4 for single precision and double precision floating-point, and edge case behavior in section 7.5. This option includes the -cl-no-signed-zeros and -cl-mad-enable options.
        /// 
        /// -cl-finite-math-only
        /// Allow optimizations for floating-point arithmetic that assume that arguments and results are not NaNs or ±∞. This option may violate the OpenCL numerical compliance requirements defined in section 7.4 for single precision and double precision floating point, and edge case behavior in section 7.5.
        /// 
        /// -cl-fast-relaxed-math
        /// Sets the optimization options -cl-finite-math-only and -cl-unsafe-math-optimizations.This allows optimizations for floating-point arithmetic that may violate the IEEE 754 standard and the OpenCL numerical compliance requirements defined in the specification in section 7.4 for single-precision and double precision floating-point, and edge case behavior in section 7.5. This option also relaxes the precision of commonly used math functions(refer to table 7.2 defined in section 7.4). This option causes the preprocessor macro __FAST_RELAXED_MATH__ to be defined in the OpenCL program.
        /// 
        /// -cl-uniform-work-group-size
        /// This requires that the global work-size be a multiple of the work-group size specified to EnqueueNDRangeKernel.Allow optimizations that are made possible by this restriction.
        /// 
        /// Options to Request or Suppress Warnings
        /// Warnings are diagnostic messages that report constructions which are not inherently erroneous but which are risky or suggest there may have been an error. The following language independent options do not enable specific warnings but control the kinds of diagnostics produced by the OpenCL compiler.
        /// -w
        /// Inhibit all warning messages.
        /// 
        /// -Werror
        /// Make all warnings into errors.
        /// 
        /// 
        /// Options Controlling the OpenCL C Version
        /// The following option controls the version of OpenCL C that the compiler accepts.
        /// -cl-std=
        /// Determine the OpenCL C language version to use.A value for this option must be provided. Valid values are:
        /// 
        /// 
        /// CL1.1 - Support all OpenCL C programs that use the OpenCL C language features defined in section 6 of the OpenCL 1.1 specification.
        /// 
        /// CL1.2 - Support all OpenCL C programs that use the OpenCL C language features defined in section 6 of the OpenCL 1.2 specification.
        /// 
        /// CL2.0 - Support all OpenCL C programs that use the OpenCL C language features defined in section 6 of the OpenCL 2.0 specification.
        /// 
        /// Calls to BuildProgram or CompileProgram with the -cl-std= CL1.1 option will fail to compile the program for any devices with OpenCLVersion = OpenCL C 1.0.
        /// 
        /// 
        /// Calls to BuildProgram or CompileProgram with the -cl-std= CL1.2 option will fail to compile the program for any devices with OpenCLVersion = OpenCL C 1.0 or OpenCL C 1.1.
        /// 
        /// 
        /// Calls to BuildProgram or CompileProgram with the -cl-std= CL2.0 option will fail to compile the program for any devices with OpenCLVersion = OpenCL C 1.0, OpenCL C 1.1, or OpenCL C 1.2.
        /// 
        /// 
        /// If the –cl-std build option is not specified, the highest OpenCL C 1.x language version supported by each device is used when compiling the program for each device. Applications are required to specify the –cl-std= CL2.0 option if they want to compile or build their programs with OpenCL C 2.0.
        /// 
        /// 
        /// Options enabled by the cl_khr_spir extension
        /// -x spir
        /// Indicates that the binary is in SPIR format.
        /// 
        /// -spir-std
        /// Specifies the version of the SPIR specification that describes the format and meaning of the binary.For example, if the binary is as described in SPIR version 1.2, then -spir-std= 1.2 must be specified.Failing to specify these compile options may result in implementation defined behavior.
        /// 
        /// Options for Querying Kernel Argument Information
        /// -cl-kernel-arg-info
        /// This option allows the compiler to store information about the arguments of a kernel(s) in the program executable.The argument information stored includes the argument name, its type, the address and access qualifiers used. Refer to description of GetKernelArgInfo on how to query this information.
        /// 
        /// Options for debugging your program
        /// -g
        /// This option can currently be used to generate additional errors for the built-in functions that allow you to enqueue commands on a device (refer to section 6.13.17).
        /// 
        /// Linker Options
        /// This specification defines a standard set of linker options that must be supported by the OpenCL C compiler when linking compiled programs online or offline. These linker options are categorized as library linking options and program linking options. These may be extended by a set of vendor- or platform-specific options.
        /// Library Linking Options
        /// The following options can be specified when creating a library of compiled binaries.
        /// -create-library
        /// Create a library of compiled binaries specified in input_programs argument to clLinkProgram.
        /// 
        /// -enable-link-options
        /// Allows the linker to modify the library behavior based on one or more link options (described in Program Linking Options, below) when this library is linked with a program executable.This option must be specified with the -create-library option.
        /// 
        /// 
        /// Program Linking Options
        /// The following options can be specified when linking a program executable.
        /// -cl-denorms-are-zero
        /// -cl-no-signed-zeroes
        /// -cl-unsafe-math-optimizations
        /// -cl-finite-math-only
        /// -cl-fast-relaxed-mat
        /// The linker may apply these options to all compiled program objects specified to clLinkProgram.The linker may apply these options only to libraries which were created with the -enable-link-option.
        /// </remarks>
        [DllImport("opencl.dll", EntryPoint = "clBuildProgram", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult BuildProgram(CLProgramPtr program,
               int num_devices,
               CLDevicePtr[] device_list,
               string options,
               pfn_BuildProgramNotifyDelegate pfn_notify,
               IntPtr user_data);

        /// <summary>
        /// Builds (compiles and links) a program executable from the program source or binary.
        /// 
        /// Notes
        /// Builds (compiles & links) a program executable from the program source or binary for all the 
        /// devices or a specific device(s) in the OpenCL context associated with program.
        /// OpenCL allows program executables to be built using the source or the binary.
        /// BuildProgram must be called for program created using either CreateProgramWithSource or CreateProgramWithBinary 
        /// to build the program executable for one or more devices associated with program.
        /// If program is created with CreateProgramWithBinary, then the program binary must be an executable binary
        /// (not a compiled binary or library).
        /// 
        /// The executable binary can be queried using GetProgramInfo(program, Binaries, ...) 
        /// and can be specified to CreateProgramWithBinary to create a new program object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/BuildProgram.html
        /// </summary>
        /// <param name="program">The program object.</param>
        /// <param name="num_devices">The number of devices listed in device_list.</param>
        /// <param name="device_list">
        /// A pointer to a list of devices associated with program. 
        /// If device_list is NULL value, the program executable is built for all devices associated with program for which a 
        /// source or binary has been loaded. 
        /// If device_list is a non-NULL value, the program executable is built for devices specified in this list for which a 
        /// source or binary has been loaded.
        /// </param>
        /// <param name="options">
        /// A pointer to a null-terminated string of characters that describes the 
        /// build options to be used for building the program executable. 
        /// The list of supported options is described in the remarks.
        /// </param>
        /// <param name="pfn_notify">
        /// A function pointer to a notification routine. 
        /// The notification routine is a callback function that an application can register and which will be called when 
        /// the program executable has been built (successfully or unsuccessfully). 
        /// If pfn_notify is not NULL, BuildProgram does not need to wait for the build to complete and can return immediately 
        /// once the build operation can begin. 
        /// The build operation can begin if the context, program whose sources are being compiled and linked, 
        /// list of devices and build options specified are all valid and appropriate host and device resources needed 
        /// to perform the build are available. 
        /// If pfn_notify is NULL, BuildProgram does not return until the build has completed. 
        /// This callback function may be called asynchronously by the OpenCL implementation. 
        /// It is the application’s responsibility to ensure that the callback function is thread-safe.
        /// </param>
        /// <param name="user_data">Passed as an argument when pfn_notify is called. user_data can be NULL.</param>
        /// <returns>returns Success if the function is executed successfully.</returns>
        public static CLResult BuildProgram(CLProgramPtr program,
       int num_devices,
       CLDevice[] device_list,
       string options,
       pfn_BuildProgramNotifyDelegate pfn_notify,
       IntPtr user_data)
        {
            CLDevicePtr[] device_listPtrs = new CLDevicePtr[device_list.Length];
            for (int i = 0; i < device_list.Length; i++)
            {
                device_listPtrs[i] = device_list[i];
            }

            return BuildProgram(program, num_devices, device_listPtrs, options, pfn_notify, user_data);
        }

        /// <summary>
        /// Compiles a program’s source for all the devices or a specific device(s) in the OpenCL context associated with program.
        /// 
        /// Notes
        /// Compiles a program’s source for all the devices or a specific device(s) in the OpenCL context associated with program.
        /// The pre-processor runs before the program sources are compiled. 
        /// The compiled binary is built for all devices associated with program or the list of devices specified.
        /// The compiled binary can be queried using GetProgramInfo(program, Binaries, ...) and can be specified to 
        /// CreateProgramWithBinary to create a new program object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CompileProgram.html
        /// </summary>
        /// <param name="program">The program object that is the compilation target.</param>
        /// <param name="num_devices">The number of devices listed in device_list.</param>
        /// <param name="device_list">
        /// A pointer to a list of devices associated with program. 
        /// If device_list is a NULL value, the compile is performed for all devices associated with program. 
        /// If device_list is a non-NULL value, the compile is performed for devices specified in this list.
        /// </param>
        /// <param name="options">
        /// A pointer to a null-terminated string of characters that describes the compilation options 
        /// to be used for building the program executable.
        /// See: CL.BuildProgram remarks
        /// </param>
        /// <param name="num_input_headers">Specifies the number of programs that describe headers in the array referenced by input_headers.</param>
        /// <param name="input_headers">An array of program embedded headers created with CreateProgramWithSource.</param>
        /// <param name="header_include_names">
        /// An array that has a one to one correspondence with input_headers. 
        /// Each entry in header_include_names specifies the include name used by source in program that comes from an embedded header. 
        /// The corresponding entry in input_headers identifies the program object which contains the header source to be used. 
        /// The embedded headers are first searched before the headers in the list of directories specified by the –I compile option 
        /// (as described in section 5.8.4.1). 
        /// If multiple entries in header_include_names refer to the same header name, the first one encountered will be used.
        /// </param>
        /// <param name="pfn_notify">
        /// A function pointer to a notification routine. 
        /// The notification routine is a callback function that an application can register and which will be called when the program 
        /// executable has been built (successfully or unsuccessfully). 
        /// If pfn_notify is not NULL, CompileProgram does not need to wait for the compiler to complete and can return immediately 
        /// once the compilation can begin. 
        /// The compilation can begin if the context, program whose sources are being compiled, list of devices, input headers, 
        /// programs that describe input headers and compiler options specified are all valid and appropriate host and 
        /// device resources needed to perform the compile are available. 
        /// If pfn_notify is NULL, CompileProgram does not return until the compiler has completed. 
        /// This callback function may be called asynchronously by the OpenCL implementation. 
        /// It is the application’s responsibility to ensure that the callback function is thread-safe.
        /// </param>
        /// <param name="user_data">Passed as an argument when pfn_notify is called. user_data can be NULL.</param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clCompileProgram", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult CompileProgram(CLProgramPtr program,
                 uint num_devices,
                 CLDevicePtr[] device_list,
                 string options,
                 uint num_input_headers,
                 CLProgramPtr[] input_headers,
                 string[] header_include_names,
                 pfn_BuildProgramNotifyDelegate pfn_notify,
                 IntPtr user_data);

        /// <summary>
        /// Returns information about the program object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetProgramInfo.html
        /// </summary>
        /// <param name="program">Specifies the program object being queried.</param>
        /// <param name="param_name">Specifies the information to query. </param>
        /// <param name="param_value_size">Used to specify the size in bytes of memory pointed to by param_value. 
        /// This size must be ≥ size of return type as described in the table above.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. 
        /// If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">Returns the actual size in bytes of data copied to param_value. 
        /// If param_value_size_ret is NULL, it is ignored.</param>
        /// <returns>Returns Success if the function is executed successfully</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetProgramInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetProgramInfo(CLProgramPtr program,
                 CLProgramInfo param_name,
                 int param_value_size,
                 IntPtr param_value,
                 [Out] out int param_value_size_ret);


        /// <summary>
        /// Returns build information for each device in the program object.
        /// 
        /// Notes
        /// A program binary (compiled binary, library binary or executable binary) built for a 
        /// parent device can be used by all its sub-devices.
        /// If a program binary has not been built for a sub-device, 
        /// the program binary associated with the parent device will be used.
        /// 
        /// A program binary for a device specified with CreateProgramWithBinary or queried using 
        /// GetProgramInfo can be used as the binary for the associated root device, 
        /// and all sub-devices created from the root-level device or sub-devices thereof.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetProgramBuildInfo.html
        /// </summary>
        /// <param name="program">Specifies the program object being queried.</param>
        /// <param name="device">Specifies the device for which build information is being queried. 
        /// device must be a valid device associated with program.</param>
        /// <param name="param_name">
        /// Specifies the information to query. 
        /// The list of supported param_name.</param>
        /// <param name="param_value_size">
        /// Specifies the size in bytes of memory pointed to by param_value. 
        /// This size must be ≥ size of return type as described in the table above.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. 
        /// If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        /// <returns>
        /// Returns Success if the function is executed successfully
        /// </returns>
        [DllImport("opencl.dll", EntryPoint = "clGetProgramBuildInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetProgramBuildInfo(CLProgramPtr program,
                      CLDevicePtr device,
                      CLProgramBuildInfo param_name,
                      int param_value_size,
                      byte[] param_value,
                      [Out] out int param_value_size_ret);

        /// <summary>
        /// Returns build information for each device in the program object.
        /// 
        /// Notes
        /// A program binary (compiled binary, library binary or executable binary) built for a 
        /// parent device can be used by all its sub-devices.
        /// If a program binary has not been built for a sub-device, 
        /// the program binary associated with the parent device will be used.
        /// 
        /// A program binary for a device specified with CreateProgramWithBinary or queried using 
        /// GetProgramInfo can be used as the binary for the associated root device, 
        /// and all sub-devices created from the root-level device or sub-devices thereof.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetProgramBuildInfo.html
        /// </summary>
        /// <param name="program">Specifies the program object being queried.</param>
        /// <param name="device">Specifies the device for which build information is being queried. 
        /// device must be a valid device associated with program.</param>
        /// <param name="param_name">
        /// Specifies the information to query. 
        /// The list of supported param_name.</param>
        /// <param name="param_value_size">
        /// Specifies the size in bytes of memory pointed to by param_value. 
        /// This size must be ≥ size of return type as described in the table above.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. 
        /// If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        /// <returns>
        /// Returns Success if the function is executed successfully
        /// </returns>
        [DllImport("opencl.dll", EntryPoint = "clGetProgramBuildInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetProgramBuildInfo(CLProgramPtr program,
                      CLDevicePtr device,
                      CLProgramBuildInfo param_name,
                      int param_value_size,
                      IntPtr param_value,
                      [Out] out int param_value_size_ret);
        /// <summary>
        /// Returns build information for each device in the program object.
        /// 
        /// Notes
        /// A program binary (compiled binary, library binary or executable binary) built for a 
        /// parent device can be used by all its sub-devices.
        /// If a program binary has not been built for a sub-device, 
        /// the program binary associated with the parent device will be used.
        /// 
        /// A program binary for a device specified with CreateProgramWithBinary or queried using 
        /// GetProgramInfo can be used as the binary for the associated root device, 
        /// and all sub-devices created from the root-level device or sub-devices thereof.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetProgramBuildInfo.html
        /// </summary>
        /// <param name="program">Specifies the program object being queried.</param>
        /// <param name="device">Specifies the device for which build information is being queried. 
        /// device must be a valid device associated with program.</param>
        /// <param name="param_name">
        /// Specifies the information to query. 
        /// The list of supported param_name.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. 
        /// If param_value is NULL, it is ignored.</param>
        /// <returns>Returns Success if the function is executed successfully</returns>
        public static CLResult GetProgramBuildInfo(CLProgramPtr program,
               CLDevicePtr device,
               CLProgramBuildInfo param_name,
               out byte[] param_value)
        {
            param_value = null;
            int num_entries = 0;
            CLResult result = GetProgramBuildInfo(program, device, param_name, num_entries, param_value, out num_entries);
            if (result != CLResult.Success)
            {
                param_value = new byte[0];
                return result;
            }
            param_value = new byte[num_entries];
            result = GetProgramBuildInfo(program, device, param_name, num_entries, param_value, out _);
            if (result != CLResult.Success)
            {
                param_value = new byte[0];
                return result;
            }

            //param_value = new byte[num_entries]; // new string((char[])platformName);

            return result;
        }

        public static CLResult GetProgramBuildInfo(CLProgramPtr program,
               CLDevicePtr device,
               out string log)
        {
            log = "";

            CLProgramBuildInfo param_name = CLProgramBuildInfo.Log;
            byte[] param_value = null;
            int num_entries = 0;
            CLResult result = GetProgramBuildInfo(program, device, param_name, num_entries, param_value, out num_entries);
            if (result != CLResult.Success)
            {
                return result;
            }
            param_value = new byte[num_entries];
            result = GetProgramBuildInfo(program, device, param_name, num_entries, param_value, out _);
            if (result != CLResult.Success)
            {
                return result;
            }

            foreach (byte c in param_value)
            {
                if (c != 0)
                    log += (char)c;
            }

            return result;
        }
        /* Kernel Object APIs */

        /// <summary>
        /// Creates a kernel object.
        /// 
        /// Notes 
        /// A kernel is a function declared in a program.
        /// A kernel is identified by the __kernel qualifier applied to any function in a program. 
        /// A kernel object encapsulates the specific __kernel function declared in a program and 
        /// the argument values to be used when executing this __kernel function.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateKernel.html
        /// </summary>
        /// <param name="program">A program object with a successfully built executable.</param>
        /// <param name="kernel_name">A function name in the program declared with the __kernel qualifier.</param>
        /// <param name="errcode_ret">Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.</param>
        /// <returns>returns a valid non-zero kernel object and errcode_ret is set to Success if the kernel object is created successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateKernel", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLKernelPtr CreateKernel(CLProgramPtr program,
               string kernel_name,
               [Out] out CLResult  errcode_ret) ;

        /// <summary>
        /// Creates kernel objects for all kernel functions in a program object.
        /// 
        /// Notes
        /// Creates kernel objects for all kernel functions in program.
        /// Kernel objects are not created for any __kernel functions in program that do not have the same 
        /// function definition across all devices for which a program executable has been successfully built.
        /// 
        /// Kernel objects can only be created once you have a program object with a valid program source or binary 
        /// loaded into the program object and the program executable has been successfully built for one or more 
        /// devices associated with program.
        /// No changes to the program executable are allowed while there are kernel objects associated with a program object. 
        /// This means that calls to BuildProgram and CompileProgram return InvalidOperation if there are kernel objects 
        /// attached to a program object. 
        /// The OpenCL context associated with program will be the context associated with kernel.
        /// The list of devices associated with program are the devices associated with kernel.
        /// Devices associated with a program object for which a valid program executable has been built can be used to execute 
        /// kernels declared in the program object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateKernelsInProgram.html
        /// </summary>
        /// <param name="program">A program object with a successfully built executable.</param>
        /// <param name="num_kernels">The size of memory pointed to by kernels specified as the number of CLKernelPtr entries.</param>
        /// <param name="kernels">
        /// The buffer where the kernel objects for kernels in program will be returned. 
        /// If kernels is NULL, it is ignored. 
        /// If kernels is not NULL, num_kernels must be greater than or equal to the number of kernels in program.
        /// </param>
        /// <param name="num_kernels_ret">The number of kernels in program. If num_kernels_ret is NULL, it is ignored.</param>
        /// <returns>Returns Success if the kernel objects are successfully allocated. </returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateKernelsInProgram", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult CreateKernelsInProgram(CLProgramPtr program,
                         int num_kernels,
                         [In, Out] CLKernelPtr[] kernels,
                         [Out] out int num_kernels_ret) ;


        /// <summary>
        /// Increments the kernel object reference count.
        /// 
        /// Notes
        ///CreateKernel or CreateKernelsInProgram do an implicit retain.
        ///
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Retain.html
        /// </summary>
        /// <param name="kernel">The kernel to retain</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clRetainKernel", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult Retain(CLKernelPtr kernel) ;

        /// <summary>
        /// Decrements the kernel reference count.
        /// 
        /// Notes
        /// The kernel object is deleted once the number of instances that are retained to kernel become zero and the 
        /// kernel object is no longer needed by any enqueued commands that use kernel.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Release.html
        /// </summary>
        /// <param name="kernel">The Kernel to release</param>
        /// <returns>Success if the kernel objects are successfully alloctaed.</returns>
        [DllImport("opencl.dll", EntryPoint = "clReleaseKernel", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult Release(CLKernelPtr kernel);

        /// <summary>
        /// Used to set the argument value for a specific argument of a kernel.
        /// 
        /// Notes
        /// A kernel object does not update the reference count for objects such as memory, 
        /// sampler objects specified as argument values by SetKernelArg.Users may not rely on a 
        /// kernel object to retain objects specified as argument values to the kernel.
        /// 
        /// Implementations shall not allow CLKernelPtr objects to hold reference counts to CLKernelPtr arguments, 
        /// because no mechanism is provided for the user to tell the kernel to release that ownership right.
        /// If the kernel holds ownership rights on kernel args, that would make it impossible for the user to tell with 
        /// certainty when he may safely release user allocated resources associated with OpenCL objects such as the 
        /// CLMemoryPtr backing store used with UseHostPointer.
        /// 
        /// An OpenCL API call is considered to be thread-safe if the public state as managed by OpenCL remains consistent when 
        /// called simultaneously by multiple host threads.
        /// OpenCL API calls that are thread-safe allow an application to call these functions in multiple host threads without 
        /// having to implement mutual exclusion across these host threads i.e.they are also re-entrant-safe.
        /// 
        /// All OpenCL API calls are thread-safe except SetKernelArg and clSetKernelArgSVMPointer.SetKernelArg and 
        /// clSetKernelArgSVMPointer are safe to call from any host thread, and safe to call re-entrantly so long as 
        /// concurrent calls operate on different CLKernelPtr objects.
        /// However, the behavior of the CLKernelPtr object is undefined if SetKernelArg or clSetKernelArgSVMPointer are called 
        /// from multiple host threads on the same CLKernelPtr object at the same time.
        /// Please note that there are additional limitations as to which OpenCL APIs may be called from OpenCL callback functions 
        /// -- please see section 5.11. 
        /// (Please refer to the OpenCL glossary for the OpenCL definition of thread-safe.
        /// This definition may be different from usage of the term in other contexts.)
        /// 
        /// There is an inherent race condition in the design of OpenCL that occurs between setting a kernel argument and 
        /// using the kernel with EnqueueNDRangeKernel.
        /// Another host thread might change the kernel arguments between when a host thread sets the kernel arguments and 
        /// then enqueues the kernel, causing the wrong kernel arguments to be enqueued.
        /// Rather than attempt to share CLKernelPtr objects among multiple host threads, applications are strongly encouraged to 
        /// make additional CLKernelPtr objects for kernel functions for each host thread.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/SetKernelArg.html
        /// </summary>
        /// <param name="kernel">A valid kernel object.</param>
        /// <param name="arg_index">The argument index. Arguments to the kernel are referred by indices that go from 
        /// 0 for the leftmost argument to n - 1, where n is the total number of arguments declared by a kernel.</param>
        /// <param name="arg_size">
        /// Specifies the size of the argument value. If the argument is a memory object, the size is the size of the memory object. 
        /// For arguments declared with the local qualifier, the size specified will be the size in bytes of the buffer that must be
        /// allocated for the local argument.
        /// If the argument is of type sampler_t, the arg_size value must be equal to sizeof(CLSamplerPtr). 
        /// If the argument is of type queue_t, the arg_size value must be equal to sizeof(CLCommandQueuePtr). 
        /// For all other arguments, the size will be the size of argument type.
        /// </param>
        /// <param name="arg_value">
        /// A pointer to data that should be used as the argument value for argument specified by arg_index. 
        /// The argument data pointed to by arg_value is copied and the arg_value pointer can therefore be 
        /// reused by the application after SetKernelArg returns. 
        /// The argument value specified is the value used by all API calls that enqueue kernel (EnqueueNDRangeKernel) 
        /// until the argument value is changed by a call to SetKernelArg for kernel.
        /// 
        /// If the argument is a memory object (buffer, pipe, image or image array), the arg_value entry will be a pointer 
        /// to the appropriate buffer, pipe, image or image array object. 
        /// The memory object must be created with the context associated with the kernel object. 
        /// If the argument is a buffer object, the arg_value pointer can be NULL or point to a NULL value in which case a 
        /// NULL value will be used as the value for the argument declared as a pointer to global or constant memory in the kernel.
        /// If the argument is declared with the local qualifier, the arg_value entry must be NULL. 
        /// If the argument is of type sampler_t, the arg_value entry must be a pointer to the sampler object. 
        /// If the argument is of type queue_t, the arg_value entry must be a pointer to the device queue object.
        /// 
        /// 
        /// If the argument is declared to be a pointer of a built-in scalar or vector type, or a user defined structure type in 
        /// the global or constant address space, the memory object specified as argument value must be a buffer object (or NULL). 
        /// If the argument is declared with the constant qualifier, the size in bytes of the memory object cannot exceed 
        /// MaxConstantBufferSize and the number of arguments declared as pointers to constant memory cannot exceed 
        /// MaxConstantArguments.
        /// 
        /// The memory object specified as argument value must be a pipe object if the argument is declared with the pipe qualifier.
        /// 
        /// The memory object specified as argument value must be a 2D image object if the argument is declared to be of type image2d_t. 
        /// The memory object specified as argument value must be a 2D image object with image channel order = Depth 
        /// if the argument is declared to be of type image2d_depth_t. 
        /// The memory object specified as argument value must be a 3D image object if argument is declared to be of type image3d_t. 
        /// The memory object specified as argument value must be a 1D image object if the argument is declared to be of type image1d_t. 
        /// The memory object specified as argument value must be a 1D image buffer object if the argument is declared to be of type image1d_buffer_t.
        /// The memory object specified as argument value must be a 1D image array object if argument is declared to be of type image1d_array_t. 
        /// The memory object specified as argument value must be a 2D image array object if argument is declared to be of type image2d_array_t. 
        /// The memory object specified as argument value must be a 2D image array object with 
        /// image channel order = Depth if argument is declared to be of type image2d_array_depth_t.
        /// 
        /// 
        /// For all other kernel arguments, the arg_value entry must be a pointer to the actual data to be used as argument value.
        /// 
        /// 
        /// If the cl_khr_gl_msaa_sharing extension is supported, if the argument is a multi-sample 2D image, 
        /// the arg_value entry must be a pointer to a multisample image object. 
        /// If the argument is a multi-sample 2D depth image, the arg_value entry must be a pointer to a multisample depth image object. 
        /// If the argument is a multi-sample 2D image array, the arg_value entry must be a pointer to a multi-sample image array object. 
        /// If the argument is a multi-sample 2D depth image array, 
        /// the arg_value entry must be a pointer to a multi-sample depth image array object.
        /// </param>
        /// <returns>returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clSetKernelArg", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult SetKernelArg([In] CLKernelPtr kernel,
               [In] int arg_index,
               [In] long arg_size,
               [In] ref CLMemoryPtr arg_value) ;


        /// <summary>
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel">Specifies the kernel object being queried.</param>
        /// <param name="param_name">Specifies the information to query.</param>
        /// <param name="param_value_size">
        /// Used to specify the size in bytes of memory pointed to by param_value. 
        /// This size must be ≥ size of return type</param>
        /// <param name="param_value">
        /// A pointer to memory where the appropriate result being queried is returned. 
        /// If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret">
        /// The actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetKernelInfo", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult GetKernelInfo(CLKernelPtr kernel,
                CLKernelInfo param_name,
                int param_value_size,
                IntPtr param_value,
                [Out] out int param_value_size_ret) ;


        /// <summary>
        /// Returns information about the arguments of a kernel.
        /// 
        /// Notes
        /// Kernel argument information is only available if the program object associated with kernel is created with 
        /// CreateProgramWithSource and the program executable is built with the -cl-kernel-arg-info option specified 
        /// in options argument to BuildProgram or CompileProgram.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetKernelArgInfo.html
        /// </summary>
        /// <param name="kernel">Specifies the kernel object being queried.</param>
        /// <param name="arg_indx">The argument index. 
        /// Arguments to the kernel are referred by indices that go from 0 for the leftmost argument to n - 1, 
        /// where n is the total number of arguments declared by a kernel.</param>
        /// <param name="param_name">Specifies the argument information to query.</param>
        /// <param name="param_value_size">
        /// Used to specify the size in bytes of memory pointed to by param_value. 
        /// This size must be > size of return type</param>
        /// <param name="param_value">
        /// A pointer to memory where the appropriate result being queried is returned. 
        /// If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetKernelArgInfo", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult GetKernelArgInfo(CLKernelPtr kernel,
                   int arg_indx,
                   CLKernelArgumentInfo param_name,
                   int param_value_size,
                   IntPtr param_value,
                   [Out] out int param_value_size_ret) ;


        /// <summary>
        /// Returns information about the kernel object that may be specific to a device.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetKernelWorkGroupInfo.html
        /// </summary>
        /// <param name="kernel">Specifies the kernel object being queried.</param>
        /// <param name="device">
        /// Identifies a specific device in the list of devices associated with kernel. 
        /// The list of devices is the list of devices in the OpenCL context that is associated with kernel. 
        /// If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name">Specifies the information to query.</param>
        /// <param name="param_value_size">
        /// Used to specify the size in bytes of memory pointed to by param_value. 
        /// This size must be ≥ size of return type<</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. 
        /// If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// /param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetKernelWorkGroupInfo", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult GetKernelWorkGroupInfo(CLKernelPtr kernel,
                         CLDevicePtr device,
                         CLKernelWorkGroupInfo param_name,
                         int param_value_size,
                         IntPtr param_value,
                         [Out] out int param_value_size_ret) ;

        /// <summary>
        /// Returns information about the kernel object that may be specific to a device.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetKernelWorkGroupInfo.html
        /// </summary>
        /// <param name="kernel">Specifies the kernel object being queried.</param>
        /// <param name="device">
        /// Identifies a specific device in the list of devices associated with kernel. 
        /// The list of devices is the list of devices in the OpenCL context that is associated with kernel. 
        /// If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name">Specifies the information to query.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. 
        /// If param_value is NULL, it is ignored.</param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        public static CLResult GetKernelWorkGroupInfo(CLKernelPtr kernel,
                         CLDevicePtr device,
                         CLKernelWorkGroupInfo param_name,
                         out byte[] param_value)
        {

            param_value = null;
            int num_entries = 0;
            CLResult result = GetKernelWorkGroupInfo(kernel, device, param_name, num_entries, IntPtr.Zero, out num_entries);
            if (result != CLResult.Success)
            {
                param_value = new byte[0];
                return result;
            }

            param_value = new byte[num_entries];
            GCHandle GlobalDataPointer = GCHandle.Alloc(param_value, GCHandleType.Pinned);
            result = GetKernelWorkGroupInfo(kernel, device, param_name, num_entries, GlobalDataPointer.AddrOfPinnedObject(), out _);
            if (result != CLResult.Success)
            {
                param_value = new byte[0];
                GlobalDataPointer.Free();
                return result;
            }

            GlobalDataPointer.Free();

            return result;
        }

        /* Event Object APIs */

        /// <summary>
        /// Waits on the host thread for commands identified by event objects to complete.
        /// 
        /// Notes
        /// Waits on the host thread for commands identified by event objects in event_list to complete. 
        /// A command is considered complete if its execution status is CL_COMPLETE or a negative value. 
        /// The events specified in event_list act as synchronization points.
        /// 
        /// If the cl_khr_gl_event extension is enabled, event objects can also be used to reflect the status of an OpenGL sync object. 
        /// The sync object in turn refers to a fence command executing in an OpenGL command stream.This provides another method of 
        /// coordinating sharing of buffers and images between OpenGL and OpenCL.
        /// 
        /// If the cl_khr_egl_event extension is enabled, Event objects can also be used to reflect the status of an EGL fence sync object.
        /// The sync object in turn refers to a fence command executing in an EGL client API command stream. 
        /// This provides another method of coordinating sharing of EGL / EGL client API objects with OpenCL. 
        /// Completion of EGL / EGL client API commands may be determined by placing an EGL fence command after commands using 
        /// eglCreateSyncKHR, creating an event from the resulting EGL sync object using clCreateEventFromEGLsyncKHR 
        /// and then specifying it in the event_wait_list of a clEnqueueAcquire*** command.This method may be considerably 
        /// more efficient than calling operations like glFinish, and is referred to as explicit synchronization.
        /// The application is responsible for ensuring the command stream associated with the EGL fence is flushed to 
        /// ensure the CL queue is submitted to the device. Explicit synchronization is most useful when an EGL client 
        /// API context bound to another thread is accessing the memory objects."
        /// 
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/WaitForEvents.html
        /// </summary>
        /// <param name="num_events">The number of events in event_list</param>
        /// <param name="event_list">The events specified in event_list act as synchronization points.</param>
        /// <returns>Returns Success if the execution status of all events in event_list is CL_COMPLETE.</returns>
        [DllImport("opencl.dll", EntryPoint = "clWaitForEvents", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult WaitForEvents(int num_events, CLEventPtr[] event_list) ;

        /// <summary>
        /// Increments the event reference count.
        /// 
        /// Notes
        /// The OpenCL commands that return an event perform an implicit retain.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Retain.html
        /// </summary>
        /// <param name="evt">Event object being retained.</param>
        /// <returns>Success if the function executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clRetainEvent", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult Retain(CLEventPtr evt) ;

        /// <summary>
        /// Decrements the event reference count.
        /// 
        /// Notes
        /// Decrements the event reference count.
        /// 
        /// The event object is deleted once the reference count becomes zero, the specific command identified by this event 
        /// has completed (or terminated) and there are no commands in the command-queues of a context that require a 
        /// wait for this event to complete.
        /// 
        /// Developers should be careful when releasing their last reference count on events created by clCreateUserEvent 
        /// that have not yet been set to status of CL_COMPLETE or an error.
        /// If the user event was used in the event_wait_list argument passed to a clEnqueue*** API or another application
        /// host thread is waiting for it in WaitForEvents, those commands and host threads will continue to wait for the 
        /// event status to reach CL_COMPLETE or error, even after the user has released the object. 
        /// Since in this scenario the developer has released his last reference count to the user event,
        /// it would be in principle no longer valid for him to change the status of the event to unblock all the 
        /// other machinery.
        /// As a result the waiting tasks will wait forever, and associated events, CLMemoryPtr objects, command queues 
        /// and contexts are likely to leak. 
        /// In-order command queues caught up in this deadlock may cease to do any work.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Release.html
        /// </summary>
        /// <param name="evt">Event object being released.</param>
        /// <returns>Success if the function executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clReleaseEvent", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult Release(CLEventPtr evt) ;


        /* Profiling APIs */
        /// <summary>
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetEventProfilingInfo.html
        /// </summary>
        /// <param name="evt">Specifies the event object.</param>
        /// <param name="param_name">pecifies the profiling data to query. The list of supported param_name types and the 
        /// information returned in param_value by GetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size">Specifies the size in bytes of memory pointed to by param_value. 
        /// This size must be ≥ size of return type as described in the table below.</param>
        /// <param name="param_value">
        /// A pointer to memory where the appropriate result being queried is returned. if param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.</param>
        /// <returns>Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetEventProfilingInfo", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult GetEventProfilingInfo(CLEventPtr            evt,
                        CLProfilingInfo param_name,
                        int param_value_size,
                        [Out] out ulong param_value,
                        [Out] out int param_value_size_ret) ;

        /* Flush and Finish APIs */
        /// <summary>
        /// Issues all previously queued OpenCL commands in a command-queue to the device associated with the command-queue.
        /// 
        /// Notes
        /// Issues all previously queued OpenCL commands in command_queue to the device associated with command_queue.
        /// Flush only guarantees that all queued commands to command_queue will eventually be submitted to the 
        /// appropriate device There is no guarantee that they will be complete after Flush returns.
        /// Any blocking commands queued in a command-queue and Release perform an implicit flush of the 
        /// command-queue.These blocking commands are EnqueueReadBuffer, clEnqueueReadBufferRect, EnqueueReadImage, 
        /// with blocking_read set to CL_TRUE; EnqueueWriteBuffer, clEnqueueWriteBufferRect, EnqueueWriteImage with 
        /// blocking_write set to CL_TRUE; EnqueueMapBuffer, EnqueueMapImage with blocking_map set to CL_TRUE; 
        /// clEnqueueSVMMemcpy with blocking_copy set to CL_TRUE; clEnqueueSVMMap with blocking_map set to CL_TRUE 
        /// or WaitForEvents.
        /// To use event objects that refer to commands enqueued in a command-queue as event objects to wait on by 
        /// commands enqueued in a different command-queue, the application must call a Flush or any blocking commands 
        /// that perform an implicit flush of the command-queue where the commands that refer to these event objects are enqueued.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Flush.html
        /// </summary>
        /// <param name="command_queue">The command queue to flush</param>
        /// <returns>Returns Success if the function call was executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clFlush", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult Flush(CLCommandQueuePtr command_queue) ;

        /// <summary>
        /// Blocks until all previously queued OpenCL commands in a command-queue are issued to the associated device and have completed.
        /// 
        /// Notes:
        /// Finish does not return until all previously queued commands in command_queue have been processed and completed. 
        /// Finish is also a synchronization point.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/Finish.html
        /// </summary>
        /// <param name="command_queue">The command queue to finish</param>
        /// <returns>Returns Success if the function call was executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clFinish", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult Finish(CLCommandQueuePtr command_queue);

        /* Enqueued Commands APIs */
        /// <summary>
        /// Enqueue commands to read from a buffer object to host memory. (Get data from GPU)
        /// 
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueReadBuffer.html
        /// </summary>
        /// <param name="command_queue">Is a valid host command-queue in which the read command will be queued. 
        /// command_queue and buffer must be created with the same OpenCL context.</param>
        /// <param name="buffer">Refers to a valid buffer object.</param>
        /// <param name="blocking_read">
        /// Indicates if the read operations are blocking or non-blocking.
        /// 
        /// If blocking_read is CL_TRUE i.e.the read command is blocking, EnqueueReadBuffer does not return until the buffer 
        /// data has been read and copied into memory pointed to by ptr.
        /// 
        /// If blocking_read is CL_FALSE i.e.the read command is non-blocking, EnqueueReadBuffer queues a non-blocking read 
        /// command and returns.The contents of the buffer that ptr points to cannot be used until the read command has completed. 
        /// The event argument returns an event object which can be used to query the execution status of the read command.
        /// When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset">The offset in bytes in the buffer object to read from.</param>
        /// <param name="size">The size in bytes of data being read.</param>
        /// <param name="ptr">The pointer to buffer in host memory where data is to be read into.</param>
        /// <param name="num_events_in_wait_list">
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and 
        /// num_events_in_wait_list must be greater than 0. 
        /// </param>
        /// <param name="event_wait_list">
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed.
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and 
        /// num_events_in_wait_list must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this 
        /// particular command to complete. event can be NULL in which case it will not be possible for the application to query the status 
        /// of this command or queue a wait for this command to complete. If the event_wait_list and the event arguments are not NULL, 
        /// the event argument should not refer to an element of the event_wait_list array.
        /// </param>
        /// <returns>returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueReadBuffer", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueReadBuffer(CLCommandQueuePtr command_queue,
                    CLMemoryPtr buffer,
                    bool blocking_read,
                    long offset,
                    long size,
                    IntPtr ptr,
                    int num_events_in_wait_list,
                    CLEventPtr[] event_wait_list,
                    [Out] out CLEventPtr evt);

        /// <summary>
        /// Enqueue commands to write to a buffer object from host memory.
        /// 
        /// Notes
        /// Calling EnqueueWriteBuffer to update the latest bits in a region of the buffer object with the ptr argument 
        /// value set to host_ptr + offset, where host_ptr is a pointer to the memory region specified when 
        /// the buffer object being written is created with UseHostPointer, must meet the following requirements 
        /// in order to avoid undefined behavior:
        /// 
        /// The host memory region given by(host_ptr + offset, cb) contains the latest bits when the enqueued write 
        /// command begins execution.
        /// The buffer object or memory objects created from this buffer object are not mapped.
        /// The buffer object or memory objects created from this buffer object are not used by any command-queue until 
        /// the read command has finished execution.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueWriteBuffer.html
        /// </summary>
        /// <param name="command_queue">Is a valid host command-queue in which the write command will be queued. 
        /// command_queue and buffer must be created with the same OpenCL context.</param>
        /// <param name="buffer">Refers to a valid buffer object.</param>
        /// <param name="blocking_write">
        /// Indicates if the write operations are blocking or nonblocking.
        /// 
        /// If blocking_write is CL_TRUE, the OpenCL implementation copies the data referred to by ptr and enqueues the 
        /// write operation in the command-queue.The memory pointed to by ptr can be reused by the application after 
        /// the EnqueueWriteBuffer call returns.
        /// 
        /// If blocking_write is CL_FALSE, the OpenCL implementation will use ptr to perform a nonblocking write.
        /// As the write is non-blocking the implementation can return immediately.
        /// The memory pointed to by ptr cannot be reused by the application after the call returns.
        /// The event argument returns an event object which can be used to query the execution status of the write command.
        /// When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset">The offset in bytes in the buffer object to write to.</param>
        /// <param name="size">The size in bytes of data being written.</param>
        /// <param name="ptr">The pointer to buffer in host memory where data is to be written from.</param>
        /// <param name="num_events_in_wait_list">
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete.
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list
        /// must be greater than 0. 
        /// </param>
        /// <param name="event_wait_list">
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete.
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list
        /// must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this 
        /// particular command to complete. 
        /// event can be NULL in which case it will not be possible for the application to query the status of this command 
        /// or queue a wait for this command to complete. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an element of the 
        /// event_wait_list array
        /// </param>
        /// <returns>EnqueueWriteBuffer returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueWriteBuffer", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueWriteBuffer(CLCommandQueuePtr command_queue,
                     CLMemoryPtr buffer,
                     bool blocking_write,
                     long offset,
                     long size,
                     IntPtr ptr,
                     int num_events_in_wait_list,
                     CLEventPtr[] event_wait_list,
                     [Out] out CLEventPtr evt) ;


        /// <summary>
        /// Enqueues a command to copy from one buffer object to another.
        /// 
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueCopyBuffer.html
        /// </summary>
        /// <param name="command_queue">The host command-queue in which the copy command will be queued. The OpenCL context associated with command_queue, src_buffer, and dst_buffer must be the same.</param>
        /// <param name="src_buffer">The source buffer to copy from</param>
        /// <param name="dst_buffer">The destination buffer to copy to</param>
        /// <param name="src_offset">The offset where to begin copying data from src_buffer.</param>
        /// <param name="dst_offset">The offset where to begin copying data into dst_buffer.</param>
        /// <param name="size">Refers to the size in bytes to copy.</param>
        /// <param name="num_events_in_wait_list">
        /// Specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list 
        /// must be greater than 0. 
        /// </param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list 
        /// must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this 
        /// particular command to complete. 
        /// event can be NULL in which case it will not be possible for the application to query the status of this command or queue 
        /// a wait for this command to complete. clEnqueueBarrierWithWaitList can be used instead. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an element of the 
        /// event_wait_list array.
        /// </param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueCopyBuffer", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueCopyBuffer(CLCommandQueuePtr command_queue,
                    CLMemoryPtr src_buffer,
                    CLMemoryPtr dst_buffer,
                    int src_offset,
                    int dst_offset,
                    int size,
                    int num_events_in_wait_list,
                    CLEventPtr[] event_wait_list,
                    [Out] out CLEventPtr evt) ;


        /// <summary>
        /// Enqueue commands to read from an image or image array object to host memory.
        /// 
        /// Notes
        /// Calling EnqueueReadImage to read a region of the image with the ptr argument value set to 
        /// host_ptr + (origin[2] * image slice pitch + origin[1] * image row pitch + origin[0] * bytes per pixel), 
        /// where host_ptr is a pointer to the memory region specified when the image being read is created with 
        /// UseHostPointer, must meet the following requirements in order to avoid undefined behavior:
        /// 
        /// All commands that use this image object have finished execution before the read command begins execution.
        /// The row_pitch and slice_pitch argument values in EnqueueReadImage must be set to the image row pitch and slice pitch.
        /// The image object is not mapped.
        /// The image object is not used by any command-queue until the read command has finished execution.
        /// If the mipmap extensions are enabled with cl_khr_mipmap_image, calls to EnqueueReadImage, EnqueueWriteImage 
        /// and EnqueueMapImage can be used to read from or write to a specific mip-level of a mip-mapped image. 
        /// If image argument is a 1D image, origin[1] specifies the mip-level to use.
        /// If image argument is a 1D image array, origin[2] specifies the mip-level to use.
        /// If image argument is a 2D image, origin[3] specifies the mip-level to use.
        /// If image argument is a 2D image array or a 3D image, origin[3] specifies the mip-level to use.

        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueReadImage.html
        /// </summary>
        /// <param name="command_queue"></param>
        /// <param name="image"></param>
        /// <param name="blocking_read"></param>
        /// <param name="origin"></param>
        /// <param name="region"></param>
        /// <param name="row_pitch"></param>
        /// <param name="slice_pitch"></param>
        /// <param name="ptr"></param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list"></param>
        /// <param name="evt"></param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueReadImage", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueReadImage(CLCommandQueuePtr command_queue,
                   CLMemoryPtr image,
                   bool blocking_read,
                   Vector3i origin,
                   Vector3i region,
                   uint row_pitch,
                   uint slice_pitch,
                   IntPtr ptr,
                   int num_events_in_wait_list,
                   CLEventPtr[] event_wait_list,
                   [Out] out CLEventPtr evt);

        /// <summary>
        /// Enqueues a command to write to an image or image array object from host memory.
        /// 
        /// Notes
        /// Calling EnqueueWriteImage to update the latest bits in a region of the image with the ptr argument value set to 
        /// host_ptr + (origin[2] * image slice pitch + origin[1] * image row pitch + origin[0] * bytes per pixel),
        /// where host_ptr is a pointer to the memory region specified when the image being written is created with 
        /// UseHostPointer, must meet the following requirements in order to avoid undefined behavior:
        /// 
        /// The host memory region being written contains the latest bits when the enqueued write command begins execution.
        /// The input_row_pitch and input_slice_pitch argument values in EnqueueWriteImage must be set to the image row pitch 
        /// and slice pitch.
        /// The image object is not mapped.
        /// The image object is not used by any command-queue until the write command has finished execution.
        /// If the mipmap extensions are enabled with cl_khr_mipmap_image, calls to 
        /// EnqueueReadImage, EnqueueWriteImage and EnqueueMapImage can be used to read from or write to a 
        /// specific mip-level of a mip-mapped image. 
        /// If image argument is a 1D image, origin[1] specifies the mip-level to use.
        /// If image argument is a 1D image array, origin[2] specifies the mip-level to use.
        /// If image argument is a 2D image, origin[3] specifies the mip-level to use.
        /// If image argument is a 2D image array or a 3D image, origin[3] specifies the mip-level to use.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueWriteImage.html
        /// </summary>
        /// <param name="command_queue">Refers to the host command-queue in which the write command will be queued. 
        /// command_queue and image must be created with the same OpenCL context.</param>
        /// <param name="image"Refers to a valid image or image array object.></param>
        /// <param name="blocking_write">
        /// Indicates if the write operation is blocking or non-blocking.
        /// 
        /// If blocking_write is CL_TRUE the OpenCL implementation copies the data referred to by ptr and enqueues the write 
        /// command in the command-queue.The memory pointed to by ptr can be reused by the application after the 
        /// EnqueueWriteImage call returns.
        /// 
        /// If blocking_write is CL_FALSE the OpenCL implementation will use ptr to perform a nonblocking write.
        /// As the write is non-blocking the implementation can return immediately.
        /// The memory pointed to by ptr cannot be reused by the application after the call returns. 
        /// The event argument returns an event object which can be used to query the execution status of the write command.
        /// When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        ///    </param>
        /// <param name="origin">
        /// Defines the (x, y, z) offset in pixels in the 1D, 2D, or 3D image, the (x, y) offset and the image index in the image array 
        /// or the (x) offset and the image index in the 1D image array. 
        /// If image is a 2D image object, origin[2] must be 0. 
        /// If image is a 1D image or 1D image buffer object, origin[1] and origin[2] must be 0. 
        /// If image is a 1D image array object, origin[2] must be 0.
        /// If image is a 1D image array object, origin[1] describes the image index in the 1D image array.
        /// If image is a 2D image array object, origin[2] describes the image index in the 2D image array.
        /// </param>
        /// <param name="region">
        /// Defines the (width, height, depth) in pixels of the 1D, 2D or 3D rectangle, the (width, height) in pixels of the 2D rectangle 
        /// and the number of images of a 2D image array or the (width) in pixels of the 1D rectangle and the number of images of a 
        /// 1D image array. If image is a 2D image object, region[2] must be 1. 
        /// If image is a 1D image or 1D image buffer object, region[1] and region[2] must be 1. 
        /// If image is a 1D image array object, region[2] must be 1. The values in region cannot be 0.
        /// </param>
        /// <param name="input_row_pitch">
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width.
        /// If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in 
        /// bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch">
        /// Size in bytes of the 2D slice of the 3D region of a 3D image or each image of a 1D or 2D image array being written. 
        /// This must be 0 if image is a 1D or 2D image. 
        /// Otherwise this value must be greater than or equal to row_pitch * height. 
        /// If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr">The pointer to a buffer in host memory where image data is to be read from.</param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before this particular command can be executed.
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete.
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and
        /// num_events_in_wait_list must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for 
        /// this particular command to complete. 
        /// event can be NULL in which case it will not be possible for the application to query the status of this command or queue 
        /// a wait for this command to complete. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an element of the
        /// event_wait_list array.
        /// </param>
        /// <returns>Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueWriteImage", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueWriteImage(CLCommandQueuePtr command_queue,
                    CLMemoryPtr image,
                    bool blocking_write,
                    Vector3i origin,
                    Vector3i region,
                    uint input_row_pitch,
                    uint input_slice_pitch,
                    IntPtr ptr,
                    int num_events_in_wait_list,
                    CLEventPtr[] event_wait_list,
                    [Out] out CLEventPtr evt) ;

        /// <summary>
        /// Enqueues a command to copy image objects.
        /// 
        /// Notes:
        /// It is currently a requirement that the src_image and dst_image image memory objects for EnqueueCopyImage 
        /// must have the exact same image format 
        /// (i.e.the CLImageFormat descriptor specified when src_image and dst_image are created must match).
        /// 
        /// If the mipmap extensions are enabled with cl_khr_mipmap_image, calls to EnqueueCopyImage, EnqueueCopyImageToBuffer,
        /// and EnqueueCopyBufferToImage can also be used to copy from and to a specific mip-level of a mip-mapped image.
        /// If src_image argument is a 1D image, src_origin[1] specifies the mip-level to use.
        /// If src_image argument is a 1D image array, src_origin[2] specifies the mip-level to use.
        /// If src_image argument is a 2D image, src_origin[3] specifies the mip-level to use.
        /// If src_image argument is a 2D image array or a 3D image, src_origin[3] specifies the mip-level to use.
        /// If dst_image argument is a 1D image, dst_origin[1] specifies the mip-level to use.
        /// If dst_image argument is a 1D image array, dst_origin[2] specifies the mip-level to use.
        /// If dst_image argument is a 2D image, dst_origin[3] specifies the mip-level to use.
        /// If dst_image argument is a 2D image array or a 3D image, dst_origin[3] specifies the mip-level to use.
        /// 
        /// If the mip level specified is not a valid value, these functions return the error InvalidMipLevel.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueCopyImage.html
        /// </summary>
        /// <param name="command_queue">
        /// Refers to the host command-queue in which the copy command will be queued. 
        /// The OpenCL context associated with command_queue, src_image and dst_image must be the same.
        /// </param>
        /// <param name="src_image">
        /// Can be 1D, 2D, 3D image or a 1D, 2D image array objects. 
        /// It is possible to copy subregions between any combinations of source and destination types, 
        /// provided that the dimensions of the subregions are the same 
        /// e.g., one can copy a rectangular region from a 2D image to a slice of a 3D image.
        /// </param>
        /// <param name="dst_image">
        /// Can be 1D, 2D, 3D image or a 1D, 2D image array objects. 
        /// It is possible to copy subregions between any combinations of source and destination types, 
        /// provided that the dimensions of the subregions are the same 
        /// e.g., one can copy a rectangular region from a 2D image to a slice of a 3D image.
        /// </param>
        /// <param name="src_origin">
        /// Defines the (x, y, z) offset in pixels in the 1D, 2D or 3D image, the (x, y) offset 
        /// and the image index in the 2D image array or the (x) offset and the image index in the 1D image array. 
        /// If image is a 2D image object, src_origin[2] must be 0. 
        /// If src_image is a 1D image object, src_origin[1] and src_origin[2] must be 0. 
        /// If src_image is a 1D image array object, src_origin[2] must be 0. 
        /// If src_image is a 1D image array object, src_origin[1] describes the image index in the 1D image array. 
        /// If src_image is a 2D image array object, src_origin[2] describes the image index in the 2D image array.
        /// </param>
        /// <param name="dst_origin">
        /// Defines the (x, y, z) offset in pixels in the 1D, 2D or 3D image, the (x, y) offset and the image index in the 
        /// 2D image array or the (x) offset and the image index in the 1D image array.
        /// If dst_image is a 2D image object, dst_origin[2] must be 0. 
        /// If dst_image is a 1D image or 1D image buffer object, dst_origin[1] and dst_origin[2] must be 0.
        /// If dst_image is a 1D image array object, dst_origin[2] must be 0. 
        /// If dst_image is a 1D image array object, dst_origin[1] describes the image index in the 1D image array. 
        /// If dst_image is a 2D image array object, dst_origin[2] describes the image index in the 2D image array.
        /// </param>
        /// <param name="region">
        /// Defines the (width, height, depth) in pixels of the 1D, 2D or 3D rectangle, 
        /// the (width, height) in pixels of the 2D rectangle and the number of images of a 2D image array or the (width) 
        /// in pixels of the 1D rectangle and the number of images of a 1D image array. 
        /// If src_image or dst_image is a 2D image object, region[2] must be 1.
        /// If src_image or dst_image is a 1D image or 1D image buffer object, region[1] and region[2] must be 1.
        /// If src_image or dst_image is a 1D image array object, region[2] must be 1. 
        /// The values in region cannot be 0.
        /// </param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid 
        /// and num_events_in_wait_list must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points.
        /// The context associated with events in event_wait_list and command_queue must be the same.
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a 
        /// wait for this particular command to complete. 
        /// event can be NULL in which case it will not be possible for the application to query the status of this 
        /// command or queue a wait for this command to complete. 
        /// clEnqueueBarrierWithWaitList can be used instead. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an element 
        /// of the event_wait_list array.
        /// </param>
        /// <returns>Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueCopyImage", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueCopyImage(CLCommandQueuePtr command_queue,
                   CLMemoryPtr src_image,
                   CLMemoryPtr dst_image,
                   Vector3i src_origin,
                   Vector3i dst_origin,
                   Vector3i region,
                   int num_events_in_wait_list,
                   CLEventPtr[] event_wait_list,
                   [Out] out CLEventPtr evt) ;

        /// <summary>
        /// Enqueues a command to copy an image object to a buffer object.
        /// 
        /// If the mipmap extensions are enabled with cl_khr_mipmap_image, calls to EnqueueCopyImage, EnqueueCopyImageToBuffer, 
        /// and EnqueueCopyBufferToImage can also be used to copy from and to a specific mip-level of a mip-mapped image. 
        /// If src_image argument is a 1D image, src_origin[1] specifies the mip-level to use.
        /// If src_image argument is a 1D image array, src_origin[2] specifies the mip-level to use.
        /// If src_image argument is a 2D image, src_origin[3] specifies the mip-level to use. 
        /// If src_image argument is a 2D image array or a 3D image, src_origin[3] specifies the mip-level to use.
        /// If dst_image argument is a 1D image, dst_origin[1] specifies the mip-level to use. 
        /// If dst_image argument is a 1D image array, dst_origin[2] specifies the mip-level to use. 
        /// If dst_image argument is a 2D image, dst_origin[3] specifies the mip-level to use. 
        /// If dst_image argument is a 2D image array or a 3D image, dst_origin[3] specifies the mip-level to use.
        /// 
        /// If the mip level specified is not a valid value, these functions return the error InvalidMipLevel.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueCopyImageToBuffer.html
        /// </summary>
        /// <param name="command_queue">
        /// Must be a valid host command-queue. The OpenCL context associated with command_queue, src_image, and dst_buffer must be the same.
        /// </param>
        /// <param name="src_image">A valid image object.</param>
        /// <param name="dst_buffer">A valid buffer object.</param>
        /// <param name="src_origin">
        /// Defines the (x, y, z) offset in pixels in the 1D, 2D or 3D image, the (x, y) offset and the image index in the 
        /// 2D image array or the (x) offset and the image index in the 1D image array. 
        /// If src_image is a 2D image object, src_origin[2] must be 0. 
        /// If src_image is a 1D image or 1D image buffer object, src_origin[1] and src_origin[2] must be 0. 
        /// If src_image is a 1D image array object, src_origin[2] must be 0. 
        /// If src_image is a 1D image array object, src_origin[1] describes the image index in the 1D image array. 
        /// If src_image is a 2D image array object, src_origin[2] describes the image index in the 2D image array.
        /// </param>
        /// <param name="region">
        /// Defines the (width, height, depth) in pixels of the 1D, 2D or 3D rectangle, the (width, height) in pixels of the 
        /// 2D rectangle and the number of images of a 2D image array or the (width) in pixels of the 1D rectangle and the number of 
        /// images of a 1D image array.
        /// If src_image is a 2D image object, region[2] must be 1.
        /// If src_image is a 1D image or 1D image buffer object, region[1] and region[2] must be 1.
        /// If src_image is a 1D image array object, region[2] must be 1. 
        /// The values in region cannot be 0.
        /// </param>
        /// <param name="dst_offset">
        /// Refers to the offset where to begin copying data into dst_buffer. 
        /// The size in bytes of the region to be copied referred to as dst_cb is 
        /// computed as width * height * depth * bytes/image element if src_image is a 3D image object, 
        /// is computed as width * height * bytes/image element if src_image is a 2D image, 
        /// is computed as width * height * arraysize * bytes/image element if src_image is a 2D image array object, 
        /// is computed as width * bytes/image element if src_image is a 1D image 
        /// or 1D image buffer object and is computed as width * arraysize * bytes/image element if src_image is a 1D image array object.
        /// </param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list 
        /// must be greater than 0. The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this
        /// particular command to complete. event can be NULL in which case it will not be possible for the application to 
        /// query the status of this command or queue a wait for this command to complete. 
        /// clEnqueueBarrierWithWaitList can be used instead. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an element of
        /// the event_wait_list array.
        /// </param>
        /// <returns>returns Success if the function is executed successfully. </returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueCopyImageToBuffer", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueCopyImageToBuffer(CLCommandQueuePtr command_queue,
                           CLMemoryPtr src_image,
                           CLMemoryPtr dst_buffer,
                           Vector3i src_origin,
                           Vector3i region,
                           int dst_offset,
                           int num_events_in_wait_list,
                           CLEventPtr[] event_wait_list,
                           [Out] out CLEventPtr evt) ;

        /// <summary>
        /// Enqueues a command to copy a buffer object to an image object.
        /// 
        /// If the mipmap extensions are enabled with cl_khr_mipmap_image, calls to EnqueueCopyImage, EnqueueCopyImageToBuffer, 
        /// and EnqueueCopyBufferToImage can also be used to copy from and to a specific mip-level of a mip-mapped image. 
        /// If src_image argument is a 1D image, src_origin[1] specifies the mip-level to use.
        /// If src_image argument is a 1D image array, src_origin[2] specifies the mip-level to use. 
        /// If src_image argument is a 2D image, src_origin[3] specifies the mip-level to use. 
        /// If src_image argument is a 2D image array or a 3D image, src_origin[3] specifies the mip-level to use. 
        /// If dst_image argument is a 1D image, dst_origin[1] specifies the mip-level to use.
        /// If dst_image argument is a 1D image array, dst_origin[2] specifies the mip-level to use.
        /// If dst_image argument is a 2D image, dst_origin[3] specifies the mip-level to use. 
        /// If dst_image argument is a 2D image array or a 3D image, dst_origin[3] specifies the mip-level to use.
        /// 
        /// If the mip level specified is not a valid value, these functions return the error InvalidMipLevel.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueCopyBufferToImage.html
        /// </summary>
        /// <param name="command_queue">
        /// A valid host command-queue. The OpenCL context associated with command_queue, src_buffer, and dst_image must be the same.
        /// </param>
        /// <param name="src_buffer">A valid buffer object.</param>
        /// <param name="dst_image">A valid image object.</param>
        /// <param name="src_offset">The offset where to begin copying data from src_buffer.</param>
        /// <param name="dst_origin">
        /// Defines the (x, y, z) offset in pixels in the 1D, 2D or 3D image, the (x, y) offset and the image index in the 
        /// 2D image array or the (x) offset and the image index in the 1D image array. 
        /// If dst_image is a 2D image object, dst_origin[2] must be 0. 
        /// If dst_image is a 1D image or 1D image buffer object, dst_origin[1] and dst_origin[2] must be 0. 
        /// If dst_image is a 1D image array object, dst_origin[2] must be 0. 
        /// If dst_image is a 1D image array object, dst_origin[1] describes the image index in the 1D image array. 
        /// If dst_image is a 2D image array object, dst_origin[2] describes the image index in the 2D image array.
        /// </param>
        /// <param name="region">
        /// Defines the (width, height, depth) in pixels of the 1D, 2D or 3D rectangle, the (width, height) in pixels 
        /// of the 2D rectangle and the number of images of a 2D image array or the (width) in pixels of the 
        /// 1D rectangle and the number of images of a 1D image array. 
        /// If dst_image is a 2D image object, region[2] must be 1. 
        /// If dst_image is a 1D image or 1D image buffer object, region[1] and region[2] must be 1. 
        /// If dst_image is a 1D image array object, region[2] must be 1. 
        /// The values in region cannot be 0.
        /// 
        /// The size in bytes of the region to be copied from src_buffer referred to as
        /// src_cb is computed as width * height * depth * bytes/image_element 
        /// if dst_image is a 3D image object, is computed as width * height * bytes/image_element 
        /// if dst_image is a 2D image, is computed as width * height * arraysize * bytes/image_element 
        /// if dst_image is a 2D image array object, is computed as width * bytes/image_element 
        /// if dst_image is a 1D image or 1D image buffer object and is computed as width * arraysize * bytes/image_element 
        /// if dst_image is a 1D image array object.
        /// </param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and 
        /// num_events_in_wait_list must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a 
        /// wait for this particular command to complete. event can be NULL in which case it will not be possible for the 
        /// application to query the status of this command or queue a wait for this command to complete. 
        /// clEnqueueBarrierWithWaitList can be used instead. If the event_wait_list and the event arguments are not NULL, 
        /// the event argument should not refer to an element of the event_wait_list array.
        /// </param>
        /// <returns>returns Success if the function is executed successfully</returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueCopyBufferToImage", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueCopyBufferToImage(CLCommandQueuePtr command_queue,
                           CLMemoryPtr src_buffer,
                           CLMemoryPtr dst_image,
                           int src_offset,
                           Vector3i dst_origin,
                           Vector3i region,
                           int num_events_in_wait_list,
                           CLEventPtr[] event_wait_list,
                           [Out] out CLEventPtr evt) ;

        /// <summary>
        /// Enqueues a command to map a region of the buffer object given by buffer into the host address space 
        /// and returns a pointer to this mapped region.
        /// 
        /// Notes
        /// The returned pointer maps a region starting at offset and is at least size bytes in size.The result of a 
        /// memory access outside this region is undefined.
        /// 
        /// If the buffer object is created with UseHostPointer set in mem_flags, the following will be true:
        /// 
        /// 
        /// The host_ptr specified in Create is guaranteed to contain the latest bits in the region being mapped 
        /// when the EnqueueMapBuffer command has completed.
        /// The pointer value returned by EnqueueMapBuffer will be derived from the host_ptr specified when the buffer 
        /// object is created.
        /// Mapped buffer objects are unmapped using EnqueueUnmapMemObject.
        /// 
        /// EnqueueMapBuffer and EnqueueMapImage increment the mapped count of the memory object. 
        /// The initial mapped count value of a memory object is zero.
        /// Multiple calls to EnqueueMapBuffer or EnqueueMapImage on the same memory object will increment this 
        /// mapped count by appropriate number of calls.EnqueueUnmapMemObject decrements the mapped count of the memory object.
        /// 
        /// 
        /// EnqueueMapBuffer and EnqueueMapImage act as synchronization points for a region of the buffer object being mapped.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueMapBuffer.html
        /// </summary>
        /// <param name="command_queue">Must be a valid host command-queue.</param>
        /// <param name="buffer">A valid buffer object. The OpenCL context associated with command_queue and buffer must be the same.</param>
        /// <param name="blocking_map">
        /// Indicates if the map operation is blocking or non-blocking.
        /// 
        /// If blocking_map is CL_TRUE, EnqueueMapBuffer does not return until the specified region in buffer is 
        /// mapped into the host address space and the application can access the contents of the mapped region using 
        /// the pointer returned by EnqueueMapBuffer.
        /// 
        /// If blocking_map is CL_FALSE i.e.map operation is non-blocking, the pointer to the mapped region returned by 
        /// EnqueueMapBuffer cannot be used until the map command has completed. 
        /// The event argument returns an event object which can be used to query the execution status of the map command. 
        /// When the map command is completed, the application can access the contents of the mapped region using the pointer 
        /// returned by EnqueueMapBuffer.
        /// </param>
        /// <param name="map_flags">A bit-bield with the following supported values.</param>
        /// <param name="offset">The offset in bytes of the region in the buffer object that is being mapped.</param>
        /// <param name="size">The size of the region in the buffer object that is being mapped.</param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and 
        /// num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a 
        /// wait for this particular command to complete. event can be NULL in which case it will not be possible for the 
        /// application to query the status of this command or queue a wait for this command to complete. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an 
        /// element of the event_wait_list array.
        /// </param>
        /// <param name="errcode_ret">The errcode_ret is set to Success if the operation completed successfully</param>
        /// <returns>returns a pointer to the mapped region. A NULL pointer is returned otherwise</returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueMapBuffer", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern IntPtr EnqueueMapBuffer(CLCommandQueuePtr command_queue,
                   CLMemoryPtr buffer,
                   bool blocking_map,
                   CLMapFlags map_flags,
                   int offset,
                   int size,
                   int num_events_in_wait_list,
                   CLEventPtr[] event_wait_list,
                   [Out] out CLEventPtr evt,
                   [Out] out CLResult errcode_ret);

        /// <summary>
        /// Enqueues a command to map a region of an image object into the host address space 
        /// and returns a pointer to this mapped region.
        /// 
        /// Notes
        /// The pointer returned maps a 1D, 2D or 3D region starting at origin and is at least region[0] pixels in size for a 
        /// 1D image, 1D image buffer or 1D image array, (RowPitch * region[1]) pixels in size for a 2D image or 2D image array,
        /// and (SlicePitch * region[2]) pixels in size for a 3D image.
        /// The result of a memory access outside this region is undefined.
        /// 
        /// If the image object is created with UseHostPointer set in mem_flags, the following will be true:
        /// 
        /// 
        /// The host_ptr specified in CreateImage is guaranteed to contain the latest bits in the region being mapped when the 
        /// EnqueueMapImage command has completed.
        /// The pointer value returned by EnqueueMapImage will be derived from the host_ptr specified when 
        /// the image object is created.
        /// Mapped image objects are unmapped using EnqueueUnmapMemObject.
        /// 
        /// EnqueueMapBuffer and EnqueueMapImage increment the mapped count of the memory object. 
        /// The initial mapped count value of a memory object is zero.
        /// Multiple calls to EnqueueMapBuffer or EnqueueMapImage on the same memory object will increment this mapped count 
        /// by appropriate number of calls.EnqueueUnmapMemObject decrements the mapped count of the memory object.
        /// 
        /// 
        /// EnqueueMapBuffer and EnqueueMapImage act as synchronization points for a region of the buffer object being mapped.
        /// 
        /// If the mipmap extensions are enabled with cl_khr_mipmap_image, calls to EnqueueReadImage, EnqueueWriteImage 
        /// and EnqueueMapImage can be used to read from or write to a specific mip-level of a mip-mapped image. 
        /// If image argument is a 1D image, origin[1] specifies the mip-level to use.
        /// If image argument is a 1D image array, origin[2] specifies the mip-level to use.
        /// If image argument is a 2D image, origin[3] specifies the mip-level to use.
        /// If image argument is a 2D image array or a 3D image, origin[3] specifies the mip-level to use.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueMapImage.html
        /// </summary>
        /// <param name="command_queue">Must be a valid host command-queue.</param>
        /// <param name="image">A valid image object. The OpenCL context associated with command_queue and image must be the same.</param>
        /// <param name="blocking_map">
        /// Indicates if the map operation is blocking or non-blocking.
        /// 
        /// If blocking_map is CL_TRUE, EnqueueMapImage does not return until the specified region in image is mapped into 
        /// the host address space and the application can access the contents of the mapped region using the pointer returned
        /// by EnqueueMapImage.
        /// 
        /// If blocking_map is CL_FALSE i.e. map operation is non-blocking, 
        /// the pointer to the mapped region returned by EnqueueMapImage cannot be used until the map command has completed. 
        /// The event argument returns an event object which can be used to query the execution status of the map command. 
        /// When the map command is completed, the application can access the contents of the mapped region using the
        /// pointer returned by EnqueueMapImage.
        /// </param>
        /// <param name="map_flags">A bit-bield with the following supported values.</param>
        /// <param name="origin">
        /// Defines the (x, y, z) offset in pixels in the 1D, 2D or 3D image, the (x, y) offset 
        /// and the image index in the 2D image array or the (x) offset and the image index in the 1D image array. 
        /// If image is a 2D image object, origin[2] must be 0. 
        /// If image is a 1D image or 1D image buffer object, origin[1] and origin[2] must be 0. 
        /// If image is a 1D image array object, origin[2] must be 0.
        /// If image is a 1D image array object, origin[1] describes the image index in the 1D image array. 
        /// If image is a 2D image array object, origin[2] describes the image index in the 2D image array.
        /// </param>
        /// <param name="region">
        /// Defines the (width, height, depth) in pixels of the 1D, 2D or 3D rectangle, the (width, height) in pixels
        /// of the 2D rectangle and the number of images of a 2D image array or the (width) in pixels of the 
        /// 1D rectangle and the number of images of a 1D image array.
        /// If image is a 2D image object, region[2] must be 1. 
        /// If image is a 1D image or 1D image buffer object, region[1] and region[2] must be 1. 
        /// If image is a 1D image array object, region[2] must be 1. The values in region cannot be 0.
        /// </param>
        /// <param name="RowPitch">Returns the scan-line pitch in bytes for the mapped region. This must be a non-NULL value.</param>
        /// <param name="SlicePitch">
        /// Returns the size in bytes of each 2D slice of a 3D image or the size of each 1D or 2D image in a 
        /// 1D or 2D image array for the mapped region. 
        /// For a 1D and 2D image, zero is returned if this argument is not NULL. 
        /// For a 3D image, 1D, and 2D image array, SlicePitch must be a non-NULL value.
        /// </param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before EnqueueMapImage can be executed. 
        /// If event_wait_list is NULL, then EnqueueMapImage does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and 
        /// num_events_in_wait_list must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a 
        /// wait for this particular command to complete. 
        /// event can be NULL in which case it will not be possible for the application to query the status of this 
        /// command or queue a wait for this command to complete. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an 
        /// element of the event_wait_list array.
        /// </param>
        /// <param name="errcode_ret">Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.</param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueMapImage", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern IntPtr EnqueueMapImage(CLCommandQueuePtr command_queue,
                  CLMemoryPtr image,
                  bool blocking_map,
                  CLMapFlags map_flags,
                  Vector3i origin,
                  Vector3i region,
                  [Out] out uint RowPitch,
                  [Out] out uint SlicePitch,
                  int num_events_in_wait_list,
                  CLEventPtr[] event_wait_list,
                  [Out] out CLEventPtr evt,
                  [Out] out CLResult errcode_ret) ;

        /// <summary>
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// 
        /// Notes
        /// Reads or writes from the host using the pointer returned by EnqueueMapBuffer or EnqueueMapImage are considered to be complete.
        /// 
        /// EnqueueMapBuffer and EnqueueMapImage increment the mapped count of the memory object. The initial mapped count value of a memory object is zero.Multiple calls to EnqueueMapBuffer or EnqueueMapImage on the same memory object will increment this mapped count by appropriate number of calls.EnqueueUnmapMemObject decrements the mapped count of the memory object.
        /// 
        ///
        /// EnqueueMapBuffer and EnqueueMapImage act as synchronization points for a region of the buffer object being mapped.
        /// 
        /// Accessing mapped regions of a memory object
        /// This section describes the behavior of OpenCL commands that access mapped regions of a memory object.
        /// 
        /// 
        /// The contents of the region of a memory object and associated memory objects (sub-buffer objects or 1D image buffer objects that overlap this region) mapped for writing (i.e. Write or WriteInvalidateRegion is set in map_flags argument to EnqueueMapBuffer or EnqueueMapImage) are considered to be undefined until this region is unmapped.
        /// 
        /// Multiple commands in command - queues can map a region or overlapping regions of a memory object and associated memory objects(sub - buffer objects or 1D image buffer objects that overlap this region) for reading(i.e.map_flags = Read).The contents of the regions of a memory object mapped for reading can also be read by kernels and other OpenCL commands(such as EnqueueCopyBuffer) executing on a device(s).
        /// 
        /// Mapping(and unmapping) overlapped regions in a memory object and / or associated memory objects(sub - buffer objects or 1D image buffer objects that overlap this region) for writing is an error and will result in InvalidOperation error returned by EnqueueMapBuffer or EnqueueMapImage.
        /// 
        /// 
        /// If a memory object is currently mapped for writing, the application must ensure that the memory object is unmapped before any enqueued kernels or commands that read from or write to this memory object or any of its associated memory objects(sub - buffer or 1D image buffer objects) or its parent object(if the memory object is a sub - buffer or 1D image buffer object) begin execution; otherwise the behavior is undefined.
        /// 
        /// If a memory object is currently mapped for reading, the application must ensure that the memory object is unmapped before any enqueued kernels or commands that write to this memory object or any of its associated memory objects(sub - buffer or 1D image buffer objects) or its parent object(if the memory object is a sub - buffer or 1D image buffer object) begin execution; otherwise the behavior is undefined.
        /// 
        /// A memory object is considered as mapped if there are one or more active mappings for the memory object irrespective of whether the mapped regions span the entire memory object.
        /// 
        /// 
        /// Accessing the contents of the memory region referred to by the mapped pointer that has been unmapped is undefined.
        /// 
        /// The mapped pointer returned by EnqueueMapBuffer or EnqueueMapImage can be used as ptr argument value to EnqueueReadBuffer, EnqueueWriteBuffer, clEnqueueReadBufferRect, clEnqueueWriteBufferRect, EnqueueReadImage, and EnqueueWriteImage, provided the rules described above are adhered to.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueUnmapMemObject.html
        /// </summary>
        /// <param name="command_queue">Must be a valid host command-queue.</param>
        /// <param name="memobj">A valid memory (buffer or image) object. The OpenCL context associated with command_queue and memobj must be the same.</param>
        /// <param name="mapped_ptr">The host address returned by a previous call to EnqueueMapBuffer or EnqueueMapImage for memobj.</param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before EnqueueUnmapMemObject can be executed. 
        /// If event_wait_list is NULL, then EnqueueUnmapMemObject does not wait on any event to complete.
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, 
        /// the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for 
        /// this particular command to complete. 
        /// event can be NULL in which case it will not be possible for the application to query the status of this command 
        /// or queue a wait for this command to complete. clEnqueueBarrierWithWaitList can be used instead. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an element of 
        /// the event_wait_list array.
        /// </param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueUnmapMemObject", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueUnmapMemObject(CLCommandQueuePtr command_queue,
                        CLMemoryPtr memobj,
                        IntPtr mapped_ptr,
                        int num_events_in_wait_list,
                        CLEventPtr[] event_wait_list,
                        [Out] out CLEventPtr evt);

        /// <summary>
        /// Enqueues a command to execute a kernel on a device.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueNDRangeKernel.html
        /// </summary>
        /// <param name="command_queue">A valid host command-queue. 
        /// The kernel will be queued for execution on the device associated with command_queue.</param>
        /// <param name="kernel">A valid kernel object. 
        /// The OpenCL context associated with kernel and command_queue must be the same.</param>
        /// <param name="work_dim">
        /// The number of dimensions used to specify the global work-items and work-items in the work-group. 
        /// work_dim must be greater than zero and less than or equal to MaxWorkItemDimensions.</param>
        /// <param name="global_work_offset">
        /// global_work_offset can be used to specify an array of work_dim unsigned values that describe the offset 
        /// used to calculate the global ID of a work-item. 
        /// If global_work_offset is NULL, the global IDs start at offset (0, 0, ... 0).
        /// </param>
        /// <param name="global_work_size">
        /// Points to an array of work_dim unsigned values that describe the number of global work-items in work_dim dimensions 
        /// that will execute the kernel function. 
        /// The total number of global work-items is computed as global_work_size[0] *...* global_work_size[work_dim - 1].
        /// </param>
        /// <param name="local_work_size">
        /// Points to an array of work_dim unsigned values that describe the number of work-items that make up a work-group 
        /// (also referred to as the size of the work-group) that will execute the kernel specified by kernel. 
        /// The total number of work-items in a work-group is computed as local_work_size[0] *... * local_work_size[work_dim - 1]. 
        /// The total number of work-items in the work-group must be less than or equal to the MaxWorkGroupSize 
        /// value specified in table of OpenCL Device Queries for GetDeviceInfo and the number of work-items specified in 
        /// local_work_size[0],... local_work_size[work_dim - 1] must be less than or equal to the corresponding values specified 
        /// by MaxWorkGroupItemSizes[0],.... MaxWorkGroupItemSizes[work_dim - 1]. 
        /// The explicitly specified local_work_size will be used to determine how to break the global work-items specified by 
        /// global_work_size into appropriate work-group instances. 
        /// The values in local_work_size need not evenly divide the global_work_size in any dimension. 
        /// In this case, any single dimension for which the global size is not divisible by the local size will be partitioned 
        /// into two regions. One region will have workgroups that have the same number of work items as was specified by the 
        /// local size parameter in that dimension. The other region will have work-groups with less than the number of work 
        /// items specified by the local size parameter in that dimension. 
        /// The global IDs and group IDs of the work items in the first region will be numerically lower than those in the second,
        /// and the second region will be at most one work-group wide in that dimension.
        /// Workgroup sizes could be non-uniform in multiple dimensions, potentially producing work-groups of up to 4 different sizes
        /// in a 2D range and 8 different sizes in a 3D range.
        /// 
        /// If local_work_size is NULL, the OpenCL runtime is free to implement the ND-range using uniform or non-uniform work-group sizes,
        /// regardless of the divisibility of the global work size.
        /// If the ND-range is implemented using non-uniform work-group sizes, the work-group sizes, global IDs and group IDs 
        /// will follow the same pattern as described in above paragraph.
        /// 
        /// The work-group size to be used for kernel can also be specified in the program source using the 
        /// __attribute__((reqd_work_group_size(X, Y, Z))) qualifier.
        /// In this case the size of work group specified by local_work_size must match the value specified by the reqd_work_group_size
        /// __attribute__ qualifier.
        /// 
        /// 
        /// These work-group instances are executed in parallel across multiple compute units or concurrently on the same compute unit.
        /// 
        /// 
        /// Each work-item is uniquely identified by a global identifier. The global ID, which can be read inside the kernel, 
        /// is computed using the value given by global_work_size and global_work_offset.
        /// In addition, a work-item is also identified within a work-group by a unique local ID.
        /// The local ID, which can also be read by the kernel, is computed using the value given by local_work_size.
        /// The starting local ID is always (0, 0, ... 0).
        /// </param>
        /// <param name="num_events_in_wait_list">The number of events in event_wait_list</param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be 
        /// greater than 0. 
        /// The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular kernel execution instance. 
        /// Event objects are unique and can be used to identify a particular kernel execution instance later on. 
        /// If event is NULL, no event will be created for this kernel execution instance and therefore it will not be 
        /// possible for the application to query or queue a wait for this particular kernel execution instance. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an element of the 
        /// event_wait_list array.
        /// </param>
        /// <returns>Returns Success if the kernel execution was successfully queued.</returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueNDRangeKernel", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueNDRangeKernel(CLCommandQueuePtr command_queue,
                       CLKernelPtr kernel,
                       int work_dim,
                       ulong[] global_work_offset,
                       ulong[] global_work_size,
                       ulong[] local_work_size,
                       int num_events_in_wait_list,
                       CLEventPtr[] event_wait_list,
                       [Out] out CLEventPtr evt) ;

        /// <summary>
        /// TODO: Verify me.
        /// According to Microsoft passing delegates is a no no. 
        /// For now use null.
        /// </summary>
        /// <param name="user_data"></param>
        public delegate void user_funcDelegate(IntPtr user_data);

        /// <summary>
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// 
        /// Notes
        /// The total number of read-only images specified as arguments to a kernel cannot exceed MaxReadImageArgs.
        /// Each image array argument to a kernel declared with the read_only qualifier counts as one image.
        /// 
        /// The total number of write-only images specified as arguments to a kernel cannot exceed MaxWriteImageArgs.
        /// Each image array argument to a kernel declared with the write_only qualifier counts as one image.
        /// 
        /// 
        /// The total number of read-write images specified as arguments to a kernel cannot exceed MaxReadWriteImageArgs.
        /// Each image array argument to a kernel declared with the read_write qualifier counts as one image.
        /// 
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueNativeKernel.html
        /// </summary>
        /// <param name="command_queue">
        /// A valid host command-queue. 
        /// A native user function can only be executed on a command-queue created on a device that has 
        /// NativeKernel capability set in ExecutionCapabilities as specified in the table of 
        /// OpenCL Device Queries for GetDeviceInfo.
        /// </param>
        /// <param name="user_func">A pointer to a host-callable user function.</param>
        /// <param name="args">A pointer to the args list that user_func should be called with.</param>
        /// <param name="cb_args">
        /// The size in bytes of the args list that args points to.
        /// 
        /// The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will 
        /// be passed to user_func.
        /// The copy needs to be done because the memory objects (CLMemoryPtr values) that args may contain need to be modified 
        /// and replaced by appropriate pointers to global memory.
        /// When EnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects">The number of buffer objects that are passed in args.</param>
        /// <param name="mem_list">
        /// A list of valid buffer objects, if num_mem_objects > 0.
        /// The buffer object values specified in mem_list are memory object handles (CLMemoryPtr values) returned by Create or NULL.
        /// </param>
        /// <param name="args_mem_loc">
        /// A pointer to appropriate locations that args points to where memory object handles (CLMemoryPtr values) are stored. 
        /// Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before this particular command can be executed.
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL,
        /// the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0.
        /// The events specified in event_wait_list act as synchronization points.
        /// The context associated with events in event_wait_list and command_queue must be the same. 
        /// The memory associated with event_wait_list can be reused or freed after the function returns.
        /// </param>
        /// <param name="evt"></param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueNativeKernel", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueNativeKernel(CLCommandQueuePtr command_queue,
                      user_funcDelegate user_func,
                      IntPtr args,
                      uint cb_args,
                      uint num_mem_objects,
                      CLMemoryPtr[] mem_list,
                      IntPtr[] args_mem_loc,
                      int num_events_in_wait_list,
                      CLEventPtr[] event_wait_list,
                      [Out] out CLEventPtr evt) ;


        /* Deprecated OpenCL 1.1 APIs */

        /// <summary>
        /// Creates a 2D image object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/CreateImage2D.html
        /// </summary>
        /// <param name="context">A valid OpenCL context on which the image object is to be created.</param>
        /// <param name="flags">A bit-field that is used to specify allocation and usage information about the image memory 
        /// object being created and is described in the table List of supported CLMemoryFlags values for Create.</param>
        /// <param name="image_format">A pointer to a structure that describes format properties of the image to be allocated. 
        /// See CLImageFormat for a detailed description of the image format descriptor.</param>
        /// <param name="Width">The width and height of the image in pixels. These must be values greater than or equal to 1.</param>
        /// <param name="Height">The width and height of the image in pixels. These must be values greater than or equal to 1.</param>
        /// <param name="RowPitch">The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 
        /// 0 or greater than or equal to Width * size of element in bytes if host_ptr is not NULL. 
        /// If host_ptr is not NULL and RowPitch is equal to 0, RowPitch is calculated as 
        /// Width * size of element in bytes. 
        /// If RowPitch is not 0, it must be a multiple of the image element size in bytes.</param>
        /// <param name="host_ptr">A pointer to the image data that may already be allocated by the application. 
        /// The size of the buffer that host_ptr points to must be greater than or equal to RowPitch * Height.
        /// The size of each element in bytes must be a power of 2. 
        /// The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. 
        /// Each scanline is stored as a linear sequence of image elements.</param>
        /// <param name="errcode_ret"> errcode_ret is set to Success if the image object is created successfully. </param>
        /// <returns>a valid non-zero image object created or null if errcode_ret is not Success</returns>
        [Obsolete]
        [DllImport("opencl.dll", EntryPoint = "clCreateImage2D", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLMemoryPtr CreateImage2D(CLContextPtr context,
                CLMemoryFlags flags,
                CLImageFormat image_format,
                int Width,
                int Height,
                int RowPitch,
                CLMemoryPtr host_ptr,
                [Out] out CLResult errcode_ret);

        /// <summary>
        /// Creates a 3D image object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/CreateImage3D.html
        /// </summary>
        /// <param name="context">A valid OpenCL context on which the image object is to be created.</param>
        /// <param name="flags">A bit-field that is used to specify allocation and usage information about the image
        /// memory object being created and is described in the table List of supported CLMemoryFlags values for Create.</param>
        /// <param name="image_format">A pointer to a structure that describes format properties of the image to be allocated. 
        /// See CLImageFormat for a detailed description of the image format descriptor.</param>
        /// <param name="Width">The width and height of the image in pixels. These must be values greater than or equal to 1.</param>
        /// <param name="Height">The width and height of the image in pixels. These must be values greater than or equal to 1.</param>
        /// <param name="Depth">The depth of the image in pixels. This must be a value greater than 1.</param>
        /// <param name="RowPitch">
        /// The scan-line pitch in bytes. 
        /// This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to 
        /// Width * size of element in bytes if host_ptr is not NULL. 
        /// If host_ptr is not NULL and RowPitch is equal to 0, RowPitch is calculated as 
        /// Width * size of element in bytes. 
        /// If RowPitch is not 0, it must be a multiple of the image element size in bytes.</param>
        /// <param name="SlicePitch">
        /// The size in bytes of each 2D slice in the 3D image.
        /// This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to 
        /// RowPitch * Height if host_ptr is not NULL.
        /// If host_ptr is not NULL and SlicePitch equal to 0, SlicePitch is calculated as RowPitch * Height. 
        /// If SlicePitch is not 0, it must be a multiple of the RowPitch.
        /// </param>
        /// <param name="host_ptr">
        /// A pointer to the image data that may already be allocated by the application. 
        /// The size of the buffer that host_ptr points to must be greater than or equal to SlicePitch * Depth. 
        /// The size of each element in bytes must be a power of 2. 
        /// The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. 
        /// Each 2D slice is a linear sequence of adjacent scanlines. 
        /// Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret">set to Success if the image object is created successfully.</param>
        /// <returns>Returns a valid non-zero image object created and the errcode_ret is set to Success if the image object is created successfully. Otherwise, it returns a NULL</returns>
        [Obsolete]
        [DllImport("opencl.dll", EntryPoint = "clCreateImage3D", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLMemoryPtr CreateImage3D(CLContextPtr context,
                CLMemoryFlags flags,
                CLImageFormat image_format,
                int Width,
                int Height,
                int Depth,
                int RowPitch,
                int SlicePitch,
                IntPtr host_ptr,
                [Out] out CLResult errcode_ret);

        /// <summary>
        /// Enqueues a marker command.
        /// 
        /// Notes
        /// Enqueues a marker command to command_queue.
        /// The marker command returns an event which can be used to queue a wait on this marker event i.e.
        /// wait for all commands queued before the marker command to complete.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/EnqueueMarker.html
        /// </summary>
        /// <param name="command_queue"></param>
        /// <param name="evt"></param>
        /// <returns>Returns Success if the function is successfully executed.</returns>
        [Obsolete][DllImport("opencl.dll", EntryPoint = "clEnqueueMarker", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueMarker(CLCommandQueuePtr command_queue,
                [Out] out CLEventPtr evt);


        /// <summary>
        /// Enqueues a wait for a specific event or a list of events to complete before any future commands queued in the command-queue are executed.
        /// 
        /// Notes
        /// The context associated with events in event_list and command_queue must be the same.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/EnqueueWaitForEvents.html
        /// </summary>
        /// <param name="command_queue">A valid command-queue.</param>
        /// <param name="num_events">Specifies the number of events given by event_list.</param>
        /// <param name="event_list">
        /// Events specified in event_list act as synchronization points. Each event in event_list must be a valid event object returned by a previous call to the following:
        ///
        /// EnqueueNDRangeKernel
        /// EnqueueTask
        /// EnqueueNativeKernel
        /// EnqueueReadBuffer, EnqueueWriteBuffer, EnqueueMapBuffer, EnqueueReadImage, EnqueueWriteImage, EnqueueMapImage
        /// EnqueueCopyBuffer, EnqueueCopyImage
        /// EnqueueCopyBufferToImage
        /// EnqueueCopyImageToBuffer
        /// EnqueueMarker
        /// </param>
        /// <returns>Returns Success if the function was successfully executed</returns>
        [Obsolete][DllImport("opencl.dll", EntryPoint = "clEnqueueWaitForEvents", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueWaitForEvents(CLCommandQueuePtr command_queue,
                        uint num_events,
                        CLEventPtr[] event_list);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func_name"></param>
        /// <returns></returns>
        [Obsolete][DllImport("opencl.dll", EntryPoint = "clGetExtensionFunctionAddress", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern IntPtr GetExtensionFunctionAddress(string func_name) ;

        /* Deprecated OpenCL 2.0 APIs */

        /// <summary>
        /// Create a command-queue on a specific device.
        /// 
        /// <see cref="CL.CreateCommandQueueWithProperties"/>
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/CreateCommandQueue.html
        /// </summary>
        /// <param name="context">Must be a valid OpenCL context.</param>
        /// <param name="device">
        /// Must be a device associated with context. 
        /// It can either be in the list of devices specified when context is created using CreateContext 
        /// or have the same device type as the device type specified when the context is created using CreateContextFromType.
        /// </param>
        /// <param name="properties">Specifies a list of properties for the command-queue.</param>
        /// <param name="errcode_ret"></param>
        /// <returns>Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.</returns>
        [Obsolete][DllImport("opencl.dll", EntryPoint = "clCreateCommandQueue", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLCommandQueuePtr CreateCommandQueue(CLContextPtr context,
                     CLDevicePtr device,
                     CLCommandQueueProperties properties,
                     [Out] out CLResult errcode_ret) ;

        /// <summary>
        /// Enqueues a command to execute a kernel on a device.
        /// 
        /// Notes
        /// The kernel is executed using a single work-item.
        /// 
        /// EnqueueTask is equivalent to calling EnqueueNDRangeKernel with 
        /// work_dim = 1, 
        /// global_work_offset = NULL, 
        /// global_work_size[0] set to 1, 
        /// and local_work_size[0] set to 1.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/EnqueueTask.html
        /// </summary>
        /// <param name="command_queue">A valid command-queue. 
        /// The kernel will be queued for execution on the device associated with command_queue.</param>
        /// <param name="kernel">A valid kernel object. 
        /// The OpenCL context associated with kernel and command_queue must be the same.</param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and 
        /// num_events_in_wait_list must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points. 
        /// The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular kernel execution instance.
        /// Event objects are unique and can be used to identify a particular kernel execution instance later on. 
        /// If event is NULL, no event will be created for this kernel execution instance and therefore it will not 
        /// be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        /// <returns></returns>
        [Obsolete][DllImport("opencl.dll", EntryPoint = "clEnqueueTask", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueTask(CLCommandQueuePtr command_queue,
              CLKernelPtr kernel,
              int num_events_in_wait_list,
              CLEventPtr[] event_wait_list,
              [Out] out CLEventPtr evt) ;

        /// <summary>
        /// Creates an OpenCL buffer object from an OpenGL buffer object.
        /// 
        /// The size of the GL buffer object data store at the time CreateFromGLBuffer is 
        /// called will be used as the size of buffer object returned by CreateFromGLBuffer. 
        /// If the state of a GL buffer object is modified through the GL API (e.g. glBufferData) 
        /// while there exists a corresponding CL buffer object, subsequent use of the 
        /// CL buffer object will result in undefined behavior.
        /// 
        /// The Retain and Release functions can be used to retain and release the buffer object.
        /// </summary>
        /// <param name="context">A valid OpenCL context created from an OpenGL context.</param>
        /// <param name="flags">A bit-field that is used to specify usage information. 
        /// Refer to the table at Create for a description of flags. 
        /// Only ReadOnly, WriteOnly and ReadWrite
        /// values specified in the table at Create can be used.</param>
        /// <param name="bufobj">
        /// The name of a GL buffer object. 
        /// The data store of the GL buffer object must have have been previously created by calling OpenGL function 
        /// glBufferData, although its contents need not be initialized. 
        /// The size of the data store will be used to determine the size of the CL buffer object.
        /// </param>
        /// <param name="errcode_ret">Returns an appropriate error code as described below. If errcode_ret is NULL, no error code is returned.</param>
        /// <returns>Returns a valid non-zero OpenCL buffer object and errcode_ret is set to Success if the buffer object is created successfully. Otherwise, it returns a NULL value</returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateFromGLBuffer", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLMemoryPtr CreateFromGLBuffer(CLContextPtr     context,
                     CLMemoryFlags   flags,
                     IntPtr bufobj, ///TODO: Make this a GL memory object when we implement Open GL
                     [Out] out CLResult       errcode_ret);


        /// <summary>
        /// Creates an OpenCL image object, image array object, or image buffer object from an OpenGL texture object, 
        /// texture array object, texture buffer object, or a single face of an OpenGL cubemap texture object.
        /// 
        /// Notes
        /// If the state of a GL texture object is modified through the GL API(e.g.glTexImage2D, glTexImage3D or the values 
        /// of the texture parameters GL_TEXTURE_BASE_LEVEL or GL_TEXTURE_MAX_LEVEL are modified) while there exists a 
        /// corresponding CL image object, subsequent use of the CL image object will result in undefined behavior.
        /// 
        /// The Retain and Release functions can be used to retain and release the image objects.
        /// 
        /// 
        /// The OpenCL specification in section 9.7 defines how to share data with texture and buffer objects in a 
        /// parallel OpenGL implementation, but does not define how the association between an OpenCL context and an 
        /// OpenGL context or share group is established.This extension defines optional attributes to OpenCL context 
        /// creation routines which associate a GL context or share group object with a newly created OpenCL context.
        /// If this extension is supported by an implementation, the string "cl_khr_gl_sharing" will be present in the 
        /// Extensions string described in the table of allowed values for param_name for GetDeviceInfo or in the
        /// Extensions string described in the table of allowed values for param_name for GetPlatformInfo.
        /// 
        /// 
        /// This section discusses OpenCL functions that allow applications to use OpenGL buffer, texture, and 
        /// renderbuffer objects as OpenCL memory objects.This allows efficient sharing of data between OpenCL and OpenGL. 
        /// The OpenCL API may be used to execute kernels that read and/or write memory objects that are also OpenGL objects.
        /// 
        /// An OpenCL image object may be created from an OpenGL texture or renderbuffer object. 
        /// An OpenCL buffer object may be created from an OpenGL buffer object.
        /// 
        /// 
        /// OpenCL memory objects may be created from OpenGL objects if and only if the OpenCL context has been created from an 
        /// OpenGL share group object or context.
        /// OpenGL share groups and contexts are created using platform specific APIs such as EGL, CGL, WGL, and GLX.
        /// On MacOS X, an OpenCL context may be created from an OpenGL share group object using the OpenCL platform extension cl_apple_gl_sharing.
        /// On other platforms including Microsoft Windows, Linux/Unix and others, an OpenCL context may be created from an 
        /// OpenGL context using the Khronos platform extension cl_khr_gl_sharing.
        /// Refer to the platform documentation for your OpenCL implementation, or visit the Khronos Registry at 
        /// https://www.khronos.org/registry/cl/ for more information.
        /// 
        /// 
        /// Any supported OpenGL object defined within the GL share group object, or the share group associated with the GL 
        /// context from which the CL context is created, may be shared, with the exception of the default OpenGL objects 
        /// (i.e.objects named zero), which may not be shared.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateFromGLTexture.html
        /// </summary>
        /// <param name="context">A valid OpenCL context created from an OpenGL context.</param>
        /// <param name="flags">
        /// A bit-field that is used to specify usage information. 
        /// Refer to the table for Create for a description of flags. 
        /// Only the values ReadOnly, WriteOnly and ReadWrite can be used.
        /// </param>
        /// <param name="target">
        /// texture_target This value must be one of Texture1D, Texture1DArray, Buffer, Texture2D, 
        /// Texture2DArray, Texture3D, CubeMapPositiveX, CubeMapPositiveY,
        /// CubeMapPositiveZ, CubeMapNegativeX, CubeMapNegativeY, 
        /// CubeMapNegativeZ, or Rectangle. 
        /// (Rectangle requires OpenGL 3.1. 
        /// Alternatively, RectangleARB may be specified if the OpenGL extension GL_ARB_texture_rectangle is supported.) 
        /// texture_target is used only to define the image type of texture. 
        /// No reference to a bound GL texture object is made or implied by this parameter.
        /// 
        /// If the cl_khr_gl_msaa_sharing extension is enabled, texture_target may be 
        /// Texture2DMultisample or Texture2DMultisampleArray.
        /// 
        /// If texture_target is Texture2DMultisample, CreateFromGLTexture creates an OpenCL 2D multi-sample image object 
        /// from an OpenGL 2D multi-sample texture
        /// 
        /// If texture_target is Texture2DMultisampleArray, CreateFromGLTexture creates an OpenCL 2D multi-sample array 
        /// image object from an OpenGL 2D multi-sample texture.
        /// </param>
        /// <param name="miplevel">
        /// The mipmap level to be used. If texture_target is Buffer, miplevel must be 0.
        /// Implementations may return InvalidOperation for miplevel values > 0
        /// </param>
        /// <param name="texture">
        /// The name of a GL 1D, 2D, 3D, 1D array, 2D array, cubemap, rectangle or buffer texture object. 
        /// The texture object must be a complete texture as per OpenGL rules on texture completeness. 
        /// The texture format and dimensions defined by OpenGL for the specified miplevel of the texture will be 
        /// used to create the OpenCL image memory object. Only GL texture objects with an public format that 
        /// maps to appropriate image channel order and data type specified in tables 5.5 and 5.6 (see CLImageFormat) 
        /// may be used to create the OpenCL image memory object.
        /// </param>
        /// <param name="errcode_ret">
        /// Returns an appropriate error code as described below. 
        /// If errcode_ret is NULL, no error code is returned.
        /// </param>
        /// <returns>
        /// Returns a valid non-zero OpenCL image object and errcode_ret is set to Success 
        /// if the image object is created successfully. Otherwise, it returns a NULL
        /// </returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateFromGLTexture", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLMemoryPtr CreateFromGLTexture(CLContextPtr      context,
                      CLMemoryFlags    flags,
                      TextureTarget target,
                      int        miplevel,
                      IntPtr texture,
                      [Out] out CLResult errcode_ret) ;


        /// <summary>
        /// Creates an OpenCL 2D image object from an OpenGL renderbuffer object.
        /// 
        /// Description
        /// If the state of a GL renderbuffer object is modified through the GL API (i.e.changes to the dimensions or 
        /// format used to represent pixels of the GL renderbuffer using appropriate GL API calls such as glRenderbufferStorage) 
        /// while there exists a corresponding CL image object, subsequent use of the 
        /// CL image object will result in undefined behavior.
        /// 
        /// The Retain and Release functions can be used to retain and release the image objects.
        /// 
        /// 
        /// The OpenCL specification in section 9.7 defines how to share data with texture and buffer objects in a parallel 
        /// OpenGL implementation, but does not define how the association between an OpenCL context and an 
        /// OpenGL context or share group is established.
        /// This extension defines optional attributes to OpenCL context creation routines which associate a GL context
        /// or share group object with a newly created OpenCL context.
        /// If this extension is supported by an implementation, the string "cl_khr_gl_sharing" will be present in the 
        /// Extensions string described in the table of allowed values for param_name for GetDeviceInfo or in the 
        /// Extensions string described in the table of allowed values for param_name for GetPlatformInfo.
        /// 
        /// This section discusses OpenCL functions that allow applications to use OpenGL buffer, texture, and renderbuffer objects 
        /// as OpenCL memory objects.This allows efficient sharing of data between OpenCL and OpenGL. 
        /// The OpenCL API may be used to execute kernels that read and/or write memory objects that are also OpenGL objects.
        /// 
        /// An OpenCL image object may be created from an OpenGL texture or renderbuffer object. 
        /// An OpenCL buffer object may be created from an OpenGL buffer object.
        /// 
        /// 
        /// OpenCL memory objects may be created from OpenGL objects if and only if the OpenCL context has been created from an 
        /// OpenGL share group object or context.
        /// OpenGL share groups and contexts are created using platform specific APIs such as EGL, CGL, WGL, and GLX.
        /// On MacOS X, an OpenCL context may be created from an OpenGL share group object using the OpenCL platform extension 
        /// cl_apple_gl_sharing.
        /// On other platforms including Microsoft Windows, Linux/Unix and others, an OpenCL context may be created from an 
        /// OpenGL context using the Khronos platform extension cl_khr_gl_sharing.
        /// Refer to the platform documentation for your OpenCL implementation, or visit the Khronos Registry at 
        /// https://www.khronos.org/registry/cl/ for more information.
        /// 
        /// 
        /// Any supported OpenGL object defined within the GL share group object, or the share group associated with the 
        /// GL context from which the CL context is created, may be shared, with the exception of the default OpenGL objects 
        /// (i.e.objects named zero), which may not be shared.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateFromGLRenderbuffer.html
        /// </summary>
        /// <param name="context">A valid OpenCL context created from an OpenGL context.</param>
        /// <param name="flags">
        /// A bit-field that is used to specify usage information. 
        /// Refer to the table at Create for a description of flags. 
        /// Only ReadOnly, WriteOnly, and ReadWrite values specified in the table at Create can be used.
        /// </param>
        /// <param name="renderbuffer">
        /// The name of a GL renderbuffer object. 
        /// The renderbuffer storage must be specified before the image object can be created. 
        /// The renderbuffer format and dimensions defined by OpenGL will be used to create the 2D image object. 
        /// Only GL renderbuffers with public formats that map to appropriate image channel order and data type specified in tables
        /// 5.5 and 5.6 (see CLImageFormat) can be used to create the 2D image object.
        /// </param>
        /// <param name="errcode_ret">
        /// Returns an appropriate error code as described below. If errcode_ret is NULL, no error code is returned.
        /// </param>
        /// <returns>
        /// Returns a valid non-zero OpenCL image object and errcode_ret is set to Success if the image object is 
        /// created successfully. Otherwise, it returns a NULL</returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateFromGLRenderbuffer", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLMemoryPtr CreateFromGLRenderbuffer(CLContextPtr   context,
                           CLMemoryFlags flags,
                           IntPtr renderbuffer,
                           [Out] out CLResult errcode_ret) ;

        /// <summary>
        /// Query an OpenGL object used to create an OpenCL memory object.
        /// 
        /// The OpenGL object used to create the OpenCL memory object and information about the object type 
        /// i.e. whether it is a texture, renderbuffer, or buffer object can be queried using this function.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetGLObjectInfo.html
        /// </summary>
        /// <param name="memobj"></param>
        /// <param name="GLObjectType">
        /// Returns the type of GL object attached to memobj and can be 
        /// Buffer, Texture2D, Texture3D, Texture2DArray, Texture1D, 
        /// Texture1DArray, TextureBuffer, or RenderBuffer. 
        /// If GLObjectType is NULL, it is ignored.
        /// </param>
        /// <param name="GLObjectName">Returns the GL object name used to create memobj. If GLObjectName is NULL, it is ignored.</param>
        /// <returns>Returns Success if the call was executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetGLObjectInfo", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult GetGLObjectInfo(CLMemoryPtr                memobj,
                  [Out] out CLGLObjectType    GLObjectType,
                  [Out] out uint           GLObjectName);

        /// <summary>
        /// Returns additional information about the GL texture object associated with a memory object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/GetGLTextureInfo.html
        /// </summary>
        /// <param name="memobj"></param>
        /// <param name="param_name">
        /// Specifies what additional information about the GL texture object associated with memobj to query. 
        /// The list of supported param_name types and the information returned in param_value by GetGLTextureInfo 
        /// is described in the table below (Table 9.5).</param>
        /// <param name="param_value_size">Specifies the size in bytes of memory pointed to by param_value. 
        /// This size must be ≥ size of return type as described in the table below.</param>
        /// <param name="param_value">A pointer to memory where the result being queried is returned. 
        /// If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// 
        /// Table 9.5:
        /// 
        /// CLGLTextureInfo      Return Type     Information returned in param_value
        /// TextureTarget    GLenum          The texture_target argument specified in CreateFromGLTexture.
        /// MipmapLevel      GLint           The miplevel argument specified in CreateFromGLTexture.
        /// NumberOfSamples       GLsizei         If the cl_khr_gl_msaa_sharing extension is supported,
        ///                                         the samples argument passed to glTexImage2DMultisample or glTexImage3DMultisample.
        ///                                         If image is not a MSAA texture, 1 is returned.
        /// </param>
        /// <returns>Returns Success if the function is executed successfully.</returns>
        [DllImport("opencl.dll", EntryPoint = "clGetGLTextureInfo", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult GetGLTextureInfo(CLMemoryPtr               memobj,
                   CLGLTextureInfo   param_name,
                   int               param_value_size,
                   [Out] out int               param_value,
                   [Out] out int             param_value_size_ret);

        /// <summary>
        /// Acquire OpenCL memory objects that have been created from OpenGL objects.
        /// 
        /// These objects need to be acquired before they can be used by any OpenCL commands queued to a command-queue. 
        /// The OpenGL objects are acquired by the OpenCL context associated with command_queue and can therefore be used by 
        /// all command-queues associated with the OpenCL context.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueAcquireGLObjects.html
        /// </summary>
        /// <param name="command_queue">A valid command-queue. 
        /// All devices used to create the OpenCL context associated with command_queue must support acquiring shared CL/GL objects. 
        /// This constraint is enforced at context creation time.</param>
        /// <param name="num_objects">The number of memory objects to be acquired in mem_objects.</param>
        /// <param name="mem_objects">A pointer to a list of CL memory objects that correspond to GL objects.</param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// Specify events that need to complete before this particular command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and 
        /// num_events_in_wait_list must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this command and can be used to query or queue a wait for the command to complete.
        /// event can be NULL in which case it will not be possible for the application to query the status of this
        /// command or queue a wait for this command to complete. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an element 
        /// of the event_wait_list array
        /// 
        /// If the cl_khr_gl_event extension is supported, if an OpenGL context is bound to the current thread, 
        /// then any OpenGL commands which affect or access the contents of a memory object listed in the mem_objects list, and
        /// were issued on that OpenGL context prior to the call to EnqueueAcquireGLObjects will complete before execution of any 
        /// OpenCL commands following the EnqueueAcquireGLObjects which affect or access any of those memory objects.
        /// If a non-NULL event object is returned, it will report completion only after completion of such OpenGL commands.
        /// 
        /// If the cl_khr_egl_event extension is supported, prior to calling EnqueueAcquireGLObjects, 
        /// the application must ensure that any pending EGL or EGL client API operations which access the objects specified
        /// in mem_objects have completed.
        /// </param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueAcquireGLObjects", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueAcquireGLObjects(CLCommandQueuePtr      command_queue,
                          uint               num_objects,
                          CLMemoryPtr []        mem_objects,
                          uint               num_events_in_wait_list,
                          CLEventPtr[]      event_wait_list,
                          [Out] out CLEventPtr evt);

        /// <summary>
        /// Release OpenCL memory objects that have been created from OpenGL objects.
        /// 
        /// See URL for more detailed documentation:
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueReleaseGLObjects.html
        /// </summary>
        /// <param name="command_queue">A valid command-queue.</param>
        /// <param name="num_objects">The number of memory objects to be released in mem_objects.</param>
        /// <param name="mem_objects">A pointer to a list of CL memory objects that correspond to GL objects.</param>
        /// <param name="num_events_in_wait_list"></param>
        /// <param name="event_wait_list">
        /// These parameters specify events that need to complete before this command can be executed. 
        /// If event_wait_list is NULL, then this particular command does not wait on any event to complete.
        /// If event_wait_list is NULL, num_events_in_wait_list must be 0.
        /// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and 
        /// num_events_in_wait_list must be greater than 0. 
        /// The events specified in event_wait_list act as synchronization points.
        /// </param>
        /// <param name="evt">
        /// Returns an event object that identifies this particular read/write command and can be used to query or queue a 
        /// wait for the command to complete. event can be NULL in which case it will not be possible for the application 
        /// to query the status of this command or queue a wait for this command to complete. 
        /// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an element 
        /// of the event_wait_list array.
        /// 
        /// If the cl_khr_gl_event extension is supported, if an OpenGL context is bound to the current thread, 
        /// then then any OpenGL commands which
        /// 
        /// affect or access the contents of the memory objects listed in the mem_objects list, and
        /// are issued on that context after the call to EnqueueReleaseGLObjects
        /// will not execute until after execution of any OpenCL commands preceding the EnqueueReleaseGLObjects which
        /// affect or access any of those memory objects.
        /// If a non-NULL event object is returned, it will report completion before execution of such OpenGL commands.
        ///     </param>
        /// <returns></returns>
        [DllImport("opencl.dll", EntryPoint = "clEnqueueReleaseGLObjects", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLResult EnqueueReleaseGLObjects(CLCommandQueuePtr      command_queue,
                          uint               num_objects,
                          CLMemoryPtr[]        mem_objects,
                          uint               num_events_in_wait_list,
                          CLEventPtr[]      event_wait_list,
                          [Out] out CLEventPtr evt);


        /* Deprecated OpenCL 1.1 APIs */

        /// <summary>
        /// Creates an OpenCL 2D image object from an OpenGL 2D texture object, or a single face of an OpenGL cubemap texture object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/CreateFromGLTexture2D.html
        /// </summary>
        /// <param name="context">A valid OpenCL context created from an OpenGL context.</param>
        /// <param name="flags">
        /// A bit-field that is used to specify usage information. 
        /// Refer to the table at Create for a description of flags. 
        /// Only ReadOnly, WriteOnly and ReadWrite values specified in the table at Create may be used.
        /// </param>
        /// <param name="target">
        /// Must be one of Texture2D, CubeMapPositiveX, CubeMapPositiveY, 
        /// CubeMapPositiveZ, CubeMapNegativeX, CubeMapNegativeY, 
        /// CubeMapNegativeZ, or Rectangle. 
        /// texture_target is used only to define the image type of texture. 
        /// No reference to a bound GL texture object is made or implied by this parameter.
        ///
        /// Using Rectangle for texture_target requires OpenGL 3.1. Alternatively, RectangleARB 
        /// may be specified if the OpenGL extension GL_ARB_texture_rectangle is supported.
        /// </param>
        /// <param name="miplevel">The mipmap level to be used. Implementations may return InvalidOperation for miplevel values greater than 0.</param>
        /// <param name="texture">
        /// The name of a GL 2D, cubemap or rectangle texture object. 
        /// The texture object must be a complete texture as per OpenGL rules on texture completeness. 
        /// The texture format and dimensions defined by OpenGL for the specified miplevel of the texture will be used to create the 
        /// 2D image object. Only GL texture objects with an public format that maps to appropriate image channel order and data type 
        /// specified in the table of supported Image Channel Order Values and the table of supported Image Channel Data Types at 
        /// CLImageFormat may be used to create a 2D image object.
        /// </param>
        /// <param name="errcode_ret">Success if the image object is created successfully.</param>
        /// <returns>
        /// Returns a valid non-zero OpenCL image object and errcode_ret is set to Success if the image object is created 
        /// successfully. Otherwise, it returns a NULL</returns>
        [Obsolete][DllImport("opencl.dll", EntryPoint = "clCreateFromGLTexture2D", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLMemoryPtr CreateFromGLTexture2D(CLContextPtr      context,
                        CLMemoryFlags    flags,
                        TextureTarget target,
                        int        miplevel,
                        IntPtr       texture,
                        [Out] out CLResult        errcode_ret);

        /// <summary>
        /// Creates an OpenCL 3D image object from an OpenGL 3D texture object.
        /// 
        /// Description
        /// If the state of a GL texture object is modified through the GL API(e.g.the OpenGL functions glTexImage2D or glTexImage3D, 
        /// or the values of the texture parameters GL_TEXTURE_BASE_LEVEL or GL_TEXTURE_MAX_LEVEL are modified) while there exists a 
        /// corresponding CL image object, subsequent use of the CL image object will result in undefined behavior.
        /// 
        /// Notes
        /// OpenCL 1.0 supports read-only 3D image memory objects.
        /// Writes to 3D image objects that are GL 3D textures are supported if the OpenCL implementation supports the 
        /// cl_khr_3d_image_writes extension. 3D images are optional in the embedded profile.
        /// If 3D images are not supported by the OpenCL embedded profile, the errcode_ret argument to CreateFromGLTexture3D 
        /// will return InvalidOperation.
              /// </summary>
              /// <param name="context">A valid OpenCL context created from an OpenGL 3D context.</param>
              /// <param name="flags">
              /// A bit-field that is used to specify usage information. Refer to the table at Create for a description of flags. 
              /// Only the valuesCL_MEM_READ_ONLY, WriteOnly and ReadWrite can be used.
              /// </param>
              /// <param name="target">texture_target is used only to define the image type of texture. 
              /// Must be Texture3D. No reference to a bound GL texture object is made or implied by this parameter.</param>
              /// <param name="miplevel">The mipmap level to be used.</param>
              /// <param name="texture">
              /// The name of a GL 3D texture object. 
              /// The texture object must be a complete texture as per OpenGL rules on texture completeness. 
              /// The texture format and dimensions defined by OpenGL for the specified miplevel of the texture will be used to create the 
              /// 3D image object. Only GL texture objects with an public format that maps to appropriate image channel order and 
              /// data type specified in the table of supported Image Channel Order Values and the table of supported Image Channel Data Types 
              /// at CLImageFormat can be used to create the 3D image object.
              /// </param>
              /// <param name="errcode_ret">Returns an appropriate error code as described below. If errcode_ret is NULL, no error code is returned.</param>
              /// <returns></returns>
        [Obsolete][DllImport("opencl.dll", EntryPoint = "clCreateFromGLTexture3D", CallingConvention = CallingConvention.Cdecl,  CharSet = CharSet.Ansi)]
        public static extern CLMemoryPtr CreateFromGLTexture3D(CLContextPtr      context,
                        CLMemoryFlags    flags,
                        TextureTarget target,
                        int        miplevel,
                        uint       texture,
                        [Out] out CLResult errcode_ret);


        /// <summary>
        /// Creates a 1D image, 1D image buffer, 1D image array, 2D image, 2D image array or 3D image object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/CreateImage.html
        /// </summary>
        /// <param name="context">A valid OpenCL context on which the image object is to be created.</param>
        /// <param name="flags">
        /// A bit-field that is used to specify allocation and usage information about the image memory object being 
        /// created and is described in the table below.
        /// 
        /// For all image types except Image1DBuffer, if value specified for flags is 0, 
        /// the default is used which is ReadWrite.
        /// 
        /// For Image1DBuffer image type, or an image created from another memory object (image or buffer), 
        /// if the ReadWrite, ReadOnly or WriteOnly values are not specified in flags, 
        /// they are inherited from the corresponding memory access qualifers associated with mem_object.
        /// The UseHostPointer, AllocateHostPointer and CopyHostPointer values cannot be specified in flags but are 
        /// inherited from the corresponding memory access qualifiers associated with mem_object.
        /// If CopyHostPointer is specified in the memory access qualifier values associated with mem_object 
        /// it does not imply any additional copies when the image is created from mem_object.
        /// If the HostWriteOnly, HostReadOnly or HostNoAccess values are not specified in flags, 
        /// they are inherited from the corresponding memory access qualifiers associated with mem_object.
        /// </param>
        /// <param name="image_format">
        /// A pointer to a structure that describes format properties of the image to be allocated. 
        /// See CLImageFormat for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_desc">
        /// A pointer to a structure that describes type and dimensions of the image to be allocated. See CLImageDescription for more information.
        /// </param>
        /// <param name="host_ptr">
        /// A pointer to the image data that may already be allocated by the application. 
        /// Refer to table below for a description of how large the buffer that host_ptr points to must be.
        /// 
        /// Image Type	                    Size of buffer that host_ptr points to
        /// Image1D	        ≥ RowPitch
        /// Image1DBuffer	≥ RowPitch
        /// Image2D	        ≥ RowPitch* Height
        /// Image3D	        ≥ SlicePitch* Depth
        /// Image1DArray	    ≥ SlicePitch* ArraySize
        /// Image2DArray	    ≥ SlicePitch* ArraySize
        /// </param>
        /// <param name="errcode_ret">Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.</param>
        /// <returns>returns a valid non-zero image object and errcode_ret is set to Success 
        /// if the image object is created successfully. Otherwise, it returns a NULL</returns>
        [DllImport("opencl.dll", EntryPoint = "clCreateImage", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLMemoryPtr CreateImage(CLContextPtr context,
                      CLMemoryFlags flags,
                      CLImageFormat image_format,
                      CLImageDescription image_desc,
                      IntPtr host_ptr,
                      [Out] out CLResult errcode_ret);

        /// <summary>
        /// Returns information about the event object.
        /// 
        /// Notes
        /// Using GetEventInfo to determine if a command identified by event has finished execution(i.e.CL_EVENT_COMMAND_EXECUTION_STATUS returns CL_COMPLETE) is not a synchronization point.There are no guarantees that the memory objects being modified by command associated with event will be visible to other enqueued commands.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/
        /// </summary>
        /// <param name="evt">Specifies the event object being queried.</param>
        /// <param name="param_name">Specifies the information to query.</param>
        /// <param name="param_value_size">Specifies the size in bytes of memory pointed to by param_value. This size must be ≥ size of the return type as described in the table below.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.</param>
        /// <param name="param_value_size_ret">Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.</param>
        /// <returns>
        /// Returns CL_SUCCESS if the function executed successfully. Otherwise, it returns one of the following errors:
        /// 
        /// CL_INVALID_VALUE if param_name is not valid, or if size in bytes specified by param_value_size is less than size of return type as described in the table above and param_value is not NULL.
        /// CL_INVALID_VALUE if information to query given in param_name cannot be queried for event.
        /// CL_INVALID_EVENT if event is not a valid event object.
        /// CL_OUT_OF_RESOURCES if there is a failure to allocate resources required by the OpenCL implementation on the device.
        /// CL_OUT_OF_HOST_MEMORY if there is a failure to allocate resources required by the OpenCL implementation on the host.
        /// </returns>
        [DllImport("opencl.dll", EntryPoint = "clGetEventInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CLResult GetEventInfo(CLEventPtr evt,
                       CLEventInfo param_name,
                       uint param_value_size,
                       byte[] param_value,
                       [Out] out uint param_value_size_ret);

        /// <summary>
        /// Returns information about the event object.
        /// 
        /// Notes
        /// Using GetEventInfo to determine if a command identified by event has finished execution(i.e.CL_EVENT_COMMAND_EXECUTION_STATUS returns CL_COMPLETE) is not a synchronization point.There are no guarantees that the memory objects being modified by command associated with event will be visible to other enqueued commands.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/
        /// </summary>
        /// <param name="evt">Specifies the event object being queried.</param>
        /// <param name="param_name">Specifies the information to query.</param>
        /// <param name="param_value">A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.</param>
        /// <returns>
        /// Returns CL_SUCCESS if the function executed successfully. Otherwise, it returns one of the following errors:
        /// 
        /// CL_INVALID_VALUE if param_name is not valid, or if size in bytes specified by param_value_size is less than size of return type as described in the table above and param_value is not NULL.
        /// CL_INVALID_VALUE if information to query given in param_name cannot be queried for event.
        /// CL_INVALID_EVENT if event is not a valid event object.
        /// CL_OUT_OF_RESOURCES if there is a failure to allocate resources required by the OpenCL implementation on the device.
        /// CL_OUT_OF_HOST_MEMORY if there is a failure to allocate resources required by the OpenCL implementation on the host.
        /// </returns>
        public static CLResult GetEventInfo(CLEventPtr evt,
                       CLEventInfo param_name,
                       out byte[] param_value)
        {
            param_value = null;
            uint num_entries = 0;
            CLResult result = GetEventInfo(evt, param_name, num_entries, param_value, out num_entries);
            if (result != CLResult.Success)
            {
                param_value = new byte[0];
                return result;
            }
            param_value = new byte[num_entries];
            result = GetEventInfo(evt, param_name, num_entries, param_value, out _);
            if (result != CLResult.Success)
            {
                param_value = new byte[0];
                return result;
            }

            param_value = new byte[num_entries]; // new string((char[])platformName);

            return result;
        }
    }
}