using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 305

    public class NumberOfIslandsII
    {
        //2, 2, [[0,0],[1,1],[0,1]]     =>   [1,2,1]

        // Partially working solution
        // Algorithm: Iterate through given positions and for each position count the number of adjacent values set to 1 using the visited HashSet which basically denotes the cells with values set to 1 previously. The values stored in the HashSet are the string representation of the coordinates. If the count is 0, then increment the total number of islands. Else if the count is > 1, then either of the adjacent values are previously set. 
        HashSet<string> visited;

        public IList<int> NumIslands2(int m, int n, int[,] positions)
        {
            visited = new HashSet<string>(m * n);

            List<int> islands = new List<int>(m * n);
            int noOfIslands = 0;

            int[,] directions = { { 0, -1 }, { 0, 1 }, { -1, 0 }, { 1, 0 } };

            for (int i = 0; i < positions.GetLength(0); i++)
            {
                int x = positions[i, 0];
                int y = positions[i, 1];
                int totalAdjacentVisited = 0;

                string current = AdjacentPosition(x, y, m, n);

                for (int j = 0; j < directions.GetLength(0); j++)
                    if (visited.Contains(AdjacentPosition(x + directions[j, 0], y + directions[j, 1], m, n)))
                        totalAdjacentVisited++;

                if (totalAdjacentVisited == 0)
                    noOfIslands++;
                else if (totalAdjacentVisited > 1)
                    noOfIslands--;

                visited.Add(current);
                islands.Add(noOfIslands);
            }

            return islands;
        }

        private string AdjacentPosition(int x, int y, int m, int n)
        {
            if (x < 0 || y < 0 || x >= m || y >= n)
                return null;

            return x + "_" + y;
        }
    }
}
