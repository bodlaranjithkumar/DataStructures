using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Example of BackTracking Algorithm
    // https://www.geeksforgeeks.org/backttracking-set-2-rat-in-a-maze/
    public class RatMaze
    {
        const int rows = 4;
        const int columns = 4;

        int[,] path = { { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 } };

        //public static void Main(string[] args)
        //{
        //    RatMaze rat = new RatMaze();

        //    int[,] maze = { { 1,0,0,0},
        //                    { 1,1,1,1},
        //                    { 0,1,0,0},
        //                    { 1,1,1,1} };

        //    if (rat.PathExists(maze))
        //        Helper.PrintMatrix(rat.path);
        //    else
        //        Console.WriteLine("Path not found");

        //    Console.ReadKey();
        //}

        public bool PathExists(int[,] maze)
        {
            return PathExists(maze, 0, 0, path);
        }

        private bool PathExists(int[,] maze, int x, int y, int[,] path)
        {
            // reached the target.
            if (x == rows - 1 && y == columns - 1)
            {
                path[x, y] = 1;
                return true;
            }

            // Check if the step in the maze is safe.
            if (IsSafe(maze, x, y))
            {
                path[x, y] = 1;

                // go right
                if (PathExists(maze, x + 1, y, path))
                    return true;

                // go down
                if (PathExists(maze, x, y + 1, path))
                    return true;

                path[x, y] = 0;
                //return false;
            }

            return false;
        }

        private bool IsSafe(int[,] maze, int x, int y)
        {
            return x >= 0
                    && x < rows
                    && y >= 0
                    && y < columns
                    && maze[x, y] == 1;
        }
    }
}
