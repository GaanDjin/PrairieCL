# PrairieCL
OpenCL wrapper for C#

```
/// Test Compute Shader:
void TestComputeShader()
{
    ComputeShader testShader = new ComputeShader(
         @"
            __kernel void helloworld(__global int* BufferData) {

             const int index_x = get_global_id(0);
            const int index_y = get_global_id(1);
            const int index_z = get_global_id(2);
            const int X = get_global_size(0);
            const int Y = get_global_size(1);
            const int Z = get_global_size(2);
            const int index_here = X*(Y*index_z + index_y) + index_x;

            BufferData[index_here] = index_x + index_y + index_z;
         }
         ");

    int[] bufData = new int[64];

    CLBuffer parameter = CLBuffer.Create(ComputeShader.Context, bufData);


    int session = testShader.ExecuteKernel("helloworld", new Vector3i(4, 4, 4), new Vector3i(1, 1, 1), new CLBuffer[] { parameter });
    testShader.Wait(session);
    int[] result = testShader.ReadBufferData<int>(parameter, session).ToArray();

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
