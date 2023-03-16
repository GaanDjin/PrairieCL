using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieCL.OpenCL
{
    /// <summary>
    /// The device under a CLPlatform for executing OpenCL Kernels.
    /// <see cref="CLPlatform"/>
    /// </summary>
    public class CLDevice
    {
        /// <summary>
        /// The OpenCL Handle for this device.
        /// </summary>
        public CLDevicePtr Handle;

        #region Device Properties

        /// <summary>
        /// The OpenCL device type. 
        /// </summary>
        public CLDeviceType Type { get; private set; }

        /// <summary>
        /// A unique device vendor identifier. An example of a unique device identifier could be the PCIe ID.
        /// </summary>
        public int VendorID { get; private set; }

        /// <summary>
        /// The number of parallel compute units on the OpenCL device. 
        /// A work-group executes on a single compute unit. The minimum value is 1.
        /// </summary>
        public int MaxComputeUnits { get; private set; }

        /// <summary>
        /// Maximum dimensions that specify the global and local work-item IDs used by the data parallel execution model. 
        /// (Refer to EnqueueNDRangeKernel). The minimum value is 3 for devices that are not of type Custom.
        /// </summary>
        public int MaxWorkItemDimensions { get; private set; }

        /// <summary>
        /// Maximum number of work-items in a work-group executing a kernel on a single compute unit, 
        /// using the data parallel execution model. (Refer to EnqueueNDRangeKernel). 
        /// The minimum value is 1.
        /// </summary>
        public long MaxWorkGroupSize { get; private set; }

        /// <summary>
        /// Maximum number of work-items that can be specified in each dimension of the work-group to EnqueueNDRangeKernel.
        /// Returns n size_t entries, where n is the value returned by the query for MaxWorkItemDimensions.
        /// The minimum value is (1, 1, 1) for devices that are not of type Custom.
        /// </summary>
        public Vector3i MaxWorkGroupItemSizes { get; private set; }

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int PreferredVectorWidthChar { get; private set; }

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int PreferredVectorWidthShort { get; private set; }

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int PreferredVectorWidthInt { get; private set; }

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int PreferredVectorWidthLong { get; private set; }

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int PreferredVectorWidthFloat { get; private set; }

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int PreferredVectorWidthDouble { get; private set; }

        /// <summary>
        /// Maximum configured clock frequency of the device in MHz.
        /// </summary>
        public int MaxClockFrequency { get; private set; }

        /// <summary>
        /// The default compute device address space size of the global address space specified as an unsigned integer value in bits. 
        /// Currently supported values are 32 or 64 bits.
        /// </summary>
        public int AddressBits { get; private set; }

        /// <summary>
        /// Max number of image objects arguments of a kernel declared with the read_only qualifier.
        /// The minimum value is 128 if ImageSupport is true.
        /// </summary>
        public int MaxReadImageArgs { get; private set; }

        /// <summary>
        /// Max number of image objects arguments of a kernel declared with the write_only qualifier. 
        /// The minimum value is 64 if ImageSupport is true. 
        /// NOTE: 
        /// MaxWriteImageArgs is only there for backward compatibility. 
        /// MaxReadWriteImageArgs should be used instead.
        /// </summary>
        public int MaxWriteImageArgs { get; private set; }

        /// <summary>
        /// Max size of memory object allocation in bytes. 
        /// The minimum value is max(min(1024*1024*1024, 1/4th of GlobalMemorySize), 128*1024*1024) 
        /// for devices that are not of type Custom.
        /// </summary>
        public long MaxMemoryAllocationSize { get; private set; }

        /// <summary>
        /// Max width of 2D image or 1D image not created from a buffer object in pixels. 
        /// The minimum value is 16384 if ImageSupport is true.
        /// </summary>
        public long Image2DMaxWidth { get; private set; }

        /// <summary>
        /// Max height of 2D image in pixels. The minimum value is 16384 if ImageSupport is true.
        /// </summary>
        public long Image2DMaxHeight { get; private set; }

        /// <summary>
        /// Max width of 3D image in pixels. The minimum value is 2048 if ImageSupport is true.
        /// </summary>
        public long Image3DMaxWidth { get; private set; }

        /// <summary>
        /// Max height of 3D image in pixels. The minimum value is 2048 if ImageSupport is true.
        /// </summary>
        public long Image3DMaxHeight { get; private set; }

        /// <summary>
        /// Max depth of 3D image in pixels. The minimum value is 2048 if ImageSupport is true.
        /// </summary>
        public long Image3DMaxDepth { get; private set; }

        /// <summary>
        /// Is true if images are supported by the OpenCL device and false otherwise.
        /// </summary>
        public bool ImageSupport { get; private set; }

        /// <summary>
        /// Max size in bytes of all arguments that can be passed to a kernel. 
        /// The minimum value is 1024 for devices that are not of type Custom. 
        /// For this minimum value, only a maximum of 128 arguments can be passed to a kernel.
        /// </summary>
        public long MaxParameterSize { get; private set; }

        /// <summary>
        /// Maximum number of samplers that can be used in a kernel.
        /// The minimum value is 16 if ImageSupport is true. (Also see sampler_t.)
        /// </summary>
        public int MaxSamplers { get; private set; }

        /// <summary>
        /// The minimum value is the size (in bits) of the largest OpenCL built-in data type supported by the device 
        /// (long16 in FULL profile, long16 or int16 in EMBEDDED profile) for devices that are not of type Custom.
        /// </summary>
        public int MemoryBaseAddressAlignment { get; private set; }

        /// <summary>
        /// ?
        /// </summary>
        public int MinDataTypeAlignmentSize { get; private set; }

        /// <summary>
        /// Describes single precision floating-point capability of the device. 
        /// 
        /// The mandated minimum floating-point capability for devices that are not of type 
        /// Custom is RoundToNearest | InfinityAndNaNs.
        /// </summary>
        public CLDeviceFPConfig SingleFPConfig { get; private set; }

        /// <summary>
        /// Type of global memory cache supported.
        /// </summary>
        public CLDeviceMemoryCacheType GlobalMemoryCacheType { get; private set; }

        /// <summary>
        /// Size of global memory cache line in bytes.
        /// </summary>
        public int GlobalMemoryCachelineSize { get; private set; }

        /// <summary>
        /// Size of global memory cache in bytes.
        /// </summary>
        public long GlobalMemoryCacheSize { get; private set; }

        /// <summary>
        /// Size of global device memory in bytes.
        /// </summary>
        public long GlobalMemorySize { get; private set; }

        /// <summary>
        /// Max size in bytes of a constant buffer allocation. 
        /// The minimum value is 64 KB for devices that are not of type Custom.
        /// </summary>
        public long MaxConstantBufferSize { get; private set; }

        /// <summary>
        /// Max number of arguments declared with the __constant qualifier in a kernel. 
        /// The minimum value is 8 for devices that are not of type Custom.
        /// </summary>
        public int MaxConstantArguments { get; private set; }

        /// <summary>
        /// Type of local memory supported. 
        /// This can be set to Local implying dedicated local memory storage such as SRAM, or Global. 
        /// For custom devices, None can also be returned indicating no local memory support.
        /// </summary>
        public CLDeviceLocalMemoryType LocalMemoryType { get; private set; }

        /// <summary>
        /// Size of local memory region in bytes. 
        /// The minimum value is 32 KB for devices that are not of type Custom.
        /// </summary>
        public long LocalMemorySize { get; private set; }

        /// <summary>
        /// Is true if the device implements error correction for all accesses to compute device memory (global and constant). 
        /// Is false if the device does not implement such error correction.
        /// </summary>
        public bool ErrorCorrectionSupport { get; private set; }

        /// <summary>
        /// Describes the resolution of device timer. This is measured in nanoseconds.
        /// </summary>
        public long ProfilingTimerResolution { get; private set; }

        /// <summary>
        /// Is true if the OpenCL device is a little endian device and false otherwise.
        /// </summary>
        public bool EndianLittle { get; private set; }

        /// <summary>
        /// Is true if the device is available and false otherwise. 
        /// A device is considered to be available if the device can be expected to successfully execute 
        /// commands enqueued to the device
        /// </summary>
        public bool Available { get; private set; }

        /// <summary>
        /// Is false if the implementation does not have a compiler available to compile the program source. 
        /// Is true if the compiler is available. This can be false for the embedded platform profile only.
        /// </summary>
        public bool CompilerAvailable { get; private set; }

        /// <summary>
        /// Describes the execution capabilities of the device. 
        /// The mandated minimum capability is Kernel.
        /// </summary>
        public CLDeviceExecCapabilities ExecutionCapabilities { get; private set; }

        /// <summary>
        /// Describes the on device command-queue properties supported by the device. 
        /// 
        /// These properties are described in the table for CreateCommandQueueWithProperties. 
        /// The mandated minimum capability is OutOfOrderExecModeEnable | ProfilingEnable.
        /// </summary>
        public CLCommandQueueProperties QueueOnDeviceProperties { get; private set; }

        /// <summary>
        /// Describes the on host command-queue properties supported by the device. 
        /// 
        /// These properties are described in the table for CreateCommandQueueWithProperties. 
        /// The mandated minimum capability is ProfilingEnable.
        /// </summary>
        public CLCommandQueueProperties QueueOnHostProperties { get; private set; }

        /// <summary>
        /// Device name string.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Vendor name string.
        /// </summary>
        public string Vendor { get; private set; }

        /// <summary>
        /// OpenCL software driver version string in the form major_number.minor_number.
        /// </summary>
        public string DriverVersion { get; private set; }

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
        /// The compiler must be available for all devices i.e. CompilerAvailable is true. 
        /// If the platform profile returned is EMBEDDED_PROFILE, then devices that are only EMBEDDED_PROFILE are supported.
        /// </summary>
        public string Profile { get; private set; }

        /// <summary>
        /// OpenCL version string. Returns the OpenCL version supported by the device. This version string has the following format:
        /// OpenCL<space><major_version.minor_version><space><vendor-specific information>
        /// The major_version.minor_version value returned will be 2.0.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// A list of extension names supported by the device. 
        /// The list of extension names returned can be vendor supported extension names and 
        /// one or more of the following Khronos approved extension names:
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
        public string[] Extensions { get; private set; }

        /// <summary>
        /// The platform associated with this device.
        /// </summary>
        public CLPlatformPtr Platform { get; private set; }

        /// <summary>
        /// Undocumented?
        /// </summary>
        public long HalfFPConfig { get; private set; }

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// 
        /// If double precision is not supported, PreferredVectorWidthDouble must return 0.
        /// 
        /// If the cl_khr_fp16 extension is not supported, PreferredVectorWidthHalf must return 0.
        /// </summary>
        public int PreferredVectorWidthHalf { get; private set; }

        [Obsolete] public int HostUnifiedMemory { get; private set; }

        /// <summary>
        /// Returns the native ISA vector width. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int NativeVectorWidthChar { get; private set; }

        /// <summary>
        /// Returns the native ISA vector width. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int NativeVectorWidthShort { get; private set; }

        /// <summary>
        /// Returns the native ISA vector width. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int NativeVectorWidthInt { get; private set; }

        /// <summary>
        /// Returns the native ISA vector width. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int NativeVectorWidthLong { get; private set; }

        /// <summary>
        /// Returns the native ISA vector width. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int NativeVectorWidthFloat { get; private set; }

        /// <summary>
        /// Returns the native ISA vector width. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int NativeVectorWidthDouble { get; private set; }

        /// <summary>
        /// Returns the native ISA vector width. 
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.
        /// </summary>
        public int NativeVectorWidthHalf { get; private set; }

        /// <summary>
        /// OpenCL C version string. Returns the highest OpenCL C version supported by the compiler for this device that 
        /// is not of type Custom. This version string has the following format:
        /// 
        /// OpenCL<space>C<space><major_version.minor_version><space><vendor-specific information>
        /// </summary>
        public string OpenCLVersion { get; private set; }

        /// <summary>
        /// Is false if the implementation does not have a linker available. 
        /// Is true if the linker is available. 
        /// This can be false for the embedded platform profile only. 
        /// This must be true if CompilerAvailable is true
        /// </summary>
        public bool LinkerAvailable { get; private set; }

        /// <summary>
        /// A list of built-in kernels supported by the device. 
        /// An empty string is returned if no built-in kernels are supported by the device.
        /// </summary>
        public string[] BuiltInKernels { get; private set; }

        /// <summary>
        /// Max number of pixels for a 1D image created from a buffer object. 
        /// The minimum value is 65536 if ImageSupport is true.
        /// </summary>
        public long ImageMaxBufferSize { get; private set; }

        /// <summary>
        /// Max number of images in a 1D or 2D image array. 
        /// The minimum value is 2048 if ImageSupport is true
        /// </summary>
        public long ImageMaxArraySize { get; private set; }

        /// <summary>
        /// Returns the CLDevicePtr of the parent device to which this sub-device belongs. 
        /// If device is a root-level device, a NULL value is returned.
        /// </summary>
        public CLDevicePtr ParentDevice { get; private set; }

        /// <summary>
        /// Returns the maximum number of sub-devices that can be created when a device is partitioned. 
        /// The value returned cannot exceed MaxComputeUnits.
        /// </summary>
        public int PartitionMaxSubDevices { get; private set; }

        /// <summary>
        /// Returns the list of partition types supported by device. 
        /// This is an array of CLDevicePartitionProperty values drawn from the following list:
        /// Equally
        /// ByCounts
        /// ByAffinityDomain
        /// If the device cannot be partitioned (i.e. there is no partitioning scheme supported by the device that will return at least two subdevices), a value of 0 will be returned.
        /// </summary>
        public CLDevicePartitionProperty PartitionProperties { get; private set; }

        /// <summary>
        /// Returns the list of supported affinity domains for partitioning the device using ByAffinityDomain. 
        /// This is a bit-field that describes one or more of the following values:
        /// Numa
        /// L4Cache
        /// L3Cache
        /// L2Cache
        /// L1Cache
        /// NextPartitionable
        /// If the device does not support any affinity domains, a value of 0 will be returned.
        /// </summary>
        public CLDeviceAffinityDomain PartitionAffinityDomain { get; private set; }

        /// <summary>
        /// Returns the properties argument specified in clCreateSubDevices if device is a subdevice. 
        /// In the case where the properties argument to clCreateSubDevices is ByAffinityDomain,
        /// NextPartitionable, the affinity domain used to perform the partition will be returned. 
        /// 
        /// Otherwise the implementation may either return a param_value_size_ret of 0 
        /// i.e. there is no partition type associated with device or can return a property value of 0 
        /// (where 0 is used to terminate the partition property list) in the memory that param_value points to.
        /// </summary>
        public CLDeviceAffinityDomain PartitionType { get; private set; }

        /// <summary>
        /// Returns the device reference count. If the device is a root-level device, a reference count of one is returned.
        /// </summary>
        public int ReferenceCount { get; private set; }

        /// <summary>
        /// Is true if the device's preference is for the user to be responsible for synchronization, 
        /// when sharing memory objects between OpenCL and other APIs such as DirectX, false if the device / implementation 
        /// has a performant path for performing synchronization of memory object shared between OpenCL and other APIs 
        /// such as DirectX
        /// </summary>
        public bool PreferredInteropUserSync { get; private set; }

        /// <summary>
        /// Maximum size in bytes of the internal buffer that holds the output of printf calls from a kernel. 
        /// The minimum value for the FULL profile is 1 MB.
        /// </summary>
        public long PrintfBufferSize { get; private set; }

        /// <summary>
        /// The row pitch alignment size in pixels for 2D images created from a buffer. 
        /// The value returned must be a power of 2. If the device does not support images, this value must be 0.
        /// </summary>
        public int ImagePitchAlignment { get; private set; }

        /// <summary>
        /// This query should be used when a 2D image is created from a buffer which was created using UseHostPointer. 
        /// The value returned must be a power of 2.
        /// This query specifies the minimum alignment in pixels of the host_ptr specified to Create. 
        /// If the device does not support images, this value must be 0.
        /// </summary>
        public int ImageBaseAddressAlignment { get; private set; }

        /// <summary>
        /// Max number of image objects arguments of a kernel declared with the write_only or read_only qualifier. 
        /// The minimum value is 64 if ImageSupport is true.
        /// </summary>
        public int MaxReadWriteImageArgs { get; private set; }

        /// <summary>
        /// The maximum number of bytes of storage that may be allocated for any single variable in program scope or inside a 
        /// function in OpenCL C declared in the global address space. 
        /// This value is also provided inside OpenCL C as a preprocessor macro by the same name. The minimum value is 64 KB.
        /// </summary>
        public long MaxGlobalVariableSize { get; private set; }

        /// <summary>
        /// Describes double precision floating-point capability of the OpenCL device. 
        /// This is a bit-field that describes one or more of the following values:
        /// Denorm - denorms are supported.
        /// InfinityAndNaNs - INF and NaNs are supported.
        /// RoundToNearest - round to nearest even rounding mode supported.
        /// RoundToZero - round to zero rounding mode supported.
        /// RoundToInfinity - round to positive and negative infinity rounding modes supported.
        /// FusedMultiplyAdd - IEEE754-2008 fused multiply-add is supported.
        /// SoftwareFloats - Basic floating-point operations (such as addition, subtraction, multiplication) are implemented in software.
        /// Double precision is an optional feature so the mandated minimum double precision floating-point capability is 0.
        /// 
        /// If double precision is supported by the device, then the minimum double precision floating-point capability must be: 
        /// FusedMultiplyAdd | RoundToNearest | InfinityAndNaNs | Denorm.
        /// </summary>
        public CLDeviceFPConfig DoubleFPConfig { get; private set; }

        /// <summary>
        /// The size of the device queue in bytes preferred by the implementation. 
        /// Applications should use this size for the device queue to ensure good performance. The minimum value is 16 KB.
        /// </summary>
        public int QueueOnDevicePreferredSize { get; private set; }

        /// <summary>
        /// The max. size of the device queue in bytes. 
        /// The minimum value is 256 KB for the full profile and 64 KB for the embedded profile
        /// </summary>
        public int QueueOnDeviceMaxSize { get; private set; }

        /// <summary>
        /// The maximum number of device queues that can be created per context. The minimum value is 1.
        /// </summary>
        public int MaxOnDeviceQueues { get; private set; }

        /// <summary>
        /// The maximum number of events in use by a device queue. 
        /// These refer to events returned by the enqueue_ built-in functions to a device queue or user events returned by the 
        /// create_user_event built-in function that have not been released. The minimum value is 1024.
        /// </summary>
        public int MaxOnDeviceEvents { get; private set; }

        /// <summary>
        /// Describes the various shared virtual memory (a.k.a. SVM) memory allocation types the device supports. 
        /// Coarse-grain SVM allocations are required to be supported by all OpenCL 2.0 devices. 
        /// This is a bit-field that describes a combination of the following values:
        /// CourseGrainBuffer – Support for coarse-grain buffer sharing using clSVMAlloc. 
        /// Memory consistency is guaranteed at synchronization points and the host must use calls to 
        /// EnqueueMapBuffer and EnqueueUnmapMemObject.
        /// FineGrainBuffer – Support for fine-grain buffer sharing using clSVMAlloc. 
        /// Memory consistency is guaranteed atsynchronization points without need for EnqueueMapBuffer and EnqueueUnmapMemObject.
        /// FineGrainSystem – Support for sharing the host’s entire virtual memory including 
        /// memory allocated using malloc. Memory consistency is guaranteed at synchronization points.
        /// Atomics – Support for the OpenCL 2.0 atomic operations that provide memory consistency 
        /// across the host and all OpenCL devices supporting fine-grain SVM allocations.
        /// 
        /// The mandated minimum capability is CourseGrainBuffer.
        /// </summary>
        public CLDeviceSVMCapabilities SVMCapabilities { get; private set; }

        /// <summary>
        /// Maximum preferred total size, in bytes, of all program variables in the global address space. 
        /// This is a performance hint. An implementation may place such variables in storage with optimized device access. 
        /// This query returns the capacity of such storage. 
        /// The minimum value is 0.
        /// </summary>
        public long GlobablVariablePreferredTotalSize { get; private set; }

        /// <summary>
        /// The maximum number of pipe objects that can be passed as arguments to a kernel. 
        /// The minimum value is 16.
        /// </summary>
        public int MaxPipeArguments { get; private set; }

        /// <summary>
        /// The maximum number of reservations that can be active for a pipe per work-item in a kernel. 
        /// A work-group reservation is counted as one reservation per work-item.
        /// The minimum value is 1.
        /// </summary>
        public int MaxActiveReservations { get; private set; }

        /// <summary>
        /// The maximum size of pipe packet in bytes. 
        /// The minimum value is 1024 bytes.
        /// </summary>
        public int PipeMaxPacketSize { get; private set; }

        /// <summary>
        /// Returns the value representing the preferred alignment in bytes for OpenCL 2.0 fine-grained SVM atomic types. 
        /// This query can return 0 which indicates that the preferred alignment is aligned to the natural size of the type.
        /// </summary>
        public int PreferredPlatformAtomicAlignment { get; private set; }

        /// <summary>
        /// Returns the value representing the preferred alignment in bytes for OpenCL 2.0 atomic types to global memory. 
        /// This query can return 0 which indicates that the preferred alignment is aligned to the natural size of the type.
        /// </summary>
        public int PreferredGlobalAtomicAlignment { get; private set; }

        /// <summary>
        /// Returns the value representing the preferred alignment in bytes for OpenCL 2.0 atomic types to local memory. 
        /// This query can return 0 which indicates that the preferred alignment is aligned to the natural size of the type.
        /// </summary>
        public int PreferredLocalAtomicAlignment { get; private set; }

        /// <summary>
        /// If the cl_khr_terminate_context extension is enabled, describes the termination capability of the OpenCL device. 
        /// This is a bitfield where a value of CL_DEVICE_TERMINATE_CAPABILITY_CONTEXT_KHR indicates that context 
        /// termination is supported.
        /// </summary>
        public long TerminateCapabilityKHR { get; private set; }

        /// <summary>
        /// If the cl_khr_spir extension is enabled, a space separated list of SPIR versions supported by the device. 
        /// For example returning “1.2 2.0” in this query implies that SPIR version 1.2 and 2.0 are supported by the implementation.
        /// </summary>
        public string[] SPIRVersions { get; private set; }

        #endregion

        /// <summary>
        /// Instantiate a new CLDevice using the GPU CL Handle.
        /// Generally instantiated via: <see cref="CLPlatform"/>
        /// </summary>
        /// <param name="clHandle">The handle to the CL Device</param>
        /// <exception cref="Exception">Throws an exception if the call to OpenCL failes.</exception>
        public CLDevice(CLDevicePtr clHandle)
        {
            Handle = clHandle;
            Populate();
        }

        /// <summary>
        /// Instantiate a new CLDevice using the GPU CL Handle.
        /// Generally instantiated via: <see cref="CLPlatform"/>
        /// </summary>
        /// <param name="clHandle">The handle to the CL Device</param>
        /// <exception cref="Exception">Throws an exception if the call to OpenCL failes.</exception>
        public CLDevice(IntPtr clHandle)
        {
            Handle = new CLDevicePtr();
            Handle.Handle = clHandle;
            Populate();
        }

        /// <summary>
        /// Creates a new device reference using the first device found in the specified platform. 
        /// </summary>
        /// <param name="platform">The platform to use</param>
        /// <exception cref="Exception">Throws an exception if the specified platform has no devices or querying OpenCL for the device info fails.</exception>
        public CLDevice(CLPlatform platform)
        {
            if (platform.DeviceHandles.Length == 0)
                throw new Exception("No devices found on specified platform!");

            Handle = platform.DeviceHandles[0];
            Populate();
        }


        /// <summary>
        /// Get the all Device properties for each value in CLDeviceInfo
        /// </summary>
        /// <exception cref="Exception">Throws an exception if the call to OpenCL failes.</exception>
        private void Populate()
        {
            int bytesRead;
            foreach (CLDeviceInfo requestType in Enum.GetValues(typeof(CLDeviceInfo)))
            {
                CLResult result = CL.GetDeviceInfo(Handle, requestType, 0, null, out bytesRead);
                if (result != CLResult.Success)
                {
                    //continue;
                    //throw new Exception("Failed to Query Platform attribute size! " + requestType + " Error: " + result);
                }
                byte[] deviceParamValue = new byte[bytesRead];
                result = CL.GetDeviceInfo(Handle, requestType, (int)deviceParamValue.Length, deviceParamValue, out bytesRead);
                if (result != CLResult.Success)
                {
                    //throw new Exception("Failed to Query Platform attribute size! " + requestType + " Error: " + result);
                }

                switch (requestType)
                {
                    case CLDeviceInfo.AddressBits:
                        if (deviceParamValue.Length > 0)
                            AddressBits = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Available:
                        if (deviceParamValue.Length > 0)
                            Available = BitConverter.ToInt32(deviceParamValue, 0) != 0;
                        break;
                    case CLDeviceInfo.BuiltInKernels:
                        string kenels = "";
                        for (int j = 0; j < bytesRead - 1; j++)
                            kenels += (char)deviceParamValue[j];
                        BuiltInKernels = kenels.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        break;
                    case CLDeviceInfo.CompilerAvailable:
                        if (deviceParamValue.Length > 0)
                            CompilerAvailable = BitConverter.ToInt32(deviceParamValue, 0) != 0;
                        break;
                    case CLDeviceInfo.DoubleFPConfig:
                        if (deviceParamValue.Length > 0)
                            DoubleFPConfig = (CLDeviceFPConfig)BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.EndianLittle:
                        if (deviceParamValue.Length > 0)
                            EndianLittle = BitConverter.ToInt32(deviceParamValue, 0) != 0;
                        break;
                    case CLDeviceInfo.ErrorCorrectionSupport:
                        if (deviceParamValue.Length > 0)
                            ErrorCorrectionSupport = BitConverter.ToInt32(deviceParamValue, 0) != 0;
                        break;
                    case CLDeviceInfo.ExecutionCapabilities:
                        if (deviceParamValue.Length > 0)
                            ExecutionCapabilities = (CLDeviceExecCapabilities)BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Extensions:
                        StringBuilder exts = new StringBuilder();
                        //string exts = "";
                        for (int j = 0; j < bytesRead - 1; j++)
                            exts.Append( (char)deviceParamValue[j]);
                        Extensions = exts.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        break;
                    case CLDeviceInfo.GlobalMemoryCachelineSize:
                        if (deviceParamValue.Length > 0)
                            GlobalMemoryCachelineSize = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.GlobalMemoryCacheSize:
                        if (deviceParamValue.Length > 0)
                            GlobalMemoryCacheSize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.GlobalMemoryCacheType:
                        if (deviceParamValue.Length > 0)
                            GlobalMemoryCacheType = (CLDeviceMemoryCacheType)BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.GlobalMemorySize:
                        if (deviceParamValue.Length > 0)
                            GlobalMemorySize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.GlobablVariablePreferredTotalSize:
                        if (deviceParamValue.Length > 0)
                            GlobablVariablePreferredTotalSize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.HalfFPConfig:
                        if (deviceParamValue.Length > 0)
                            HalfFPConfig = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.HostUnifiedMemory:
                        if (deviceParamValue.Length > 0)
                            HostUnifiedMemory = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Image2DMaxHeight:
                        if (deviceParamValue.Length > 0)
                            Image2DMaxHeight = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Image2DMaxWidth:
                        if (deviceParamValue.Length > 0)
                            Image2DMaxWidth = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Image3DMaxDepth:
                        if (deviceParamValue.Length > 0)
                            Image3DMaxDepth = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Image3DMaxHeight:
                        if (deviceParamValue.Length > 0)
                            Image3DMaxHeight = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Image3DMaxWidth:
                        if (deviceParamValue.Length > 0)
                            Image3DMaxWidth = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.ImageBaseAddressAlignment:
                        if (deviceParamValue.Length > 0)
                            ImageBaseAddressAlignment = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.ImageMaxArraySize:
                        if (deviceParamValue.Length > 0)
                            ImageMaxArraySize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.ImageMaxBufferSize:
                        if (deviceParamValue.Length > 0)
                            ImageMaxBufferSize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.ImagePitchAlignment:
                        if (deviceParamValue.Length > 0)
                            ImagePitchAlignment = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.ImageSupport:
                        if (deviceParamValue.Length > 0)
                            ImageSupport = BitConverter.ToInt32(deviceParamValue, 0) != 0;
                        break;
                    case CLDeviceInfo.LinkerAvailable:
                        if (deviceParamValue.Length > 0)
                            LinkerAvailable = BitConverter.ToInt32(deviceParamValue, 0) != 0;
                        break;
                    case CLDeviceInfo.LocalMemorySize:
                        if (deviceParamValue.Length > 0)
                            LocalMemorySize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.LocalMemoryType:
                        if (deviceParamValue.Length > 0)
                            LocalMemoryType = (CLDeviceLocalMemoryType )BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxClockFrequency:
                        if (deviceParamValue.Length > 0)
                            MaxClockFrequency = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxComputeUnits:
                        if (deviceParamValue.Length > 0)
                            MaxComputeUnits = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxConstantArguments:
                        if (deviceParamValue.Length > 0)
                            MaxConstantArguments = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxConstantBufferSize:
                        if (deviceParamValue.Length > 0)
                            MaxConstantBufferSize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxGlobalVariableSize:
                        if (deviceParamValue.Length > 0)
                            MaxGlobalVariableSize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxMemoryAllocationSize:
                        if (deviceParamValue.Length > 0)
                            MaxMemoryAllocationSize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxOnDeviceEvents:
                        if (deviceParamValue.Length > 0)
                            MaxOnDeviceEvents = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxOnDeviceQueues:
                        if (deviceParamValue.Length > 0)
                            MaxOnDeviceQueues = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxParameterSize:
                        if (deviceParamValue.Length > 0)
                            MaxParameterSize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxPipeArguments:
                        if (deviceParamValue.Length > 0)
                            MaxPipeArguments = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxReadImageArgs:
                        if (deviceParamValue.Length > 0)
                            MaxReadImageArgs = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxReadWriteImageArgs:
                        if (deviceParamValue.Length > 0)
                            MaxReadWriteImageArgs = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxSamplers:
                        if (deviceParamValue.Length > 0)
                            MaxSamplers = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxWorkGroupSize:
                        if (deviceParamValue.Length > 0)
                            MaxWorkGroupSize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxWorkItemDimensions:
                        if (deviceParamValue.Length > 0)
                            MaxWorkItemDimensions = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxWorkGroupItemSizes:
                        if (deviceParamValue.Length > 0)
                        {
                            Vector3i vec = new Vector3i();
                            vec.X = BitConverter.ToInt32(deviceParamValue, 0);
                            vec.Y = BitConverter.ToInt32(deviceParamValue, 4);
                            vec.Z = BitConverter.ToInt32(deviceParamValue, 8);
                            MaxWorkGroupItemSizes = vec;
                        }
                        break;
                    case CLDeviceInfo.MaxWriteImageArgs:
                        if (deviceParamValue.Length > 0)
                            MaxWriteImageArgs = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MemoryBaseAddressAlignment:
                        if (deviceParamValue.Length > 0)
                            MemoryBaseAddressAlignment = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MinDataTypeAlignmentSize:
                        if (deviceParamValue.Length > 0)
                            MinDataTypeAlignmentSize = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Name:
                        for (int j = 0; j < bytesRead - 1; j++)
                            Name += (char)deviceParamValue[j];
                        break;
                    case CLDeviceInfo.NativeVectorWidthChar:
                        if (deviceParamValue.Length > 0)
                            NativeVectorWidthChar = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.NativeVectorWidthDouble:
                        if (deviceParamValue.Length > 0)
                            NativeVectorWidthDouble = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.NativeVectorWidthFloat:
                        if (deviceParamValue.Length > 0)
                            NativeVectorWidthFloat = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.NativeVectorWidthHalf:
                        if (deviceParamValue.Length > 0)
                            NativeVectorWidthHalf = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.NativeVectorWidthInt:
                        if (deviceParamValue.Length > 0)
                            NativeVectorWidthInt = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.NativeVectorWidthLong:
                        if (deviceParamValue.Length > 0)
                            NativeVectorWidthLong = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.NativeVectorWidthShort:
                        if (deviceParamValue.Length > 0)
                            NativeVectorWidthShort = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.OpenCLVersion:
                        for (int j = 0; j < bytesRead - 1; j++)
                            OpenCLVersion += (char)deviceParamValue[j];
                        break;
                    case CLDeviceInfo.ParentDevice:
                        ///TODO: Prent Device... 
                        if (deviceParamValue.Length > 0)
                        {
                            CLDevicePtr plf = new CLDevicePtr();
                            plf.Handle = new IntPtr(BitConverter.ToInt64(deviceParamValue, 0));
                            ParentDevice = plf;
                        }
                        break;
                    case CLDeviceInfo.PartitionAffinityDomain:
                        if (deviceParamValue.Length > 0)
                            PartitionAffinityDomain = (CLDeviceAffinityDomain)BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PartitionMaxSubDevices:
                        if (deviceParamValue.Length > 0)
                            PartitionMaxSubDevices = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PartitionProperties:
                        if (deviceParamValue.Length > 0)
                            PartitionProperties = (CLDevicePartitionProperty )BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PartitionType:
                        if (deviceParamValue.Length > 0)
                            PartitionType = (CLDeviceAffinityDomain )BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.MaxActiveReservations:
                        if (deviceParamValue.Length > 0)
                            MaxActiveReservations = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PipeMaxPacketSize:
                        if (deviceParamValue.Length > 0)
                            PipeMaxPacketSize = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Platform:
                        if (deviceParamValue.Length > 0)
                        {
                            CLPlatformPtr plf = new CLPlatformPtr();
                            plf.Handle = new IntPtr(BitConverter.ToInt64(deviceParamValue, 0));
                            Platform = plf;
                        }
                        break;
                    case CLDeviceInfo.PreferredGlobalAtomicAlignment:
                        if (deviceParamValue.Length > 0)
                            PreferredGlobalAtomicAlignment = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PreferredInteropUserSync:
                        if (deviceParamValue.Length > 0)
                            PreferredInteropUserSync = BitConverter.ToInt32(deviceParamValue, 0) != 0;
                        break;
                    case CLDeviceInfo.PreferredLocalAtomicAlignment:
                        if (deviceParamValue.Length > 0)
                            PreferredLocalAtomicAlignment = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PreferredPlatformAtomicAlignment:
                        if (deviceParamValue.Length > 0)
                            PreferredPlatformAtomicAlignment = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PreferredVectorWidthChar:
                        if (deviceParamValue.Length > 0)
                            PreferredVectorWidthChar = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PreferredVectorWidthDouble:
                        if (deviceParamValue.Length > 0)
                            PreferredVectorWidthDouble = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PreferredVectorWidthFloat:
                        if (deviceParamValue.Length > 0)
                            PreferredVectorWidthFloat = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PreferredVectorWidthHalf:
                        if (deviceParamValue.Length > 0)
                            PreferredVectorWidthHalf = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PreferredVectorWidthInt:
                        if (deviceParamValue.Length > 0)
                            PreferredVectorWidthInt = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PreferredVectorWidthLong:
                        if (deviceParamValue.Length > 0)
                            PreferredVectorWidthLong = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PreferredVectorWidthShort:
                        if (deviceParamValue.Length > 0)
                            PreferredVectorWidthShort = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.PrintfBufferSize:
                        if (deviceParamValue.Length > 0)
                            PrintfBufferSize = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Profile:
                        for (int j = 0; j < bytesRead - 1; j++)
                            Profile += (char)deviceParamValue[j];
                        break;
                    case CLDeviceInfo.ProfilingTimerResolution:
                        if (deviceParamValue.Length > 0)
                            ProfilingTimerResolution = BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.QueueOnDeviceMaxSize:
                        if (deviceParamValue.Length > 0)
                            QueueOnDeviceMaxSize = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.QueueOnDevicePreferredSize:
                        if (deviceParamValue.Length > 0)
                            QueueOnDevicePreferredSize = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.QueueOnDeviceProperties:
                        if (deviceParamValue.Length > 0)
                            QueueOnDeviceProperties = (CLCommandQueueProperties)BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.QueueOnHostProperties:
                        if (deviceParamValue.Length > 0)
                            QueueOnHostProperties = (CLCommandQueueProperties )BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.ReferenceCount:
                        if (deviceParamValue.Length > 0)
                            ReferenceCount = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.SingleFPConfig:
                        if (deviceParamValue.Length > 0)
                            SingleFPConfig = (CLDeviceFPConfig )BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.SPIRVersions:

                        string spirvers = "";
                        for (int j = 0; j < bytesRead - 1; j++)
                            spirvers += (char)deviceParamValue[j];
                        SPIRVersions = spirvers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        break;
                    case CLDeviceInfo.SVMCapabilities:
                        SVMCapabilities = (CLDeviceSVMCapabilities )BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.TerminateCapabilityKHR:
                        if (deviceParamValue.Length > 0)
                            TerminateCapabilityKHR = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Type:
                        if (deviceParamValue.Length > 0)
                            Type = (CLDeviceType ) BitConverter.ToInt64(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Vendor:
                        for (int j = 0; j < bytesRead - 1; j++)
                            Vendor += (char)deviceParamValue[j];
                        break;
                    case CLDeviceInfo.VendorID:
                        if (deviceParamValue.Length > 0)
                            VendorID = BitConverter.ToInt32(deviceParamValue, 0);
                        break;
                    case CLDeviceInfo.Version:
                        for (int j = 0; j < bytesRead - 1; j++)
                            Version += (char)deviceParamValue[j];
                        break;
                    case CLDeviceInfo.DriverVersion:
                        for (int j = 0; j < bytesRead - 1; j++)
                            DriverVersion += (char)deviceParamValue[j];
                        break;
                }
            }
        }


        public static implicit operator CLDevicePtr(CLDevice from)
            => from == null ? new CLDevicePtr(): from.Handle;

        public static explicit operator CLDevice(CLDevicePtr from)
            => new(from);
    }
}
