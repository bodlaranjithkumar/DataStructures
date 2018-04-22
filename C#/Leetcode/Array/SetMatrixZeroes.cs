namespace LeetcodeSolutions.Array
{
    // Leetcode 73
    // Submission Detail: https://leetcode.com/submissions/detail/151101702/
    public class SetMatrixZeroes
    {
        //[                   [
        //  [1,1,1],            [1,0,1],
        //  [1,0,1],    =>      [0,0,0],
        //  [1,1,1]             [1,0,1]
        //]                    ]

        // Tx = O(mn)
        // Sx = O(1)
        // Idea: 1. Use firstrow and firstcolumn flags to check if the values need to be set to 0.
        //          if (i,j) is 0, set (i,0) and (0,j) to 0 in first iteration. Then,
        //          set the (i,j) to 0 if (i,0) and (0,j) was previously set to 0.
        public void SetZeroes(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            bool firstRow = false;
            bool firstColumn = false;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        if (i == 0) firstRow = true;
                        if (j == 0) firstColumn = true;
                        if (i != 0 && j != 0)
                        {
                            matrix[i, 0] = 0;
                            matrix[0, j] = 0;
                        }
                    }
                }
            }

            for (int i = 1; i < m; i++)
                for (int j = 1; j < n; j++)
                    if (matrix[0, j] == 0 || matrix[i, 0] == 0)
                        matrix[i, j] = 0;

            if (firstRow)
                for (int j = 0; j < n; j++)
                    matrix[0, j] = 0;

            if (firstColumn)
                for (int i = 0; i < m; i++)
                    matrix[i, 0] = 0;
        }
    }
}
