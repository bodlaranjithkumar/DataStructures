using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 46 - https://leetcode.com/problems/permutations/description/
    // Submission Detail - https://leetcode.com/submissions/detail/137275400/

    public class Permutations
    {
        //public static void Main(string[] args)
        //{
        //    Permutations p = new Permutations();
        //    var result1 = p.Permute(new int[] { 1, 2, 3 });
        //    var result2 = p.Permute(new int[] { });
        //}

        // Runtime: 494ms
        // Tx = O(n!)
        // Sx = O(n!)

        IList<IList<int>> result = new List<IList<int>>();

        public IList<IList<int>> Permute(int[] nums)
        {            
            Permute(new List<int>(), nums);

            return result;
        }

        private void Permute(IList<int> list, int[] nums)
        {
            if (list.Count == nums.Length)
                result.Add(new List<int>(list));
            else
                for (int i = 0; i < nums.Length; i++)
                {
                    if (list.Contains(nums[i]))
                        continue; // Skip the number previously added.

                    list.Add(nums[i]);
                    Permute(list, nums);
                    list.RemoveAt(list.Count - 1);
                }
        }
    }
}
