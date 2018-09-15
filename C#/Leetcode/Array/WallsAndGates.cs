using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 286
    // Depth-First Search (DFS)
    // Reference: https://www.programcreek.com/2014/05/leetcode-walls-and-gates-java/
    //You are given a m x n 2D grid initialized with these three possible values.

    //-1 - A wall or an obstacle.
    //0 -  A gate.
    //INF - Infinity means an empty room.We use the value 2^31 - 1 = 2147483647 to represent INF as you may 
    //      assume that the distance to a gate is less than 2147483647.

    //Question: Fill each empty room with the distance to its nearest gate.
    //           If it is impossible to reach a gate, it should be filled with INF.

    //For example, given the 2D grid:
    //INF  -1  0  INF
    //INF INF INF  -1
    //INF  -1 INF  -1
    //  0  -1 INF INF

    //After running your function, the 2D grid should be:
    //  3  -1   0   1
    //  2   2   1  -1
    //  1  -1   2  -1
    //  0  -1   3   4

    // Tx = O(m*n) - actually 4*m*n
    // Sx = O(m*n)
    public class WallsAndGates
    {
        //public static void Main(string[] args)
        //{
        //    int[,] rooms = { { max, -1, 0, max },
        //                    { max, max, max, -1 },
        //                    { max, -1, max, -1 },
        //                    { 0, -1, max, max } };

        //    WallsAndGates wg = new WallsAndGates();
        //    wg.FillWallsAndGates(rooms);
        //    Helper.PrintMatrix(rooms);

        //    Console.ReadKey();
        //}

        private static int max = int.MaxValue;
        private int m, n;

        // Intuition: Start DFS from an index with value 0 instead of start from index with value INF.
        public void FillWallsAndGates(int[,] rooms)
        {
            if (rooms == null || rooms.GetLength(0) == 0 || rooms.GetLength(1) == 0)
                return;

            m = rooms.GetLength(0);
            n = rooms.GetLength(1);

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (rooms[i, j] == 0)
                        FillWallsAndGates(rooms, i, j, 0);

        }

        private void FillWallsAndGates(int[,] rooms, int i, int j, int distance)
        {
            // Base condition.
            // rooms[i, j] < distance - covers:
            //      1. if value at index -1
            //      2. if value is not max which means previously found minimum is the minimum than the current distance.
            if (i < 0 || i >= m || j < 0 || j >= n || rooms[i, j] < distance) return;

            rooms[i, j] = distance;
            FillWallsAndGates(rooms, i + 1, j, distance + 1);   // Go Right
            FillWallsAndGates(rooms, i - 1, j, distance + 1);   // Go Left
            FillWallsAndGates(rooms, i, j + 1, distance + 1);   // Go Down
            FillWallsAndGates(rooms, i, j - 1, distance + 1);   // Go Up
        }
    }
}

