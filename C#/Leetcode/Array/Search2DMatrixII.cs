using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 240 - https://leetcode.com/problems/search-a-2d-matrix-ii/
    // Submission Detail - https://leetcode.com/submissions/detail/169370932/

    public class Search2DMatrixII
    {
        // Tx = O(m + n) {m: #of rows, n: #of cols}
        // Sx = O(1)

        // Idea: From observation, diagonal numbers in the matrix starting from 0,n-1 to m-1,0 are the highest numbers in that row & column.
        //       Start from 0,n-1 and compare it with the target. 
        //          1. If target is greater, it doesn't exist in the row to left and exists downwards. so, increment row (i) by 1.
        //          2. If target is lesser, it doesn't exist downwards and exists to left. so, decrement col (j) by 1.
        //          3. If equals then return true.
        //          4. If number doesn't exit which means the other end of the diagonal has been passed is the breaking condition for the loop which means, the iteration holds true for i < rows and j >= 0.

        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return false;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int i = 0, j = cols - 1;

            while (i < rows && j >= 0)
            {
                if (target == matrix[i, j])
                    return true;
                else if (target < matrix[i, j])
                    j--;
                else
                    i++;
            }

            return false;
        }
    }
}
