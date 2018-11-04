using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 694 - https://leetcode.com/problems/number-of-distinct-islands
    // Submission Detail - https://leetcode.com/submissions/detail/186458902/
    // Depth-First Traversal
    public class NumberOfDistinctIslands
    {
        //public static void Main(string[] args)
        //{
        //    NumberOfDistinctIslands distinctIslands = new NumberOfDistinctIslands();

        //    int[,] grid1 = { { 1, 1, 0, 0 },
        //                     { 1, 1, 0, 0 },
        //                     { 0, 0, 1, 1 },
        //                     { 0, 0, 1, 1 } };

        //    Console.WriteLine(distinctIslands.NumDistinctIslands(grid1));   //1

        //    int[,] grid2 = { { 1, 1, 0, 1, 1 },
        //                     { 1, 0, 0, 0, 0 },
        //                     { 0, 0, 0, 0, 1 },
        //                     { 1, 1, 0, 1, 1 } };

        //    Console.WriteLine(distinctIslands.NumDistinctIslands(grid2));   //3

        //    Console.ReadKey();
        //}

        // Idea: Use DFS. This is an extension to number of islands problem.
        //      This problem requires comparing the indexes of all the islands. If there are n islands, nP2 comparisions.
        //      Optimal way is to create a unique identifier - string that represents the boundaries of the island
        //      Boundaries are calculated relative to base coordinates (baseX, baseY). Now the problem becomes
        //      finding the number of these unique strings which can be done using a hashset.

        int m, n;
        public int NumDistinctIslands(int[,] grid)
        {
            if (grid == null || grid.GetLength(0) == 0 || grid.GetLength(1) == 0)
                return 0;

            m = grid.GetLength(0);
            n = grid.GetLength(1);

            HashSet<string> distinctIslands = new HashSet<string>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        StringBuilder sb = new StringBuilder();

                        NumDistinctIslands(grid, i, j, i, j, sb);

                        if (!distinctIslands.Contains(sb.ToString()))
                            distinctIslands.Add(sb.ToString());
                    }
                }
            }

            return distinctIslands.Count;
        }

        private void NumDistinctIslands(int[,] grid, int i, int j, int baseX, int baseY, StringBuilder sb)
        {
            if (i < 0 || j < 0 || i >= m || j >= n || grid[i, j] == 0)
                return;

            if (sb.Length > 0) sb.Append("_");

            sb.Append(i - baseX).Append("_").Append(j - baseY);
            grid[i, j] = 0;

            NumDistinctIslands(grid, i + 1, j, baseX, baseY, sb);   // go right
            NumDistinctIslands(grid, i - 1, j, baseX, baseY, sb);   // go left
            NumDistinctIslands(grid, i, j + 1, baseX, baseY, sb);   // go down
            NumDistinctIslands(grid, i, j - 1, baseX, baseY, sb);   // go up
        }
    }
}
