using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 304 - https://leetcode.com/problems/range-sum-query-2d-immutable/description/
    // Submission Detail - https://leetcode.com/submissions/detail/205045120/

    public class RangSumQuery2DImmutable
    {
        /* Algorithm : The key is to calculate sum of (i,j) w.r.t (0,0). To do this use the 
        previously computed  values. For the sum region the observation is that sum of a region 
        (i,j,m,n) - sum(m,n) - sum(i-1,n) - sum(m-1,j) + sum(i-1,j-1). To avoid any index out of
        bounds exception we can use conditional checks but instead to make it even simple just 
        have an extra row and column at 0th level with value set to 0 when initiatlizing the sum
        matrix. */

        readonly int[,] sum;

        // Tx = O(mn)
        // Sx = O(mn)
        public RangSumQuery2DImmutable(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0)
                return;

            sum = new int[matrix.GetLength(0) + 1, matrix.GetLength(1) + 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum[i + 1, j + 1] = sum[i + 1, j] + sum[i, j + 1] - sum[i, j] + matrix[i, j];
                }
            }
        }

        // Tx = O(1)
        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return sum[row2 + 1, col2 + 1] - sum[row1, col2 + 1] - sum[row2 + 1, col1] + sum[row1, col1];
        }
    }
}
