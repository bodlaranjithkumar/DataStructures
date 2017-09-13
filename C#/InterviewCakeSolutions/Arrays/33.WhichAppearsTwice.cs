using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.Arrays
{
    class DuplicateArrayNumber
    {
        //public static void Main(string[] args)
        //{
        //    DuplicateArrayNumber duplicate = new DuplicateArrayNumber();
        //    int[] numbers = { 1, 3, 10, 9, 8, 7, 5, 6, 4, 2, 1 };
        //    //Console.WriteLine($"Duplicate number in the array is : {duplicate.FindDuplicateNumber(numbers, 10)}");
        //    Console.WriteLine($"Duplicate number in the array is : {duplicate.FindDuplicateNumberSpaceOptimized(numbers, 10)}");
        //    Console.ReadKey();
        //}

        /// <summary>
        /// Finds the duplicate number in the integer array.
        /// </summary>
        /// <param name="numbers">Integer Array of numbers.</param>
        /// <param name="n">Maximum number in the array.</param>
        /// <returns>Number whiche appear twice.</returns>
        /// Tx = O(n), Sx = O(n)
        public int FindDuplicateNumber(int[] numbers, int n)
        {
            // Edge Cases
            if (n != numbers.Length - 1)
                throw new ArgumentException(nameof(n), "Array does not exactly contain 1 duplicate number.");


            HashSet<int> numbersVisited = new HashSet<int>();
            foreach (int number in numbers)
            {
                if (number > n)
                    throw new ArgumentOutOfRangeException("Value of the number in the array is greater than the max value.");

                if (!numbersVisited.Contains(number))
                    numbersVisited.Add(number);
                else
                    return number;
            }

            // This won't be reached at any point.
            return 0;
        }


        public int FindDuplicateNumberSpaceOptimized(int[] numbers, int n)
        {
            // Edge Cases
            if (n != numbers.Length - 1)
                throw new ArgumentException(nameof(n), "Array does not exactly contain 1 duplicate number.");

            int duplicateNumber = 0;

            //while(n > 0)
            //{
            //    sumOfN += n;
            //    n--;
            //}

            //foreach(int number in numbers)
            //{
            //    if (number > n)
            //        throw new ArgumentOutOfRangeException("Value of the number in the array is greater than the max value.");

            //    sumOfNumbers += number;
            //}

            //return sumOfNumbers - sumOfN;

            int count = n;
            foreach (int number in numbers)
            {
                if (number > n)
                    throw new ArgumentOutOfRangeException("Value of the number in the array is greater than the max value.");

                duplicateNumber += number - count;
                count--;
            }

            return duplicateNumber;
        }
    }
}
