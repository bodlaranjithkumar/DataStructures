using System;

namespace InterviewCakeSolutions.Arrays
{
    class RotationPoint
    {
        //public static void Main(string[] args)
        //{
        //    RotationPoint rotationPoint = new RotationPoint();
        //    int[] numbers = { 20, 25, 30, 35, 40, 1, 5, 10, 15 };

        //    Console.WriteLine($"Minimum Number Index in Rotated Array : {rotationPoint.FindMinimumNumberIndex(numbers)}");
        //    Console.WriteLine($"Maximum Number Index in Rotated Array : {rotationPoint.FindMaximumNumberIndex(numbers)}");
        //    Console.ReadKey();
        //}

        private int FindMinimumNumberIndex(int[] numbers)
        {
            return FindIndex(numbers, true);
        }

        private int FindMaximumNumberIndex(int[] numbers)
        {
            return FindIndex(numbers, false);
        }

        // Modified Question: Find minimum/Maximum number in a rotated increasing order array.
        // Handles edge case with 0,1 array elements or 
        private int FindIndex(int[] numbers, bool findMinNumberIndex)
        {
            int floorIndex = 0, ceilIndex = numbers.Length - 1 ;
            int firstNumber = numbers[0];

            while(floorIndex < ceilIndex)
            {
                int guessIndex = floorIndex + ((ceilIndex - floorIndex) / 2);

                if(numbers[guessIndex] >= firstNumber)  //Go right
                {
                    floorIndex = guessIndex;
                }
                else
                {
                    ceilIndex = guessIndex;
                }

                if(floorIndex+1 == ceilIndex)
                {
                    break;
                }
            }
            return ceilIndex;
        }        
    }
}
