using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrairieCL.OpenCL
{
    /// <summary>
    /// The command queue manages Kernel calls to the GPU.
    /// </summary>
    public class CLCommandQueue : IDisposable
    {
        /// <summary>
        /// The pointer to the OpenCL Command Queue on the GPU
        /// </summary>
        public CLCommandQueuePtr Handle;

        /// <summary>
        /// The Context that created this CommandQueue
        /// 
        /// This is really just for reference and doesn't need to be used. <see cref="CLContext"/>
        /// </summary>
        public CLContextPtr ParentContext { get; private set; }

        /// <summary>
        /// The Device (GPU) that created this CommandQueue.
        /// 
        /// This is really just for reference and doesn't need to be used. <see cref="CLDevice"/>
        /// </summary>
        public CLDevicePtr ParentDevice { get; private set; }

        /// <summary>
        /// Return the command-queue reference count.
        /// The reference count returned should be considered immediately stale.
        /// It is unsuitable for general use in applications.
        /// This feature is provided for identifying memory leaks.
        /// </summary>
        public long ReferenceCount
        {
            get
            {
                int bytesRead = 8;
                IntPtr data = Marshal.AllocHGlobal(bytesRead);
                CLResult result = CL.GetCommandQueueInfo(Handle, CLCommandQueueInfo.ReferenceCount, bytesRead, data, out bytesRead);

                if (result != CLResult.Success)
                {
                    throw new Exception("Failed to Query Command Queue Reference Count! Error: " + result);
                }

                long count = Marshal.ReadInt64(data);

                Marshal.FreeHGlobal(data);

                return count;
            }
        }

        /// <summary>
        /// Return the currently specified properties for the command-queue. 
        /// These properties are specified by the value associated with the CL_COMMAND_QUEUE_PROPERTIES passed 
        /// in properties argument in CreateCommandQueueWithProperties.
        /// (The propertied used when creating this command queue, currently internally set to 0 (Default value))
        /// </summary>
        public CLCommandQueueProperties Properties { get; private set; }

        /// <summary>
        /// Return the currently specified size for the device command-queue. 
        /// This query is only supported for device command queues.
        /// </summary>
        public long Size {
            get
            {
                int bytesRead = 8;
                IntPtr data = Marshal.AllocHGlobal(bytesRead);
                CLResult result = CL.GetCommandQueueInfo(Handle, CLCommandQueueInfo.Size, bytesRead, data, out bytesRead);

                if (result != CLResult.Success)
                {
                    throw new Exception("Failed to Query Command Queue Size! Error: " + result);
                }

                long sz = Marshal.ReadInt64(data);

                Marshal.FreeHGlobal(data);

                return sz;
            }
        }

        /// <summary>
        /// Gets a command queue using the OpenCL pointer. 
        /// </summary>
        /// <param name="handle">The GPU pointer of the command queue on the gpu</param>
        internal CLCommandQueue(CLCommandQueuePtr handle)
        {
            Handle = handle;
            Populate();
        }

        /// <summary>
        /// Gets a command queue using the OpenCL pointer. 
        /// 
        /// To Create a command queue on the GPU use: <see cref="CreateCommandQueueWithProperties"/>
        /// </summary>
        /// <param name="handle">The GPU pointer of the command queue on the gpu</param>
        public CLCommandQueue(IntPtr handle)
        {
            Handle = new CLCommandQueuePtr();
            Handle.Handle = handle;
            Populate();
        }

        /// <summary>
        /// Creates a command queue on the specified device (GPU) using the specified context.
        /// </summary>
        /// <param name="context">The Context on the GPU to use.</param>
        /// <param name="device">The GPU Device to use.</param>
        /// <exception cref="Exception">If the command queue fails to create an Exception is thrown with the GPU result code</exception>
        public CLCommandQueue(CLContext context, CLDevice device)
        {
            if (context == null)
                throw new ArgumentNullException("Creting CLCommandQueue requires a context! (device context cannot be null)");
            if (device == null)
                throw new ArgumentNullException("Creting CLCommandQueue requires a device! (device argument cannot be null)");

            CLResult result;
            CLCommandQueuePtr handle = CL.CreateCommandQueueWithProperties(context.Handle,
                device.Handle,
                new CLCommandQueueProperties[] { CLCommandQueueProperties.Default },
                out result);

            if (result != CLResult.Success)
            {
                throw new Exception("Faild to create command queue! " + result);
            }

            Handle = handle;
            Populate();
        }

        /// <summary>
        /// Create a host or device command-queue on a specific device.
        /// </summary>
        /// <param name="context">The Context on the GPU to use.</param>
        /// <param name="device">The GPU Device to use.</param>
        /// <returns>A CLCommandQueue </returns>
        /// <exception cref="Exception">If the command queue fails to create an Exception is thrown with the GPU result code</exception>
        public static CLCommandQueue CreateCommandQueueWithProperties(CLContext context, CLDevice device)
        {
            CLResult result;
            CLCommandQueuePtr handle = CL.CreateCommandQueueWithProperties(context.Handle,
                device.Handle,
                new CLCommandQueueProperties[] { CLCommandQueueProperties.Default },
                out result);

            if (result != CLResult.Success)
            {
                throw new Exception("Faild to create command queue! " + result);
            }

            CLCommandQueue commandQueue = new CLCommandQueue(handle);

            return commandQueue;
        }

        /// <summary>
        /// Get and fill the properties of this CLCommandQueue object.
        /// </summary>
        /// <exception cref="Exception">Throws an exception if the call to OpenCL fails.</exception>
        private void Populate()
        {
            CLResult result;
            foreach (CLCommandQueueInfo requestType in Enum.GetValues(typeof(CLCommandQueueInfo)))
            {
                int bytesRead = 0;

                result = CL.GetCommandQueueInfo(Handle, requestType, 0, IntPtr.Zero, out bytesRead);

                if (result != CLResult.Success)
                {
                    //throw new Exception("Failed to Query Command Queue attribute size! " + requestType + " Error: " + result);
                }

                IntPtr data = Marshal.AllocHGlobal(bytesRead);
                result = CL.GetCommandQueueInfo(Handle, requestType, bytesRead, data, out bytesRead);

                if (result != CLResult.Success)
                {
                    //throw new Exception("Failed to Query Command Queue attribute! " + requestType + " Error: " + result);
                }

                switch (requestType)
                {
                    case CLCommandQueueInfo.Context:
                        CLContextPtr con = new CLContextPtr();
                        con.Handle = new IntPtr(Marshal.ReadInt64(data));
                        ParentContext = con;
                        break;
                    case CLCommandQueueInfo.Device:
                        CLDevicePtr dev = new CLDevicePtr();
                        dev.Handle = new IntPtr(Marshal.ReadInt64(data));
                        ParentDevice = dev;
                        break;
                    case CLCommandQueueInfo.Properties:
                        Properties = (CLCommandQueueProperties)Marshal.ReadInt32(data);
                        break;
                    case CLCommandQueueInfo.ReferenceCount:
                        //We will use the property (Dangerous?) to update the reference count on request. ReferenceCount
                        break;
                    case CLCommandQueueInfo.Size:
                        //We will use the property (Dangerous?) to update the reference count on request. 
                        break;
                    case CLCommandQueueInfo.EndOfList:
                        //Do nothing. Just a placeholder.
                        break;
                }

                Marshal.FreeHGlobal(data);
            }
        }

        /// <summary>
        /// Issues all previously queued OpenCL commands in a command-queue to the device associated with the command-queue.
        /// 
        /// Flush only guarantees that all queued commands to command_queue will eventually be submitted to the 
        /// appropriate device There is no guarantee that they will be complete after Flush returns.
        /// Any blocking commands queued in a command-queue and Release perform an implicit flush of the command-queue.
        /// 
        /// To use event objects that refer to commands enqueued in a command-queue as event objects to wait on by commands 
        /// enqueued in a different command-queue, the application must call a Flush or any blocking commands that perform 
        /// an implicit flush of the command-queue where the commands that refer to these event objects are enqueued.
        /// </summary>
        /// <exception cref="Exception">Thrown if OpenCL failes to flush the command queue.</exception>
        public void Flush()
        {
            CLResult result = CL.Flush(Handle);

            if (result != CLResult.Success)
            {
                throw new Exception("Failed to flush command queue! " + result);
            }
        }

        /// <summary>
        /// Blocks until all previously queued OpenCL commands in a command-queue are issued to the associated device and have completed.
        /// 
        /// Finish does not return until all previously queued commands in command_queue have been processed and completed. 
        /// Finish is also a synchronization point.
        /// </summary>
        /// <exception cref="Exception">Thrown if OpenCL failes to flush the command queue.</exception>
        public void Finish()
        {
            CLResult result = CL.Finish(Handle);

            if (result != CLResult.Success)
            {
                throw new Exception("Failed to execute finish on command queue! " + result);
            }
        }

        /* Enqueued Commands APIs */


        /// <summary>
        /// Enqueues a command to execute a kernel on a device.
        /// </summary>
        /// <param name="kernel">The Kernel to Execute</param>
        /// <param name="work_dim">
        /// The number of dimensions to run. Must be 1 to 3 (inclusive)
        /// Usually: 3
        /// </param>
        /// <param name="global_work_offset">
        /// The global worker id offset
        /// Usually: Vector3i.Zero</param>
        /// <param name="global_work_size">
        /// The size of the global workgroup
        /// Multipule of 2. Like (32, 32, 32) or (8, 8, 8)
        /// Specific to the Compute Shader
        /// </param>
        /// <param name="local_work_size">
        /// The size of the local workgroup
        /// Multipule of 2. Like (32, 32, 32) or (8, 8, 8)
        /// Specific to the Compute Shader
        /// </param>
        /// <param name="event_wait_list">
        /// Events that need to complete before this command can execute.
        /// Can be null or empty to run now.
        /// </param>
        /// <param name="evt">A reference to this command. Can be used to tell other commands to wait for this one.</param>
        /// <returns>The OpenCL queue result. Success if this command completed successfully.</returns>
        public CLResult EnqueueKernel(CLKernel kernel,
                       int work_dim,
                       Vector3i global_work_offset,
                       Vector3i global_work_size,
                       Vector3i local_work_size,
                       CLEvent[] event_wait_list,
                       out CLEvent evt)
        {
            if (event_wait_list == null)
                event_wait_list = new CLEvent[0];

            CLEventPtr[] evtList = new CLEventPtr[event_wait_list.Length];

            for (int i = 0; i < evtList.Length; i++)
                evtList[i] = event_wait_list[i].Handle;
            CLEventPtr cl_Event;

            CLResult result = CL.EnqueueNDRangeKernel(Handle,
                                   kernel,
                                   work_dim,
                                   new ulong[] { (ulong)global_work_offset.X, (ulong)global_work_offset.Y, (ulong)global_work_offset.Z },
                                   new ulong[] { (ulong)global_work_size.X, (ulong)global_work_size.Y, (ulong)global_work_size.Z },
                                   new ulong[] { (ulong)local_work_size.X, (ulong)local_work_size.Y, (ulong)local_work_size.Z },
                                   evtList.Length,
                                   evtList.Length == 0 ? null : evtList,
                                   out cl_Event);

            evt = new CLEvent(cl_Event);

            return result;
        }


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
        /// <param name="data">The pointer to buffer in host memory where data is to be read into.</param>
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
        public CLResult EnqueueReadBuffer<T>(CLBuffer buffer,
                    bool blocking_read,
                    int offset,
                    out T[] data,
                    CLEvent[] event_wait_list,
                    out CLEvent evt) where T: unmanaged
        {
            CLResult result;
            
            if (event_wait_list == null)
                event_wait_list = new CLEvent[0];

            CLEventPtr[] evtList = new CLEventPtr[event_wait_list.Length];

            for(int i = 0; i < evtList.Length; i++)
                evtList[i] = event_wait_list[i].Handle;
            CLEventPtr cl_Event;

            int dataSize = (int)buffer.Size;
            data = new T[dataSize / Marshal.SizeOf(typeof(T))];

            if (buffer.GlobalDataPointer == null || !buffer.GlobalDataPointer.IsAllocated)
                buffer.GlobalDataPointer = GCHandle.Alloc(data, GCHandleType.Pinned);

            result = CL.EnqueueReadBuffer(Handle,
                     buffer.Handle,
                     blocking_read,
                     offset,
                     dataSize,
                     buffer.GlobalDataPointer.AddrOfPinnedObject(),
                     evtList.Length,
                     evtList.Length == 0 ? null : evtList,
                     out cl_Event); ;

            data = buffer.GlobalDataPointer.Target as T[];
            //gCHandle.Free();

            evt = new CLEvent(cl_Event);
            return result;
        }

         

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
        public CLResult EnqueueWriteBuffer<T>(CLBuffer buffer,
                     bool blocking_write,
                     int offset,
                     T[] data,
                     CLEvent[] event_wait_list,
                     out CLEvent evt) where T : unmanaged
        {
            if (event_wait_list == null)
                event_wait_list = new CLEvent[0];

            CLEventPtr[] evtList = new CLEventPtr[event_wait_list.Length];

            for (int i = 0; i < evtList.Length; i++)
                evtList[i] = event_wait_list[i].Handle;

            //if (buffer.GlobalDataPointer == IntPtr.Zero)
            //    buffer.GlobalDataPointer = Marshal.AllocHGlobal((int)buffer.Size);

            //fixed (void* a = data)
            //    Buffer.MemoryCopy(a, (void*)buffer.GlobalDataPointer, buffer.Size, buffer.Size);

            //int dataSize = Marshal.SizeOf(data);

            //Marshal.StructureToPtr(data, buffer.GlobalDataPointer, false);

            if (buffer.GlobalDataPointer == null || !buffer.GlobalDataPointer.IsAllocated)
            {
                //data = new T[dataSize];
                buffer.GlobalDataPointer = GCHandle.Alloc(data); // Marshal.AllocHGlobal(dataSize);
            }

            CLResult result;
            CLEventPtr cl_Event;

                result = CL.EnqueueWriteBuffer(Handle,
                    buffer,
                    blocking_write,
                    offset,
                    buffer.Size,
                    buffer.GlobalDataPointer.AddrOfPinnedObject(),
                    evtList.Length,
                    evtList.Length == 0 ? null : evtList,
                    out cl_Event);

            evt = new CLEvent(cl_Event);
            //data = Marshal.PtrToStructure<T>(buffer.GlobalDataPointer);

            //Marshal.Copy(buffer.GlobalDataPointer, data, 0, dataSize);

            return result;
        }

        ///// <summary>
        ///// Enqueues a command to copy from one buffer object to another.
        ///// 
        ///// 
        ///// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueCopyBuffer.html
        ///// </summary>
        ///// <param name="command_queue">The host command-queue in which the copy command will be queued. The OpenCL context associated with command_queue, src_buffer, and dst_buffer must be the same.</param>
        ///// <param name="src_buffer">The source buffer to copy from</param>
        ///// <param name="dst_buffer">The destination buffer to copy to</param>
        ///// <param name="src_offset">The offset where to begin copying data from src_buffer.</param>
        ///// <param name="dst_offset">The offset where to begin copying data into dst_buffer.</param>
        ///// <param name="size">Refers to the size in bytes to copy.</param>
        ///// <param name="num_events_in_wait_list">
        ///// Specify events that need to complete before this particular command can be executed. 
        ///// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        ///// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        ///// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list 
        ///// must be greater than 0. 
        ///// </param>
        ///// <param name="event_wait_list">
        ///// Specify events that need to complete before this particular command can be executed. 
        ///// If event_wait_list is NULL, then this particular command does not wait on any event to complete. 
        ///// If event_wait_list is NULL, num_events_in_wait_list must be 0. 
        ///// If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list 
        ///// must be greater than 0. 
        ///// The events specified in event_wait_list act as synchronization points. 
        ///// The context associated with events in event_wait_list and command_queue must be the same. 
        ///// The memory associated with event_wait_list can be reused or freed after the function returns.
        ///// </param>
        ///// <param name="evt">
        ///// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this 
        ///// particular command to complete. 
        ///// event can be NULL in which case it will not be possible for the application to query the status of this command or queue 
        ///// a wait for this command to complete. clEnqueueBarrierWithWaitList can be used instead. 
        ///// If the event_wait_list and the event arguments are not NULL, the event argument should not refer to an element of the 
        ///// event_wait_list array.
        ///// </param>
        ///// <returns>Returns Success if the function is executed successfully.</returns>
        //CLResult CL.EnqueueCopyBuffer(CLCommandQueuePtr command_queue,
        //            CLMemoryPtr src_buffer,
        //            CLMemoryPtr dst_buffer,
        //            int src_offset,
        //            int dst_offset,
        //            int size,
        //            int num_events_in_wait_list,
        //            CLEventPtr[] event_wait_list,
        //            [Out] out CLEventPtr evt);


        ///// <summary>
        ///// Enqueue commands to read from an image or image array object to host memory.
        ///// 
        ///// Notes
        ///// Calling EnqueueReadImage to read a region of the image with the ptr argument value set to 
        ///// host_ptr + (origin[2] * image slice pitch + origin[1] * image row pitch + origin[0] * bytes per pixel), 
        ///// where host_ptr is a pointer to the memory region specified when the image being read is created with 
        ///// UseHostPointer, must meet the following requirements in order to avoid undefined behavior:
        ///// 
        ///// All commands that use this image object have finished execution before the read command begins execution.
        ///// The row_pitch and slice_pitch argument values in EnqueueReadImage must be set to the image row pitch and slice pitch.
        ///// The image object is not mapped.
        ///// The image object is not used by any command-queue until the read command has finished execution.
        ///// If the mipmap extensions are enabled with cl_khr_mipmap_image, calls to EnqueueReadImage, EnqueueWriteImage 
        ///// and EnqueueMapImage can be used to read from or write to a specific mip-level of a mip-mapped image. 
        ///// If image argument is a 1D image, origin[1] specifies the mip-level to use.
        ///// If image argument is a 1D image array, origin[2] specifies the mip-level to use.
        ///// If image argument is a 2D image, origin[3] specifies the mip-level to use.
        ///// If image argument is a 2D image array or a 3D image, origin[3] specifies the mip-level to use.

        ///// https://www.khronos.org/registry/OpenCL/sdk/2.0/docs/man/xhtml/EnqueueReadImage.html
        ///// </summary>
        ///// <param name="command_queue"></param>
        ///// <param name="image"></param>
        ///// <param name="blocking_read"></param>
        ///// <param name="origin"></param>
        ///// <param name="region"></param>
        ///// <param name="row_pitch"></param>
        ///// <param name="slice_pitch"></param>
        ///// <param name="ptr"></param>
        ///// <param name="num_events_in_wait_list"></param>
        ///// <param name="event_wait_list"></param>
        ///// <param name="evt"></param>
        ///// <returns></returns>
        //CLResult CL.EnqueueReadImage(CLCommandQueuePtr command_queue,
        //           CLMemoryPtr image,
        //           bool blocking_read,
        //           Vector3i origin,
        //           Vector3i region,
        //           uint row_pitch,
        //           uint slice_pitch,
        //           IntPtr ptr,
        //           int num_events_in_wait_list,
        //           CLEventPtr[] event_wait_list,
        //           [Out] out CLEventPtr evt);

        //CLResult CL.EnqueueWriteImage(CLCommandQueuePtr command_queue,
        //                    CLMemoryPtr image,
        //                    bool blocking_write,
        //                    Vector3i origin,
        //                    Vector3i region,
        //                    uint input_row_pitch,
        //                    uint input_slice_pitch,
        //                    IntPtr ptr,
        //                    int num_events_in_wait_list,
        //                    CLEventPtr[] event_wait_list,
        //                    [Out] out CLEventPtr evt);

        //CLResult CL.EnqueueCopyImage(CLCommandQueuePtr command_queue,
        //                   CLMemoryPtr src_image,
        //                   CLMemoryPtr dst_image,
        //                   Vector3i src_origin,
        //                   Vector3i dst_origin,
        //                   Vector3i region,
        //                   int num_events_in_wait_list,
        //                   CLEventPtr[] event_wait_list,
        //                   [Out] out CLEventPtr evt);

        //CLResult CL.EnqueueCopyImageToBuffer(CLCommandQueuePtr command_queue,
        //                           CLMemoryPtr src_image,
        //                           CLMemoryPtr dst_buffer,
        //                           Vector3i src_origin,
        //                           Vector3i region,
        //                           int dst_offset,
        //                           int num_events_in_wait_list,
        //                           CLEventPtr[] event_wait_list,
        //                           [Out] out CLEventPtr evt);

        //CLResult CL.EnqueueCopyBufferToImage(CLCommandQueuePtr command_queue,
        //                           CLMemoryPtr src_buffer,
        //                           CLMemoryPtr dst_image,
        //                           int src_offset,
        //                           Vector3i dst_origin,
        //                           Vector3i region,
        //                           int num_events_in_wait_list,
        //                           CLEventPtr[] event_wait_list,
        //                           [Out] out CLEventPtr evt);

        //IntPtr CL.EnqueueMapBuffer(CLCommandQueuePtr command_queue,
        //                   CLMemoryPtr buffer,
        //                   bool blocking_map,
        //                   CLMapFlags map_flags,
        //                   int offset,
        //                   int size,
        //                   int num_events_in_wait_list,
        //                   CLEventPtr[] event_wait_list,
        //                   [Out] out CLEventPtr evt,
        //                   [Out] CLResult errcode_ret);

        //IntPtr CL.EnqueueMapImage(CLCommandQueuePtr command_queue,
        //                  CLMemoryPtr image,
        //                  bool blocking_map,
        //                  CLMapFlags map_flags,
        //                  Vector3i origin,
        //                  Vector3i region,
        //                  [Out] uint RowPitch,
        //                  [Out] uint SlicePitch,
        //                  int num_events_in_wait_list,
        //                  CLEventPtr[] event_wait_list,
        //                  [Out] out CLEventPtr evt,
        //                  [Out] CLResult errcode_ret);

        //CLResult CL.EnqueueUnmapMemObject(CLCommandQueuePtr command_queue,
        //                        CLMemoryPtr memobj,
        //                        IntPtr mapped_ptr,
        //                        int num_events_in_wait_list,
        //                        CLEventPtr[] event_wait_list,
        //                        [Out] out CLEventPtr evt);

        //CLResult CL.EnqueueNativeKernel(CLCommandQueuePtr command_queue,
        //              user_funcDelegate user_func,
        //              IntPtr args,
        //              uint cb_args,
        //              uint num_mem_objects,
        //              CLMemoryPtr[] mem_list,
        //              IntPtr[] args_mem_loc,
        //              int num_events_in_wait_list,
        //              CLEventPtr[] event_wait_list,
        //              [Out] out CLEventPtr evt);


        //CLResult CL.EnqueueAcquireGLObjects(CLCommandQueuePtr command_queue,
        //                          uint num_objects,
        //                          CLMemoryPtr[] mem_objects,
        //                          uint num_events_in_wait_list,
        //                          CLEventPtr[] event_wait_list,
        //                          [Out] out CLEventPtr evt);

        //CLResult CL.EnqueueReleaseGLObjects(CLCommandQueuePtr command_queue,
        //                          uint num_objects,
        //                          CLMemoryPtr[] mem_objects,
        //                          uint num_events_in_wait_list,
        //                          CLEventPtr[] event_wait_list,
        //                          [Out] out CLEventPtr evt);


        bool _disposed = false;

        /// <summary>
        /// Frees the allocated command queue from the GPU.
        /// TODO: Currently fails silently. Should we spaz or just assume that an OpenCL error isn't an issue here?
        /// </summary>
        public void Dispose()
        {
            if (_disposed) return;
            
            CLResult result = CL.Release(Handle);

            if (result != CLResult.Success)
            {
                Console.WriteLine("Warning: Failed to release command queue! " + result);
            }

            _disposed = true;
        }

        ~CLCommandQueue() { Dispose(); }

        public static implicit operator CLCommandQueuePtr(CLCommandQueue from)
            => from.Handle;

        public static implicit operator CLCommandQueue(CLCommandQueuePtr from)
            => new(from);
    }
}
