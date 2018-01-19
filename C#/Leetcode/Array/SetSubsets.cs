using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 78
    public class SetSubsets
    {
        //public static void Main(string[] args)
        //{
        //    SetSubsets sets = new SetSubsets();
        //    var result1 = sets.FindSubsets(new int[] { 1, 2, 3 });
        //    var result2 = sets.FindSubsets(new int[] { });
        //}

        // using bit manipulation
        // Runtime: 500ms
        // Tx = O(n*2^n)
        // Sx = O(n*2^n)
        public IList<IList<int>> FindSubsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            int n = nums.Length;

            // run the outer loop for 2^n iterations because there are 2^n subsets for a set.
            for (int i = 0; i < (1 << n); i++)
            {
                List<int> list = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                        list.Add(nums[j]);
                }

                result.Add(list);
            }

            return result;
        }
    }
}
