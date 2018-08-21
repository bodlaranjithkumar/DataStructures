using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 74 - https://leetcode.com/problems/search-a-2d-matrix/description/
    // Submission Detail: https://leetcode.com/submissions/detail/169349625/

    public class Search2DMatrix
    {
        // Tx = O(m + logn) {m : # of rows, n: # of columns}
        // Sx = O(1)

        // [[1]], 1 -> true. Handled this case by using = in end>=0 and start <= end

        // Idea: Extended version of binary search to multiple rows (matrix).
        public bool SearchMatrix(int[,] matrix, int target)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int start = 0, end = cols - 1;

            for (int i = 0; i < rows && end >= 0; i++)
            {
                if (target >= matrix[i, start] && target <= matrix[i, end])
                {
                    while (start <= end)
                    {
                        int mid = start + (end - start) / 2;
                        int midVal = matrix[i, mid];

                        if (target == midVal)
                            return true;
                        else if (target > midVal)
                            start = mid + 1;
                        else
                            end = mid - 1;
                    }
                }
            }

            return false;
        }
    }
}
