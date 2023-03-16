using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrairieCL.OpenCL
{
    /// <summary>
    /// A link to memory stored on the GPU.
    /// Used to tell the GPU where to pass data to and from the host memory (regular RAM)
    /// </summary>
    public class CLBuffer : IDisposable
    {
        /// <summary>
        /// The actual handle pointing to this data on the GPU.
        /// </summary>
        public CLMemoryPtr Handle;

        /// <summary>
        /// The pinned data this buffer was created with. 
        /// We hold the memory in a static location so we can tell the GPU where it is
        /// without the garbage collector moving it around on us. 
        /// </summary>
        internal GCHandle GlobalDataPointer;

        #region Get Mem Object Info

        /// <summary>
        /// Returns one of the following values:
        /// Buffer if memobj is created with Create or clCreateSubBuffer.
        /// 
        /// CLImageDescription.Type argument value if memobj is created with CreateImage.
        /// 
        /// Pipe if memobj is created with clCreatePipe.
        /// </summary>
        public CLMemoryObjectType Type
        {
            get
            {
                int param_value_size = 0;

                CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
                           CLMemoryInfo.Type,
                           param_value_size,
                           IntPtr.Zero,
                           out param_value_size);

                if (errcode_ret != CLResult.Success)
                    throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

                IntPtr data = Marshal.AllocHGlobal(param_value_size);

                errcode_ret = CL.GetMemObjectInfo(Handle,
                           CLMemoryInfo.Type,
                           param_value_size,
                           data,
                           out param_value_size);

                if (errcode_ret != CLResult.Success)
                    throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


                int sz = Marshal.ReadInt32(data);
                Marshal.FreeHGlobal(data);
                return (CLMemoryObjectType)sz;
            }
        }
    

        /// <summary>
        /// Returns the flags argument value specified when memobj is created with 
        /// Create, clCreateSubBuffer, CreateImage, or clCreatePipe.
        /// If memobj is a sub-buffer the memory access qualifiers inherited from parent buffer is also returned.
        /// </summary>
        public CLMemoryFlags Flags
        {
            get
            {

            int param_value_size = 0;

            CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.Flags,
                       param_value_size,
                       IntPtr.Zero,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

            IntPtr data = Marshal.AllocHGlobal(param_value_size);

            errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.Flags,
                       param_value_size,
                       data,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


            int sz = Marshal.ReadInt32(data);
            Marshal.FreeHGlobal(data);
            return (CLMemoryFlags)sz;
        }
    }

        /// <summary>
        /// Return actual size of the data store associated with memobj in bytes.
        /// </summary>
        public long Size
        {
            get
            {

            int param_value_size = 0;

            CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.Size,
                       param_value_size,
                       IntPtr.Zero,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

            IntPtr data = Marshal.AllocHGlobal(param_value_size);

            errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.Size,
                       param_value_size,
                       data,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


                long sz = (long)Marshal.ReadInt64(data);
                Marshal.FreeHGlobal(data);
                return (long)sz;
        }
    }

        /// <summary>
        /// If memobj is created with Create or CreateImage and UseHostPointer is specified in mem_flags, 
        /// return the host_ptr argument value specified when memobj is created.Otherwise a NULL value is returned.
        /// 
        /// If memobj is created with clCreateSubBuffer, return the host_ptr + origin value specified when memobj is created.
        /// host_ptr is the argument value specified to Create and UseHostPointer is specified in mem_flags 
        /// for memory object from which memobj is created.Otherwise a NULL value is returned.
        /// </summary>
        public IntPtr HostPointer
        {
            get
            {

            int param_value_size = 0;

            CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.HostPointer,
                       param_value_size,
                       IntPtr.Zero,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.HostPointer failed to call OpenCL. Error: " + errcode_ret);

            IntPtr data = Marshal.AllocHGlobal(param_value_size);

            errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.HostPointer,
                       param_value_size,
                       data,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.HostPointer failed to call OpenCL. Error: " + errcode_ret);


                long sz = Marshal.ReadInt64(data);
                Marshal.FreeHGlobal(data); //Not sure about this. Seems redundant?
                return new IntPtr(sz);
        }
    }

        /// <summary>
        /// Map count. 
        /// The map count returned should be considered immediately stale.It is unsuitable for general use in 
        /// applications.This feature is provided for debugging.
        /// </summary>
        public int MapCount
        {
            get
            {

            int param_value_size = 0;

            CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.MapCount,
                       param_value_size,
                       IntPtr.Zero,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

            IntPtr data = Marshal.AllocHGlobal(param_value_size);

            errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.MapCount,
                       param_value_size,
                       data,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


                int sz = Marshal.ReadInt32(data);
                Marshal.FreeHGlobal(data);
                return (int)sz;
        }
    }

        /// <summary>
        /// Return memobj reference count. 
        /// The reference count returned should be considered immediately stale.
        /// It is unsuitable for general use in applications.This feature is provided for identifying memory leaks.
        /// </summary>
        public int ReferenceCount
        {
            get
            {

            int param_value_size = 0;

            CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.ReferenceCount,
                       param_value_size,
                       IntPtr.Zero,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

            IntPtr data = Marshal.AllocHGlobal(param_value_size);

            errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.ReferenceCount,
                       param_value_size,
                       data,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


                int sz = Marshal.ReadInt32(data);
                Marshal.FreeHGlobal(data);
                return sz;
        }
    }

        /// <summary>
        /// Return context specified when memory object is created.
        /// If memobj is created using clCreateSubBuffer, the context associated with the memory object specified as the 
        /// buffer argument to clCreateSubBuffer is returned.
        /// </summary>
        public CLContext Context
        {
            get
            {

                int param_value_size = 0;

                CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
                           CLMemoryInfo.Context,
                           param_value_size,
                           IntPtr.Zero,
                           out param_value_size);

                if (errcode_ret != CLResult.Success)
                    throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

                IntPtr data = Marshal.AllocHGlobal(param_value_size);

                errcode_ret = CL.GetMemObjectInfo(Handle,
                           CLMemoryInfo.Context,
                           param_value_size,
                           data,
                           out param_value_size);

                if (errcode_ret != CLResult.Success)
                    throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


                long sz = Marshal.ReadInt64(data);
                Marshal.FreeHGlobal(data);
                return new CLContext(new IntPtr(sz));
            }
        }

        /// <summary>
        /// Return memory object from which memobj is created.
        /// This returns the memory object specified as buffer argument to clCreateSubBuffer if memobj is a subbuffer object 
        /// created using clCreateSubBuffer.
        /// 
        /// This returns the mem_object specified in CLImageDescription if memobj is an image object.
        /// 
        /// Otherwise a NULL value is returned.
        /// </summary>
        public CLBuffer AssociatedMemoryObject
        {
            get
            {

            int param_value_size = 0;

            CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.AssociatedMemoryObject,
                       param_value_size,
                       IntPtr.Zero,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

            IntPtr data = Marshal.AllocHGlobal(param_value_size);

            errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.AssociatedMemoryObject,
                       param_value_size,
                       data,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


                long sz = Marshal.ReadInt64(data);
                Marshal.FreeHGlobal(data);
                return new CLBuffer(new IntPtr(sz));
            }
    }

        /// <summary>
        /// Return offset if memobj is a sub-buffer object created using clCreateSubBuffer.
        /// This returns 0 if memobj is not a subbuffer object.
        /// </summary>
        public int Offset
        {
            get
            {

            int param_value_size = 0;

            CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.Offset,
                       param_value_size,
                       IntPtr.Zero,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

            IntPtr data = Marshal.AllocHGlobal(param_value_size);

            errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.Offset,
                       param_value_size,
                       data,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


                int sz = Marshal.ReadInt32(data);
                Marshal.FreeHGlobal(data);
                return sz;
            }
    }

        /// <summary>
        /// Return CL_TRUE if memobj is a buffer object that was created with UseHostPointer or is a subbuffer object of a 
        /// buffer object that was created with UseHostPointer and the host_ptr specified when the buffer object 
        /// was created is a SVM pointer; otherwise returns CL_FALSE.
        /// </summary>
        public bool UsesSVMPointer
        {
            get
            {

            int param_value_size = 0;

            CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.UsesSVMPointer,
                       param_value_size,
                       IntPtr.Zero,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

            IntPtr data = Marshal.AllocHGlobal(param_value_size);

            errcode_ret = CL.GetMemObjectInfo(Handle,
                       CLMemoryInfo.UsesSVMPointer,
                       param_value_size,
                       data,
                       out param_value_size);

            if (errcode_ret != CLResult.Success)
                throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


                int sz = Marshal.ReadInt32(data);
                Marshal.FreeHGlobal(data);
                return sz != 0;
        }
    }

        #endregion

        #region Get Image Info
        /// <summary>
        /// Return image format descriptor specified when image is created with CreateImage.
        /// </summary>
        public CLImageFormat Format { get; private set; }

        /// <summary>
        /// Return size of each element of the image memory object given by image in bytes. 
        /// An element is made up of n channels. 
        /// The value of n is given in CLImageFormat descriptor.
        /// </summary>
        public int ElementSize { get; private set; }

        /// <summary>
        /// Return calculated row pitch in bytes of a row of elements of the image object given by image.
        /// </summary>
        public int RowPitch { get; private set; }

        /// <summary>
        /// Return calculated slice pitch in bytes of a 2D slice for the 3D image object or size of each image in a 
        /// 1D or 2D image array given by image. For a 1D image, 1D image buffer and 2D image object return 0.
        /// </summary>
        public int SlicePitch { get; private set; }

        /// <summary>
        /// Return width of image in pixels.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Return height of image in pixels. For a 1D image, 1D image buffer and 1D image array object, height = 0.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Return depth of the image in pixels. For a 1D image, 1D image buffer, 2D image or 1D and 2D image array object, depth = 0.
        /// </summary>
        public int Depth { get; private set; }

        /// <summary>
        /// Return number of images in the image array. If image is not an image array, 0 is returned.
        /// </summary>
        public int ArraySize { get; private set; }

        /// <summary>
        /// deprecated
        /// </summary>
        [Obsolete]
        public IntPtr Buffer { get; private set; }

        /// <summary>
        /// Return NumberOfMipLevels associated with image.
        /// </summary>
        public int NumberOfMipLevels { get; private set; }

        /// <summary>
        /// Return NumberOfSamples associated with image.
        /// </summary>
        public int NumberOfImageSamples { get; private set; }


        ///// <summary>
        ///// (if the cl_khr_d3d10_sharing extension is enabled) 
        ///// If image was created using clCreateFromD3D10Texture2DKHR or clCreateFromD3D10Texture3DKHR, 
        ///// returns the subresource argument specified when image was created.
        ///// 
        ///// D3D10Resource *
        ///// </summary>
        //public D3D10Resource* D3D10SubresourceKHR = 0x4016,
        ///// <summary>
        ///// If the cl_khr_d3d11_sharing extension is suported, If image was created using clCreateFromD3D11Texture2DKHR, 
        ///// or clCreateFromD3D11Texture3DKHR, returns the subresource argument specified when image was created.
        ///// 
        ///// ID3D11Resource *
        ///// </summary>
        //public ID3D11Resource* D3D11SubresourceKHR = 0x401F,
        ///// <summary>
        ///// Returns the plane argument value specified when memobj is created using clCreateFromDX9MediaSurfaceKHR. 
        ///// (If the cl_khr_dx9_media_sharing extension is supported)
        ///// 
        ///// uint
        ///// </summary>
        //public IntPtr DX9MediaPlaneKHR = 0x202A
        #endregion

        #region Get GL Object Info

        /// <summary>
        /// The type of GL object attached
        /// </summary>
        public CLGLObjectType GLObjectType { get; private set; }

        /// <summary>
        /// Returns the GL object name used to create this mem obj
        /// </summary>
        public uint GLObjectName { get; private set; }
        #endregion

        #region Get GL Texture Info
        /// <summary>
        /// The miplevel argument specified in CreateFromGLTexture.
        /// </summary>
        public int MipmapLevel { get; private set; }

        /// <summary>
        /// If the cl_khr_gl_msaa_sharing extension is supported, the samples argument passed to 
        /// glTexImage2DMultisample or glTexImage3DMultisample. 
        /// If image is not a MSAA texture, 1 is returned.
        /// </summary>
        public int NumberOfGLObjectSamples { get; private set; }

        /// <summary>
        /// The texture_target argument specified in CreateFromGLTexture.
        /// </summary>
        public int TextureTarget { get; private set; }
        #endregion

        //    /// <summary>
        //    /// If the cl_khr_d3d10_sharing extension is enabled, and if memobj was created using 
        //    /// clCreateFromD3D10BufferKHR, clCreateFromD3D10Texture2DKHR, or clCreateFromD3D10Texture3DKHR, 
        //    /// returns the resource argument specified when memobj was created.
        //    /// </summary>
        //    public ID3D10Resource* D3D10ResourceKHR
        //    {
        //        get
        //        {

        //        int param_value_size = 0;

        //        CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
        //                   CLMemoryInfo.D3D10ResourceKHR,
        //                   param_value_size,
        //                   IntPtr.Zero,
        //                   out param_value_size);

        //        if (errcode_ret != CLResult.Success)
        //            throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

        //        IntPtr data = Marshal.AllocHGlobal(param_value_size);

        //        errcode_ret = CL.GetMemObjectInfo(Handle,
        //                   CLMemoryInfo.D3D10ResourceKHR,
        //                   param_value_size,
        //                   data,
        //                   out param_value_size);

        //        if (errcode_ret != CLResult.Success)
        //            throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


        //        //int sz = Marshal.ReadInt32(data)
        //        //Marshal.FreeHGlobal(data);
        //        //return (T)sz;

        //        //CLMemoryObjectType sz = (CLMemoryObjectType)BitConverter.ToInt64(data, 0);
        //        Marshal.FreeHGlobal(data);
        //        return val;

        //    }
        //}

        //    /// <summary>
        //    /// Returns the cl_dx9_media_adapter_type_khr argument value specified when memobj is created using 
        //    /// clCreateFromDX9MediaSurfaceKHR (If the cl_khr_dx9_media_sharing extension is supported)
        //    /// </summary>
        //    public cl_dx9_media_adapter_type_khr DX9MediaAdapterTypeKHR
        //    {
        //        get
        //        {

        //        int param_value_size = 0;

        //        CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
        //                   CLMemoryInfo.DX9MediaAdapterTypeKHR,
        //                   param_value_size,
        //                   IntPtr.Zero,
        //                   out param_value_size);

        //        if (errcode_ret != CLResult.Success)
        //            throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

        //        IntPtr data = Marshal.AllocHGlobal(param_value_size);

        //        errcode_ret = CL.GetMemObjectInfo(Handle,
        //                   CLMemoryInfo.DX9MediaAdapterTypeKHR,
        //                   param_value_size,
        //                   data,
        //                   out param_value_size);

        //        if (errcode_ret != CLResult.Success)
        //            throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


        //        //int sz = Marshal.ReadInt32(data)
        //        //Marshal.FreeHGlobal(data);
        //        //return (T)sz;

        //        //CLMemoryObjectType sz = (CLMemoryObjectType)BitConverter.ToInt64(data, 0);
        //        Marshal.FreeHGlobal(data);
        //        return val;

        //    }
        //}

        //    /// <summary>
        //    /// Returns the cl_dx9_surface_info_khr argument value specified when memobj is created using 
        //    /// clCreateFromDX9MediaSurfaceKHR (If the cl_khr_dx9_media_sharing extension is supported)
        //    /// </summary>
        //    public cl_dx9_surface_info_khr DX9MediaSurfaceInfoKHR
        //    {
        //        get
        //        {

        //        int param_value_size = 0;

        //        CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
        //                   CLMemoryInfo.DX9MediaSurfaceInfoKHR,
        //                   param_value_size,
        //                   IntPtr.Zero,
        //                   out param_value_size);

        //        if (errcode_ret != CLResult.Success)
        //            throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

        //        IntPtr data = Marshal.AllocHGlobal(param_value_size);

        //        errcode_ret = CL.GetMemObjectInfo(Handle,
        //                   CLMemoryInfo.DX9MediaSurfaceInfoKHR,
        //                   param_value_size,
        //                   data,
        //                   out param_value_size);

        //        if (errcode_ret != CLResult.Success)
        //            throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


        //        //int sz = Marshal.ReadInt32(data)
        //        //Marshal.FreeHGlobal(data);
        //        //return (T)sz;

        //        //CLMemoryObjectType sz = (CLMemoryObjectType)BitConverter.ToInt64(data, 0);
        //        Marshal.FreeHGlobal(data);
        //        return val;

        //    }
        //}

        //    /// <summary>
        //    /// If the cl_khr_d3d11_sharing extension is supported, if memobj was created using 
        //    /// clCreateFromD3D11BufferKHR, clCreateFromD3D11Texture2DKHR, or clCreateFromD3D11Texture3DKHR, 
        //    /// returns the resource argument specified when memobj was created.
        //    /// </summary>
        //    public ID3D11Resource* D3D11ResourceKHR
        //    {
        //        get
        //        {

        //        int param_value_size = 0;

        //        CLResult errcode_ret = CL.GetMemObjectInfo(Handle,
        //                   CLMemoryInfo.D3D11ResourceKHR,
        //                   param_value_size,
        //                   IntPtr.Zero,
        //                   out param_value_size);

        //        if (errcode_ret != CLResult.Success)
        //            throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);

        //        IntPtr data = Marshal.AllocHGlobal(param_value_size);

        //        errcode_ret = CL.GetMemObjectInfo(Handle,
        //                   CLMemoryInfo.D3D11ResourceKHR,
        //                   param_value_size,
        //                   data,
        //                   out param_value_size);

        //        if (errcode_ret != CLResult.Success)
        //            throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);


        //        //int sz =Marshal.ReadInt32(data)
        //        //Marshal.FreeHGlobal(data);
        //        //return (T)sz;

        //        //CLMemoryObjectType sz = (CLMemoryObjectType)BitConverter.ToInt64(data, 0);
        //        Marshal.FreeHGlobal(data);
        //        return val;

        //    }
        //}

        /// <summary>
        /// Creates a GPU Memory Object Buffer from the specified Handle.
        /// </summary>
        /// <param name="handle"></param>
        public CLBuffer(IntPtr handle)
        {
            Handle = new CLMemoryPtr();
            Handle.Handle = handle;

            //GetGetImageInfo();
            //GetGLObjectInfo();
            //GetGLTextureInfo();


        }

        /// <summary>
        /// Creates a GPU Memory Object Buffer from the specified Handle.
        /// </summary>
        /// <param name="handle"></param>
        public CLBuffer(CLMemoryPtr handle)
        {
            Handle = handle;

            //GetGetImageInfo();
            //GetGLObjectInfo();
            //GetGLTextureInfo();
        }

        /// <summary>
        /// Creates a buffer object and allocats memory on the GPU. 
        /// 
        /// Does not init data on the GPU. To do this (send data to the gpu) see <see cref="CLCommandQueue.EnqueueWriteBuffer"/>
        /// </summary>
        /// <param name="context">Owner context to create this allocation under</param>
        /// <param name="flags">
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to 
        /// allocate the buffer object and how it will be used. 
        /// The default is used which is ReadWrite.</param>
        /// <param name="size">The size in bytes of the buffer memory object to be allocated.</param>
        /// <param name="dataAlreadyOnGpu">
        /// A pointer to the buffer data that may already be allocated by the application. 
        /// The size of the buffer that host_ptr points to must be ≥ size bytes.
        /// </param>
        public CLBuffer(CLContext context, int[] data, CLMemoryFlags flags = CLMemoryFlags.ReadWrite | CLMemoryFlags.UseHostPointer)
        {
            int sz = sizeof(int) * data.Length; // Marshal.SizeOf(typeof(int[])) * data.Length;
            CLResult errcode_ret;
            GlobalDataPointer = GCHandle.Alloc(data, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);
            
            Handle = CL.CreateBuffer(context.Handle, flags, sz, GlobalDataPointer.AddrOfPinnedObject(), out errcode_ret);
            
            if (errcode_ret != CLResult.Success) {
                throw new Exception("Failed to create CLBuffer! Error: " + errcode_ret);
            }

            //GetGetImageInfo();
            //GetGLObjectInfo();
            //GetGLTextureInfo();
        }

        /// <summary>
        /// Create a buffer object for the array of objects in the data parameter. 
        /// This allocates the memory on the GPU for data and passes to the data to the GPU.
        /// We then can use this buffer as a reference to the compute shader to pass as
        /// parameters and get the processed data back from the GPU 
        /// <see cref="ComputeShader.ReadBufferData{T}(CLBuffer, int, long)"/>
        /// </summary>
        /// <typeparam name="T">An unmanaged data type like a bittable struct, float, int, Vector3, etc.</typeparam>
        /// <param name="context">The Compute Shader Context to use <see cref="ComputeShader.Context"/></param>
        /// <param name="data">
        /// The Data to send to the GPU. For an output paremeter on a kernel this
        /// can be an empty array of the size of data we want back from the GPU.
        /// </param>
        /// <param name="flags">Usage flags describing how this buffer will be used</param>
        /// <returns>The Buffer now on the GPU.</returns>
        /// <exception cref="Exception">Thrown if the GPU failed to create a new buffer reference.</exception>
        public static CLBuffer Create<T>(CLContext context, T[] data, CLMemoryFlags flags = CLMemoryFlags.ReadWrite | CLMemoryFlags.UseHostPointer) where T: unmanaged
        {
            int sz = Marshal.SizeOf(typeof(T)) * data.Length; // Marshal.SizeOf(typeof(int[])) * data.Length;
            CLResult errcode_ret;
            GCHandle GlobalDataPointer = GCHandle.Alloc(data, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            CLMemoryPtr Handle = CL.CreateBuffer(context.Handle, flags, sz, GlobalDataPointer.AddrOfPinnedObject(), out errcode_ret);


            if (errcode_ret != CLResult.Success)
            {
                throw new Exception("Failed to create CLBuffer! Error: " + errcode_ret);
            }

            CLBuffer buf = new CLBuffer(Handle);
            buf.GlobalDataPointer = GlobalDataPointer;

            return buf;
        }

        /// <summary>
        /// Create a buffer object for the object passed in the data parameter. 
        /// This allocates the memory on the GPU for data and passes to the data to the GPU.
        /// We then can use this buffer as a reference to the compute shader to pass as
        /// parameters and get the processed data back from the GPU 
        /// <see cref="ComputeShader.ReadBufferData{T}(CLBuffer, int, long)"/>
        /// </summary>
        /// <typeparam name="T">An unmanaged data type like a bittable struct, float, int, Vector3, etc.</typeparam>
        /// <param name="context">The Compute Shader Context to use <see cref="ComputeShader.Context"/></param>
        /// <param name="data">
        /// The Data to send to or reference later on the GPU.
        /// </param>
        /// <param name="flags">Usage flags describing how this buffer will be used</param>
        /// <returns>The Buffer now on the GPU.</returns>
        /// <exception cref="Exception">Thrown if the GPU failed to create a new buffer reference.</exception>
        public static CLBuffer Create<T>(CLContext context, T data, CLMemoryFlags flags = CLMemoryFlags.ReadWrite | CLMemoryFlags.UseHostPointer) where T : unmanaged
        {
            int sz = Marshal.SizeOf(typeof(T));

            CLResult errcode_ret;
            GCHandle GlobalDataPointer = GCHandle.Alloc(data, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            CLMemoryPtr Handle = CL.CreateBuffer(context.Handle, flags, sz, GlobalDataPointer.AddrOfPinnedObject(), out errcode_ret);


            if (errcode_ret != CLResult.Success)
            {
                throw new Exception("Failed to create CLBuffer! Error: " + errcode_ret);
            }

            CLBuffer buf = new CLBuffer(Handle);
            buf.GlobalDataPointer = GlobalDataPointer;

            return buf;
        }

        /// <summary>
        /// Get information specific to an image object created with CreateImage.
        /// </summary>
        public void GetGetImageInfo()
        {
            foreach (CLImageInfo param_name in Enum.GetValues(typeof(CLImageInfo)))
            {

                int param_value_size = 0;
                CLResult errcode_ret;

                errcode_ret = CL.GetImageInfo(Handle,
                       param_name,
                       param_value_size,
                       IntPtr.Zero,
                       out int param_value_size_ret);

                if (errcode_ret != CLResult.Success)
                {
                    return; //Not an image
                            //throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);
                }

                IntPtr data = Marshal.AllocHGlobal(param_value_size);

                errcode_ret = CL.GetImageInfo(Handle,
                       param_name,
                       param_value_size,
                       data,
                       out param_value_size_ret);

                if (errcode_ret != CLResult.Success)
                {
                    Marshal.FreeHGlobal(data);
                    return;
                    // throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);
                }

                switch (param_name)
                {
                    case CLImageInfo.ArraySize:
                        ArraySize = Marshal.ReadInt32(data);
                        break;
                    case CLImageInfo.Buffer:
                        Buffer = new IntPtr(Marshal.ReadInt64(data));
                        break;
                    case CLImageInfo.D3D10SubresourceKHR:
                        //D3D10SubresourceKHR = data.ToInt32();
                        break;
                    case CLImageInfo.D3D11SubresourceKHR:
                        //D3D11SubresourceKHR = data.ToInt32();
                        break;
                    case CLImageInfo.Depth:
                        Depth = Marshal.ReadInt32(data);
                        break;
                    case CLImageInfo.DX9MediaPlaneKHR:
                        //DX9MediaPlaneKHR = data.ToInt32();
                        break;
                    case CLImageInfo.ElementSize:
                        ElementSize = Marshal.ReadInt32(data);
                        break;
                    case CLImageInfo.Format:
                        Format = Marshal.PtrToStructure<CLImageFormat>(data);
                        break;
                    case CLImageInfo.Height:
                        Height = Marshal.ReadInt32(data);
                        break;
                    case CLImageInfo.NumberOfMipLevels:
                        NumberOfMipLevels = Marshal.ReadInt32(data);
                        break;
                    case CLImageInfo.NumberOfSamples:
                        NumberOfImageSamples = Marshal.ReadInt32(data);
                        break;
                    case CLImageInfo.RowPitch:
                        RowPitch = Marshal.ReadInt32(data);
                        break;
                    case CLImageInfo.SlicePitch:
                        SlicePitch = Marshal.ReadInt32(data);
                        break;
                    case CLImageInfo.Width:
                        Width = Marshal.ReadInt32(data);
                        break;
                }

                Marshal.FreeHGlobal(data);
            }
        }

        /// <summary>
        /// Query this buffer about OpenGL object used to create it.
        /// </summary>
        public void GetGLObjectInfo()
        {
            CLGLObjectType objType;
            uint name;

            CLResult errcode_ret = CL.GetGLObjectInfo(Handle,
                          out objType,
                          out name);

            if (errcode_ret != CLResult.Success)
            {
                GLObjectType = CLGLObjectType.Undefined;
                return; //Not  GL Object
                //throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);
            }

            GLObjectType = objType;
            GLObjectName = name;
        }

        /// <summary>
        /// Populates additional information about the GL texture object associated with a memory object.
        /// </summary>
        public void GetGLTextureInfo()
        {
            foreach (CLGLTextureInfo param_name in Enum.GetValues(typeof(CLGLTextureInfo)))
            {
                int param_value_size = 4;
                int param_value;

                CLResult errcode_ret = CL.GetGLTextureInfo(Handle,
                               param_name,
                               param_value_size,
                               out param_value,
                               out param_value_size);

                if (errcode_ret != CLResult.Success)
                {
                    //Marshal.FreeHGlobal(data);
                    return; //Not a texture.
                    // throw new Exception("CLBuffer.Type failed to call OpenCL. Error: " + errcode_ret);
                }

                switch (param_name)
                {
                    case CLGLTextureInfo.MipmapLevel:
                        MipmapLevel = param_value;
                        break;
                    case CLGLTextureInfo.NumberOfSamples:
                        NumberOfGLObjectSamples = param_value;
                        break;
                    case CLGLTextureInfo.TextureTarget:
                        TextureTarget = param_value;
                        break;
                    
                }

               // Marshal.FreeHGlobal(data);
            }
        }

        /// <summary>
        /// Releases this buffer from the GPU.
        /// </summary>
        public void Dispose()
        {
            //if (GlobalDataPointer != null && GlobalDataPointer != IntPtr.Zero)
            //    Marshal.FreeHGlobal(GlobalDataPointer);
            if (GlobalDataPointer != null && GlobalDataPointer.IsAllocated)
            {
                GlobalDataPointer.Free();

                try
                {
                    CLResult result = CL.Release(Handle);

                    if (result != CLResult.Success)
                    {
                        Console.WriteLine("Warning: Failed to release command queue! " + result);
                    }
                }
                catch (Exception) { }
            }
        }

        ~CLBuffer() { Dispose(); }

        /// <summary>
        /// Gets the memory handle of this buffer object
        /// </summary>
        /// <param name="from"></param>
        public static implicit operator CLMemoryPtr(CLBuffer from)
            => from.Handle;

        /// <summary>
        /// Creates a Buffer object from a memory handle already on the gpu.
        /// </summary>
        /// <param name="from"></param>
        public static explicit operator CLBuffer(CLMemoryPtr from)
            => new(from);
    }
}
