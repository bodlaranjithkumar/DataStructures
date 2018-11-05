using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Question: https://www.geeksforgeeks.org/snake-ladder-problem-2/
    // Shortest path in a Directed Graph problem. So, use Breadth-First Traversal

    public class SnakesAndLadders
    {
        //public static void Main(string[] args)
        //{
        //    int[] board = new int[30];
        //    for (int i = 0; i < board.Length; i++)
        //        board[i] = -1;  // No snake or ladder

        //    //[-1,-1,21,-1,7,-1,-1,-1,-1,25
        //    //,-1,-1,-1,-1,-1,3,-1,6,28,8
        //    //,-1,-1,-1,-1,-1,0,-1,-1,-1,-1]
        //    // Ladders 
        //    board[2] = 21;
        //    board[4] = 7;
        //    board[10] = 25;
        //    board[19] = 28;

        //    // Snakes 
        //    board[26] = 0;
        //    board[20] = 8;
        //    board[16] = 3;
        //    board[18] = 6;

        //    SnakesAndLadders sl = new SnakesAndLadders();
        //    Console.WriteLine(sl.MinDiceRolls(board));  //3

        //    int[] board1 = { -1, -1, -1, -1, -1, -1 };
        //    Console.WriteLine(sl.MinDiceRolls(board1));  // 1

        //    int[] board2 = new int[0];
        //    Console.WriteLine(sl.MinDiceRolls(board2));  // -1

        //    Console.ReadKey();
        //}

        public int MinDiceRolls(int[] board)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> cells = new Queue<int>();

            // Initialize minDiceMoves to 1 because if the goal is > 6 and it is reached
            // inside the for loop, one dice roll is accounted.
            int goal = board.Length, minDiceRolls = 1, diceRolls = 0;

            cells.Enqueue(0);   // start node which is out of the board.

            while (cells.Count > 0)
            {
                int cell = cells.Dequeue();

                for (int newCell = cell + 1; newCell <= goal && newCell <= cell + 6; newCell++)
                {
                    if (newCell == goal)
                        return minDiceRolls + (goal <= 6 ? 0 : 1);

                    if (!visited.Contains(newCell))
                    {
                        visited.Add(newCell);

                        if (board[newCell] == -1)
                            cells.Enqueue(newCell); // neither snake nor ladder
                        else
                            cells.Enqueue(board[newCell]);  //enqueue the destination cell instead of the current.
                    }
                }

                diceRolls++;

                if(diceRolls % 6 == 0)  // for every 6 cells visited, increment minDiceMoves.
                    minDiceRolls++;
            }

            return -1;  // hits only when goal is 0.
        }
    }
}
