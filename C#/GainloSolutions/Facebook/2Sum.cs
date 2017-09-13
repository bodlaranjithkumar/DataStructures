using System;
using System.Collections.Generic;
using System.Text;

namespace GainloSolutions.Facebook
{
    class _2Sum
    {
        //public static void Main(string[] args)
        //{
        //    _2Sum sum = new _2Sum();

        //    int[] numbers = { 1,2,3,4,5,6,7,8};
        //    Console.WriteLine($"{sum.Does2NumbersExistsWithGivenSum(numbers, 20)}");
        //    Console.ReadKey();
        //}

        /// <summary>
        /// Checks if the sum 2 integers in the sorted array is equal to given sum.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="sum"></param>
        /// <returns>true or false</returns>
        public bool Does2NumbersExistsWithGivenSum(int[] numbers, int sum)
        {
            int start = 0;
            int end = numbers.Length - 1;

            while(start < end)
            {
                if (numbers[start] + numbers[end] < sum)
                    start += 1;
                else if (numbers[start] + numbers[end] > sum)
                    end -= 1;
                else
                    return true;
            }

            return false;
        }
    }
}
