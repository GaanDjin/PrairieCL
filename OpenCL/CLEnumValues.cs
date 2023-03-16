using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieCL.OpenCL
{
    /// <summary>
    /// A List of results from OpenCL commands. 
    /// TODO: Build an exception list or just return these values and let the application decide?
    /// </summary>
    public enum CLResult : int
    {
        /// <summary>
        /// The operation completed successfully.
        /// </summary>
        Success = 0,
        /// <summary>
        /// if no devices that match device_type and property values specified in properties were found.
        /// </summary>
        DeviceNotFound = -1,
        /// <summary>
        /// if no devices that match device_type and property values specified in properties are currently available.
        /// </summary>
        DeviceNotAvailable = -2,
        /// <summary>
        /// program is created with CreateProgramWithSource and a compiler is not available 
        /// i.e. CompilerAvailable specified in the table of OpenCL Device Queries for GetDeviceInfo is set to CL_FALSE.
        /// </summary>
        CompilerNotAvailable = -3,
        /// <summary>
        /// if there is a failure to allocate memory for buffer object.
        /// </summary>
        MemoryObjectAllocationFailure = -4,
        /// <summary>
        /// if there is a failure to allocate resources required by the OpenCL implementation on the device.
        /// </summary>
        OutOfResources = -5,
        /// <summary>
        /// if there is a failure to allocate resources required by the OpenCL implementation on the host.
        /// </summary>
        OutOfHostMemory = -6,
        /// <summary>
        /// the ProfilingEnable flag is not set for the command-queue and if the profiling information is currently not available 
        /// (because the command identified by event has not completed)
        /// </summary>
        ProfilingInfoNotAvailable = -7,
        /// <summary>
        /// if src_buffer and dst_buffer are the same buffer or subbuffer object and the source and destination 
        /// regions overlap or if src_buffer and dst_buffer are different sub-buffers of the same associated buffer object 
        /// and they overlap. 
        /// The regions overlap if src_offset ≤ dst_offset ≤ src_offset + size - 1, 
        /// or if dst_offset ≤ src_offset ≤ dst_offset + size - 1.
        /// </summary>
        MemoryCopyOverlap = -8,
        /// <summary>
        /// src_image and dst_image do not use the same image format.
        /// </summary>
        ImageFormatMismatch = -9,
        /// <summary>
        /// the image_format is not supported.
        /// </summary>
        ImageFormatNotSupported = -10,
        /// <summary>
        /// there is a failure to build the program executable. 
        /// This error will be returned if BuildProgram does not return until the build has completed.
        /// </summary>
        BuildProgramFailure = -11,
        /// <summary>
        /// Returned by EnqueueMapBuffer and EnqueueMapImage if there is a failure to map the requested region into the host address space. 
        /// This error cannot occur for buffer objects created with UseHostPointer or AllocateHostPointer.
        /// </summary>
        MapFailure = -12,
        /// <summary>
        /// if buffer is a sub-buffer object and offset specified when the sub-buffer object is created is not 
        /// aligned to MemoryBaseAddressAlignment value for device associated with queue.
        /// </summary>
        MisalignedSubBufferOffset = -13,
        /// <summary>
        /// if the read and write operations are blocking and the execution status of any of 
        /// the events in event_wait_list is a negative integer value.
        /// </summary>
        ExecStatusErrorForEventsInWaitList = -14,
        /// <summary>
        /// there is a failure to compile the program source. This error will be returned if CompileProgram does not return until the compile has completed.
        /// </summary>
        CompileProgramFailure = -15,
        /// <summary>
        /// a linker is not available i.e. LinkerAvailable specified in the table of
        /// allowed values for param_name for GetDeviceInfo is set to false.
        /// </summary>
        LinkerNotAvailable = -16,
        /// <summary>
        /// there is a failure to link the compiled binaries and/or libraries.
        /// </summary>
        LinkProgramFailure = -17,
        /// <summary>
        /// if the partition name is supported by the implementation but in_device could not be further partitioned.
        /// </summary>
        DevicePartitionFailed = -18,
        /// <summary>
        /// the argument information is not available for kernel.
        /// </summary>
        KernelArgInfoNotAvailable = -19,
        /// <summary>
        /// if pfn_notify is NULL but user_data is not NULL.
        /// 
        /// if the 2D or 3D rectangular region specified by src_origin and src_origin + region refers to a region outside 
        /// src_image, or if the 2D or 3D rectangular region specified by dst_origin and dst_origin + region refers to a 
        /// region outside dst_image.
        /// 
        /// if values in src_origin, dst_origin and region do not follow rules described in the argument description for 
        /// src_origin, dst_origin and region.
        /// </summary>
        InvalidValue = -30,
        /// <summary>
        /// if device_type is not a valid value.
        /// </summary>
        InvalidDeviceType = -31,
        /// <summary>
        /// if properties is NULL and no platform could be selected or if platform value specified in properties is not a valid platform.
        /// If the cl_khr_gl_sharing extension is supported, this error is replaced (or not) by 
        /// CL_INVALID_GL_SHAREGROUP_REFERENCE_KHR and possibly InvalidOperation 
        /// (see below and section 9.5.4 of the spec for clarification).
        /// </summary>
        InvalidPlatform = -32,
        /// <summary>
        /// device is not in the list of devices associated with program.
        /// </summary>
        InvalidDevice = -33,
        /// <summary>
        /// if context is not a valid OpenCL context.
        /// </summary>
        InvalidContext = -34,
        /// <summary>
        /// Returned by CreateCommandQueue and clSetCommandQueueProperty if 
        /// specified properties are valid but are not supported by the device.
        /// </summary>
        InvalidQueueProperties = -35,
        /// <summary>
        /// if command_queue is not a valid command-queue.
        /// </summary>
        InvalidCommandQueue = -36,
        /// <summary>
        /// if host_ptr is NULL and UseHostPointer or CopyHostPointer are set in flags 
        /// or if host_ptr is not NULL but CopyHostPointer or UseHostPointer are not set in flags.
        /// </summary>
        InvalidHostPointer = -37,
        /// <summary>
        /// if memobj is a not a valid memory object.
        /// </summary>
        InvalidMemoryObject = -38,
        /// <summary>
        /// if values specified in image_format are not valid or if image_format is NULL.
        /// </summary>
        InvalidImageFormatDescriptor = -39,
        /// <summary>
        /// if Width or Height are 0 or if they exceed values specified in 
        /// Image2DMaxWidth or Image2DMaxHeight 
        /// respectively for all devices in context 
        /// or if values specified by RowPitch do not follow rules described in the argument description above.
        /// </summary>
        InvalidImageSize = -40,
        /// <summary>
        /// if sampler is not a valid sampler object.
        /// </summary>
        InvalidSampler = -41,
        /// <summary>
        /// program is created with CreateProgramWithBinary and devices listed in device_list do not have a valid program binary loaded.
        /// </summary>
        InvalidBinary = -42,
        /// <summary>
        /// the build options specified by options are invalid.
        /// </summary>
        InvalidBuildOptions = -43,
        /// <summary>
        /// program is a not a valid program object.
        /// </summary>
        InvalidProgram = -44,
        /// <summary>
        /// there is no successfully built executable for any device in program.
        /// </summary>
        InvalidProgramExecutable = -45,
        /// <summary>
        /// kernel_name is not found in program.
        /// </summary>
        InvalidKernelName = -46,
        /// <summary>
        /// the function definition for __kernel function given by kernel_name such as the number of arguments, 
        /// the argument types are not the same for all devices for which the program executable has been built.
        /// </summary>
        InvalidKernelDefinition = -47,
        /// <summary>
        /// kernel is not a valid kernel object.
        /// </summary>
        InvalidKernel = -48,
        /// <summary>
        /// arg_index is not a valid argument index.
        /// </summary>
        InvalidArgumentIndex = -49,
        /// <summary>
        /// arg_value specified is not a valid value.
        /// the argument is an image declared with the read_only qualifier and arg_value refers to an image object 
        /// created with CLMemoryFlags of CL_MEM_WRITE or if the image argument is declared with the write_only qualifier 
        /// and arg_value refers to an image object created with CLMemoryFlags of CL_MEM_READ.
        /// </summary>
        InvalidArgumentValue = -50,
        /// <summary>
        /// arg_size does not match the size of the data type for an argument that is not a memory object or if the argument is a 
        /// memory object and arg_size != sizeof(CLMemoryPtr) or if arg_size is zero and the argument is declared with the local qualifier 
        /// or if the argument is a sampler and arg_size != sizeof(CLSamplerPtr).
        /// </summary>
        InvalidArgumentSize = -51,
        /// <summary>
        /// the kernel argument values have not been specified or if a kernel argument declared 
        /// to be a pointer to a type does not point to a named address space.
        /// </summary>
        InvalidKernelArguments = -52,
        /// <summary>
        /// work_dim is not a valid value (i.e. a value between 1 and 3).
        /// </summary>
        InvalidWorkDimension = -53,
        /// <summary>
        /// local_work_size is specified and does not match the work-group size for kernel in the 
        /// program source given by the __attribute__ ((reqd_work_group_size(X, Y, Z))) qualifier.
        /// or
        /// local_work_size is specified and the total number of work-items in the work-group computed as 
        /// local_work_size[0] * … local_work_size[work_dim – 1] is greater than the value specified by 
        /// MaxWorkGroupSize in the table of OpenCL Device Queries for GetDeviceInfo.
        /// or
        /// local_work_size is NULL and the __attribute__ ((reqd_work_group_size(X, Y, Z))) qualifier 
        /// is used to declare the work-group size for kernel in the program source.
        /// or
        /// the program was compiled with –cl-uniform-work-group-size and the number of work-items 
        /// specified by global_work_size is not evenly divisible by size of work-group given by local_work_size.
        /// </summary>
        InvalidWorkGroupSize = -54,
        /// <summary>
        /// the number of work-items specified in any of local_work_size[0], ... local_work_size[work_dim - 1] 
        /// is greater than the corresponding values specified by MaxWorkGroupItemSizes[0], .... 
        /// MaxWorkGroupItemSizes[work_dim - 1].
        /// </summary>
        InvalidWorkItemSize = -55,
        /// <summary>
        /// the value specified in global_work_size + the corresponding values in global_work_offset for any 
        /// dimensions is greater than the sizeof(size_t) for the device on which the kernel execution will be enqueued.
        /// </summary>
        InvalidGlobalOffset = -56,
        /// <summary>
        ///  if event_wait_list is NULL and num_events_in_wait_list > 0, 
        ///  or event_wait_list is not NULL and num_events_in_wait_list is 0, 
        ///  or if event objects in event_wait_list are not valid events.
        /// </summary>
        InvalidEventWaitList = -57,
        /// <summary>
        /// event is not a valid event object.
        /// </summary>
        InvalidEvent = -58,
        /// <summary>
        /// if interoperability is specified by setting AdapterD3D9KHR, AdapterD3D9EXKHR or AdapterDXVAKHR to a non-NULL value, and interoperability with another graphics API is also specified. (only if the cl_khr_dx9_media_sharing extension is supported).
        /// if Direct3D 10 interoperability is specified by setting CL_INVALID_D3D10_DEVICE_KHR to a non-NULL value, and interoperability with another graphics API is also specified (if the cl_khr_d3d10_sharing extension is enabled).
        /// if Direct3D 11 interoperability is specified by setting CL_INVALID_D3D11_DEVICE_KHR to a non-NULL value, and interoperability with another graphics API is also specified. (only if the cl_khr_d3d11_sharing extension is supported).
        /// </summary>
        InvalidOperation = -59,
        /// <summary>
        /// if bufobj is not a GL buffer object or is a GL buffer object but does not have an existing data store.
        /// </summary>
        InvalidGLObject = -60,
        /// <summary>
        /// if size is 0.
        /// Implementations may return InvalidBufferSize if size is greater than the MaxMemoryAllocationSize value
        /// specified in the table of allowed values for param_name for GetDeviceInfo for all devices in context.
        /// </summary>
        InvalidBufferSize = -61,
        /// <summary>
        /// if miplevel is less than the value of levelbase (for OpenGL implementations) or zero (for OpenGL ES implementations); 
        /// or greater than the value of q (for both OpenGL and OpenGL ES). 
        /// levelbase and q are defined for the texture in section 3.8.10 (Texture Completeness) 
        /// of the OpenGL 2.1 specification and section 3.7.10 of the OpenGL ES 2.0.
        /// 
        /// if miplevel is greater than zero and the OpenGL implementation does not support creating from non-zero mipmap levels.
        /// </summary>
        InvalidMipLevel = -62,
        /// <summary>
        /// global_work_size is NULL, or if any of the values specified in global_work_size[0], ...global_work_size [work_dim - 1] 
        /// are 0 or exceed the range given by the sizeof(size_t) for the device on which the kernel execution will be enqueued.
        /// </summary>
        InvalidGlobalWorkSize = -63,
        /// <summary>
        /// if context property name in properties is not a supported property name, or if the value specified for a 
        /// supported property name is not valid, or if the same property name is specified more than once.
        /// </summary>
        InvalidProperty = -64,
        /// <summary>
        /// values specified in image_desc are not valid or if image_desc is NULL.
        /// </summary>
        InvalidImageDescriptor = -65,
        /// <summary>
        /// the compiler options specified by options are invalid.
        /// </summary>
        InvalidCompilerOptions = -66,
        /// <summary>
        /// the linker options specified by options are invalid
        /// </summary>
        InvalidLinkerOptions = -67,
        /// <summary>
        /// if the partition name specified in properties is ByCounts and the number of 
        /// sub-devices requested exceeds PartitionMaxSubDevices or the total number of compute 
        /// units requested exceeds CL_DEVICE_PARTITION_MAX_COMPUTE_UNITS for in_device, 
        /// or the number of compute units requested for one or more sub-devices is less than zero or the 
        /// number of sub-devices requested exceeds CL_DEVICE_PARTITION_MAX_COMPUTE_UNITS for in_device.
        /// </summary>
        InvalidDevicePartitionCount = -68,
        /// <summary>
        /// pipe_packet_size is 0 or the pipe_packet_size exceeds PipeMaxPacketSize value specified in table 4.3 
        /// (see GetDeviceInfo) for all devices in context or if pipe_max_packets is 0.
        /// </summary>
        InvalidPipeSize = -69,
        /// <summary>
        /// for an argument declared to be of type queue_t when the specified arg_value is not a valid device queue object.
        /// </summary>
        InvalidDeviceQueue = -70,
        /// <summary>
        /// the specified specialization constant ID is not valid for the specified program.
        /// </summary>
        InvalidSpecID = -71,
        /// <summary>
        /// the size of the specified kernel argument value exceeds the maximum size defined for the kernel argument.
        /// </summary>
        MaxSizeRestrictionExceeded = -72
    }

    public enum TextureTarget
    {
        /// <summary>
        /// A one-dimensional texture
        /// </summary>
        Texture1D = 0x0DE0,
        /// <summary>
        /// A one-dimensional array texture
        /// </summary>
        Texture1DArray = 0x8C18,
        /// <summary>
        /// a buffer texture
        /// </summary>
        Buffer = 0x8C2A,
        /// <summary>
        /// A two-dimensional texture
        /// </summary>
        Texture2D = 0x0DE1,
        /// <summary>
        /// A two-dimensional array texture
        /// </summary>
        Texture2DArray = 0x8C1A,
        /// <summary>
        /// A three-dimensional texture
        /// </summary>
        Texture3D = 0x806F,
        /// <summary>
        /// a cube-mapped texture
        /// </summary>
        CubeMapPositiveX = 0x8515,
        /// <summary>
        /// a cube-mapped texture
        /// </summary> 
        CubeMapPositiveY = 0x8517,
        /// <summary>
        /// a cube-mapped texture
        /// </summary> 
        CubeMapPositiveZ = 0x8519,
        /// <summary>
        /// a cube-mapped texture
        /// </summary> 
        CubeMapNegativeX = 0x8516,
        /// <summary>
        /// a cube-mapped texture
        /// </summary>
        CubeMapNegativeY = 0x8518,
        /// <summary>
        /// a cube-mapped texture
        /// </summary>
        CubeMapNegativeZ = 0x851A,
        /// <summary>
        /// A rectangle texture
        /// </summary>
        Rectangle = 0x84F5,
        /// <summary>
        /// may be specified if the OpenGL extension GL_ARB_texture_rectangle is supported; otherwise use Rectangle 
        /// </summary>
        RectangleARB = 0x84F5,
        //GL_ARB_texture_rectangle = 1,
        /// <summary>
        /// a two-dimensional multisampled texture
        /// </summary>
        Texture2DMultisample = 0x9100,
        /// <summary>
        /// a two-dimensional multisampled array texture
        /// </summary>
        Texture2DMultisampleArray = 0x9102
    }

    /// <summary>
    /// Specifies how out-of-range image coordinates are handled when reading from an image.
    /// </summary>
    public enum CLAddressingMode
    {
        /// <summary>
        /// Behavior is undefined for out-of-range image coordinates.
        /// </summary>
        None = 0x1130,
        /// <summary>
        /// Out-of-range image coordinates are clamped to the edge of the image.
        /// </summary>
        ClampToEdge = 0x1131,
        /// <summary>
        /// Out-of-range image coordinates are assigned a border color value.
        /// </summary>
        Clamp = 0x1132,
        /// <summary>
        /// Out-of-range image coordinates read from the image as-if the image data were replicated in all dimensions.
        /// </summary>
        Repeat = 0x1133,
        /// <summary>
        /// Out-of-range image coordinates read from the image as-if the image data were replicated in all
        /// dimensions, mirroring the image contents at the edge of each replication.
        /// </summary>
        MirroredRepeat = 0x1134
    }

    /// <summary>
    /// Describes the type of buffer object to be created.
    /// </summary>
    public enum CLBufferCreateType
    {
        /// <summary>
        /// Create a buffer object that represents a specific region in buffer.
        /// </summary>
        Region = 0x1220
    }

    /// <summary>
    /// Program Build Status
    /// </summary>
    public enum CLBuildStatus
    {
        /// <summary>
        /// The build status returned if BuildProgram, CompileProgram or clLinkProgram
        /// whichever was performed last on the specified program object for device was successful.
        /// </summary>
        Success = 0,
        /// <summary>
        /// The build status returned if no BuildProgram, CompileProgram or clLinkProgram 
        /// has been performed on the specified program object for device.
        /// </summary>
        None = -1,
        /// <summary>
        /// The build status returned if BuildProgram, CompileProgram or clLinkProgram 
        /// whichever was performed last on the specified program object for device generated an error.
        /// </summary>
        Error = -2,
        /// <summary>
        /// The build status returned if BuildProgram, CompileProgram or clLinkProgram 
        /// whichever was performed last on the specified program object for device has not finished.
        /// </summary>
        InProgress = -3
    }

    /// <summary>
    /// Specifies the number of channels and the channel layout i.e. the memory layout in which channels are stored in the image.
    /// </summary>
    public enum CLChannelOrder
    {
        A = 0x10B1,
        R = 0x10B0,
        RG = 0x10B2,
        RA = 0x10B3,
        /// <summary>
        /// This formats can only be used if channel data type = UnsignedNormalizedShort565, UnsignedNormalizedShort555 or UnsignedNormalizedInt101010.
        /// </summary>
        RGB = 0x10B4,
        RGBA = 0x10B5,
        /// <summary>
        /// This formats can only be used if channel data type = UnsignedNormalizedInt8, SignedNormalizedInt8, SignedInt8 or UnsignedInt8.
        /// </summary>
        BGRA = 0x10B6,
        /// <summary>
        /// This formats can only be used if channel data type = UnsignedNormalizedInt8, SignedNormalizedInt8, SignedInt8 or UnsignedInt8.
        /// </summary>
        ARGB = 0x10B7,
        /// <summary>
        /// This formats can only be used if channel data type = UnsignedNormalizedInt8, SignedNormalizedInt8, SignedInt8 or UnsignedInt8.
        /// </summary>
        ABGR = 0x10C3,
        /// <summary>
        /// This format can only be used if channel data type = UnsignedNormalizedInt8, UnsignedNormalizedInt16, SignedNormalizedInt8, SignedNormalizedInt16, HalfFloat, or Float.
        /// </summary>
        Intensity = 0x10B8,
        /// <summary>
        /// This format can only be used if channel data type = UnsignedNormalizedInt8, UnsignedNormalizedInt16, SignedNormalizedInt8, SignedNormalizedInt16, HalfFloat, or Float.
        /// </summary>
        Luminance = 0x10B9,
        /// <summary>
        /// This format can only be used if channel data type = UnsignedNormalizedInt16 or Float.
        /// </summary>
        Depth = 0x10BD,
        Rx = 0x10BA,
        RGx = 0x10BB,
        /// <summary>
        /// This formats can only be used if channel data type = UnsignedNormalizedShort565, UnsignedNormalizedShort555 or UnsignedNormalizedInt101010.
        /// </summary>
        RGBx = 0x10BC,
        /// <summary>
        /// This formats can only be used if channel data type = UnsignedNormalizedInt8.
        /// </summary>
        sRGB = 0x10BF,
        /// <summary>
        /// This formats can only be used if channel data type = UnsignedNormalizedInt8.
        /// </summary>
        sRGBx = 0x10C0,
        /// <summary>
        /// This formats can only be used if channel data type = UnsignedNormalizedInt8.
        /// </summary>
        sRGBA = 0x10C1,
        /// <summary>
        /// This formats can only be used if channel data type = UnsignedNormalizedInt8.
        /// </summary>
        sBGRA = 0x10C2,
        /// <summary>
        /// This format can only be used if channel data type = UnsignedNormalizedInt24 or Float (applies if the cl_khr_gl_depth_images extension is enabled).
        /// </summary>
        DepthStencil = 0x10BE
    }


    /// <summary>
    /// Describes the size of the channel data type. 
    /// The number of bits per element determined by the ChannelDataType and ChannelOrder must be a power of two.
    /// </summary>
    public enum CLChannelType
    {
        /// <summary>
        /// Each channel component is a normalized signed 8-bit integer value.
        /// </summary>
        SignedNormalizedInt8 = 0x10D0,
        /// <summary>
        /// Each channel component is a normalized signed 16-bit integer value.
        /// </summary>
        SignedNormalizedInt16 = 0x10D1,
        /// <summary>
        /// Each channel component is a normalized unsigned 8-bit integer value.
        /// </summary>
        UnsignedNormalizedInt8 = 0x10D2,
        /// <summary>
        /// Each channel component is a normalized unsigned 16-bit integer value.
        /// </summary>
        UnsignedNormalizedInt16 = 0x10D3,
        /// <summary>
        /// Represents a normalized 5-6-5 3-channel RGB image. The channel order must be RGB or RGBx.
        /// </summary>
        UnsignedNormalizedShort565 = 0x10D4,
        /// <summary>
        /// Represents a normalized x-5-5-5 4-channel xRGB image. The channel order must be RGB or RGBx.
        /// </summary>
        UnsignedNormalizedShort555 = 0x10D5,
        /// <summary>
        /// Represents a normalized x-10-10-10 4-channel xRGB image. The channel order must be RGB or RGBx.
        /// </summary>
        UnsignedNormalizedInt101010 = 0x10D6,
        /// <summary>
        /// Each channel component is an unnormalized signed 8-bit integer value.
        /// </summary>
        SignedInt8 = 0x10D7,
        /// <summary>
        /// Each channel component is an unnormalized signed 16-bit integer value.
        /// </summary>
        SignedInt16 = 0x10D8,
        /// <summary>
        /// Each channel component is an unnormalized signed 32-bit integer value.
        /// </summary>
        SignedInt32 = 0x10D9,
        /// <summary>
        /// Each channel component is an unnormalized unsigned 8-bit integer value.
        /// </summary>
        UnsignedInt8 = 0x10DA,
        /// <summary>
        /// Each channel component is an unnormalized unsigned 16-bit integer value.
        /// </summary>
        UnsignedInt16 = 0x10DB,
        /// <summary>
        /// Each channel component is an unnormalized unsigned 32-bit integer value.
        /// </summary>
        UnsignedInt32 = 0x10DC,
        /// <summary>
        /// Each channel component is a 16-bit half-float value.
        /// </summary>
        HalfFloat = 0x10DD,
        /// <summary>
        /// Each channel component is a single precision floating-point value.
        /// </summary>
        Float = 0x10DE, //(applies if the cl_khr_gl_depth_images extension is enabled)
        /// <summary>
        /// Each channel component is a normalized unsigned 24-bit integer value 
        /// (applies if the cl_khr_gl_depth_images extension is enabled).
        /// </summary>
        UnsignedNormalizedInt24 = 0x10DF//(applies if the cl_khr_gl_depth_images extension is enabled)
    }

    public enum CLCommandQueueInfo
    {
        /// <summary>
        /// Return type: CLContextPtr
        /// Return the context specified when the command-queue is created.
        /// </summary>
        Context = 0x1090,
        /// <summary>
        /// Return type: CLDevicePtr
        /// Return the device specified when the command-queue is created.
        /// </summary>
        Device = 0x1091,
        /// <summary>
        /// Return type: cl_uint
        /// Return the command-queue reference count.
        /// 
        /// The reference count returned with ReferenceCount should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </summary>
        ReferenceCount = 0x1092,

        /// <summary>
        /// Return type: CLCommandQueueProperties
        /// Return the currently specified properties for the command-queue. 
        /// These properties are specified by the value associated with the CL_COMMAND_QUEUE_PROPERTIES passed in 
        /// properties argument in CreateCommandQueueWithProperties.
        /// </summary>
        Properties = 0x1093,
        /// <summary>
        /// Specifies the size of the device queue in bytes.
        /// 
        /// This can only be specified if CL_QUEUE_ON_DEVICE is set in Properties. This must be a value ≤ QueueOnDeviceMaxSize.
        /// 
        /// For best performance, this should be ≤ QueueOnDevicePreferredSize.
        /// 
        /// If Size is not specified, the device queue is created with QueueOnDevicePreferredSize as the size of the queue.
        /// </summary>
        Size = 0x1094,
        /// <summary>
        /// The list is terminated with 0. (CreateCommandQueueWithProperties)
        /// </summary>
        EndOfList = 0
    }

    /// <summary>
    /// specifies the information to query from a command queue.
    /// </summary>
    public enum CLCommandQueueProperties
    {
        /// <summary>
        /// Determines whether the commands queued in the command-queue are executed in-order or out-of-order. 
        /// If set, the commands in the command-queue are executed out-of-order. 
        /// Otherwise, commands are executed in-order.
        /// </summary>
        OutOfOrderExecModeEnable = (1 << 0),
        /// <summary>
        /// Enable or disable profiling of commands in the command-queue. If set, the profiling of commands is enabled. 
        /// Otherwise profiling of commands is disabled. See GetEventProfilingInfo for more information.
        /// </summary>
        ProfilingEnable = (1 << 1),
        /// <summary>
        /// Use default settings for the command queue.
        /// Also needed at the end of the list in CreateCommandQueueWithProperties.
        /// </summary>
        Default = 0
    }

    /// <summary>
    /// The command type associated with event.
    /// </summary>
    public enum CLCommandType
    {
        /// <summary>
        /// Event Created By: EnqueueNDRangeKernel
        /// </summary>
        NDRangeKernel = 0x11F0,
        /// <summary>
        /// Event Created By: EnqueueNativeKernel
        /// </summary>
        NativeKernel = 0x11F2,
        /// <summary>
        /// Event Created By: EnqueueReadBuffer
        /// </summary>
        ReadBuffer = 0x11F3,
        /// <summary>
        /// Event Created By: EnqueueWriteBuffer
        /// </summary>
        WriteBuffer = 0x11F4,
        /// <summary>
        /// Event Created By: EnqueueCopyBuffer
        /// </summary>
        CopyBuffer = 0x11F5,
        /// <summary>
        /// Event Created By: EnqueueReadImage
        /// </summary>
        ReadImage = 0x11F6,
        /// <summary>
        /// Event Created By: EnqueueWriteImage
        /// </summary>
        WriteImage = 0x11F7,
        /// <summary>
        /// Event Created By: EnqueueCopyImage
        /// </summary>
        CopyImage = 0x11F8,
        /// <summary>
        /// Event Created By: EnqueueCopyImageToBuffer
        /// </summary>
        CopyImageToBuffer = 0x11F9,
        /// <summary>
        /// Event Created By: EnqueueCopyBufferToImage
        /// </summary>
        CopyBufferToImage = 0x11FA,
        /// <summary>
        /// Event Created By: EnqueueMapBuffer
        /// </summary>
        MapBuffer = 0x11FB,
        /// <summary>
        /// Event Created By: EnqueueMapImage
        /// </summary>
        MapImage = 0x11FC,
        /// <summary>
        /// Event Created By: EnqueueUnmapMemObject
        /// </summary>
        UnmapMemoryObject = 0x11FD,
        /// <summary>
        /// Event Created By: EnqueueMarker or clEnqueueMarkerWithWaitList
        /// </summary>
        Marker = 0x11FE,
        /// <summary>
        /// Event Created By: EnqueueAcquireGLObjects
        /// </summary>
        AquireGLObjects = 0x11FF,
        /// <summary>
        /// Event Created By: EnqueueReleaseGLObjects
        /// </summary>
        ReleaseGLObjects = 0x1200,
        /// <summary>
        /// Event Created By: clEnqueueReadBufferRect
        /// </summary>
        ReadBufferRectangle = 0x1201,
        /// <summary>
        /// Event Created By: clEnqueueWriteBufferRect
        /// </summary>
        WriteBufferRectangle = 0x1202,
        /// <summary>
        /// Event Created By: clEnqueueCopyBufferRect
        /// </summary>
        CopyBufferRectangle = 0x1203,
        /// <summary>
        /// Event Created By: clCreateUserEvent
        /// </summary>
        User = 0x1204,
        /// <summary>
        /// Event Created By: clEnqueueBarrier or clEnqueueBarrierWithWaitList
        /// </summary>
        Barrier = 0x1205,
        /// <summary>
        /// Event Created By: clEnqueueMigrateMemObjects
        /// </summary>
        MigrateMemoryObjects = 0x1206,
        /// <summary>
        /// Event Created By: clEnqueueFillBuffer
        /// </summary>
        FillBuffer = 0x1207,
        /// <summary>
        /// Event Created By: clEnqueueFillImage
        /// </summary>
        FillImage = 0x1208,
        /// <summary>
        /// Event Created By: clEnqueueSVMFree
        /// </summary>
        SVMFree = 0x1209,
        /// <summary>
        /// Event Created By: clEnqueueSVMMemcpy
        /// </summary>
        SVMMemoryCopy = 0x120A,
        /// <summary>
        /// Event Created By: clEnqueueSVMMemFill
        /// </summary>
        SVMMemoryFill = 0x120B,
        /// <summary>
        /// Event Created By: clEnqueueSVMMap
        /// </summary>
        SVMMap = 0x120C,
        /// <summary>
        /// Event Created By: clEnqueueSVMUnmap
        /// </summary>
        SVMUnmap = 0x120D,
        /// <summary>
        /// If cl_khr_gl_event  is enabled, indicating that the event is associated with a 
        /// GL sync object, rather than an OpenCL command
        /// </summary>
        GLFenceSyncObjectKHR = 0x200D,
        /// <summary>
        /// Event Created By: if cl_khr_egl_event is enabled
        /// </summary>
        EGLFenceSyncObjectKHR = 0x202F,
        /// <summary>
        /// Event Created By: if cl_khr_d3d10_sharing is enabled
        /// </summary>
        AquireD3D10ObjectsKHR = 0x4017,
        /// <summary>
        /// Event Created By: if cl_khr_d3d10_sharing is enabled
        /// </summary>
        ReleaseD3D10ObjectsKHR = 0x4018,
        /// <summary>
        /// Event Created By: if  cl_khr_d3d11_sharing is enabled
        /// </summary>
        AquireD3D11ObjectsKHR = 0x4020,
        /// <summary>
        /// Event Created By: if  cl_khr_d3d11_sharing is enabled
        /// </summary>
        ReleaseD3D11ObjectsKHR = 0x4021,
        /// <summary>
        /// Event Created By: if cl_khr_dx9_media_sharing is enabled
        /// </summary>
        AquireDX9MediaSurfacesKHR = 0x202B,
        /// <summary>
        /// Event Created By: if cl_khr_dx9_media_sharing is enabled
        /// </summary>
        ReleaseDX9MediaSurfacesKHR = 0x202C
    }

    /// <summary>
    /// An enumeration constant that specifies the information to query about a CL context.
    /// </summary>
    public enum CLContextInfo
    {
        /// <summary>
        /// Return the context reference count. The reference count returned should be considered immediately stale. 
        /// It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </summary>
        ReferenceCount = 0x1080,
        /// <summary>
        /// Return the list of devices in context.
        /// </summary>
        Devices = 0x1081,
        /// <summary>
        /// Return the properties argument specified in CreateContext or CreateContextFromType.
        /// If the properties argument specified in CreateContext or CreateContextFromType used to create context is not NULL, 
        /// the implementation must return the values specified in the properties argument.
        /// 
        /// If the properties argument specified in CreateContext or CreateContextFromType used to create context is NULL, 
        /// the implementation may return either a param_value_size_ret of 0, 
        /// i.e. there is no context property value to be returned or can return a context property value of 0 
        ///     (where 0 is used to terminate the context properties list) in the memory that param_value points to.
        /// </summary>
        Properties = 0x1082,
        /// <summary>
        /// Return the number of devices in context.
        /// </summary>
        NumberOfDevices = 0x1083,
        /*
         * If the cl_khr_d3d10_sharing extension is enabled, returns CL_TRUE if Direct3D 10 resources created as shared by 
         * setting MiscFlags to include D3D10_RESOURCE_MISC_SHARED will perform faster when shared with OpenCL, 
         * compared with resources which have not set this flag. Otherwise returns CL_FALSE.
         */
        //CL_CONTEXT_D3D10_PREFER_S0x1083HARED_RESOURCES_KHR = ,
        /// <summary>
        /// If the cl_khr_d3d11_sharing extension is enabled, returns CL_TRUE if Direct3D 11 resources created as shared by 
        /// setting MiscFlags to include D3D11_RESOURCE_MISC_SHARED will perform faster when shared with OpenCL, 
        /// compared with resources which have not set this flag. Otherwise returns CL_FALSE.
        /// </summary>
        D3D11PreferSharedResourcesKHR = 0x402D
    }

    /// <summary>
    /// A list of context property names and their corresponding values. Each property name is immediately followed by the corresponding desired value. The list is terminated with 0. properties can be NULL in which case the platform that is selected is implementation-defined. The list of supported properties is described in the table below.
    /// If the extension cl_khr_dx9_media_sharing is enabled, then properties specifies a list of context property names 
    /// and their corresponding values.Each property is followed immediately by the corresponding desired value.
    /// The list is terminated with zero.If a property is not specified in properties, then its default value
    /// (listed in the table below) is used (it is said to be specified implicitly). 
    /// If properties is NULL or empty(points to a list whose first value is zero), all attributes take on their default values.
    /// 
    /// If the extension cl_khr_d3d10_sharing is enabled, then properties specifies a list of context property names 
    /// and their corresponding values.Each property is followed immediately by the corresponding desired value.
    /// The list is terminated with zero. if a property is not specified in properties, then its default value is used
    /// (it is said to be specified implicitly). 
    /// If properties is NULL or empty (points to a list whose first value is zero), all attributes take on their default value.
    /// 
    ///  If the extension cl_khr_d3d11_sharing is enabled, then properties specifies a list of context property names 
    ///  and their corresponding values.Each property is followed immediately by the corresponding desired value.
    ///  The list is terminated with zero.If a property is not specified in properties, then its default value is used 
    ///  (it is said to be specified implicitly). 
    ///  If properties is NULL or empty (points to a list whose first value is zero), all attributes take on their default value.
    /// 
    /// If the extension cl_khr_gl_sharing is enabled, then properties points to an attribute list, 
    /// which is a array of ordered<attribute name, value> pairs terminated with zero.
    /// If an attribute is not specified in properties, then its default value is used (it is said to be specified implicitly). 
    /// If properties is NULL or empty (points to a list whose first value is zero), all attributes take on their default values.
    /// </summary>
    public enum CLContextProperties
    {
        None = 0,
        /// <summary>
        /// Specifies the platform to use.
        /// </summary>
        Platform = 0x1084,
        /// <summary>
        /// Specifies whether the user is responsible for synchronization between OpenCL and other APIs. Please refer to the specific sections in the OpenCL 2.0 extension specification that describe sharing with other APIs for restrictions on using this flag. If InteropUserSync is not specified, a default of CL_FALSE is assumed.
        /// </summary>
        InteropUserSync = 0x1085,
        /// <summary>
        /// OpenGL context to associated the OpenCL context with (available if the cl_khr_gl_sharing extension is enabled)
        /// </summary>
        GLContextKHR = 0x2008,
        /// <summary>
        /// EGLDisplay an OpenGL context was created with respect to (available if the cl_khr_gl_sharing extension is enabled)
        /// </summary>
        EGLDisplayKHR = 0x2009,
        /// <summary>
        /// X Display an OpenGL context was created with respect to (available if the cl_khr_gl_sharing extension is enabled)
        /// </summary>
        GLXDisplayKHR = 0x200A,
        /// <summary>
        /// HDC an OpenGL context was created with respect to (available if the cl_khr_gl_sharing extension is enabled)
        /// </summary>
        WGLHDCKHR = 0x200B,
        /// <summary>
        /// CGL share group to associate the OpenCL context with (available if the cl_khr_gl_sharing extension is enabled)
        /// </summary>
        CGLSharegroupKHR = 0x200C,
        /// <summary>
        /// Specifies the ID3D10Device * to use for Direct3D 10 interoperability. The default value is NULL (applies if the extension cl_khr_d3d10_sharing is supported)
        /// </summary>
        D3D10DeviceKHR = 0x4014,
        /// <summary>
        /// Specifies the ID3D11Device * to use for Direct3D 11 interoperability. The default value is NULL. (Applies if the cl_khr_d3d11_sharing extension is supported.)
        /// </summary>
        D3D11DeviceKHR = 0x401D,
        /// <summary>
        /// Specifies an IDirect3DDevice9 to use for D3D9 interop (applies if the cl_khr_dx9_media_sharing extension is supported)
        /// </summary>
        AdapterD3D9KHR = 0x2025,
        /// <summary>
        /// Specifies an IDirect3DDevice9Ex to use for D3D9 interop (applies if the cl_khr_dx9_media_sharing extension is supported)
        /// </summary>
        AdapterD3D9EXKHR = 0x2026,
        /// <summary>
        /// Specifies an IDXVAHD_Device to use for DXVA interop (applies if the cl_khr_dx9_media_sharing extension is supported)
        /// </summary>
        AdapterDXVAKHR = 0x2027,
        /// <summary>
        /// Describes which memory types for the context must be initialized. 
        /// This is a bit-field, where the following values are currently supported:
        /// CL_CONTEXT_MEMORY_INITIALIZE_LOCAL_KHR - Initialize local memory to zeros.
        /// CL_CONTEXT_MEMORY_INITIALIZE_PRIVATE_KHR - Initialize private memory to zeros.
        /// (applies if the cl_khr_initialize_memory extension is supported)
        /// </summary>
        MemoryInitializeKHR = 0x2030,
        /// <summary>
        /// Specifies whether the context can be terminated. 
        /// The default value is CL_FALSE. (applies if the cl_khr_terminate_context extension is supported)
        /// </summary>
        TerminateKHR = 0x2032
    }

    /// <summary>
    /// Specifies the set of devices to return
    /// </summary>
    public enum CLD3D10DeviceSetKHR
    {
        /// <summary>
        /// The OpenCL devices associated with the specified Direct3D object.
        /// </summary>
        PreferredDevicesForD3D10KHR = 0x4012,
        /// <summary>
        /// All OpenCL devices which may interoperate with the specified Direct3D object.
        /// Performance of sharing data on these devices may be considerably less than on the preferred devices.
        /// </summary>
        AllDevicesForD3D10KHR = 0x4013
    }

    /// <summary>
    /// Type of d3d_object
    /// </summary>
    public enum CLD3D10DeviceSourceKHR
    {
        /// <summary>
        /// ID3D10Device *
        /// </summary>
        DeviceKHR = 0x4010,
        /// <summary>
        /// IDXGIAdapter *
        /// </summary>
        DXGIAdapterKHR = 0x4011
    }

    /// <summary>
    /// Specifies the set of devices to return,
    /// </summary>
    public enum CLD3D11DeviceSetKHR
    {
        /// <summary>
        /// The OpenCL devices associated with the specified Direct3D object.
        /// </summary>
        PreferredDevicesForD3D11KHR = 0x401B,
        /// <summary>
        /// All OpenCL devices which may interoperate with the specified Direct3D object. 
        /// Performance of sharing data on these devices may be considerably less than on the preferred devices.
        /// </summary>
        AllDevicesForD3D11KHR = 0x401C
    }

    /// <summary>
    /// Specifies the type of d3d_object
    /// </summary>
    public enum CLD3D11DeviceSourceKHR
    {
        /// <summary>
        /// ID3D11Device *
        /// </summary>
        DeviceKHR = 0x4019,
        /// <summary>
        /// IDXGIAdapter *
        /// </summary>
        DXGIAdapterKHR = 0x401A
    }

    /// <summary>
    /// Split the device into smaller aggregate devices containing one or more compute units that all share part of a cache hierarchy.
    /// </summary>
    public enum CLDeviceAffinityDomain
    {
        /// <summary>
        /// Split the device into sub-devices comprised of compute units that share a NUMA node.
        /// </summary>
        Numa = (1 << 0),
        /// <summary>
        /// Split the device into sub-devices comprised of compute units that share a level 4 data cache.
        /// </summary>
        L4Cache = (1 << 1),
        /// <summary>
        /// Split the device into sub-devices comprised of compute units that share a level 3 data cache.
        /// </summary>
        L3Cache = (1 << 2),
        /// <summary>
        /// Split the device into sub-devices comprised of compute units that share a level 2 data cache.
        /// </summary>
        L2Cache = (1 << 3),
        /// <summary>
        /// Split the device into sub-devices comprised of compute units that share a level 1 data cache.
        /// </summary>
        L1Cache = (1 << 4),
        /// <summary>
        /// Split the device along the next partitionable affinity domain.
        /// The implementation shall find the first level along which the device or sub-device may be further 
        /// subdivided in the order NUMA, L4, L3, L2, L1, 
        /// and partition the device into sub-devices comprised of compute units that share memory subsystems at this level.
        /// 
        /// The user may determine what happened by calling GetDeviceInfo (PartitionType) on the sub-devices.
        /// </summary>
        NextPartitionable = (1 << 5)
    }

    /// <summary>
    /// Describes the execution capabilities of the device.
    /// </summary>
    public enum CLDeviceExecCapabilities
    {
        /// <summary>
        /// The OpenCL device can execute OpenCL kernels.
        /// </summary>
        Kernel = (1 << 0),
        /// <summary>
        /// The OpenCL device can execute native kernels.
        /// </summary>
        NativeKernel = (1 << 1)
    }

    /// <summary>
    /// Describes double precision floating-point capability of the OpenCL device.
    /// </summary>
    public enum CLDeviceFPConfig
    {
        /// <summary>
        /// Denorms are supported.
        /// </summary>
        Denorm = (1 << 0),
        /// <summary>
        /// INF and NaNs are supported.
        /// </summary>
        InfinityAndNaNs = (1 << 1),
        /// <summary>
        /// Round to nearest even rounding mode supported.
        /// </summary>
        RoundToNearest = (1 << 2),
        /// <summary>
        /// Round to zero rounding mode supported.
        /// </summary>
        RoundToZero = (1 << 3),
        /// <summary>
        /// Round to positive and negative infinity rounding modes supported.
        /// </summary>
        RoundToInfinity = (1 << 4),
        /// <summary>
        /// IEEE754-2008 fused multiply-add is supported.
        /// </summary>
        FusedMultiplyAdd = (1 << 5),
        /// <summary>
        /// Basic floating-point operations (such as addition, subtraction, multiplication) are implemented in software.
        /// </summary>
        SoftwareFloats = (1 << 6),
        /// <summary>
        /// Divide and sqrt are correctly rounded as defined by the IEEE754 specification.
        /// </summary>
        CorrectlyRoundedDivideAndSqrt = (1 << 7)
    }

    /// <summary>
    /// Information about a specified device
    /// </summary>Maximum
    public enum CLDeviceInfo
    {
        /// <summary>
        /// The OpenCL device type. 
        /// Currently supported values are: 
        /// CPU, 
        /// GPU, 
        /// Accelerator, 
        /// Default, 
        /// a combination of the above types, 
        /// or Custom.
        /// </summary>
        Type = 0x1000,
        /// <summary>
        /// A unique device vendor identifier. An example of a unique device identifier could be the PCIe ID.
        /// </summary>
        VendorID = 0x1001,
        /// <summary>
        /// The number of parallel compute units on the OpenCL device. 
        /// A work-group executes on a single compute unit. The minimum value is 1.
        /// </summary>
        MaxComputeUnits = 0x1002,
        /// <summary>
        /// Maximum dimensions that specify the global and local work-item IDs used by the data parallel execution model. 
        /// (Refer to EnqueueNDRangeKernel). The minimum value is 3 for devices that are not of type Custom.
        /// </summary>
        MaxWorkItemDimensions = 0x1003,
        /// <summary>
        /// Maximum number of work-items in a work-group executing a kernel on a single compute unit, using the data parallel execution model.
        /// (Refer to EnqueueNDRangeKernel). The minimum value is 1.
        /// </summary>
        MaxWorkGroupSize = 0x1004,
        /// <summary>
        /// Maximum number of work-items that can be specified in each dimension of the work-group to EnqueueNDRangeKernel.
        /// Returns n size_t entries, where n is the value returned by the query for MaxWorkItemDimensions.
        /// The minimum value is (1, 1, 1) for devices that are not of type Custom.
        /// </summary>
        MaxWorkGroupItemSizes = 0x1005,
        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// 
        /// If double precision is not supported, PreferredVectorWidthDouble must return 0.
        /// 
        /// If the cl_khr_fp16 extension is not supported, PreferredVectorWidthHalf must return 0.
        /// </summary>
        PreferredVectorWidthChar = 0x1006,
        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// 
        /// If double precision is not supported, PreferredVectorWidthDouble must return 0.
        /// 
        /// If the cl_khr_fp16 extension is not supported, PreferredVectorWidthHalf must return 0.
        /// </summary>
        PreferredVectorWidthShort = 0x1007,
        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// 
        /// If double precision is not supported, PreferredVectorWidthDouble must return 0.
        /// 
        /// If the cl_khr_fp16 extension is not supported, PreferredVectorWidthHalf must return 0.
        /// </summary>
        PreferredVectorWidthInt = 0x1008,
        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// 
        /// If double precision is not supported, PreferredVectorWidthDouble must return 0.
        /// 
        /// If the cl_khr_fp16 extension is not supported, PreferredVectorWidthHalf must return 0.
        /// </summary>
        PreferredVectorWidthLong = 0x1009,
        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// 
        /// If double precision is not supported, PreferredVectorWidthDouble must return 0.
        /// 
        /// If the cl_khr_fp16 extension is not supported, PreferredVectorWidthHalf must return 0.
        /// </summary>
        PreferredVectorWidthFloat = 0x100A,
        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// 
        /// If double precision is not supported, PreferredVectorWidthDouble must return 0.
        /// 
        /// If the cl_khr_fp16 extension is not supported, PreferredVectorWidthHalf must return 0.
        /// </summary>
        PreferredVectorWidthDouble = 0x100B,
        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// 
        /// If double precision is not supported, PreferredVectorWidthDouble must return 0.
        /// 
        /// If the cl_khr_fp16 extension is not supported, PreferredVectorWidthHalf must return 0.
        /// </summary>
        PreferredVectorWidthHalf = 0x1034,
        /// <summary>
        /// Maximum configured clock frequency of the device in MHz.
        /// </summary>
        MaxClockFrequency = 0x100C,
        /// <summary>
        /// The default compute device address space size of the global address space specified as an unsigned integer value in bits. Currently supported values are 32 or 64 bits.
        /// </summary>
        AddressBits = 0x100D,
        /// <summary>
        /// Max number of image objects arguments of a kernel declared with the read_only qualifier.
        /// The minimum value is 128 if ImageSupport is CL_TRUE.
        /// </summary>
        MaxReadImageArgs = 0x100E,
        /// <summary>
        /// Max number of image objects arguments of a kernel declared with the write_only qualifier. 
        /// The minimum value is 64 if ImageSupport is CL_TRUE. 
        /// NOTE: 
        /// MaxWriteImageArgs is only there for backward compatibility. 
        /// MaxReadWriteImageArgs should be used instead.
        /// </summary>
        MaxWriteImageArgs = 0x100F,
        /// <summary>
        /// Max number of image objects arguments of a kernel declared with the write_only or read_only qualifier. 
        /// The minimum value is 64 if ImageSupport is CL_TRUE.
        /// </summary>
        MaxReadWriteImageArgs = 0x104C,
        /// <summary>
        /// Max size of memory object allocation in bytes. 
        /// The minimum value is max(min(1024*1024*1024, 1/4th of GlobalMemorySize), 128*1024*1024) 
        /// for devices that are not of type Custom.
        /// </summary>
        MaxMemoryAllocationSize = 0x1010,
        /// <summary>
        /// Max width of 2D image or 1D image not created from a buffer object in pixels. The minimum value is 16384 if ImageSupport is CL_TRUE.
        /// </summary>
        Image2DMaxWidth = 0x1011,
        /// <summary>
        /// Max height of 2D image in pixels. The minimum value is 16384 if ImageSupport is CL_TRUE.
        /// </summary>
        Image2DMaxHeight = 0x1012,
        /// <summary>
        /// Max width of 3D image in pixels. The minimum value is 2048 if ImageSupport is CL_TRUE.
        /// </summary>
        Image3DMaxWidth = 0x1013,
        /// <summary>
        /// Max height of 3D image in pixels. The minimum value is 2048 if ImageSupport is CL_TRUE.
        /// </summary>
        Image3DMaxHeight = 0x1014,
        /// <summary>
        /// Max depth of 3D image in pixels. The minimum value is 2048 if ImageSupport is CL_TRUE.
        /// </summary>
        Image3DMaxDepth = 0x1015,
        /// <summary>
        /// Is CL_TRUE if images are supported by the OpenCL device and CL_FALSE otherwise.
        /// </summary>
        ImageSupport = 0x1016,
        /// <summary>
        /// Max size in bytes of all arguments that can be passed to a kernel. 
        /// The minimum value is 1024 for devices that are not of type Custom. 
        /// For this minimum value, only a maximum of 128 arguments can be passed to a kernel.
        /// </summary>
        MaxParameterSize = 0x1017,
        /// <summary>
        /// Maximum number of samplers that can be used in a kernel.
        /// The minimum value is 16 if ImageSupport is CL_TRUE. (Also see sampler_t.)
        /// </summary>
        MaxSamplers = 0x1018,
        /// <summary>
        /// The row pitch alignment size in pixels for 2D images created from a buffer. The value returned must be a power of 2. If the device does not support images, this value must be 0.
        /// </summary>
        ImagePitchAlignment = 0x104A,
        /// <summary>
        /// This query should be used when a 2D image is created from a buffer which was created using UseHostPointer. The value returned must be a power of 2. This query specifies the minimum alignment in pixels of the host_ptr specified to Create. If the device does not support images, this value must be 0.
        /// </summary>
        ImageBaseAddressAlignment = 0x104B,
        /// <summary>
        /// The maximum number of pipe objects that can be passed as arguments to a kernel. The minimum value is 16.
        /// </summary>
        MaxPipeArguments = 0x1055,
        /// <summary>
        /// The maximum number of reservations that can be active for a pipe per work-item in a kernel. 
        /// A work-group reservation is counted as one reservation per work-item. The minimum value is 1.
        /// </summary>
        MaxActiveReservations = 0x1056,
        /// <summary>
        /// The maximum size of pipe packet in bytes. The minimum value is 1024 bytes.
        /// </summary>
        PipeMaxPacketSize = 0x1057,
        /// <summary>
        /// The minimum value is the size (in bits) of the largest OpenCL built-in data type supported by the device 
        /// (long16 in FULL profile, long16 or int16 in EMBEDDED profile) for devices that are not of type Custom.
        /// </summary>
        MemoryBaseAddressAlignment = 0x1019,
        MinDataTypeAlignmentSize = 0x101A,
        /// <summary>
        /// Describes single precision floating-point capability of the device. This is a bit-field that describes one or more of the following values:
        ///
        /// Denorm - denorms are supported
        /// InfinityAndNaNs - INF and quiet NaNs are supported
        /// RoundToNearest - round to nearest even rounding mode supported
        /// RoundToZero - round to zero rounding mode supported
        /// RoundToInfinity - round to +ve and -ve infinity rounding modes supported
        /// FusedMultiplyAdd - IEEE754-2008 fused multiply-add is supported
        /// CorrectlyRoundedDivideAndSqrt - divide and sqrt are correctly rounded as defined by the IEEE754 specification.
        /// SoftwareFloats - Basic floating-point operations (such as addition, subtraction, multiplication) are implemented in software.
        /// 
        /// The mandated minimum floating-point capability for devices that are not of type Custom is RoundToNearest | InfinityAndNaNs.
        /// </summary>
        SingleFPConfig = 0x101B,
        /// <summary>
        /// Type of global memory cache supported. Valid values are: None, ReadOnlyCache, and ReadWriteCache.
        /// </summary>
        GlobalMemoryCacheType = 0x101C,
        /// <summary>
        /// Size of global memory cache line in bytes.
        /// </summary>
        GlobalMemoryCachelineSize = 0x101D,
        /// <summary>
        /// Size of global memory cache in bytes.
        /// </summary>
        GlobalMemoryCacheSize = 0x101E,
        /// <summary>
        /// Size of global device memory in bytes.
        /// </summary>
        GlobalMemorySize = 0x101F,
        /// <summary>
        /// Max size in bytes of a constant buffer allocation. 
        /// The minimum value is 64 KB for devices that are not of type Custom.
        /// </summary>
        MaxConstantBufferSize = 0x1020,
        /// <summary>
        /// Max number of arguments declared with the __constant qualifier in a kernel. 
        /// The minimum value is 8 for devices that are not of type Custom.
        /// </summary>
        MaxConstantArguments = 0x1021,
        /// <summary>
        /// The maximum number of bytes of storage that may be allocated for any single variable in program scope or inside a 
        /// function in OpenCL C declared in the global address space. 
        /// This value is also provided inside OpenCL C as a preprocessor macro by the same name. The minimum value is 64 KB.
        /// </summary>
        MaxGlobalVariableSize = 0x104D,
        /// <summary>
        /// Maximum preferred total size, in bytes, of all program variables in the global address space. This is a performance hint. An implementation may place such variables in storage with optimized device access. This query returns the capacity of such storage. The minimum value is 0.
        /// </summary>
        GlobablVariablePreferredTotalSize = 0x1054,
        /// <summary>
        /// Type of local memory supported. This can be set to Local implying dedicated local memory storage such as SRAM, or Global. 
        /// For custom devices, None can also be returned indicating no local memory support.
        /// </summary>
        LocalMemoryType = 0x1022,
        /// <summary>
        /// Size of local memory region in bytes. 
        /// The minimum value is 32 KB for devices that are not of type Custom.
        /// </summary>
        LocalMemorySize = 0x1023,
        /// <summary>
        /// Is CL_TRUE if the device implements error correction for all accesses to compute device memory (global and constant). Is CL_FALSE if the device does not implement such error correction.
        /// </summary>
        ErrorCorrectionSupport = 0x1024,
        /// <summary>
        /// Describes the resolution of device timer. This is measured in nanoseconds.
        /// </summary>
        ProfilingTimerResolution = 0x1025,
        /// <summary>
        /// Is CL_TRUE if the OpenCL device is a little endian device and CL_FALSE otherwise.
        /// </summary>
        EndianLittle = 0x1026,
        /// <summary>
        /// Is CL_TRUE if the device is available and CL_FALSE otherwise. A device is considered to be available if the device can be expected to successfully execute commands enqueued to the device
        /// </summary>
        Available = 0x1027,
        /// <summary>
        /// Is CL_FALSE if the implementation does not have a compiler available to compile the program source. Is CL_TRUE if the compiler is available. This can be CL_FALSE for the embedded platform profile only.
        /// </summary>
        CompilerAvailable = 0x1028,
        /// <summary>
        /// Describes the execution capabilities of the device. This is a bit-field that describes one or more of the following values:
        /// Kernel - The OpenCL device can execute OpenCL kernels.
        /// NativeKernel - The OpenCL device can execute native kernels.
        /// The mandated minimum capability is Kernel.
        /// </summary>
        ExecutionCapabilities = 0x1029,
        /// <summary>
        /// Describes the on host command-queue properties supported by the device. 
        /// This is a bit-field that describes one or more of the following values:
        /// 
        /// OutOfOrderExecModeEnable
        /// 
        /// ProfilingEnable
        /// 
        /// These properties are described in the table for CreateCommandQueueWithProperties. 
        /// The mandated minimum capability is ProfilingEnable.
        /// </summary>
        QueueOnHostProperties = 0x102A,
        /// <summary>
        /// Describes the on device command-queue properties supported by the device. 
        /// This is a bit-field that describes one or more of the following values:
        /// 
        /// OutOfOrderExecModeEnable
        /// 
        /// ProfilingEnable
        /// 
        /// These properties are described in the table for CreateCommandQueueWithProperties. 
        /// The mandated minimum capability is OutOfOrderExecModeEnable | ProfilingEnable.
        /// </summary>
        QueueOnDeviceProperties = 0x104E,
        /// <summary>
        /// The size of the device queue in bytes preferred by the implementation. 
        /// Applications should use this size for the device queue to ensure good performance. The minimum value is 16 KB.
        /// </summary>
        QueueOnDevicePreferredSize = 0x104F,
        /// <summary>
        /// The max. size of the device queue in bytes. 
        /// The minimum value is 256 KB for the full profile and 64 KB for the embedded profile
        /// </summary>
        QueueOnDeviceMaxSize = 0x1050,
        /// <summary>
        /// The maximum number of device queues that can be created per context. The minimum value is 1.
        /// </summary>
        MaxOnDeviceQueues = 0x1051,
        /// <summary>
        /// The maximum number of events in use by a device queue. 
        /// These refer to events returned by the enqueue_ built-in functions to a device queue or user events returned by the 
        /// create_user_event built-in function that have not been released. The minimum value is 1024.
        /// </summary>
        MaxOnDeviceEvents = 0x1052,
        /// <summary>
        /// Device name string.
        /// </summary>
        Name = 0x102B,
        /// <summary>
        /// Vendor name string.
        /// </summary>
        Vendor = 0x102C,
        /// <summary>
        /// OpenCL software driver version string in the form major_number.minor_number.
        /// </summary>
        DriverVersion = 0x102D,
        /// <summary>
        /// OpenCL profile string. Returns the profile name supported by the device (see note). 
        /// The profile name returned can be one of the following strings:
        /// 
        /// FULL_PROFILE - if the device supports the OpenCL specification (functionality defined as part of the 
        /// core specification and does not require any extensions to be supported).
        /// 
        /// EMBEDDED_PROFILE - if the device supports the OpenCL embedded profile.
        /// 
        /// The platform profile returns the profile that is implemented by the OpenCL framework. 
        /// If the platform profile returned is FULL_PROFILE, the OpenCL framework will support devices that are 
        /// FULL_PROFILE and may also support devices that are EMBEDDED_PROFILE. 
        /// The compiler must be available for all devices i.e. CompilerAvailable is CL_TRUE. 
        /// If the platform profile returned is EMBEDDED_PROFILE, then devices that are only EMBEDDED_PROFILE are supported.
        /// </summary>
        Profile = 0x102E,
        /// <summary>
        /// OpenCL version string. Returns the OpenCL version supported by the device. This version string has the following format:
        /// OpenCL<space><major_version.minor_version><space><vendor-specific information>
        /// The major_version.minor_version value returned will be 2.0.
        /// </summary>
        Version = 0x102F,
        /// <summary>
        /// Returns a space separated list of extension names (the extension names themselves do not contain any spaces) supported by the device. The list of extension names returned can be vendor supported extension names and one or more of the following Khronos approved extension names:
        /// 
        /// cl_khr_int64_base_atomics
        /// cl_khr_int64_extended_atomics
        /// cl_khr_fp16
        /// cl_khr_gl_sharing
        /// cl_khr_gl_event
        /// cl_khr_d3d10_sharing
        /// cl_khr_dx9_media_sharing
        /// cl_khr_d3d11_sharing
        /// cl_khr_gl_depth_images
        /// cl_khr_gl_msaa_sharing
        /// cl_khr_initialize_memory
        /// cl_khr_context_abort
        /// cl_khr_spir
        /// cl_khr_srgb_image_writes
        /// 
        /// The following approved Khronos extension names must be returned by all device that support OpenCL C 2.0:
        /// 
        /// cl_khr_byte_addressable_store
        /// cl_khr_fp64 (for backward compatibility if double precision is supported)
        /// cl_khr_3d_image_writes
        /// cl_khr_image2d_from_buffer
        /// cl_khr_depth_images
        /// 
        /// Please refer to the OpenCL 2.0 Extension Specification for a detailed description of these extensions.
        /// </summary>
        Extensions = 0x1030,
        /// <summary>
        /// The platform associated with this device.
        /// </summary>
        Platform = 0x1031,
        /// <summary>
        /// Describes double precision floating-point capability of the OpenCL device. This is a bit-field that describes one or more of the following values:
        /// Denorm - denorms are supported.
        /// InfinityAndNaNs - INF and NaNs are supported.
        /// RoundToNearest - round to nearest even rounding mode supported.
        /// RoundToZero - round to zero rounding mode supported.
        /// RoundToInfinity - round to positive and negative infinity rounding modes supported.
        /// FusedMultiplyAdd - IEEE754-2008 fused multiply-add is supported.
        /// SoftwareFloats - Basic floating-point operations (such as addition, subtraction, multiplication) are implemented in software.
        /// Double precision is an optional feature so the mandated minimum double precision floating-point capability is 0.
        /// 
        /// If double precision is supported by the device, then the minimum double precision floating-point capability must be: FusedMultiplyAdd | RoundToNearest | InfinityAndNaNs | Denorm.
        /// 
        /// GetDeviceInfo Return type: cl_device_ - fp_config
        /// </summary>
        DoubleFPConfig = 0x1032,
        [Obsolete]
        HostUnifiedMemory = 0x1035, //(deprecated)
        /// <summary>
        /// Returns the native ISA vector width. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// If double precision is not supported, NativeVectorWidthDouble must return 0.
        /// If the cl_khr_fp16 extension is not supported, NativeVectorWidthHalf must return 0.
        /// </summary>
        NativeVectorWidthChar = 0x1036,
        /// <summary>
        /// Returns the native ISA vector width. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// If double precision is not supported, NativeVectorWidthDouble must return 0.
        /// If the cl_khr_fp16 extension is not supported, NativeVectorWidthHalf must return 0.
        /// </summary>
        NativeVectorWidthShort = 0x1037,
        /// <summary>
        /// Returns the native ISA vector width. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// If double precision is not supported, NativeVectorWidthDouble must return 0.
        /// If the cl_khr_fp16 extension is not supported, NativeVectorWidthHalf must return 0.
        /// </summary>
        NativeVectorWidthInt = 0x1038,
        /// <summary>
        /// Returns the native ISA vector width. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// If double precision is not supported, NativeVectorWidthDouble must return 0.
        /// If the cl_khr_fp16 extension is not supported, NativeVectorWidthHalf must return 0.
        /// </summary>
        NativeVectorWidthLong = 0x1039,
        /// <summary>
        /// Returns the native ISA vector width. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// If double precision is not supported, NativeVectorWidthDouble must return 0.
        /// If the cl_khr_fp16 extension is not supported, NativeVectorWidthHalf must return 0.
        /// </summary>
        NativeVectorWidthFloat = 0x103A,
        /// <summary>
        /// Returns the native ISA vector width. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// If double precision is not supported, NativeVectorWidthDouble must return 0.
        /// If the cl_khr_fp16 extension is not supported, NativeVectorWidthHalf must return 0.
        /// </summary>
        NativeVectorWidthDouble = 0x103B,
        /// <summary>
        /// Returns the native ISA vector width. The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// If double precision is not supported, NativeVectorWidthDouble must return 0.
        /// If the cl_khr_fp16 extension is not supported, NativeVectorWidthHalf must return 0.
        /// </summary>
        NativeVectorWidthHalf = 0x103C,
        /// <summary>
        /// OpenCL C version string. Returns the highest OpenCL C version supported by the compiler for this device that is not of type Custom. This version string has the following format:
        /// 
        /// OpenCL<space>C<space><major_version.minor_version><space><vendor-specific information>
        /// </summary>
        OpenCLVersion = 0x103D,
        /// <summary>
        /// Is CL_FALSE if the implementation does not have a linker available. 
        /// Is CL_TRUE if the linker is available. 
        /// This can be CL_FALSE for the embedded platform profile only. 
        /// This must be CL_TRUE if CompilerAvailable is CL_TRUE
        /// </summary>
        LinkerAvailable = 0x103E,
        /// <summary>
        /// A semi-colon separated list of built-in kernels supported by the device. An empty string is returned if no built-in kernels are supported by the device.
        /// </summary>
        BuiltInKernels = 0x103F,
        /// <summary>
        /// Max number of pixels for a 1D image created from a buffer object. The minimum value is 65536 if ImageSupport is CL_TRUE.
        /// </summary>
        ImageMaxBufferSize = 0x1040,
        /// <summary>
        /// Max number of images in a 1D or 2D image array. The minimum value is 2048 if ImageSupport is CL_TRUE
        /// </summary>
        ImageMaxArraySize = 0x1041,
        /// <summary>
        /// Returns the CLDevicePtr of the parent device to which this sub-device belongs. 
        /// If device is a root-level device, a NULL value is returned.
        /// </summary>
        ParentDevice = 0x1042,
        /// <summary>
        /// Returns the maximum number of sub-devices that can be created when a device is partitioned. 
        /// The value returned cannot exceed MaxComputeUnits.
        /// </summary>
        PartitionMaxSubDevices = 0x1043,
        /// <summary>
        /// Returns the list of partition types supported by device. This is an array of CLDevicePartitionProperty values drawn from the following list:
        /// Equally
        /// ByCounts
        /// ByAffinityDomain
        /// If the device cannot be partitioned (i.e. there is no partitioning scheme supported by the device that will return at least two subdevices), a value of 0 will be returned.
        /// </summary>
        PartitionProperties = 0x1044,
        /// <summary>
        /// Returns the list of supported affinity domains for partitioning the device using ByAffinityDomain. This is a bit-field that describes one or more of the following values:
        /// Numa
        /// L4Cache
        /// L3Cache
        /// L2Cache
        /// L1Cache
        /// NextPartitionable
        /// If the device does not support any affinity domains, a value of 0 will be returned.
        /// </summary>
        PartitionAffinityDomain = 0x1045,
        /// <summary>
        /// Returns the properties argument specified in clCreateSubDevices if device is a subdevice. 
        /// In the case where the properties argument to clCreateSubDevices is ByAffinityDomain,
        /// NextPartitionable, the affinity domain used to perform the partition will be returned. 
        /// This can be one of the following values:
        /// Numa
        /// L4Cache
        /// L3Cache
        /// L2Cache
        /// L1Cache
        /// Otherwise the implementation may either return a param_value_size_ret of 0 
        /// i.e. there is no partition type associated with device or can return a property value of 0 
        /// (where 0 is used to terminate the partition property list) in the memory that param_value points to.
        /// </summary>
        PartitionType = 0x1046,
        /// <summary>
        /// Returns the device reference count. If the device is a root-level device, a reference count of one is returned.
        /// </summary>
        ReferenceCount = 0x1047,
        /// <summary>
        /// Describes the various shared virtual memory (a.k.a. SVM) memory allocation types the device supports. Coarse-grain SVM allocations are required to be supported by all OpenCL 2.0 devices. This is a bit-field that describes a combination of the following values:
        /// CourseGrainBuffer – Support for coarse-grain buffer sharing using clSVMAlloc. Memory consistency is guaranteed at synchronization points and the host must use calls to EnqueueMapBuffer and EnqueueUnmapMemObject.
        /// FineGrainBuffer – Support for fine-grain buffer sharing using clSVMAlloc. Memory consistency is guaranteed atsynchronization points without need for EnqueueMapBuffer and EnqueueUnmapMemObject.
        /// FineGrainSystem – Support for sharing the host’s entire virtual memory including memory allocated using malloc. Memory consistency is guaranteed at synchronization points.
        /// Atomics – Support for the OpenCL 2.0 atomic operations that provide memory consistency across the host and all OpenCL devices supporting fine-grain SVM allocations.
        /// 
        /// The mandated minimum capability is CourseGrainBuffer.
        /// </summary>
        SVMCapabilities = 0x1053,
        /// <summary>
        /// Returns the value representing the preferred alignment in bytes for OpenCL 2.0 fine-grained SVM atomic types. 
        /// This query can return 0 which indicates that the preferred alignment is aligned to the natural size of the type.
        /// </summary>
        PreferredPlatformAtomicAlignment = 0x1058,
        /// <summary>
        /// Returns the value representing the preferred alignment in bytes for OpenCL 2.0 atomic types to global memory. 
        /// This query can return 0 which indicates that the preferred alignment is aligned to the natural size of the type.
        /// </summary>
        PreferredGlobalAtomicAlignment = 0x1059,
        /// <summary>
        /// Returns the value representing the preferred alignment in bytes for OpenCL 2.0 atomic types to local memory. 
        /// This query can return 0 which indicates that the preferred alignment is aligned to the natural size of the type.
        /// </summary>
        PreferredLocalAtomicAlignment = 0x105A,
        /// <summary>
        /// Is CL_TRUE if the device's preference is for the user to be responsible for synchronization, 
        /// when sharing memory objects between OpenCL and other APIs such as DirectX, CL_FALSE if the device / implementation 
        /// has a performant path for performing synchronization of memory object shared between OpenCL and other APIs 
        /// such as DirectX
        /// </summary>
        PreferredInteropUserSync = 0x1048,
        /// <summary>
        /// Maximum size in bytes of the internal buffer that holds the output of printf calls from a kernel. 
        /// The minimum value for the FULL profile is 1 MB.
        /// </summary>
        PrintfBufferSize = 0x1049,
        /// <summary>
        /// Undocumented?
        /// </summary>
        HalfFPConfig = 0x1033,
        /// <summary>
        /// If the cl_khr_terminate_context extension is enabled, describes the termination capability of the OpenCL device. 
        /// This is a bitfield where a value of CL_DEVICE_TERMINATE_CAPABILITY_CONTEXT_KHR indicates that context 
        /// termination is supported.
        /// </summary>
        TerminateCapabilityKHR = 0x2031,
        /// <summary>
        /// If the cl_khr_spir extension is enabled, a space separated list of SPIR versions supported by the device. 
        /// For example returning “1.2 2.0” in this query implies that SPIR version 1.2 and 2.0 are supported by the implementation.
        /// </summary>
        SPIRVersions = 0x40E0
    }

    /// <summary>
    /// Type of local memory supported.
    /// </summary>
    public enum CLDeviceLocalMemoryType
    {
        /// <summary>
        /// Dedicated global memory storage such as SRAM
        /// </summary>
        Global = 0x2,
        /// <summary>
        /// Dedicated local memory storage such as SRAM
        /// </summary>
        Local = 0x1,
        /// <summary>
        /// no local memory support
        /// </summary>
        None = 0x0
    }

    /// <summary>
    /// Type of global memory cache supported.
    /// </summary>
    public enum CLDeviceMemoryCacheType
    {
        /// <summary>
        /// No global cache memory
        /// </summary>
        None = 0x0,
        /// <summary>
        /// Read only global cache
        /// </summary>
        ReadOnlyCache = 0x1,
        /// <summary>
        /// Read & Write global cache
        /// </summary>
        ReadWriteCache = 0x2
    }

    /// <summary>
    /// partition types supported by device.
    /// </summary>
    public enum CLDevicePartitionProperty
    {
        /// <summary>
        /// Split the aggregate device into as many smaller aggregate devices as can be created, each containing n compute units. 
        /// The value n is passed as the value accompanying this property.
        /// </summary>
        Equally = 0x1086,
        /// <summary>
        /// This property is followed by a list of compute unit counts terminated with ByCountsListEnd. 
        /// For each non-zero count m in the list, a sub-device is created with m compute units in it.
        /// </summary>
        ByCounts = 0x1087,
        /// <summary>
        /// End of the list
        /// </summary>
        ByCountsListEnd = 0x0,
        /// <summary>
        /// Split the device into smaller aggregate devices containing one or more compute units that all share part of a cache hierarchy.
        /// </summary>
        ByAffinityDomain = 0x1088,

        None = 0
    }

    /// <summary>
    /// Describes the various shared virtual memory (a.k.a. SVM) memory allocation types the device supports. 
    /// Coarse-grain SVM allocations are required to be supported by all OpenCL 2.0 devices.
    /// 
    /// The mandated minimum capability is CourseGrainBuffer.
    /// </summary>
    public enum CLDeviceSVMCapabilities
    {
        /// <summary>
        /// Support for coarse-grain buffer sharing using clSVMAlloc. 
        /// Memory consistency is guaranteed at synchronization points and the host must use calls to 
        /// EnqueueMapBuffer and EnqueueUnmapMemObject.
        /// </summary>
        CourseGrainBuffer =   (1 << 0),
        /// <summary>
        /// Support for fine-grain buffer sharing using clSVMAlloc. 
        /// Memory consistency is guaranteed atsynchronization points without need for EnqueueMapBuffer and EnqueueUnmapMemObject.
        /// </summary>
        FineGrainBuffer =   (1 << 1),
        /// <summary>
        /// Support for sharing the host’s entire virtual memory including memory allocated using malloc. 
        /// Memory consistency is guaranteed at synchronization points.
        /// </summary>
        FineGrainSystem =   (1 << 2),
        /// <summary>
        /// Support for the OpenCL 2.0 atomic operations that provide memory consistency across the
        /// host and all OpenCL devices supporting fine-grain SVM allocations.
        /// </summary>
        Atomics =   (1 << 3)
    }

    /// <summary>
    /// The device_type can be used to query specific OpenCL devices or all OpenCL devices available.
    /// </summary>
    public enum CLDeviceType : ulong
    {
        /// <summary>
        /// The default OpenCL device in the system. The default device cannot be a Custom device.
        /// </summary>
        Default = (1 << 0),
        /// <summary>
        /// An OpenCL device that is the host processor. The host processor runs the OpenCL implementations and is a single or multi-core CPU.
        /// </summary>
        CPU = (1 << 1),
        /// <summary>
        /// An OpenCL device that is a GPU. By this we mean that the device can also be used to accelerate a 3D API such as OpenGL or DirectX.
        /// </summary>
        GPU = (1 << 2),
        /// <summary>
        /// Dedicated OpenCL accelerators (for example the IBM CELL Blade). These devices communicate with the host processor using a peripheral interconnect such as PCIe.
        /// </summary>
        Accelerator = (1 << 3),
        /// <summary>
        /// Dedicated accelerators that do not support programs written in OpenCL C.
        /// </summary>
        Custom = (1 << 4),
        /// <summary>
        /// All OpenCL devices available in the system except Custom devices.
        /// </summary>
        All = 0xFFFFFFFF
    }

    /// <summary>
    /// specifies the information to query from clGetEventInfo
    /// </summary>
    public enum CLEventInfo
    {
        /// <summary>
        /// Return the command-queue associated with event. For user event objects, a NULL value is returned.
        /// </summary>
        CommandQueue = 0x11D0,
        /// <summary>
        /// Return the command associated with event.
        /// </summary>
        CommandType = 0x11D1,
        /// <summary>
        /// Return the event reference count.
        /// </summary>
        ReferenceCount = 0x11D2,
        /// <summary>
        /// Return the execution status of the command identified by event.
        /// </summary>
        ExecutionStatus = 0x11D3,
        /// <summary>
        /// Return the execution status of the command identified by event. The valid values are:
        /// CL_QUEUED (0x3) - command has been enqueued in the command-queue,
        /// CL_SUBMITTED (0x2) - enqueued command has been submitted by the host to the device associated with the command-queue,
        /// CL_RUNNING (0x1) - device is currently executing this command,
        /// CL_COMPLETE (0x0) - the command has completed, or
        /// Error code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.) These error codes come from the same set of error codes that are returned from the platform or runtime API calls as return values or errcode_ret values.
        /// The error code values are negative, and event state values are positive. The event state values are ordered from the largest value (CL_QUEUED) for the first or initial state to the smallest value (CL_COMPLETE or negative integer value) for the last or complete state. The value of CL_COMPLETE and CL_SUCCESS are the same.
        /// If the cl_khr_gl_event extension is enabled, the status of a linked event is either CL_SUBMITTED, indicating that the fence command associated with the sync object has not yet completed, or CL_COMPLETE, indicating that the fence command has completed.
        /// If the cl_khr_egl_event extension is enabled, the status of a linked event is either CL_SUBMITTED, indicating that the fence command associated with the sync object has not yet completed, or CL_COMPLETE, indicating that the fence command has completed.
        /// </summary>
        CommandExecutionStatus = 0x11D3,

        /// <summary>
        /// Return the context associated with event.
        /// </summary>
        Context = 0x11D4
    }

    /// <summary>
    /// Specifies the type of filter that is applied when reading an image.
    /// </summary>
    public enum CLFilterMode
    {
        /// <summary>
        /// Returns the image element nearest to the image coordinate.
        /// </summary>
        Nearest = 0x1140,
        /// <summary>
        /// Returns a weighted average of the four image elements nearest to the image coordinate.
        /// </summary>
        Linear = 0x1141
    }

    /// <summary>
    /// The actual size in bytes of data being queried by clGetGLContextInfoKHR 
    /// </summary>
    public enum CLGLContextInfo
    {
        /// <summary>
        /// CLDevicePtr
        /// 
        /// Return the CL device currently associated with the specified OpenGL context.
        /// </summary>
        CurrentDeviceForGLContextKHR = 0x2006,
        /// <summary>
        /// CLDevicePtr[]	
        /// 
        /// List of all CL devices which may be associated with the specified OpenGL context.
        /// </summary>
        DevicesForGLContextKHR = 0x2007
    }
   
    /// <summary>
    /// 
    /// </summary>
    public enum CLGLObjectType
    {
        Buffer = 0x2000,
        Texture2D = 0x2001,
        Texture3D = 0x2002,
        RenderBuffer = 0x2003,
        Texture2DArray = 0x200E,
        Texture1D = 0x200F,
        Texture1DArray = 0x2010,
        TextureBuffer = 0x2011,
        Undefined = 0
    }

    /// <summary>
    /// 
    /// </summary>
    public enum CLGLTextureInfo
    {
        /// <summary>
        /// The texture_target argument specified in CreateFromGLTexture.
        /// </summary>
        TextureTarget = 0x2004,
        /// <summary>
        /// The miplevel argument specified in CreateFromGLTexture.
        /// </summary>
        MipmapLevel = 0x2005,
        /// <summary>
        /// If the cl_khr_gl_msaa_sharing extension is supported, the samples argument passed to 
        /// glTexImage2DMultisample or glTexImage3DMultisample. 
        /// If image is not a MSAA texture, 1 is returned.
        /// </summary>
        NumberOfSamples = 0x2012
    }

    /// <summary>
    /// Specifies the information to query. 
    /// </summary>
    public enum CLImageInfo
    {
        /// <summary>
        /// Return image format descriptor specified when image is created with CreateImage.
        /// 
        /// CLImageFormat	
        /// </summary>
        Format = 0x1110,
        /// <summary>
        /// Return size of each element of the image memory object given by image in bytes. 
        /// An element is made up of n channels. 
        /// The value of n is given in CLImageFormat descriptor.
        /// 
        /// size_t	
        /// </summary>
        ElementSize = 0x1111,
        /// <summary>
        /// Return calculated row pitch in bytes of a row of elements of the image object given by image.
        /// 
        /// size_t	
        /// </summary>
        RowPitch = 0x1112,
        /// <summary>
        /// Return calculated slice pitch in bytes of a 2D slice for the 3D image object or size of each image in a 
        /// 1D or 2D image array given by image. For a 1D image, 1D image buffer and 2D image object return 0.
        /// 
        /// size_t	
        /// </summary>
        SlicePitch = 0x1113,
        /// <summary>
        /// Return width of image in pixels.
        /// 
        /// size_t	
        /// </summary>
        Width = 0x1114,
        /// <summary>
        /// Return height of image in pixels. For a 1D image, 1D image buffer and 1D image array object, height = 0.
        /// 
        /// size_t	
        /// </summary>
        Height = 0x1115,
        /// <summary>
        /// Return depth of the image in pixels. For a 1D image, 1D image buffer, 2D image or 1D and 2D image array object, depth = 0.
        /// 
        /// size_t	
        /// </summary>
        Depth = 0x1116,
        /// <summary>
        /// Return number of images in the image array. If image is not an image array, 0 is returned.
        /// 
        /// size_t	
        /// </summary>
        ArraySize = 0x1117,
        /// <summary>
        /// deprecated
        /// </summary>
        [Obsolete]
        Buffer = 0x1118,
        /// <summary>
        /// Return NumberOfMipLevels associated with image.
        /// 
        /// cl_uint	
        /// </summary>
        NumberOfMipLevels = 0x1119,
        /// <summary>
        /// Return NumberOfSamples associated with image.
        /// 
        /// uint
        /// </summary>
        NumberOfSamples = 0x111A,
        /// <summary>
        /// (if the cl_khr_d3d10_sharing extension is enabled) 
        /// If image was created using clCreateFromD3D10Texture2DKHR or clCreateFromD3D10Texture3DKHR, 
        /// returns the subresource argument specified when image was created.
        /// 
        /// D3D10Resource *
        /// </summary>
        D3D10SubresourceKHR = 0x4016,
        /// <summary>
        /// If the cl_khr_d3d11_sharing extension is suported, If image was created using clCreateFromD3D11Texture2DKHR, 
        /// or clCreateFromD3D11Texture3DKHR, returns the subresource argument specified when image was created.
        /// 
        /// ID3D11Resource *
        /// </summary>
        D3D11SubresourceKHR = 0x401F,
        /// <summary>
        /// Returns the plane argument value specified when memobj is created using clCreateFromDX9MediaSurfaceKHR. 
        /// (If the cl_khr_dx9_media_sharing extension is supported)
        /// 
        /// uint
        /// </summary>
        DX9MediaPlaneKHR = 0x202A
    }

    /// <summary>
    /// Argument address space used
    /// </summary>
    public enum CLKernelArgumentAddressQualifier
    {
        /// <summary>
        /// Globabl address space
        /// </summary>
        Global = 0x119B,
        /// <summary>
        /// Local address space
        /// </summary>
        Local = 0x119C,
        /// <summary>
        /// Constant address space
        /// </summary>
        Constant = 0x119D,
        /// <summary>
        /// Private address space
        /// </summary>
        Private = 0x119E
    }
    
    /// <summary>
    /// Access for a kernel argument
    /// </summary>
    public enum CLKernelArgumentAccessQualifier
    {
        /// <summary>
        /// Kernel has Read Only Access to this argument
        /// </summary>
        ReadOnly = 0x11A0,
        /// <summary>
        /// Kernel has Write Only Access to this argument
        /// </summary>
        WriteOnly = 0x11A1,
        /// <summary>
        /// Kernel has Read and Write Access to this argument
        /// </summary>
        ReadWrite = 0x11A2,
        /// <summary>
        /// Kernel has No Access to this argument
        /// </summary>
        None = 0x11A3
    }

    /// <summary>
    /// Information to query about a kernel arguments.
    /// </summary>
    public enum CLKernelArgumentInfo
    {
        /// <summary>
        /// Returns the address qualifier specified for the argument given by arg_indx.
        /// 
        /// If no address qualifier is specified, the default address qualifier which is Private is returned.
        /// 
        /// Type: CLKernelArgumentAddressQualifier
        /// </summary>
        AddressQualifier = 0x1196,
        /// <summary>
        /// Returns the access qualifier specified for the argument given by arg_indx.
        /// 
        /// If argument is not an image type and is not declared with the pipe qualifier, None is returned. 
        /// If argument is an image type, the access qualifier specified or the default access qualifier is returned.
        /// 
        /// Type: CLKernelArgumentAccessQualifier
        /// </summary>
        AccessQualifier = 0x1197,
        /// <summary>
        /// Returns the type name specified for the argument given by arg_indx. 
        /// The type name returned will be the argument type name as it was declared with any whitespace removed. 
        /// If argument type name is an unsigned scalar type (i.e. unsigned char, unsigned short, unsigned int, unsigned long), 
        /// uchar, ushort, uint and ulong will be returned. The argument type name returned does not include any type qualifiers.
        /// 
        /// Type: string
        /// </summary>
        TypeName = 0x1198,
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
        /// 
        /// Type: CLKernelArgumentTypeQualifier
        /// </summary>
        TypeQualifier = 0x1199,
        /// <summary>
        /// Returns the name specified for the argument given by arg_indx.
        /// 
        /// Type: string
        /// </summary>
        Name = 0x119A
    }
    
    /// <summary>
    /// The qualifiers used to declare kernel argument
    /// </summary>
    public enum CLKernelArgumentTypeQualifier
    {
        /// <summary>
        /// Returned if the argument is a pointer and the referenced type is declared with the const qualifier.
        /// For example, a kernel argument declared as global int const *x returns Const but a 
        /// kernel argument declared as global int * const x does not.
        /// 
        /// If the argument is declared with the constant address space qualifier, 
        /// the Const type qualifier will be set.
        /// </summary>
        Const = (1 << 0),

        /// <summary>
        /// Returned if the argument is a pointer and the referenced type is declared with the restrict qualifier.
        /// </summary>
        Restrict = (1 << 1),
        
        /// <summary>
        /// eturned if the argument is a pointer and the pointer is declared with the volatile qualifier. 
        /// For example, a kernel argument declared as global int volatile *x returns Volatile 
        /// but a kernel argument declared as global int * volatile x does not.
        /// </summary>
        Volatile = (1 << 2),
        
        /// <summary>
        /// Pipe qualifier?
        /// </summary>
        Pipe = (1 << 3),

        /// <summary>
        /// No qualifier set.
        /// </summary>
        None = 0
    }

    /// <summary>
    /// Specifies the information to be passed to kernel in clSetKernelExecInfo
    /// </summary>
    public enum CLKernelExecInfo
    {
        /// <summary>
        /// void*[]
        /// SVM pointers must reference locations contained entirely within buffers that are passed to kernel as arguments,
        /// or that are passed through the execution information.
        /// 
        /// Non-argument SVM buffers must be specified by passing pointers to those buffers via clSetKernelExecInfo 
        /// for coarse-grain and fine-grain buffer SVM allocations but not for finegrain system SVM allocations.
        /// </summary>
        SVMPointers = 0x11B6,
        /// <summary>
        /// bool
        /// 
        /// This flag indicates whether the kernel uses pointers that are fine grain system SVM allocations.
        /// These fine grain system SVM pointers may be passed as arguments or defined in SVM buffers that are passed as arguments to kernel.
        /// </summary>
        SVMFineGrainSystem = 0x11B7
    }

    /// <summary>
    /// Specifies the information to query about a kernel function
    /// </summary>
    public enum CLKernelInfo
    {
        /// <summary>
        /// Return the kernel function name.
        /// </summary>
        FunctionName = 0x1190,
        /// <summary>
        /// Return the number of arguments to kernel.
        /// </summary>
        NumberOfArguments = 0x1191,
        /// <summary>
        /// Return the kernel reference count.
        /// 
        /// The reference count returned should be considered immediately stale.
        /// It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </summary>
        ReferenceCount = 0x1192,
        /// <summary>
        /// Return the context associated with kernel.
        /// </summary>
        Context = 0x1193,
        /// <summary>
        /// Return the program object associated with kernel.
        /// </summary>
        Program = 0x1194,
        /// <summary>
        /// Returns any attributes specified using the __attribute__ 
        /// qualifier with the kernel function declaration in the program source. 
        /// These attributes include those on the __attribute__ page and other attributes supported by an implementation.
        /// 
        /// Attributes are returned as they were declared inside __attribute__((...)), with any surrounding whitespace and 
        /// embedded newlines removed. When multiple attributes are present, they are returned as a single, space delimited string.
        /// </summary>
        Attributes = 0x1195
    }

    /// <summary>
    /// Information about the kernel object that may be specific to a device.
    /// </summary>
    public enum CLKernelWorkGroupInfo
    {
        /// <summary>
        /// This provides a mechanism for the application to query the maximum global size that can be used to execute a kernel (i.e. global_work_size argument to EnqueueNDRangeKernel) on a custom device given by device or a built-in kernel on an OpenCL device given by device.
        /// If device is not a custom device or kernel is not a built-in kernel, GetKernelArgInfo returns the error InvalidValue.
        /// Type: Vector3i
        /// </summary>
        WorkGroupSize = 0x11B0,
        /// <summary>
        /// This provides a mechanism for the application to query the maximum work-group size that can be used to execute a kernel on a 
        /// specific device given by device. 
        /// The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this 
        /// work-group size should be.
        /// 
        /// Type: int
        /// </summary>
        CompileWorkGroupSize = 0x11B1,
        /// <summary>
        /// Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with SetKernelArg.
        /// 
        /// If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// 
        /// Type: ulong
        /// </summary>
        LocalMemorySize = 0x11B2,
        /// <summary>
        /// Returns the preferred multiple of workgroup size for launch. This is a performance hint. 
        /// Specifying a workgroup size that is not a multiple of the value returned by this query as the value of the local work size 
        /// argument to EnqueueNDRangeKernel will not fail to enqueue the kernel for execution unless the work-group size specified 
        /// is larger than the device maximum.
        /// 
        /// Type: int
        /// </summary>
        PreferredWorkGroupSizeMultiple = 0x11B3,
        /// <summary>
        /// Returns the minimum amount of private memory, in bytes, used by each workitem in the kernel. 
        /// This value may include any private memory needed by an implementation to execute the kernel, 
        /// including that used by the language built-ins and variable declared inside the kernel with the __private qualifier.
        /// 
        /// Type: ulong
        /// </summary>
        PrivateMemorySize = 0x11B4,
        /// <summary>
        /// This provides a mechanism for the application to query the maximum work-group size that can be used to execute a 
        /// kernel on a specific device given by device. 
        /// The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this 
        /// work-group size should be.
        /// 
        /// Type: int
        /// </summary>
        GlobalWorkSize = 0x11B5
    }

    /// <summary>
    /// A bit-bield with the following supported values.
    /// </summary>
    public enum CLMapFlags
    {
        /// <summary>
        /// This flag specifies that the region being mapped in the memory object is being mapped for reading.
        /// 
        /// The pointer returned by clEnqueueMap{Buffer|Image} is guaranteed to contain the latest bits in the region being mapped  
        /// when the clEnqueueMap{Buffer|Image} command has completed.
        /// </summary>
        Read = (1 << 0),
        /// <summary>
        /// This flag specifies that the region being mapped in the memory object is being mapped for writing.
        /// 
        /// The pointer returned by clEnqueueMap{Buffer|Image} is guaranteed to contain the latest bits in the region being mapped 
        /// when the clEnqueueMap{Buffer|Image} command has completed.
        /// </summary>
        Write = (1 << 1),
        /// <summary>
        /// This flag specifies that the region being mapped in the memory object is being mapped for writing.
        /// 
        /// The contents of the region being mapped are to be discarded.
        /// This is typically the case when the region being mapped is overwritten by the host. 
        /// This flag allows the implementation to no longer guarantee that the pointer returned by clEnqueueMap{Buffer|Image} 
        /// contains the latest bits in the region being mapped which can be a significant performance enhancement.
        /// 
        /// Read or Write and WriteInvalidateRegion are mutually exclusive.
        /// </summary>
        WriteInvalidateRegion = (1 << 2)
    }

    /// <summary>
    /// All work-items in a work-group executing the kernel on a processor must execute this function 
    /// before any are allowed to continue execution beyond the work_group_barrier. 
    /// This function must be encountered by all work-items in a work-group executing the kernel.
    /// </summary>
    public enum CLMemoryFenceFlags
    {
        /// <summary>
        /// The work_group_barrier function ensure that all global memory accesses become visible to the 
        /// appropriate scope as given by scope.
        /// </summary>
        GlobalMemoryFence = 0x02,
        /// <summary>
        /// The work_group_barrier function will ensure that all local memory accesses become visible to all
        /// work-items in the work-group.
        /// Note that the value of scope is ignored as the memory scope is always memory_scope_work_group.
        /// </summary>
        LocalMemoryFence = 0x01,
        /// <summary>
        /// The work_group_barrier function will ensure that all image memory accesses become visible to the 
        /// appropriate scope as given by scope. 
        /// The value of scope must be memory_scope_work_group.
        /// </summary>
        ImageMemoryFence = 0x04
    }

    /// <summary>
    /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to 
    /// allocate the buffer object and how it will be used. The following table describes the possible values for flags. 
    /// The default is ReadWrite.
    /// </summary>
    public enum CLMemoryFlags : ulong
    {
        /// <summary>
        /// This flag specifies that the memory object will be read and written by a kernel. This is the default.
        /// </summary>
        ReadWrite = (1 << 0),
        /// <summary>
        /// This flag specifies that the memory object will be written but not read by a kernel.
        /// Reading from a buffer or image object created with WriteOnly inside a kernel is undefined.
        /// ReadWrite and WriteOnly are mutually exclusive.
        /// </summary>
        WriteOnly = (1 << 1),
        /// <summary>
        /// This flag specifies that the memory object is a read-only memory object when used inside a kernel.
        /// Writing to a buffer or image object created with ReadOnly inside a kernel is undefined.
        /// ReadWrite or WriteOnly and ReadOnly are mutually exclusive.
        /// </summary>
        ReadOnly = (1 << 2),
        /// <summary>
        /// This flag is valid only if host_ptr is not NULL. 
        /// If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr 
        /// as the storage bits for the memory object.
        /// OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. 
        /// This cached copy can be used when kernels are executed on a device.
        /// The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping 
        /// host regions is considered to be undefined.
        /// Refer to the description of the alignment rules for host_ptr for memory objects (buffer and images) 
        /// created using UseHostPointer.
        /// </summary>
        UseHostPointer = (1 << 3),
        /// <summary>
        /// This flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.
        ///AllocateHostPointer and UseHostPointer are mutually exclusive.
        /// </summary>
        AllocateHostPointer = (1 << 4),
        /// <summary>
        /// This flag is valid only if host_ptr is not NULL. 
        /// If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory
        /// object and copy the data from memory referenced by host_ptr.
        /// CopyHostPointer and UseHostPointer are mutually exclusive.
        /// CopyHostPointer can be used with AllocateHostPointer to initialize the contents of the CLMemoryPtr object 
        /// allocated using host-accessible (e.g.PCIe) memory.
        /// </summary>
        CopyHostPointer = (1 << 5),

        /// <summary>
        /// This flag specifies that the host will only write to the memory object (using OpenCL APIs that enqueue a write or a map for write).
        /// This can be used to optimize write access from the host (e.g. enable write-combined allocations for memory objects for devices 
        /// that communicate with the host over a system bus such as PCIe).
        /// </summary>
        HostWriteOnly = (1 << 7),
        /// <summary>
        /// This flag specifies that the host will only read the memory object (using OpenCL APIs that enqueue a read or a map for read).
        /// HostWriteOnly and HostReadOnly are mutually exclusive.
        /// </summary>
        HostReadOnly = (1 << 8),
        /// <summary>
        /// This flag specifies that the host will not read or write the memory object.
        /// HostWriteOnly or HostReadOnly and HostNoAccess are mutually exclusive.
        /// </summary>
        HostNoAccess = (1 << 9)

    }

    /// <summary>
    /// Specifies the information to query.
    /// </summary>
    public enum CLMemoryInfo
    {
        /// <summary>
        /// Returns one of the following values:
        /// Buffer if memobj is created with Create or clCreateSubBuffer.
        /// CLImageDescription.Type argument value if memobj is created with CreateImage.
        /// Pipe if memobj is created with clCreatePipe.
        /// 
        /// Return Type: 	CLMemoryObjectType
        /// </summary>
        Type = 0x1100,
        /// <summary>
        /// Returns the flags argument value specified when memobj is created with 
        /// Create, clCreateSubBuffer, CreateImage, or clCreatePipe. 
        /// If memobj is a sub-buffer the memory access qualifiers inherited from parent buffer is also returned.
        /// 
        /// Return Type: CLMemoryFlags
        /// </summary>
        Flags = 0x1101,
        /// <summary>
        /// Return actual size of the data store associated with memobj in bytes.
        /// 
        /// Return Type: int
        /// </summary>
        Size = 0x1102,
        /// <summary>
        /// If memobj is created with Create or CreateImage and UseHostPointer is specified in mem_flags, 
        /// return the host_ptr argument value specified when memobj is created. Otherwise a NULL value is returned.
        /// 
        /// If memobj is created with clCreateSubBuffer, return the host_ptr + origin value specified when memobj is created.
        /// host_ptr is the argument value specified to Create and UseHostPointer is specified in mem_flags 
        /// for memory object from which memobj is created. Otherwise a NULL value is returned.
        ///
        /// Return Type: IntPtr
        /// </summary>
        HostPointer = 0x1103,
        /// <summary>
        /// Map count. The map count returned should be considered immediately stale. 
        /// It is unsuitable for general use in applications. This feature is provided for debugging.
        /// 
        /// Return Type: uint
        /// </summary>
        MapCount = 0x1104,
        /// <summary>
        /// Return memobj reference count. The reference count returned should be considered immediately stale. 
        /// It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// 
        /// Return Type: uint
        /// </summary>
        ReferenceCount = 0x1105,
        /// <summary>
        /// Return context specified when memory object is created. 
        /// If memobj is created using clCreateSubBuffer, the context associated with the memory object specified 
        /// as the buffer argument to clCreateSubBuffer is returned.
        /// 
        /// Return Type: CLContextPtr
        /// </summary>
        Context = 0x1106,
        /// <summary>
        /// Return memory object from which memobj is created.
        /// This returns the memory object specified as buffer argument to clCreateSubBuffer if memobj is a subbuffer 
        /// object created using clCreateSubBuffer.
        /// 
        /// This returns the mem_object specified in CLImageDescription if memobj is an image object.
        /// 
        /// Otherwise a NULL value is returned.
        /// 
        /// Return Type: CLMemoryPtr
        /// </summary>
        AssociatedMemoryObject = 0x1107,
        /// <summary>
        /// Return offset if memobj is a sub-buffer object created using clCreateSubBuffer.
        /// This returns 0 if memobj is not a subbuffer object.
        /// 
        /// Return Type: int
        /// </summary>
        Offset = 0x1108,
        /// <summary>
        /// Return CL_TRUE if memobj is a buffer object that was created with UseHostPointer or is a 
        /// subbuffer object of a buffer object that was created with UseHostPointer and the host_ptr 
        /// specified when the buffer object was created is a SVM pointer; otherwise returns CL_FALSE.
        /// 
        /// Return Type: bool
        /// </summary>
        UsesSVMPointer = 0x1109,
        /// <summary>
        /// If the cl_khr_d3d10_sharing extension is enabled, and if memobj was created using 
        /// clCreateFromD3D10BufferKHR, clCreateFromD3D10Texture2DKHR, or clCreateFromD3D10Texture3DKHR, 
        /// returns the resource argument specified when memobj was created.
        /// 
        /// Return Type: IntPtr (ID3D10Resource  Pointer)
        /// </summary>
        D3D10ResourceKHR = 0x4015,
        /// <summary>
        /// If the cl_khr_d3d11_sharing extension is supported, if memobj was created using 
        /// clCreateFromD3D11BufferKHR, clCreateFromD3D11Texture2DKHR, or clCreateFromD3D11Texture3DKHR, 
        /// returns the resource argument specified when memobj was created.
        /// 
        /// Return Type: IntPtr (ID3D11Resource *)
        /// </summary>
        D3D11ResourceKHR = 0x401E,
        /// <summary>
        /// Returns the cl_dx9_media_adapter_type_khr argument value specified when memobj is created using 
        /// clCreateFromDX9MediaSurfaceKHR (If the cl_khr_dx9_media_sharing extension is supported)
        /// 
        /// Return Type: cl_dx9_media_- adapter_type_khr
        /// </summary>
        DX9MediaAdapterTypeKHR = 0x2028,
        /// <summary>
        /// Returns the cl_dx9_surface_info_khr argument value specified when memobj is created using 
        /// clCreateFromDX9MediaSurfaceKHR (If the cl_khr_dx9_media_sharing extension is supported)
        /// 
        /// Return Type: IntPtr (cl_dx9_- surface_info_khr)
        /// </summary>
        DX9MediaSurfaceInfoKHR = 0x2029
    }

    /// <summary>
    /// A bit-field that is used to specify migration options in clEnqueueMigrateMemObjects .
    /// </summary>
    public enum CLMemoryMigrationFlags
    {
        /// <summary>
        /// This flag indicates that the specified set of memory objects are to be migrated to the host, 
        /// regardless of the target command-queue.
        /// </summary>
        Host = (1 << 0),
        /// <summary>
        /// This flag indicates that the contents of the set of memory objects are undefined after migration.
        /// The specified set of memory objects are migrated to the device associated with command_queue without 
        /// incurring the overhead of migrating their contents.
        /// </summary>
        ContentUndefined = (1 << 1)
    }

    /// <summary>
    /// Describes the image type
    /// </summary>
    public enum CLMemoryObjectType
    {
        /// <summary>
        /// If memobj is created with Create or clCreateSubBuffer.
        /// </summary>
        Buffer = 0x10F0,
        /// <summary>
        /// If memobj is created with clCreatePipe.
        /// </summary>
        Pipe = 0x10F7,
        Image2D = 0x10F1,
        Image3D = 0x10F2,
        Image2DArray = 0x10F3,
        Image1D = 0x10F4,
        Image1DArray = 0x10F5,
        Image1DBuffer = 0x10F6
    }

    /// <summary>
    /// specifies the information to query in clGetPipeInfo.
    /// </summary>
    public enum CLPipeInfo
    {
        /// <summary>
        /// Return pipe packet size specified when pipe is created with clCreatePipe.
        /// </summary>
        PacketSize = 0x1120,
        /// <summary>
        /// Return max. number of packets specified when pipe is created with clCreatePipe.
        /// </summary>
        MaxPackets = 0x1121
    }

    /// <summary>
    /// An enumeration constant that identifies the platform information being queried.
    /// </summary>
    public enum CLPlatformInfo
    {
        /// <summary>
        /// OpenCL profile string. Returns the profile name supported by the implementation. 
        /// The profile name returned can be one of the following strings:
        /// 
        /// FULL_PROFILE - if the implementation supports the OpenCL specification (functionality defined as part of the core 
        ///     specification and does not require any extensions to be supported).
        /// 
        /// EMBEDDED_PROFILE - if the implementation supports the OpenCL embedded profile. The embedded profile is defined 
        ///     to be a subset for each version of OpenCL. The embedded profile for OpenCL 2.0 is described in section 
        ///     10 of the OpenCL Specification.
        /// </summary>
        Profile = 0x0900,
        /// <summary>
        /// OpenCL version string. Returns the OpenCL version supported by the implementation. 
        /// This version string has the following format:
        /// 
        /// OpenCL<space><major_version.minor_version><space><platform-specific information>
        /// 
        /// The major_version.minor_version value returned will be 2.0.
        /// </summary>
        Version = 0x0901,
        /// <summary>
        /// Platform name string.
        /// </summary>
        Name = 0x0902,
        /// <summary>
        /// Platform vendor string.
        /// </summary>
        Vendor = 0x0903,
        /// <summary>
        /// Returns a space-separated list of extension names (the extension names themselves do not contain any spaces) 
        /// supported by the platform. Extensions defined here must be supported by all devices associated with this platform.
        /// </summary>
        Extensions = 0x0904,
        /// <summary>
        /// If the cl_khr_icd extension is enabled, the function name suffix used to identify extension functions to be directed 
        /// to this platform by the ICD Loader.
        /// </summary>
        ICDSuffixKHR = 0x0920
    }

    /// <summary>
    /// Specifies the profiling data to query in GetEventProfilingInfo. 
    /// </summary>
    public enum CLProfilingInfo
    {
        /// <summary>
        /// A 64-bit value that describes the current device time counter in nanoseconds when the command identified by event 
        /// is enqueued in a command-queue by the host.
        /// </summary>
        Queued = 0x1280,
        /// <summary>
        /// A 64-bit value that describes the current device time counter in nanoseconds when the command identified by event 
        /// that has been enqueued is submitted by the host to the device associated with the command-queue.
        /// </summary>
        Submit = 0x1281,
        /// <summary>
        /// A 64-bit value that describes the current device time counter in nanoseconds when the command identified by event 
        /// starts execution on the device.
        /// </summary>
        Start = 0x1282,
        /// <summary>
        /// A 64-bit value that describes the current device time counter in nanoseconds when the command identified by event 
        /// has finished execution on the device.
        /// </summary>
        End = 0x1283,
        /// <summary>
        /// A 64-bit value that describes the current device time counter in nanoseconds when the command identified by event 
        /// and any child commands enqueued by this command on the device have finished execution.
        /// </summary>
        Complete = 0x1284
    }

    /// <summary>
    /// CL Program Executable Types
    /// </summary>
    public enum CLProgramBinaryType
    {
        /// <summary>
        /// There is no binary associated with device.
        /// </summary>
        None = 0x0,
        /// <summary>
        /// A compiled binary is associated with device. This is the case if program was created using CreateProgramWithSource and compiled using CompileProgram or a compiled binary is loaded using CreateProgramWithBinary.
        /// </summary>
        CompiledObject = 0x1,
        /// <summary>
        /// A library binary is associated with device.This is the case if program was created by clLinkProgram which is called with the –create-library link option or if a library binary is loaded using CreateProgramWithBinary.
        /// </summary>
        Library = 0x2,
        /// <summary>
        /// An executable binary is associated with device.This is the case if program was created by clLinkProgram without the –create-library link option or program was created by BuildProgram or an executable binary is loaded using CreateProgramWithBinary.
        /// </summary>
        Executable = 0x4,
        /// <summary>
        /// An intermediate(non-source) representation for the program is loaded as a binary.
        /// The program must be further processed with CompileProgram or BuildProgram.
        /// If processed with CompileProgram, the result will be a binary of type 
        /// CompiledObject or Library.
        /// If processed with BuildProgram, the result will be a binary of type Executable.
        /// </summary>
        Intermediate = 0x8
    }

    /// <summary>
    /// Types of data that can be queried from clProgramBuildInfo.
    /// </summary>
    public enum CLProgramBuildInfo
    {
        /// <summary>
        /// Return type: CLBuildStatus
        /// Returns the build, compile or link status, whichever was performed last on program for device.
        /// </summary>
        Status = 0x1181,
        /// <summary>
        /// Return type: char[]
        /// Return the build, compile or link options specified by the options argument in 
        /// BuildProgram, CompileProgram or clLinkProgram, whichever was performed last on program for device.
        /// 
        /// If build status of program for device is None, an empty string is returned.
        /// </summary>
        Options = 0x1182,
        /// <summary>
        /// Return the build, compile or link log for BuildProgram or CompileProgram 
        /// whichever was performed last on program for device.
        ///
        /// If build status of program for device is None, an empty string is returned.
        /// </summary>
        Log = 0x1183,
        /// <summary>
        /// Return type: CLProgramBinaryType
        /// Return the program binary type for device. This can be one of the following values:
        /// 
        /// </summary>
        BinaryType = 0x1184,
        /// <summary>
        /// Return type: size_t
        /// The total amount of storage, in bytes, used by program variables in the global address space.
        /// </summary>
        GlobablVariableTotalSize = 0x1185
    }
    
    /// <summary>
    /// Information that can be queried about a CL Program.
    /// </summary>
    public enum CLProgramInfo
    {
        /// <summary>
        /// Return type: cl_uint
        /// Return the program reference count.
        /// 
        /// The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </summary>
        ReferenceCount = 0x1160,
        /// <summary>
        /// Return type: CLContextPtr
        /// Return the context specified when the program object is created
        /// </summary>
        Context = 0x1161,
        /// <summary>
        /// Return type: cl_uint
        /// Return the number of devices associated with program.
        /// </summary>
        NumberOfDevices = 0x1162,
        /// <summary>
        /// Return type: CLDevicePtr[]
        /// Return the list of devices associated with the program object. This can be the devices associated with context on which the program object has been created or can be a subset of devices that are specified when a progam object is created using CreateProgramWithBinary.
        /// </summary>
        Devices = 0x1163,
        /// <summary>
        /// Return type: char[]
        /// Return the program source code specified by CreateProgramWithSource. The source string returned is a concatenation of all source strings specified to CreateProgramWithSource with a null terminator. The concatenation strips any nulls in the original source strings.
        /// 
        /// If program is created using CreateProgramWithBinary or clCreateProgramWithBuiltInKernels, a null string or the appropriate program source code is returned depending on whether or not the program source code is stored in the binary.
        /// 
        /// The actual number of characters that represents the program source code including the null terminator is returned in param_value_size_ret.
        /// </summary>
        Source = 0x1164,
        /// <summary>
        /// Return type: size_t[]
        /// Returns an array that contains the size in bytes of the program binary (could be an executable binary, compiled binary or library binary) for each device associated with program. The size of the array is the number of devices associated with program. If a binary is not available for a device(s), a size of zero is returned.
        /// 
        /// If program is created using clCreateProgramWithBuiltInKernels, the implementation may return zero in any entries of the returned array.
        /// </summary>
        BinarySizes = 0x1165,
        /// <summary>
        /// Return type: unsigned char *[]
        /// Return the program binaries (could be an executable binary, compiled binary or library binary) for all devices associated with program. For each device in program, the binary returned can be the binary specified for the device when program is created with CreateProgramWithBinary or it can be the executable binary generated by BuildProgram or clLinkProgram. If program is created with CreateProgramWithSource, the binary returned is the binary generated by BuildProgram, CompileProgram, or clLinkProgram. The bits returned can be an implementation-specific intermediate representation (a.k.a. IR) or device specific executable bits or both. The decision on which information is returned in the binary is up to the OpenCL implementation.
        /// 
        /// param_value points to an array of n pointers allocated by the caller, where n is the number of devices associated with program. The buffer sizes needed to allocate the memory that these n pointers refer to can be queried using the BinarySizes query as described in this table.
        /// 
        /// Each entry in this array is used by the implementation as the location in memory where to copy the program binary for a specific device, if there is a binary available.To find out which device the program binary in the array refers to, use the Devices query to get the list of devices. There is a one-to-one correspondence between the array of n pointers returned by Binaries and array of devices returned by Devices.
        /// 
        /// If an entry value in the array is NULL, the implementation skips copying the program binary for the specific device identified by the array index.
        /// </summary>
        Binaries = 0x1166,
        /// <summary>
        /// Return type: size_t
        /// Returns the number of kernels declared in program that can be created with CreateKernel. This information is only available after a successful program executable has been built for at least one device in the list of devices associated with program.
        /// </summary>
        NumberOfKernels = 0x1167,
        /// <summary>
        /// Return type: char[]
        /// Returns a semi-colon separated list of kernel names in program that can be created with CreateKernel. This information is only available after a successful program executable has been built for at least one device in the list of devices associated with program.
        /// </summary>
        KernelNames = 0x1168
    }

    /// <summary>
    /// Specifies the sampler information to query.
    /// </summary>
    public enum CLSamplerInfo
    {
        /// <summary>
        /// Return type: cl_uint
        /// Return the sampler reference count. The reference count returned should be considered immediately stale. 
        /// It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </summary>
        ReferenceCount = 0x1150,
        /// <summary>
        /// Return type: CLContextPtr
        /// Return the context specified when the sampler is created.
        /// </summary>
        Context = 0x1151,
        /// <summary>
        /// Return type: cl_bool
        /// Return the normalized coords value associated with sampler.
        /// </summary>
        NormalizedCoords = 0x1152,
        /// <summary>
        /// Return type: CLAddressingMode
        /// Return the addressing mode value associated with sampler.
        /// </summary>
        AddressingModes = 0x1153,
        /// <summary>
        /// Return type: CLFilterMode
        /// Return the filter mode value associated with sampler.
        /// </summary>
        FilterMode = 0x1154
    }

    /// <summary>
    /// specifies a list of sampler property names and their corresponding values. 
    /// Each sampler property name is immediately followed by the corresponding desired value. 
    /// The list is terminated with 0. The list of supported properties is described in the Sampler Properties table. 
    /// If a supported property and its value is not specified in sampler_properties, its default value will be used. 
    /// sampler_properties can be NULL in which case the default values for supported sampler properties will be used.
    /// </summary>
    public enum CLSamplerProperties
    {
        /// <summary>
        /// bool
        /// A boolean value that specifies whether the image coordinates specified are normalized or not.
        /// </summary>
        NormalizedCoords = 0x1152,
        /// <summary>
        /// CLAddressingMode
        /// Specifies how out-of-range image coordinates are handled when reading from an image.
        /// </summary>
        AddressingModes = 0x1153,
        /// <summary>
        /// CLFilterMode
        /// Specifies the type of filter that is applied when reading an image.
        /// </summary>
        FilterMode = 0x1154
    }

    /// <summary>
    /// A bit-field that is used to specify allocation and usage information in clSVMAlloc.
    /// </summary>
    public enum CLSVMMemoryFlags
    {
        /// <summary>
        /// This flag specifies that the SVM buffer will be read and written by a kernel. This is the default.
        /// </summary>
        ReadWrite = (1 << 0),
        /// <summary>
        /// This flag specifies that the SVM buffer will be written but not read by a kernel.
        /// 
        /// Reading from a SVM buffer created with CL_​MEM_​WRITE_​ONLY inside a kernel is undefined.
        /// 
        /// CL_​MEM_​READ_​WRITE and CL_​MEM_​WRITE_​ONLY are mutually exclusive.
        /// </summary>
        WriteOnly = (1 << 1),
        /// <summary>
        /// This flag specifies that the SVM buffer object is a read-only memory object when used inside a kernel.
        /// 
        /// Writing to a SVM buffer created with CL_​MEM_​READ_​ONLY inside a kernel is undefined.
        /// 
        ///  CL_​MEM_​READ_​WRITE or CL_​MEM_​WRITE_​ONLY and CL_​MEM_​READ_​ONLY are mutually exclusive.
        /// </summary>
        ReadOnly = (1 << 2),
        /// <summary>
        /// This specifies that the application wants the OpenCL implementation to do a fine-grained allocation.
        /// </summary>
        FineGrainBuffer = (1 << 10),
        /// <summary>
        /// This flag is valid only if CL_​MEM_​SVM_​FINE_​GRAIN_​BUFFER is specified in flags. 
        /// It is used to indicate that SVM atomic operations can control visibility of memory accesses in this SVM buffer.
        /// </summary>
        Atomics = (1 << 11)
    }
    
}
