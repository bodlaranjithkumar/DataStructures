namespace LeetcodeSolutions.Array
{
    // Leetcode 463 - https://leetcode.com/problems/island-perimeter/description/
    // Submission Detail -  https://leetcode.com/submissions/detail/208733134/

    public class IslandPerimeter
    {
        int perimeter = 0;

        // The number of surrounding 0s to 1 is the perimeter of the island.

        // Tx = O(m*n)
        // Sx = O(1)

        public int CalculateIslandPerimeter(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 1)
                    {
                        perimeter += Helper(grid, i - 1, j);
                        perimeter += Helper(grid, i + 1, j);
                        perimeter += Helper(grid, i, j - 1);
                        perimeter += Helper(grid, i, j + 1);
                    }
                }
            }

            return perimeter;
        }

        private int Helper(int[,] grid, int i, int j)
        {
            if (i < 0 || j < 0 || i == grid.GetLength(0) || j == grid.GetLength(1) || grid[i, j] == 0)
            {
                return 1;
            }

            return 0;
        }
    }
}
