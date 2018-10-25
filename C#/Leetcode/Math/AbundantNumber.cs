using System;

namespace LeetcodeSolutions.Math
{
    public class AbundantNumber
    {
        // Ref: https://www.geeksforgeeks.org/abundant-number/

        //public static void Main(string[] args)
        //{
        //    AbundantNumber abundantNumber = new AbundantNumber();

        //    bool a1 = abundantNumber.IsAbundantNumber(12);     // 1,2,3,4,6. True
        //    bool a2 = abundantNumber.IsAbundantNumber(18);     // 1,2,3,6,9. True
        //    bool a3 = abundantNumber.IsAbundantNumber(21);     // 1,3,7.     False
        //}

        public bool IsAbundantNumber(int n)
        {
            return GetDivisorsSumOptimized(n) > n;
        }

        // Tx = O(Sqrt(n))
        private long GetDivisorsSumOptimized(int n)
        {
            long sum = 0;

            for(int i = 1; i <= System.Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    sum += i;

                    if (n / i != i)
                        sum += n / i;
                }
            }

            sum -= n;   // when i is 1, we are adding n to sum above. So, subtract it from sum.
            return sum;
        }

        // Tx = O(n)
        private long GetDivisorsSum(int n)
        {
            long sum = 0;

            for(int i = 0; i <= n/2; i++)
            {
                if (n % i == 0)
                    sum += i;
            }

            return sum;
        }
    }
}
