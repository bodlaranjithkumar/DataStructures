using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 348: https://leetcode.com/problems/design-tic-tac-toe/description/
    // Submission Detail: https://leetcode.com/submissions/detail/183595831/

    public class DesignTicTacToe
    {
        private readonly int[] rows;
        private readonly int[] cols;
        int diagonalLR, diagonalRL;

        /** Initialize your data structure here. */
        public DesignTicTacToe(int n)
        {
            rows = new int[n];
            cols = new int[n];
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            int playerValue = player == 1 ? 1 : -1;

            rows[row] += playerValue;
            cols[col] += playerValue;

            if (row == col)
                diagonalLR += playerValue;

            int n = rows.Length;
            if (col == n - row - 1)
                diagonalRL += playerValue;

            if (System.Math.Abs(rows[row]) == n
                || System.Math.Abs(cols[col]) == n
                || System.Math.Abs(diagonalLR) == n
                || System.Math.Abs(diagonalRL) == n)
                return player;

            return 0;
        }
    }
}
