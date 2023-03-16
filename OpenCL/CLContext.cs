using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieCL.OpenCL
{
    /// <summary>
    /// An OpenCL context is created with one or more devices. 
    /// Contexts are used by the OpenCL runtime for managing objects such as command-queues, memory, program and kernel objects 
    /// and for executing kernels on one or more devices specified in the context.
    /// </summary>
    public class CLContext : IDisposable
    {
        public CLContextPtr Handle;

        /// <summary>
        /// Return the context reference count.
        /// The reference count returned should be considered immediately stale.
        /// It is unsuitable for general use in applications.This feature is provided for identifying memory leaks.
        /// </summary>
        public int ReferenceCount
        {
            get
            {
                CLResult result;
                int bytesRead = 0;

                result = CL.GetContextInfo(Handle,
                 CLContextInfo.ReferenceCount,
                 0,
                 null,
                 out bytesRead);

                if (result != CLResult.Success)
                {
                    throw new Exception("Failed to Query Context Reference Count size! Error: " + result);
                }
                byte[] param_value = new byte[bytesRead];

                result = CL.GetContextInfo(Handle,
                 CLContextInfo.ReferenceCount,
                 bytesRead,
                 param_value,
                 out bytesRead);

                if (result != CLResult.Success)
                {
                    throw new Exception("Failed to Query Context Reference Count attribute! Error: " + result);
                }

                if (bytesRead > 0)
                {
                    return BitConverter.ToInt32(param_value, 0);
                }
                return 0;

            }
        }
        
        /// <summary>
        /// Return the number of devices in context.
        /// </summary>
        public int NumberOfDevices { get; private set; }

        /// <summary>
        /// Return the list of devices in context.
        /// </summary>
        public CLDevicePtr[] Devices { get; private set; }

        /// <summary>
        /// Return the properties argument specified in CreateContext or CreateContextFromType.
        /// If the properties argument specified in CreateContext or CreateContextFromType used to create context is not NULL,
        /// the implementation must return the values specified in the properties argument.
        /// 
        /// If the properties argument specified in CreateContext or CreateContextFromType used to create context is NULL, 
        /// the implementation may return either a param_value_size_ret of 0, 
        /// i.e.
        /// there is no context property value to be returned or can return a context property value of 0 
        /// (where 0 is used to terminate the context properties list) in the memory that param_value points to.
        /// 
        /// </summary>
        public CLContextProperties[] Properties { get; private set; }

        /// <summary>
        /// If the cl_khr_d3d10_sharing extension is enabled, returns CL_TRUE if Direct3D 10 resources created as shared by 
        /// setting MiscFlags to include D3D10_RESOURCE_MISC_SHARED will perform faster when shared with OpenCL, 
        /// compared with resources which have not set this flag.
        /// Otherwise returns CL_FALSE.
        /// </summary>
        public bool D3D10PreferSharedResourcesKHR { get; private set; }

        /// <summary>
        /// If the cl_khr_d3d11_sharing extension is enabled, returns CL_TRUE if Direct3D 11 resources created as shared by 
        /// setting MiscFlags to include D3D11_RESOURCE_MISC_SHARED will perform faster when shared with OpenCL, 
        /// compared with resources which have not set this flag.
        /// Otherwise returns CL_FALSE.
        /// </summary>
        public bool D3D11PreferSharedResourcesKHR { get; private set; }

        /// <summary>
        /// An OpenCL context is created with one or more devices. 
        /// Contexts are used by the OpenCL runtime for managing objects such as command-queues, memory, program and kernel objects 
        /// and for executing kernels on one or more devices specified in the context.
        /// </summary>
        /// <param name="devices">Duplicate devices specified in devices are ignored.</param>
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
        /// 
        /// <returns>An OpenCL context.</returns>
        public CLContext(CLDevice[] devices, CL.pfn_notifyDelegate pfn_notify = null, byte[] user_data = null)
        {
            CLDevicePtr[] dids = new CLDevicePtr[devices.Length];

            for (int i = 0; i < dids.Length; i++)
                dids[i] = devices[i].Handle;

            Handle = CL.CreateContext(CLContextProperties.None,
                dids.Length,
                dids,
                pfn_notify,
                user_data,
                out CLResult errcode_ret);

            if (errcode_ret != CLResult.Success)
                throw new Exception("Failed to create CL context! " + errcode_ret);
            Populate();
        }

        /// <summary>
        /// An OpenCL context is created with one or more devices. 
        /// Contexts are used by the OpenCL runtime for managing objects such as command-queues, memory, program and kernel objects 
        /// and for executing kernels on one or more devices specified in the context.
        /// </summary>
        /// <param name="handle">The handle to the GPU context created elsewhere</param>
        public CLContext(IntPtr handle)
        {
            Handle = new CLContextPtr();
            Handle.Handle = handle;
            Populate();
        }

        /// <summary>
        /// An OpenCL context is created with one or more devices. 
        /// Contexts are used by the OpenCL runtime for managing objects such as command-queues, memory, program and kernel objects 
        /// and for executing kernels on one or more devices specified in the context.
        /// </summary>
        /// <param name="handle">The handle to the GPU context created elsewhere</param>
        public CLContext(CLContextPtr handle)
        {
            Handle = handle;
            Populate();
        }

        /// <summary>
        /// Create an OpenCL context from a device type that identifies the specific device(s) to use.
        /// Only devices that are returned by GetDeviceIDs for device_type are used to create the context. 
        /// The context does not reference any sub-devices that may have been created from these devices.
        /// </summary>
        /// <param name="devicetype">A bit-field that identifies the type of device</param>
        /// <param name="pfn_notify">A callback function that can be registered by the application. 
        /// This callback function will be used by the OpenCL implementation to report information on errors during 
        /// context creation as well as errors that occur at runtime in this context. 
        /// This callback function may be called asynchronously by the OpenCL implementation. 
        /// It is the application's responsibility to ensure that the callback function is thread-safe. 
        /// If pfn_notify is NULL, no callback function is registered.</param>
        /// <param name="user_data">Passed as the user_data argument when pfn_notify is called. user_data can be NULL.</param>
        public CLContext(CLDeviceType devicetype, CL.pfn_notifyDelegate pfn_notify = null, byte[] user_data = null)
        {
            Handle = CL.CreateContextFromType(CLContextProperties.None,
                devicetype,
                pfn_notify,
                user_data,
                out CLResult errcode_ret);

            if (errcode_ret != CLResult.Success)
                throw new Exception("Failed to create CL context! " + errcode_ret);

            Populate();
        }

        private void Populate()
        {
            foreach (CLContextInfo requestType in Enum.GetValues(typeof(CLContextInfo)))
            {
                CLResult result;
                int bytesRead = 0;

                result = CL.GetContextInfo(Handle, requestType, 0, null, out bytesRead);

                if (result != CLResult.Success)
                {
                    //throw new Exception("Failed to Query Command Queue attribute size! " + requestType + " Error: " + result);
                }
                byte[] param_value = new byte[bytesRead];
                result = CL.GetContextInfo(Handle, requestType, bytesRead, param_value, out bytesRead);

                if (result != CLResult.Success)
                {
                    //throw new Exception("Failed to Query Command Queue attribute! " + requestType + " Error: " + result);
                }

                switch (requestType)
                {
                    case CLContextInfo.D3D11PreferSharedResourcesKHR:
                        if (bytesRead > 0)
                        {
                            D3D11PreferSharedResourcesKHR = BitConverter.ToInt32(param_value, 0) > 0;
                        }
                        break;
                    case CLContextInfo.Devices:
                        if (bytesRead > 0)
                        {
                            int idx = 0;
                            Devices = new CLDevicePtr[bytesRead / 8];
                            for (int i = 0; i < bytesRead; i += 8)
                            {
                                CLDevicePtr dev = new CLDevicePtr();
                                dev.Handle = new IntPtr(BitConverter.ToInt64(param_value, i));
                                Devices[idx++] = dev;
                            }
                        }
                        else
                            Devices = new CLDevicePtr[0];
                        break;
                    case CLContextInfo.NumberOfDevices:
                        if (bytesRead > 0)
                        {
                            NumberOfDevices = BitConverter.ToInt32(param_value, 0);
                        }
                        break;
                    case CLContextInfo.Properties:
                        if (bytesRead > 0)
                        {
                            if (bytesRead > 0)
                            {
                                int idx = 0;
                                Properties = new CLContextProperties[bytesRead / 4];
                                for (int i = 0; i < bytesRead; i += 4)
                                    Properties[idx++] = (CLContextProperties)(BitConverter.ToInt32(param_value, i));
                            }
                            else
                                Properties = new CLContextProperties[0];
                        }
                        break;
                    case CLContextInfo.ReferenceCount:
                        break;
                }
            }
        }

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
        public CLImageFormat[] GetSupportedImageFormats(CLMemoryFlags flags, CLMemoryObjectType Type)
        {
            int num_entries = 0;
            CLResult result = CL.GetSupportedImageFormats(Handle, flags, Type, num_entries, null, out num_entries);

            if (result != CLResult.Success)
                throw new Exception("GetSupportedImageFormats failed to call OpenCL. Error: " + result);

            CLImageFormat[] image_formats = new CLImageFormat[num_entries];
            result = CL.GetSupportedImageFormats(Handle, flags, Type, num_entries, image_formats, out _);

            if (result != CLResult.Success)
                throw new Exception("GetSupportedImageFormats failed to call OpenCL. Error: " + result);

            return image_formats;
        }

        /// <summary>
        /// Creates a 1D image, 1D image buffer, 1D image array, 2D image, 2D image array or 3D image object.
        /// </summary>
        /// <param name="flags">
        /// A bit-field that is used to specify allocation and usage information about the image memory object 
        /// being created and is described in the table below.
        /// 
        /// For all image types except Image1DBuffer, if value specified for flags is 0, 
        /// the default is used which is ReadWrite.</param>
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
        /// <returns>a valid non-zero image object created</returns>
        /// <exception cref="Exception">Throws an exception if the image failed to create.</exception>
        public CLBuffer CreateImage(CLMemoryFlags flags,
                      CLImageFormat image_format,
                      CLImageDescription image_desc,
                      IntPtr host_ptr = default(IntPtr)) 
        {
            CLMemoryPtr mem = CL.CreateImage(Handle,
                      flags,
                      image_format,
                      image_desc,
                      host_ptr,
                      out CLResult errcode_ret);


            if (errcode_ret != CLResult.Success)
                throw new Exception("CreateImage failed to call OpenCL. Error: " + errcode_ret);

            return new CLBuffer(mem);
        }


        /// <summary>
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="flags">A bit-field that is used to specify allocation and usage information about the image memory 
        /// object being created and is described in the table List of supported CLMemoryFlags values for Create.</param>
        /// <param name="image_format">A structure that describes format properties of the image to be allocated. 
        /// See CLImageFormat for a detailed description of the image format descriptor.</param>
        /// <param name="Width">The width and height of the image in pixels. These must be values greater than or equal to 1.</param>
        /// <param name="Height">The width and height of the image in pixels. These must be values greater than or equal to 1.</param>
        /// <param name="RowPitch">The scan-line pitch in bytes. This must be 0 if preExistingData is NULL and can be either 
        /// 0 or greater than or equal to Width * size of element in bytes if preExistingData is not NULL. 
        /// If preExistingData is not NULL and RowPitch is equal to 0, RowPitch is calculated as 
        /// Width * size of element in bytes. 
        /// If RowPitch is not 0, it must be a multiple of the image element size in bytes.</param>
        /// <param name="preExistingData">A pointer to the image data that may already be allocated by the application. 
        /// The size of the buffer that preExistingData points to must be greater than or equal to RowPitch * Height.
        /// The size of each element in bytes must be a power of 2. 
        /// The image data specified by preExistingData is stored as a linear sequence of adjacent scanlines. 
        /// Each scanline is stored as a linear sequence of image elements.</param>
        /// <returns>a valid non-zero image object created</returns>
        /// <exception cref="Exception">Throws an exception if the image failed to create.</exception>
        [Obsolete]
        public CLBuffer CreateImage2D(CLMemoryFlags flags,
                            CLImageFormat image_format,
                            int Width,
                            int Height,
                            int RowPitch, CLBuffer preExistingData = null)
        {

            CLMemoryPtr mem = CL.CreateImage2D(
                Handle,
                flags,
                image_format,
                Width,
                Height,
                RowPitch,
                preExistingData.Handle,
                out CLResult errcode_ret);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CreateImage2D failed to call OpenCL. Error: " + errcode_ret);

            return new CLBuffer(mem);
        }

        /// <summary>
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="flags">A bit-field that is used to specify allocation and usage information about the image
        /// memory object being created and is described in the table List of supported CLMemoryFlags values for Create.</param>
        /// <param name="image_format">A pointer to a structure that describes format properties of the image to be allocated. 
        /// See CLImageFormat for a detailed description of the image format descriptor.</param>
        /// <param name="Width">The width and height of the image in pixels. These must be values greater than or equal to 1.</param>
        /// <param name="Height">The width and height of the image in pixels. These must be values greater than or equal to 1.</param>
        /// <param name="Depth">The depth of the image in pixels. This must be a value greater than 1.</param>
        /// <param name="RowPitch">The scan-line pitch in bytes. 
        /// This must be 0 if preExistingData is NULL and can be either 0 or greater than or equal to 
        /// Width * size of element in bytes if preExistingData is not NULL. 
        /// If preExistingData is not NULL and RowPitch is equal to 0, RowPitch is calculated as 
        /// Width * size of element in bytes. 
        /// If RowPitch is not 0, it must be a multiple of the image element size in bytes.</param>
        /// <param name="SlicePitch">
        /// The size in bytes of each 2D slice in the 3D image.
        /// This must be 0 if preExistingData is NULL and can be either 0 or greater than or equal to 
        /// RowPitch * Height if preExistingData is not NULL.
        /// If preExistingData is not NULL and SlicePitch equal to 0, SlicePitch is calculated as RowPitch * Height. 
        /// If SlicePitch is not 0, it must be a multiple of the RowPitch.
        /// </param>
        /// <param name="preExistingData">
        /// A pointer to the image data that may already be allocated by the application. 
        /// The size of the buffer that preExistingData points to must be greater than or equal to SlicePitch * Depth. 
        /// The size of each element in bytes must be a power of 2. 
        /// The image data specified by preExistingData is stored as a linear sequence of adjacent 2D slices. 
        /// Each 2D slice is a linear sequence of adjacent scanlines. 
        /// Each scanline is a linear sequence of image elements.
        /// </param>
        /// <returns>a valid non-zero image object created</returns>
        /// <exception cref="Exception">Throws an exception if the image failed to create.</exception>
        [Obsolete]
        public CLBuffer CreateImage3D(CLMemoryFlags flags,
                            CLImageFormat image_format,
                            int Width,
                            int Height,
                            int Depth,
                            int RowPitch,
                            int SlicePitch,
                            CLBuffer preExistingData = null) 
        {
            CLMemoryPtr mem = CL.CreateImage3D(Handle,
                            flags,
                            image_format,
                            Width,
                            Height,
                            Depth,
                            RowPitch,
                            SlicePitch,
                            preExistingData.Handle.Handle,
                            out CLResult errcode_ret);


            if (errcode_ret != CLResult.Success)
                throw new Exception("CreateImage3D failed to call OpenCL. Error: " + errcode_ret);

            return new CLBuffer(mem);
        }

        /// <summary>
        /// Creates an OpenCL buffer object from an OpenGL buffer object.
        /// 
        /// The size of the GL buffer object data store at the time CreateFromGLBuffer is 
        /// called will be used as the size of buffer object returned by CreateFromGLBuffer. 
        /// If the state of a GL buffer object is modified through the GL API (e.g. glBufferData) 
        /// while there exists a corresponding CL buffer object, subsequent use of the 
        /// CL buffer object will result in undefined behavior.
        /// 
        /// </summary>
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
        /// <returns>a valid non-zero image object created</returns>
        /// <exception cref="Exception">Throws an exception if the image failed to create.</exception>
        public CLBuffer CreateFromGLBuffer(CLMemoryFlags flags,
                             IntPtr bufobj) 

        {
            CLMemoryPtr mem = CL.CreateFromGLBuffer(Handle,
                                  flags,
                                  bufobj,
                                 out CLResult errcode_ret);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CreateFromGLBuffer failed to call OpenCL. Error: " + errcode_ret);

            return new CLBuffer(mem);

        }

        /// <summary>
        /// Creates an OpenCL image object, image array object, or image buffer object from an OpenGL texture object, 
        /// texture array object, texture buffer object, or a single face of an OpenGL cubemap texture object.
        /// 
        /// </summary>
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
        /// used to create the OpenCL image memory object. Only GL texture objects with an internal format that 
        /// maps to appropriate image channel order and data type specified in tables 5.5 and 5.6 (see CLImageFormat) 
        /// may be used to create the OpenCL image memory object.
        /// </param>
        /// <returns>a valid non-zero image object created</returns>
        /// <exception cref="Exception">Throws an exception if the image failed to create.</exception>
        public CLBuffer CreateFromGLTexture(CLMemoryFlags flags,
                              TextureTarget target,
                              int miplevel,
                              IntPtr texture) 

        {
            CLMemoryPtr mem = CL.CreateFromGLTexture(Handle,
                               flags,
                               target,
                               miplevel,
                               texture,
                              out CLResult errcode_ret);


            if (errcode_ret != CLResult.Success)
                throw new Exception("CreateFromGLTexture failed to call OpenCL. Error: " + errcode_ret);

            return new CLBuffer(mem);

        }

        /// <summary>
        /// Creates an OpenCL 2D image object from an OpenGL renderbuffer object.
        /// </summary>
        /// <param name="flags">
        /// A bit-field that is used to specify usage information. 
        /// Refer to the table at Create for a description of flags. 
        /// Only ReadOnly, WriteOnly, and ReadWrite values specified in the table at Create can be used.
        /// </param>
        /// <param name="renderbuffer">
        /// The name of a GL renderbuffer object. 
        /// The renderbuffer storage must be specified before the image object can be created. 
        /// The renderbuffer format and dimensions defined by OpenGL will be used to create the 2D image object. 
        /// Only GL renderbuffers with internal formats that map to appropriate image channel order and data type specified in tables
        /// 5.5 and 5.6 (see CLImageFormat) can be used to create the 2D image object.
        /// </param>
        /// <returns>a valid non-zero image object created</returns>
        /// <exception cref="Exception">Throws an exception if the image failed to create.</exception>
        public CLBuffer CreateFromGLRenderbuffer(CLMemoryFlags flags,
                                   IntPtr renderbuffer) 

        {

            CLMemoryPtr mem = CL.CreateFromGLRenderbuffer(Handle,
                                    flags,
                                    renderbuffer,
                                   out CLResult errcode_ret);


            if (errcode_ret != CLResult.Success)
                throw new Exception("CreateFromGLRenderbuffer failed to call OpenCL. Error: " + errcode_ret);

            return new CLBuffer(mem);
        }

        /// <summary>
        /// Creates an OpenCL 2D image object from an OpenGL 2D texture object, or a single face of an OpenGL cubemap texture object.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/CreateFromGLTexture2D.html
        /// </summary>
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
        /// Using Rectangle for texture_target requires OpenGL 3.1. Alternatively, RectangleARB 
        /// may be specified if the OpenGL extension GL_ARB_texture_rectangle is supported.
        /// </param>
        /// <param name="miplevel">The mipmap level to be used. Implementations may return InvalidOperation for miplevel values greater than 0.</param>
        /// <param name="texture">
        /// The name of a GL 2D, cubemap or rectangle texture object. 
        /// The texture object must be a complete texture as per OpenGL rules on texture completeness. 
        /// The texture format and dimensions defined by OpenGL for the specified miplevel of the texture will be used to create the 
        /// 2D image object. Only GL texture objects with an internal format that maps to appropriate image channel order and data type 
        /// specified in the table of supported Image Channel Order Values and the table of supported Image Channel Data Types at 
        /// CLImageFormat may be used to create a 2D image object.
        /// </param>
        /// <returns>a valid non-zero image object created</returns>
        /// <exception cref="Exception">Throws an exception if the image failed to create.</exception>
        [Obsolete]
        public CLBuffer CreateFromGLTexture2D(CLMemoryFlags flags,
                                TextureTarget target,
                                int miplevel,
                                IntPtr texture) 

        {
            CLMemoryPtr mem = CL.CreateFromGLTexture2D(Handle,
                                 flags,
                                 target,
                                 miplevel,
                                 texture,
                                out CLResult errcode_ret);


            if (errcode_ret != CLResult.Success)
                throw new Exception("CreateFromGLTexture2D failed to call OpenCL. Error: " + errcode_ret);

            return new CLBuffer(mem);
        }

        /// <summary>
        /// Creates an OpenCL 3D image object from an OpenGL 3D texture object.
        /// 
        /// Description
        /// If the state of a GL texture object is modified through the GL API(e.g.the OpenGL functions glTexImage2D or glTexImage3D, 
        /// or the values of the texture parameters GL_TEXTURE_BASE_LEVEL or GL_TEXTURE_MAX_LEVEL are modified) while there exists a 
        /// corresponding CL image object, subsequent use of the CL image object will result in undefined behavior.
        /// 
        /// The Retain and Release functions can be used to retain and release the image objects.
        /// 
        /// 
        /// Notes
        /// OpenCL 1.0 supports read-only 3D image memory objects.Writes to 3D image objects that are GL 3D textures are
        /// supported if the OpenCL implementation supports the cl_khr_3d_image_writes extension. 
        /// 3D images are optional in the embedded profile.If 3D images are not supported by the OpenCL embedded profile,
        /// the errcode_ret argument to CreateFromGLTexture3D will return InvalidOperation.
        /// 
        /// https://www.khronos.org/registry/OpenCL/sdk/1.0/docs/man/xhtml/CreateFromGLTexture3D.html
        /// </summary>
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
        /// 3D image object. Only GL texture objects with an internal format that maps to appropriate image channel order and 
        /// data type specified in the table of supported Image Channel Order Values and the table of supported Image Channel Data Types 
        /// at CLImageFormat can be used to create the 3D image object.
        /// </param>
        /// <returns>a valid non-zero image object created</returns>
        /// <exception cref="Exception">Throws an exception if the image failed to create.</exception>
        [Obsolete]
        public CLBuffer CreateFromGLTexture3D(CLMemoryFlags flags,
                                TextureTarget target,
                                int miplevel,
                                uint texture) 

        {
            CLMemoryPtr mem = CL.CreateFromGLTexture3D(Handle,
                                flags,
                                target,
                                miplevel,
                                texture,
                                out CLResult errcode_ret);


            if (errcode_ret != CLResult.Success)
                throw new Exception("CreateFromGLTexture3D failed to call OpenCL. Error: " + errcode_ret);

            return new CLBuffer(mem);
        }

        private bool _disposed = false;
        public void Dispose()
        {
            if (_disposed) return;

            CLResult result = CL.Release(Handle);

            if (result != CLResult.Success)
            {
                ///TODO: Silent fail or throw?
                Console.WriteLine("Failed to release context from GPU! " + result);
            }

            _disposed = true;
        }

        ~CLContext() { Dispose(); }

        public static implicit operator CLContextPtr(CLContext from)
            => from.Handle;

        public static explicit operator CLContext(CLContextPtr from)
            => new (from);


    }
}
