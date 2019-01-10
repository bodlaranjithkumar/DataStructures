using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 329 - https://leetcode.com/problems/longest-increasing-path-in-a-matrix/description/
    // Submission Detail - https://leetcode.com/submissions/detail/192309685/
    // Depth-First Traversal 

    public class LongestIncreasingPathInMatrix
    {
        int m, n, max;

        public int LongestIncreasingPath(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0)
                return 0;

            m = matrix.GetLength(0);
            n = matrix.GetLength(1);

            int[,] cache = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int currentMax = LongestIncreasingPath(i, j, matrix, cache, int.MaxValue);
                    max = System.Math.Max(currentMax, max);
                }
            }

            return max;
        }

        private int LongestIncreasingPath(int i, int j, int[,] matrix, int[,] cache, int callerValue)
        {
            // check boundary
            if (i < 0 || j < 0 || i >= m || j >= n || matrix[i, j] >= callerValue)
                return 0;

            // computing the max for the first time. Cache holds potential maxLength
            // at (i,j) and serves as visited if value is non-zero.
            if (cache[i, j] == 0)
            {
                int curr = matrix[i, j];
                int adjacentMax = 0;

                adjacentMax = System.Math.Max(LongestIncreasingPath(i + 1, j, matrix, cache, curr), adjacentMax);    // Go Down
                adjacentMax = System.Math.Max(LongestIncreasingPath(i - 1, j, matrix, cache, curr), adjacentMax);    // Go Up
                adjacentMax = System.Math.Max(LongestIncreasingPath(i, j + 1, matrix, cache, curr), adjacentMax);    // Go Right
                adjacentMax = System.Math.Max(LongestIncreasingPath(i, j - 1, matrix, cache, curr), adjacentMax);    // Go Left

                cache[i, j] = adjacentMax + 1;
            }

            return cache[i, j];
        }
    }
}
