using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 90 - https://leetcode.com/problems/subsets-ii/
    // Submission Detail - https://leetcode.com/submissions/detail/137052493/

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

        IList<IList<int>> result = new List<IList<int>>();

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            System.Array.Sort(nums);    // This the first difference between no duplicates and duplicates subset problem.
            SubsetsWithDup(new List<int>(), nums, 0);

            return result;
        }

        private void SubsetsWithDup(IList<int> list, int[] nums, int start)
        {
            result.Add(new List<int>(list));

            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1])    // This the second difference between no duplicates and duplicates subset problem.
                    continue;

                list.Add(nums[i]);
                SubsetsWithDup(list, nums, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
