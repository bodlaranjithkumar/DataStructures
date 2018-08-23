using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 398 - https://leetcode.com/problems/random-pick-index/description/
    // Submission Detail - https://leetcode.com/submissions/detail/171110438/

    public class RandomPickIndex
    {
        // Ref: https://leetcode.com/problems/random-pick-index/discuss/88072/Simple-Reservoir-Sampling-solution?page=2

        int[] nums;
        Random rand;
        public RandomPickIndex(int[] nums)
        {
            this.nums = nums;
            rand = new Random();
        }

        public int Pick(int target)
        {
            int result = -1;
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    count++;

                    if (rand.Next(0, count) == 0)
                        result = i;
                }
            }

            return result;
        }
    }
}
