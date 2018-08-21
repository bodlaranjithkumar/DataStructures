using sys = System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 53 - https://leetcode.com/problems/maximum-subarray/description/
    // Submission Detail - https://leetcode.com/submissions/detail/129847416/
    // Input: [-2,1,-3,4,-1,2,1,-5,4],
    // Output: 6
    // Contiguous subarray with max sum = [4, -1, 2, 1] 

    public class MaximumSubArraySum
    {
        // Runtime = 149ms
        // Tx = O(n)
        // Sx = O(1)
        // Greedy Algorithm
        public int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int maxSoFar = nums[0];

            for (int index = 1; index < nums.Length; index++)
            {
                maxSoFar = sys.Math.Max(maxSoFar + nums[index], nums[index]);
                maxSum = sys.Math.Max(maxSum, maxSoFar);
            }

            return maxSum;
        }
    }
}
