using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 36 - https://leetcode.com/problems/valid-sudoku/description/
    // Submission Detail - https://leetcode.com/submissions/detail/188006975/

    public class ValidSudoku
    {
        // Tx = O(9*9)
        // Sx = O(1)
        public bool IsValidSudoku(char[,] board)
        {
            HashSet<string> visited = new HashSet<string>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] != '.')
                    {
                        int digit = board[i, j];

                        string row = digit + " seen in row " + i;
                        string col = digit + " seen in col " + j;
                        string box = digit + " seen in box " + i / 3 + j / 3;

                        if (visited.Contains(row) || visited.Contains(col) || visited.Contains(box))
                            return false;

                        visited.Add(row);
                        visited.Add(col);
                        visited.Add(box);
                    }
                }
            }

            return true;
        }
    }
}
