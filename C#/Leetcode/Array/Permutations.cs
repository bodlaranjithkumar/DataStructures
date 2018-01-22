using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 46
    public class Permutations
    {
        //public static void Main(string[] args)
        //{
        //    Permutations p = new Permutations();
        //    var result1 = p.Permute(new int[] { 1, 2, 3 });
        //    var result2 = p.Permute(new int[] { });
        //}

        // Using backtracking
        // Runtime: 494ms
        // Tx = O(n!)
        // Sx = O(n!)
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Permute(result, new List<int>(), nums);
            return result;
        }

        private void Permute(IList<IList<int>> result, IList<int> list, int[] nums)
        {
            if (list.Count == nums.Length)
            {
                result.Add(new List<int>(list));
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (list.Contains(nums[i]))
                        continue; // Skip the number previously added.

                    list.Add(nums[i]);
                    Permute(result, list, nums);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
    }
}
