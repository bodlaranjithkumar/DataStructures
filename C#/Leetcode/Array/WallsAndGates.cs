using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 286 - https://leetcode.com/problems/walls-and-gates
    // Submission Detail - https://leetcode.com/submissions/detail/187268598/

    // You are given a m x n 2D grid initialized with these three possible values.

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

        // Bread-First Traversal : https://leetcode.com/submissions/detail/187268598/
        // Using BFS over DFS is time efficient since a previously visted empty room
        // won't be visited again and it is promised that the distance found in the first visit is the shortest.

        // Tx = O(m*n)
        // Sx = O(n)
        public void WallsAndGatesBFS(int[,] rooms)
        {
            if (rooms == null || rooms.GetLength(0) == 0 || rooms.GetLength(1) == 0)
                return;

            Queue<int[]> emptyRooms = new Queue<int[]>();

            int max = int.MaxValue, m = rooms.GetLength(0), n = rooms.GetLength(1);

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (rooms[i, j] == 0)
                        emptyRooms.Enqueue(new int[] { i, j });

            while (emptyRooms.Count > 0)
            {
                int[] top = emptyRooms.Dequeue();
                int row = top[0], col = top[1];

                // Top
                if (row > 0 && rooms[row - 1, col] == max)
                {
                    rooms[row - 1, col] = rooms[row, col] + 1;  // Found the shortest distance from the gate.
                    emptyRooms.Enqueue(new int[] { row - 1, col });
                }

                // Bottom
                if (row < m - 1 && rooms[row + 1, col] == max)
                {
                    rooms[row + 1, col] = rooms[row, col] + 1;
                    emptyRooms.Enqueue(new int[] { row + 1, col });
                }

                // Left
                if (col > 0 && rooms[row, col - 1] == max)
                {
                    rooms[row, col - 1] = rooms[row, col] + 1;
                    emptyRooms.Enqueue(new int[] { row, col - 1 });
                }

                // Right
                if (col < n - 1 && rooms[row, col + 1] == max)
                {
                    rooms[row, col + 1] = rooms[row, col] + 1;
                    emptyRooms.Enqueue(new int[] { row, col + 1 });
                }
            }
        }


        private static int max = int.MaxValue;
        private int m, n;

        // Depth First Traversal
        // Intuition: Start DFS from an index with value 0 instead of start from index with value INF.
        // Tx = O(m*n)^2) 
        // Sx = O(m*n)  -- Call stack
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

