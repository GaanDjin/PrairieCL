# PrairieCL
OpenCL wrapper for C#

This small library wrapped OpenCL using PInvoke. There are no "unsafe" directives and use the OpenCL documentation for *almost* everywhere. 

This library is thread safe and in another project I use this to generate 64\*64\*64 voxel chunks of terrain over 11 threads. 

Using a compute shader is pretty straighforward: 



```C#
/// Test Compute Shader:
void TestComputeShader()
{

    //  Instantiate a Compute Shader by passing the shader code to the ComputeShader constructor
    ComputeShader testShader = new ComputeShader(
         @"
            __kernel void helloworld(__global int* BufferData) {

             const int index_x = get_global_id(0); //The global X value (Its total position not the local workgroup position) of the current thread.
            const int index_y = get_global_id(1); //The global Y value of the current thread.
            const int index_z = get_global_id(2); //The global Z value of the current thread.
            const int X = get_global_size(0); //The global X size of the job.
            const int Y = get_global_size(1); //The global Y size of the job.
            const int Z = get_global_size(2); //The global Z size of the job.
            
            //Working index of the output. Here we use a simple 3D position translated to a 1D array.
            const int index_here = X*(Y*index_z + index_y) + index_x;

            //Set the output to the sum of the worker thread position.
            BufferData[index_here] = index_x + index_y + index_z;
         }
         ");

    // Allocate the data on the Host side
    int[] bufData = new int[64];

    // Allocate the data on the GPU side and transmit the values in bufData to the GPU. 
    // For this case it's kind of redundant as we will only want to pull the data back after execution. 
    // But this is how we also pass input data to the GPU. 
    CLBuffer parameter = CLBuffer.Create(ComputeShader.Context, bufData);

    // Execute the helloworld function on the GPU. 
    // The workgroup selection is a bit tricky. 
    // Here the global workers (4,4,4) is the total number of workers we want to execute. 
    // In this example we have 4 workers in each dimension for a total of 64 threads being executed. 
    // The next local workers is (1,1,1). This is the number of workers per group. 
    // Basically this depends on the GPU hardware but allows us to process more threads than GPU can compute at once.    
    // We could use (4,4,4) and run all 64 threads at once. This doesn't really become an issue until you want to process
    // a larger amount of data. Say 262,144 data points in a 64*64*64 3D grid. 
    // Finally the last parameter is a CLBuffer array. This must match the same number of and data size of the kernel parameters. 
    // In this case we have one int* BufferData parameter and it needs to be 64 ints long (one for each thread executed)
    int session = testShader.ExecuteKernel("helloworld", new Vector3i(4, 4, 4), new Vector3i(1, 1, 1), new CLBuffer[] { parameter });
    // Next we wait for the GPU to finish executing the kernel job as ExecuteKernel dispatched the request asynconously.
    testShader.Wait(session);
    // Finally we need to get the result from the buffer we allocated earlier. 
    int[] result = testShader.ReadBufferData<int>(parameter, session).ToArray();

    // And for fun we'll output the result to the console. 
    // The result will be the sum of each global ID. 
    for (int i = 0; i < result.Length; i++)
    {
        Console.Write(result[i] + " ");
        if (i > 0 && (i + 1) % 16 == 0)
            Console.WriteLine();
        else if (i > 0 && (i + 1) % 8 == 0)
            Console.Write(" ");
    }

}
```
![The expected output from our Hello World Example.](/Images/VsDebugConsole_ZPxX1Vtxj9.png)

Below is an example of how I shape local workers for the total amount of threads on the global group. 

```C#

        /// <summary>
        /// Sets the max number of local workgroups that can be executed at once
        /// per compute shader. This expects <see cref="VoxelManager.ChunkSize"/> 
        /// to be a base 2 number (8, 16, 32, 64) and then works out the number of 
        /// workgroups that can run without exceeding the compute shader 
        /// <see cref="ComputeShader.MaxGroupSize"/>.
        /// 
        /// As an example:
        /// For instance if a dim 3 shader wanting to process a block of 64x64x64 
        /// with a max group size of 256 (Meaning all 3 dimentions cant exceed 256)
        /// The local workgroup size would need to be 4x4x4 = 64 which 
        /// is the largest cubed (x*y*z) base 2 number less than 256.
        /// The GPU will then execute the shader code 4 times of 64 threads each time 
        /// to make up the total 256 threads that need to be run. 
        /// </summary>
        private void SetMaxWorkgroupSize()
        {
            // ComputeShader computeShader; is a property or feild of the class this method lives in.
            int totalMaxGroupSize = (int)computeShader.MaxGroupSize;
            // In my case this code came from a Voxel engine I'm working on. 
            // I've set it to 64 units (My voxel chunks are equal length in all 3 dimensions)
            int sz = VoxelManager.ChunkSize;
            // Now we sz the total cube size to execute and break it down until 
            // we get a cubed dimension that fits our GPU specs
            while (sz * sz * sz > totalMaxGroupSize)
                sz = sz >> 1;

            localWorkers = new Vector3i(sz, sz, sz);


        }
```

Some GPUs don't support doubles unless you add the extension:
```C
#ifdef cl_khr_fp64
#pragma OPENCL EXTENSION cl_khr_fp64 : enable
#endif
```

Another useful function of this wrapper is `ComputeShader.AddInclude` which allows you to add several include files
that can be used in other files letting you split compute shader source code into everal files or parts. 

As always, if you find a problem please let me know. 


[OpenCL](https://www.khronos.org/opencl/)

[OpenCL-Guide](https://github.com/KhronosGroup/OpenCL-Guide)

[OpenCL Reference](https://registry.khronos.org/OpenCL/sdk/3.0/docs/man/html/)

