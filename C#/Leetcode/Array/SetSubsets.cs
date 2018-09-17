using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 78 - https://leetcode.com/problems/subsets/description/
    // Submission Detail - https://leetcode.com/submissions/detail/176163960/
    // Similar to LCD-46 - Permutation problem with a difference in the base condition - Add the list to result with no condition.

    public class SetSubsets
    {
        //public static void Main(string[] args)
        //{
        //    SetSubsets sets = new SetSubsets();
        //    var result1 = sets.FindSubsets(new int[] { 1, 2, 3 });
        //    var result2 = sets.FindSubsets(new int[] { });


        //    var result3 = sets.FindSubsetsBackTrack(new int[] { 1,3, 2 });
        //    var result4 = sets.FindSubsetsBackTrack(new int[] { });
        //    Console.ReadKey();
        //}

        // Runtime: 518ms
        // Tx = O(2^n) //?
        // Sx = O(2^n)

        List<List<int>> result = new List<List<int>>();

        public List<List<int>> FindSubsetsBackTrack(int[] nums)
        {
            FindSubsetsBackTrack(new List<int>(), nums, 0);

            return result;
        }

        private void FindSubsetsBackTrack(List<int> list, int[] nums, int start)
        {
            result.Add(new List<int>(list));

            for (int i = start; i < nums.Length; i++)
            {
                list.Add(nums[i]);
                FindSubsetsBackTrack(list, nums, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }

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
