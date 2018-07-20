using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 79
    // Submission Detail: https://leetcode.com/submissions/detail/164768711/
    // Similar to Leetcode 200 - NumberOfIslands problem.
    public class WordSearch
    {
        public static void Main(string[] args)
        {
            WordSearch ws = new WordSearch();
                
            char[,] board1 = { { 'A', 'B', 'C', 'E' }, 
                              { 'S', 'F', 'C', 'S' }, 
                              { 'A', 'D', 'E', 'E' } };

            ws.Exist(board1, "ABCCED"); // True
            ws.Exist(board1, "ECS"); // True
            ws.Exist(board1, "ABCB"); // False
        }

        int rows = 0, cols = 0;
        int[,] visited;
        public bool Exist(char[,] board, string word)
        {
            rows = board.GetLength(0);
            cols = board.GetLength(1);

            visited = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == word[0])
                        if (Exist(board, word, i, j, 0))
                            return true;
                }
            }

            return false;
        }

        private bool Exist(char[,] board, string word, int i, int j, int charIndex)
        {
            if (charIndex == word.Length) return true;
            if (i < 0 || j < 0 || i >= rows || j >= cols || charIndex > word.Length || board[i, j] != word[charIndex] || visited[i, j] == 1)
                return false;
            
            visited[i, j] = 1;

            charIndex += 1;
            if (Exist(board, word, i + 1, j, charIndex)
                    || Exist(board, word, i - 1, j, charIndex)
                    || Exist(board, word, i, j + 1, charIndex)
                    || Exist(board, word, i, j - 1, charIndex))
                return true;

            visited[i, j] = 0;
            return false;
        }
    }
}
