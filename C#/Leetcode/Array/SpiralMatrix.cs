using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 54
    public class SpiralMatrix
    {
        //public static void Main(string[] args)
        //{
        //    SpiralMatrix matrix = new SpiralMatrix();

        //    int[,] matrix1 = { { 1, 2, 3, 4 }, { 12, 13, 14, 5 }, { 11, 16, 15, 6 }, { 10, 9, 8, 7 } };
        //    Helper.PrintListElements(matrix.SpiralOrder(matrix1));

        //    int[,] matrix2 = { { 1 }, { 12 } };
        //    Helper.PrintListElements(matrix.SpiralOrder(matrix2));

        //    int[,] matrix3 = { { 1,2 } };
        //    Helper.PrintListElements(matrix.SpiralOrder(matrix3));

        //    int[,] matrix4 = { };
        //    Helper.PrintListElements(matrix.SpiralOrder(matrix4));

        //    Console.ReadKey();
        //}

        // Runtime: 468ms
        // Tx = O(m*n)
        // Sx = O(m*n)
        public List<int> SpiralOrder(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int Top = 0, Bottom = m - 1, Left = 0, Right = n - 1;
            int dir = 0;

            List<int> result = new List<int>();

            while (Top <= Bottom && Left <= Right)
            {
                if (dir == 0)
                {
                    for (int i = Left; i <= Right; i++)
                        result.Add(matrix[Top, i]);

                    Top++;
                    dir = 1;
                }
                else if (dir == 1)
                {
                    for (int i = Top; i <= Bottom; i++)
                        result.Add(matrix[i, Right]);

                    Right--;
                    dir = 2;
                }
                else if (dir == 2)
                {
                    for (int i = Right; i >= Left; i--)
                        result.Add(matrix[Bottom, i]);

                    Bottom--;
                    dir = 3;
                }
                else
                {
                    for (int i = Bottom; i >= Top; i--)
                        result.Add(matrix[i, Left]);

                    Left++;
                    dir = 0;
                }
            }

            return result;
        }
    }
}
