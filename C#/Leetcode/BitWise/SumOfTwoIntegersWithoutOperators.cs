using System;

namespace LeetcodeSolutions.BitWise
{
    class SumOfTwoIntegersWithoutOperators
    {
        //static void Main(string[] args)
        //{
        //    SumOfTwoIntegersWithoutOperators sum = new SumOfTwoIntegersWithoutOperators();

        //    Helper.Print<int>(sum.GetSum(1, 2));

        //    Console.ReadLine();
        //}

        public int GetSum(int a, int b)
        {
            int f = a & 1;
            int g = b & 1;
            return (a & 1) ^ (b & 1);
        }
    }
}
