using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    public class SubsetsWithGivenSum
    {
        //public static void Main(string[] args)
        //{
        //    SubsetsWithGivenSum sub = new SubsetsWithGivenSum();
        //    var result1 = sub.SubsetsEqualToSum(new int[] { 2, 3, 6, 5, 1 }, 8);
        //}

        // Distinct numbers and doesn't need to be consecutive numbers.
        // Tx = O(2^n)
        // Sx = O(2^n)
        public IList<IList<int>> SubsetsEqualToSum(int[] input, int sum)
        {
            int n = input.Length;
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < (1 << n); i++)
            {
                IList<int> list = new List<int>();
                int SubSetSum = 0;

                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        SubSetSum += input[j];
                        list.Add(input[j]);
                    }
                }

                if (SubSetSum == sum)
                    result.Add(list);
            }

            return result;
        }
    }
}
