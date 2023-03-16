using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace PrairieCL.OpenCL
{
    /// <summary>
    /// A simple integer based Vector object to pass data to and from the GPU.
    /// Rather than using <see cref="System.Numerics.Vector3"/> 
    /// and having to cast to int arrays all over the place.
    /// </summary>
    public struct Vector3i
    {
        public int X;
        public int Y;
        public int Z;

        public override string ToString()
        {
            return "{" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + "}";
        }

        public Vector3i(int x, int y, int z)
        {
            X = x;
            Y = y;  
            Z = z;
        }

        public static Vector3i Zero
        {
            get
            {
                return new Vector3i(0,0,0);
            }
        }
    }

    /// <summary>
    /// A low level handle used to reference a CL Context on the GPU
    /// </summary>
    public struct CLContextPtr // : IEquatable<CLContextPtr>
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        //public override bool Equals([NotNullWhen(true)] object? obj)
        //{
        //    if (obj.GetType() == typeof(IntPtr))
        //        return ((IntPtr)obj) == Handle;

        //    return base.Equals(obj);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        public static implicit operator CLContextPtr(IntPtr from)
        {
            CLContextPtr to = new CLContextPtr();
            to.Handle = from;
            return to;
        }
    }

    /// <summary>
    /// A low level handle used to reference a CL GPU Device
    /// </summary>
    public struct CLDevicePtr
    {
        public IntPtr Handle;
        public override string ToString()
        {
            return Handle.ToString("X");
        }


        public static implicit operator CLDevicePtr(IntPtr from)
        {
            CLDevicePtr to = new CLDevicePtr();
            to.Handle = from;
            return to;
        }

    }


    /// <summary>
    /// A low level handle used to reference a CL Command Queue on the GPU
    /// </summary>
    public struct CLCommandQueuePtr
    {
        public IntPtr Handle;
        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator CLCommandQueuePtr(IntPtr from)
        {
            CLCommandQueuePtr to = new CLCommandQueuePtr();
            to.Handle = from;
            return to;
        }
    }

    /// <summary>
    /// A low level handle used to reference a CL GPU Platform (A GPU brand / maker ie. NVidia or Intel)
    /// </summary>
    public struct CLPlatformPtr
    {
        public IntPtr Handle;
        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator CLPlatformPtr(IntPtr from)
        {
            CLPlatformPtr to = new CLPlatformPtr();
            to.Handle = from;
            return to;
        }
    }

    /// <summary>
    /// A low level handle used to reference a CL Memory range on the GPU
    /// </summary>
    public struct CLMemoryPtr
    {
        public IntPtr Handle;
        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator CLMemoryPtr(IntPtr from)
        {
            CLMemoryPtr to = new CLMemoryPtr();
            to.Handle = from;
            return to;
        }
    }

    /// <summary>
    /// A low level handle used to reference a CL Sampler on the GPU
    /// </summary>
    public struct CLSamplerPtr
    {
        public IntPtr Handle;
        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator CLSamplerPtr(IntPtr from)
        {
            CLSamplerPtr to = new CLSamplerPtr();
            to.Handle = from;
            return to;
        }
    }

    /// <summary>
    /// A low level handle used to reference a CL Program on the GPU
    /// </summary>
    public struct CLProgramPtr
    {
        public IntPtr Handle;
        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator CLProgramPtr(IntPtr from)
        {
            CLProgramPtr to = new CLProgramPtr();
            to.Handle = from;
            return to;
        }
    }

    /// <summary>
    /// A low level handle used to reference a CL Kernel on the GPU
    /// </summary>
    public struct CLKernelPtr
    {
        public IntPtr Handle;
        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator CLKernelPtr(IntPtr from)
        {
            CLKernelPtr to = new CLKernelPtr();
            to.Handle = from;
            return to;
        }
    }

    /// <summary>
    /// A low level handle used to reference a CL Event on the GPU
    /// </summary>
    public struct CLEventPtr
    {
        public IntPtr Handle;
        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator CLEventPtr(IntPtr from)
        {
            CLEventPtr to = new CLEventPtr();
            to.Handle = from;
            return to;
        }
    }


    /// <summary>
    /// The image format descriptor structure
    /// </summary>
    public struct CLImageFormat
    {
        /// <summary>
        /// Specifies the number of channels and the channel layout i.e. the memory layout in which channels are stored in the image.
        /// </summary>
        public CLChannelOrder ChannelOrder;
        /// <summary>
        /// Describes the size of the channel data type. 
        /// The number of bits per element determined by the ChannelDataType and ChannelOrder must be a power of two.
        /// </summary>
        public CLChannelType ChannelDataType;
    }

    /// <summary>
    /// The image descriptor structure describes the type and dimensions of the image or image array
    /// 
    /// Note
    /// Concurrent reading from, writing to and copying between both a buffer object and 1D image buffer or 2D image object 
    /// associated with the buffer object is undefined.
    /// Only reading from both a buffer object and 1D image buffer or 2D image object associated with the buffer object is defined.
    /// 
    /// Writing to an image created from a buffer and then reading from this buffer in a kernel even if appropriate 
    /// synchronization operations (such as a barrier) are performed between the writes and reads is undefined. 
    /// Similarly, writing to the buffer and reading from the image created from this buffer with appropriate 
    /// synchronization between the writes and reads is undefined.
    /// </summary>
    public struct CLImageDescription
    {
        /// <summary>
        /// Describes the image type
        /// </summary>
        public CLMemoryObjectType Type;

        /// <summary>
        /// The width of the image in pixels.
        /// For a 2D image and image array, the image width must be a value >= 1 and ≤ Image2DMaxWidth. 
        /// For a 3D image, the image width must be a value ≥ 1 and ≤ Image3DMaxWidth.
        /// For a 1D image buffer, the image width must be a value ≥ 1 and ≤ ImageMaxBufferSize.
        /// For a 1D image and 1D image array, the image width must be a value ≥ 1 and ≤ Image2DMaxWidth.
        /// </summary>
        public int Width;

        /// <summary>
        /// The height of the image in pixels. This is only used if the image is a 2D or 3D image, or a 2D image array. 
        /// For a 2D image or image array, the image height must be a value ≥ 1 and ≤ Image2DMaxHeight.
        /// For a 3D image, the image height must be a value ≥ 1 and ≤ Image3DMaxHeight.
        /// </summary>
        public int Height;

        /// <summary>
        /// The depth of the image in pixels. 
        /// This is only used if the image is a 3D image and must be a value ≥ 1 and ≤ Image3DMaxDepth.
        /// </summary>
        public int Depth;

        /// <summary>
        /// The number of images in the image array. This is only used if the image is a 1D or 2D image array. 
        /// The values for ArraySize, if specified, must be a value ≥ 1 and ≤ ImageMaxArraySize.
        /// 
        /// Note that reading and writing 2D image arrays from a kernel with ArraySize = 1 
        /// may be lower performance than 2D images.
        /// </summary>
        public int ArraySize;

        /// <summary>
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 
        /// or ≥ Width * size of element in bytes if host_ptr is not NULL. 
        /// If host_ptr is not NULL and RowPitch = 0, RowPitch is calculated as 
        /// Width * size of element in bytes. 
        /// If RowPitch is not 0, it must be a multiple of the image element size in bytes. 
        /// For a 2D image created from a buffer, the pitch specified (or computed if pitch specified is 0) 
        /// must be a multiple of the maximum of the ImagePitchAlignment value for all devices in the 
        /// context associated with image_desc.mem_object and that support images.
        /// </summary>
        public int RowPitch;

        /// <summary>
        /// The size in bytes of each 2D slice in the 3D image or the size in bytes of each image in a 1D or 2D image array. 
        /// This must be 0 if host_ptr is NULL. 
        /// If host_ptr is not NULL, SlicePitch can be either 0 or ≥ RowPitch * Height for a 2D image array 
        /// or 3D image and can be either 0 or ≥ RowPitch for a 1D image array. 
        /// If host_ptr is not NULL and SlicePitch = 0, SlicePitch is calculated as 
        /// RowPitch * Height for a 2D image array or 3D image and RowPitch for a 1D image array. 
        /// If SlicePitch is not 0, it must be a multiple of the RowPitch.
        /// </summary>
        public int SlicePitch;

        /// <summary>
        /// Must be 0.
        /// </summary>
        public uint NumberOfMipLevels;

        /// <summary>
        /// Must be 0.
        /// </summary>
        public uint NumberOfSamples;

        /// <summary>
        /// Refers to a valid buffer or image memory object. mem_object can be a buffer memory object if Type is 
        /// Image1DBuffer or Image2D 
        /// (To create a 2D image from a buffer object that share the data store between the image and buffer object). 
        /// mem_object can be a image object if Type is Image2D 
        /// (To create an image object from another image object that share the data store between these image objects).
        /// Otherwise it must be NULL. The image pixels are taken from the memory object’s data store. 
        /// When the contents of the specified memory object’s data store are modified, those changes are reflected in the 
        /// contents of the image object and vice-versa at corresponding sychronization points. 
        /// For a 1D image buffer object, the Width * size of element in bytes must be ≤ size of buffer object data store.
        /// For a 2D image created from a buffer, the RowPitch * Height must be ≤ size of buffer object data store. 
        /// For an image object created from another image object, the values specified in the image descriptor except for 
        /// mem_object must match the image descriptor information associated with mem_object.
        /// </summary>
        public CLMemoryPtr Buffer;
    }

    /// <summary>
    /// The CLBufferRegion structure specifies a region of a buffer object
    /// </summary>
    public struct CLBufferRegion
    {
        /// <summary>
        /// the offset in bytes of the region.
        /// </summary>
        public uint Origin;
        /// <summary>
        /// the size in bytes of the region.
        /// </summary>
        public uint Size;
    }

    /// <summary>
    /// 
    /// </summary>
    public struct CLNameVersion
    {
        public const int NameVersionMaxNameSize = 64;
        public uint Version;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NameVersionMaxNameSize)] public string Name; // [CL_NAME_VERSION_MAX_NAME_SIZE];
    }

    public struct CLMemoryExtHostPtr
    {
        /// <summary>
        /// Type of external memory allocation.
        /// Legal values will be defined in layered extensions.
        /// </summary>
        public uint AllocationType;

        /// <summary>
        /// Host cache policy for this external memory allocation.
        /// </summary>
        public uint HostCachePolicy;
    }


    /*********************************
    * cl_qcom_ion_host_ptr extension
    *********************************/

    public struct CLMemoryIonHostPtr
    {
        /* Type of external memory allocation. */
        /* Must be CL_MEM_ION_HOST_PTR_QCOM for ION allocations. */
        public CLMemoryExtHostPtr ExternalHostPointer;

        /* ION file descriptor */
        public int IonFileDescriptor;

        /* Host pointer to the ION allocated memory */
        public IntPtr IonHostPointer;

    }


    /*********************************
    * cl_qcom_android_native_buffer_host_ptr extension
    *********************************/

    public struct CLMemoryAndroidNativeBufferHostPtr
    {
        /* Type of external memory allocation. */
        /* Must be CL_MEM_ANDROID_NATIVE_BUFFER_HOST_PTR_QCOM for Android native buffers. */
        public CLMemoryExtHostPtr ExternalHostPointer;

        /* Virtual pointer to the android native buffer */
        public IntPtr AndroidNativeBufferPointer;

    }

    /*********************************
    * cl_khr_priority_hints extension
    *********************************/
    /* This extension define is for backwards compatibility.
       It shouldn't be required since this extension has no new functions. */
    //typedef uint cl_queue_priority_khr;

    /*********************************
    * cl_khr_throttle_hints extension
    *********************************/
    /* This extension define is for backwards compatibility.
       It shouldn't be required since this extension has no new functions. */
    //typedef uint cl_queue_throttle_khr;

    /*********************************
    * cl_khr_extended_versioning
    *********************************/

    //typedef uint cl_version_khr;

    public struct CLNameVersionKhr
    {
        public const int CL_NAME_VERSION_MAX_NAME_SIZE_KHR = 64;
        public uint Version;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CL_NAME_VERSION_MAX_NAME_SIZE_KHR)] public string Name; // [CL_NAME_VERSION_MAX_NAME_SIZE_KHR];
    }

    /***************************************************************
    * cl_khr_pci_bus_info
    ***************************************************************/

    public struct CLDevicePciBusInfoKhr
    {
        public uint Domain;
        public uint Bus;
        public uint Device;
        public uint Function;
    }

    /***************************************************************
    * cl_khr_integer_dot_product
    ***************************************************************/

    //typedef ulong         cl_device_integer_dot_product_capabilities_khr;

    public struct CLDeviceIntegerDotProductAccelerationPropertiesKhr
    {
        public bool SignedAccelerated;
        public bool UnsignedAccelerated;
        public bool MixedSignednessAccelerated;
        public bool AccumulatingSaturatingSignedAccelerated;
        public bool AccumulatingSaturatingUnsignedAccelerated;
        public bool AccumulatingSaturatingMixedSignednessAccelerated;
    }

    /***************************************************************
    * cl_khr_external_semaphore
    ***************************************************************/

    //    internal struct cl_semaphore_khr * cl_semaphore_khr;
    //typedef uint cl_external_semaphore_handle_type_khr;

    ///* type cl_semaphore_khr */
    //typedef ulong cl_semaphore_properties_khr;
    //typedef uint cl_semaphore_info_khr;
    //typedef uint cl_semaphore_type_khr;
    //typedef ulong cl_semaphore_payload_khr;

    /**********************************
     * cl_arm_import_memory extension *
     **********************************/

    //typedef intptr_t cl_import_properties_arm;



    /*********************************
    * cl_arm_scheduling_controls
    *********************************/
    //typedef ulong cl_device_scheduling_controls_capabilities_arm;

    /**************************************
    * cl_arm_controlled_kernel_termination
    ***************************************/

    /* Bit fields for controlled termination feature query */
    //typedef ulong cl_device_controlled_termination_capabilities_arm;

    /* Values returned for event termination reason query */
    //typedef uint cl_command_termination_reason_arm;

    /***************************************************************
    * cl_intel_device_attribute_query
    ***************************************************************/
    //typedef ulong cl_device_feature_capabilities_intel;

    /************************************************
    * cl_intel_accelerator extension                *
    * cl_intel_motion_estimation extension          *
    * cl_intel_advanced_motion_estimation extension *
    *************************************************/
    //internal struct cl_accelerator_intel* cl_accelerator_intel;
    //typedef uint cl_accelerator_type_intel;
    //typedef uint cl_accelerator_info_intel;

    public struct CLMotionEstimationDescIntel
    {
        public uint MBBlockType;
        public uint SubpixelMode;
        public uint SadAdjustMode;
        public uint SearchPathType;
    }


    /***************************************************************
    * cl_intel_command_queue_families
    ***************************************************************/
    //typedef ulong cl_command_queue_capabilities_intel;
    public struct CLQueueFamilyPropertiesIntel
    {
        public const int CL_QUEUE_FAMILY_MAX_NAME_SIZE_INTEL = 64;
        public CLCommandQueueProperties Properties;
        public ulong Capabilities;
        public uint Count;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CL_QUEUE_FAMILY_MAX_NAME_SIZE_INTEL)] public string Name; // [CL_QUEUE_FAMILY_MAX_NAME_SIZE_INTEL];
    }
}
