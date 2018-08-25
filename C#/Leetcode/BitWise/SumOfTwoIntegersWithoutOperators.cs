using System;

namespace LeetcodeSolutions.BitWise
{
    // Leetcode 371 - https://leetcode.com/problems/sum-of-two-integers/

    public class SumOfTwoIntegersWithoutOperators
    {
        //static void Main(string[] args)
        //{
        //    SumOfTwoIntegersWithoutOperators sum = new SumOfTwoIntegersWithoutOperators();

        //    Helper.Print<int>(sum.GetSum(1, 2));

        //    Console.ReadLine();
        //}

        // To be done
        public int GetSum(int a, int b)
        {
            int f = a & 1;
            int g = b & 1;
            return (a & 1) ^ (b & 1);
        }
    }
}
