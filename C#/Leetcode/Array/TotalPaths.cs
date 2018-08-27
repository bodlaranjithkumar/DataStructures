using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Question - https://www.geeksforgeeks.org/count-number-ways-reach-destination-maze/
    // Similar to Rat-Maz problem - https://www.geeksforgeeks.org/rat-in-a-maze-backtracking-2/

    public class TotalPaths
    {
        //public static void Main(string[] args)
        //{
        //    TotalPaths tot = new TotalPaths();

        //    int[,] matrix = {{1,1,1,1,1},
        //                     {1,0,1,0,1},
        //                     {1,0,1,0,1},
        //                     {1,1,1,1,1}};

        //    Console.WriteLine(tot.CountTotalPaths(matrix));     // expected: 3

        //    int[,] matrix1 = {{1,1,1,1},
        //                      {1,0,1,1},
        //                      {0,1,1,1},
        //                      {1,1,1,1}};

        //    Console.WriteLine(tot.CountTotalPaths(matrix1));     // expected: 4

        //    Console.ReadKey();
        //}

        int m = 0, n = 0, count = 0;

        public int CountTotalPaths(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;

            m = matrix.GetLength(0);
            n = matrix.GetLength(1);

            CountTotalPaths(matrix, 0, 0);

            return count;
        }

        private void CountTotalPaths(int[,] matrix, int i, int j)
        {
            if (i >= m || j >= n || matrix[i, j] == 0)
                return;

            if (i == m - 1 && j == n - 1)
            {
                count++;
                return;
            }

            CountTotalPaths(matrix, i, j + 1); // go right
            CountTotalPaths(matrix, i + 1, j); // go down
        }
    }
}
