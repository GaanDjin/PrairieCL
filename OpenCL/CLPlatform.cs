using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieCL.OpenCL
{
    /// <summary>
    /// Describes a GPU and its capabilities. 
    /// The Base starting point for using OpenCL
    /// </summary>
    public class CLPlatform
    {
        /// <summary>
        /// Lists all platforms (GPUs) on this computer. 
        /// Start Here to get a CPU to execute kernels on.
        /// </summary>
        public static CLPlatform[] Platforms { get {
                if (_platforms == null)
                    Populate();
                return _platforms;
            }
        }

        private static CLPlatform[] _platforms = null;

        /// <summary>
        /// The OpenCL Handle for this platform on the GPU.
        /// </summary>
        public CLPlatformPtr Handle;

        /// <summary>
        /// The list of devices that exist under this GPU.
        /// </summary>
        public CLDevice[] Devices { get; private set; }

        internal CLDevicePtr[] DeviceHandles { get; private set; }

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
        public string Profile { get; private set; }

        /// <summary>
        /// OpenCL version string. Returns the OpenCL version supported by the implementation. 
        /// This version string has the following format:
        /// 
        /// "OpenCL major_version.minor_version platform_specific_information"
        /// 
        /// The major_version.minor_version value returned will be 2.0.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Platform name string.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Platform vendor string.
        /// </summary>
        public string Vendor { get; private set; }

        /// <summary>
        /// A list of extension names supported by the platform. 
        /// Extensions defined here must be supported by all devices associated with this platform.
        /// </summary>
        public string[] Extensions { get; private set; }
        
        /// <summary>
        /// If the cl_khr_icd extension is enabled, the function name suffix used to identify extension functions to be directed 
        /// to this platform by the ICD Loader.
        /// </summary>
        public string IcdSuffixKhr { get; private set; }

        /// <summary>
        /// Instantiate this platform. 
        /// </summary>
        /// <param name="platformhandle">The OpenCL platform handle.</param>
        public CLPlatform(IntPtr clHandle)
        {
            Handle = new CLPlatformPtr();
            Handle.Handle = clHandle;
        }

        /// <summary>
        /// Instantiate this platform. Used to fill <see cref="CLPlatform.Platforms"/> 
        /// </summary>
        /// <param name="platformhandle">The OpenCL platform handle.</param>
        internal CLPlatform(CLPlatformPtr platformhandle)
        {
            Handle = platformhandle;
        }

        /// <summary>
        /// Get and fill the properties of this CLPlatform object. Incl. the devices under this platform.
        /// </summary>
        /// <exception cref="Exception">Throws an exception if the call to OpenCL fails.</exception>
        private static void Populate()
        {

            int numPlatforms = 0;
            CLResult result = CL.GetPlatformIDs(0, null, out numPlatforms);

            if(result != CLResult.Success)
            {
                throw new Exception("Failed to Query OpenCL for number of platforms! " + result);
            }

            _platforms = new CLPlatform[numPlatforms];

            if (numPlatforms == 0)
                return;

            CLPlatformPtr[] platforms = new CLPlatformPtr[numPlatforms];
            result = CL.GetPlatformIDs(platforms.Length, platforms, out numPlatforms);
            //string[] platformNames = new string[numPlatforms];

            if (result != CLResult.Success)
            {
                throw new Exception("Failed to Query OpenCL for platforms! " + result);
            }

            int bytesRead;


            for (int i = 0; i < numPlatforms; i++) // (CLPlatformPtr platform in platforms)
            {
                CLPlatform platform = new CLPlatform(platforms[i]);

                string name = ""; // BitConverter.ToString(platformName, 0, (int)bytesRead);

                
                foreach (CLPlatformInfo requestType in Enum.GetValues(typeof(CLPlatformInfo)))
                {
                    //The name of the OpenGL Graphivs Card Processor
                    result = CL.GetPlatformInfo(platform.Handle, requestType, 0, null, out bytesRead);

                    if (result != CLResult.Success)
                    {
                        throw new Exception("Failed to Query Platform attribute size! " + requestType + " Error: " + result);
                    }

                    ///TODO: Replace byte[] with IntPtr to use Marshal to conver to string rather than looping chars?
                    byte[] platformName = new byte[bytesRead];
                    result = CL.GetPlatformInfo(platform.Handle, requestType, platformName.Length, platformName, out bytesRead);

                    if (result != CLResult.Success)
                    {
                        throw new Exception("Failed to Query Platform attribute! " + requestType + " Error: " + result);
                    }

                    name = ""; // BitConverter.ToString(platformName, 0, (int)bytesRead);
                    for (int j = 0; j < bytesRead - 1; j++)
                        name += (char)platformName[j];

                    switch (requestType)
                    {
                        case CLPlatformInfo.Extensions:
                            platform.Extensions = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            break;
                        case CLPlatformInfo.Profile:
                            platform.Profile = name;
                            break;
                        case CLPlatformInfo.ICDSuffixKHR:
                            platform.IcdSuffixKhr = name;
                            break;
                        case CLPlatformInfo.Name:
                            platform.Name = name;
                            break;
                        case CLPlatformInfo.Vendor:
                            platform.Vendor = name;
                            break;
                        case CLPlatformInfo.Version:
                            platform.Version = name;
                            break;
                    }
                }

                platform.GetDevices();

                _platforms[i] = platform;
            }
        }

        /// <summary>
        /// Get the devices under this platform.
        /// </summary>
        private void GetDevices()
        {
            CLResult result = CL.GetDeviceIDs(Handle, CLDeviceType.All, 0, null, out int numDevices);

            DeviceHandles = new CLDevicePtr[numDevices];
            result = CL.GetDeviceIDs(Handle, CLDeviceType.All, DeviceHandles.Length, DeviceHandles, out numDevices);

            Devices = new CLDevice[numDevices];

            for(int i = 0; i < numDevices; i++)
            {
                Devices[i] = new CLDevice(DeviceHandles[i]);
            }
        }


        public static implicit operator CLPlatformPtr(CLPlatform from)
            => from.Handle;

        public static explicit operator CLPlatform(CLPlatformPtr from)
            => new(from);
    }
}
