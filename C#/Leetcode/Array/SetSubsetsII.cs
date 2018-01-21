using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 90
    public class SetSubsetsII
    {
        //public static void Main(string[] args)
        //{
        //    SetSubsetsII sub = new SetSubsetsII();
        //    var result1 = sub.SubsetsWithDup(new int[] { 1, 2, 2});
        //    var result2 = sub.SubsetsWithDup(new int[] { 1, 2, 2, 2 });
        //}

        // Runtime= 643ms
        // Tx= O(2^n)
        // Sx= O(2^n)
        // Using backtracking
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            System.Array.Sort(nums);
            SubsetsWithDup(result, new List<int>(), nums, 0);
            return result;
        }

        private void SubsetsWithDup(IList<IList<int>> result, IList<int> list, int[] nums, int start)
        {
            result.Add(new List<int>(list));

            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) continue;
                list.Add(nums[i]);
                SubsetsWithDup(result, list, nums, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
