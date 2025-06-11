namespace LeetcodeSolutions.Patterns.DFS
{
    // Leetcode 200 - https://leetcode.com/problems/number-of-islands/
    // Submission Detail - https://leetcode.com/submissions/detail/142275958/
    // Depth-First Traversal (DFS)

    public class NumberOfIslands
    {
        private int m, n;

        // Tx = O(m*n)  // Actually 4*m*n
        // Sx = O(m*n) for call stack
        public int NumIslands(char[,] grid)
        {
            if (grid == null)
                return 0;

            m = grid.GetLength(0);
            n = grid.GetLength(1);
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i, j] == '1')
                    {
                        NumIslands(grid, i, j);
                        count++;
                    }
                }
            }

            return count;
        }
        
        private void NumIslands(char[,] grid, int i, int j)
        {
            if (i < 0 || j < 0 || i >= m || j >= n || grid[i, j] != '1') return;    // grid value is 0.
            grid[i, j] = '0';                   // mark as visited.
            NumIslands(grid, i + 1, j);   // go down
            NumIslands(grid, i - 1, j);   // go up
            NumIslands(grid, i, j + 1);   // go right
            NumIslands(grid, i, j - 1);   // go left
        }
    }
}
