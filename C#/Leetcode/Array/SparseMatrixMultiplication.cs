using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 311
    // Submission Detail: https://leetcode.com/submissions/detail/182412206/

    public class SparseMatrixMultiplication
    {
        //public static void Main(string[] args)
        //{
        //    SparseMatrixMultiplication mul = new SparseMatrixMultiplication();

        //    int[,] A = { { 1, 0, 0 }, { -1, 0, 3 } };
        //    int[,] B = { { 7, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } };
        //    Stopwatch watch = new Stopwatch();

        //    watch.Start();
        //    int[,] result = mul.Multiply(A, B);
        //    watch.Stop();

        //    Helper.PrintMatrix(result); //{{7,0,0},{-7,0,3}};
        //    Console.WriteLine($"UnOptimized Elapsed time:{watch.ElapsedTicks}");

        //    watch.Start();
        //    result = mul.MultiplyOptimized(A, B);
        //    watch.Stop();

        //    Helper.PrintMatrix(result); //{{7,0,0},{-7,0,3}};
        //    Console.WriteLine($"Optimized Elapsed time:{watch.ElapsedTicks}");

        //    Console.ReadKey();
        //}

        // Tx = O(m * n * nB)
        // Sx = O(m * nB)
        public int[,] MultiplyOptimized(int[,] A, int[,] B)
        {
            int m = A.GetLength(0), n = A.GetLength(1), nB = B.GetLength(1);
            int[,] result = new int[m, nB];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    // This is the key in sparse matrix since it skips the next for loop.
                    if (A[i, j] != 0)      
                        for (int k = 0; k < nB; k++)
                            if (B[j, k] != 0)
                                result[i, k] += A[i, j] * B[j, k];

            return result;
        }

        public int[,] Multiply(int[,] A, int[,] B)
        {
            int m = A.GetLength(0), n = A.GetLength(1), nB = B.GetLength(1);
            int[,] result = new int[m, nB];

            for (int i = 0; i < m; i++)
                for (int k = 0; k < nB; k++)
                    for (int j = 0; j < n; j++)
                        if (A[i, j] != 0 && B[j, k] != 0)
                            result[i, k] += A[i, j] * B[j, k];

            return result;
        }
    }
}
