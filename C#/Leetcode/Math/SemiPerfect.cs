using LeetcodeSolutions.DynamicProgramming;
using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Math
{
    // Description: https://www.geeksforgeeks.org/semiperfect-number/

    public class SemiPerfect
    {
        //public static void Main(string[] args)
        //{
        //    SemiPerfect semiPerfect = new SemiPerfect();

        //    bool sp1 = semiPerfect.IsSemiperfect(40);       //true;
        //    bool sp2 = semiPerfect.IsSemiperfect(70);       //false;
        //}

        public bool IsSemiperfect(int n)
        {
            int[] divisors = GetDivisors(n);

            SubsetSum subsetSum = new SubsetSum();

            // Call the problem array has subset with sum = given sum.
            return subsetSum.IsSubsetWithGivenSumExists(divisors, n);            
        }

        private int[] GetDivisors(int n)
        {
            List<int> divisors = new List<int>() { 1 };

            for(int i = 2; i <= System.Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    divisors.Add(i);

                    if (n / i != i)
                        divisors.Add(n / i);
                }
            }

            return divisors.ToArray();
        }
    }
}
