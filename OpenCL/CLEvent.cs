using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieCL.OpenCL
{
    /// <summary>
    /// An event is reference to jobs that are to be executed by the GPU. 
    /// This includes executing kernels or compying memory to/from the GPU. 
    /// We can use events to wait for the Compute Shader to finish a job before 
    /// trying to get the data back from the GPU, for instance. <see cref="ComputeShader.Wait(int)"/>
    /// </summary>
    public class CLEvent : IDisposable
    {
        public CLEventPtr Handle;

        public CLEvent(CLEventPtr handle)
        {

            Handle = handle;
        }

        public CLEvent(IntPtr handle)
        {
            Handle = new CLEventPtr();
            Handle.Handle = handle;
        }

        /// <summary>
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="param_name">Specifies the profiling data to query.</param>
        /// <returns>
        /// A 64-bit value that describes the current device time counter in nanoseconds when the command identified 
        /// by event param_name in a command-queue by the host.</returns>
        public ulong GetEventProfilingInfo(CLProfilingInfo param_name)
        {
            ulong val;

                /* Profiling APIs */
                CLResult result = CL.GetEventProfilingInfo(Handle,
                                    param_name,
                                    8,
                                    out val,
                                    out _);

            return val;
        }

        /// <summary>
        /// Waits on the host thread for commands identified by event objects to complete.
        /// </summary>
        /// <param name="event_list">The events specified in event_list act as synchronization points.</param>
        /// <returns></returns>
        public static CLResult WaitForEvents(CLEvent[] event_list)
        {
            CLEventPtr[] evtPtrs = new CLEventPtr[event_list.Length];
            for (int i = 0; i < evtPtrs.Length; i++)
                evtPtrs[i] = event_list[i].Handle;

            CLResult result = CL.WaitForEvents(event_list.Length, evtPtrs);

            return result;
        }

        /// <summary>
        /// Waits on the host thread for commands identified by event objects to complete.
        /// </summary>
        /// <param name="event_list">The events specified in event_list act as synchronization points.</param>
        /// <returns></returns>
        public CLResult WaitForEvent()
        {
            CLEventPtr[] evtPtrs = new CLEventPtr[] {Handle};
            CLResult result = CL.WaitForEvents(1, evtPtrs);

            return result;
        }

        private bool _disposed = false;

        public void Dispose()
        {
            if (_disposed)
                return;

            CLResult result = CLResult.InvalidEvent;
            try {
            result = CL.Release(Handle);
                Handle.Handle = IntPtr.Zero; // = new CLEventPtr(0);

 } catch (Exception) { }
            if (result != CLResult.Success)
            {
                ///TODO: Silent fail or throw?
                Console.WriteLine("Failed to release event from GPU! " + result);
            }

            _disposed = true;
        }

        ~CLEvent() { Dispose(); }

        public static implicit operator CLEventPtr(CLEvent from)
            => from.Handle;

        public static explicit operator CLEvent(CLEventPtr from)
            => new(from);
    }
}
