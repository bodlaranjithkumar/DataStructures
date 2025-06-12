package DynamicProgramming;

public class LongestIncreasingSubsequence {
    // Leetcode 300: https://leetcode.com/problems/longest-increasing-subsequence/description/
    // Submission Detail: https://leetcode.com/problems/longest-increasing-subsequence/submissions/1662367078

    //Input: nums = [8,2,4,3,6,12]
    //Output:  4

    //Input: nums = [10,9,2,5,3,7,101,18]
    //Output: 4
    //Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.

    //Input: nums = [0,1,0,3,2,3]
    //Output: 4

    //Input: nums = [7,7,7,7,7,7,7]
    //Output: 1

    //Input: nums = [7,6,5,4,3,2,1]
    //Output: 1

    // Tx = O(n*n)
    // Sx = O(n)
    public int lengthOfLIS(int[] nums) {
        int[] dp = new int[nums.length];
        int maxLength = 1;  // initialize to 1 because the nums could be in decreasing order. And max is atleast 1.

        // Base Case: Each value in the nums has a minimum length of 1
        for(int i=0; i<dp.length; i++)
            dp[i] = 1;

        for(int i=0; i<nums.length; i++) {
            for(int j=0; j<i; j++) {
                if(nums[i] > nums[j]) {
                    dp[i] = Math.max(dp[i], dp[j]+1); // +1 because current number at i is greater than j in nums.
                    maxLength = Math.max(maxLength, dp[i]);
                }
            }
        }

        return maxLength;
    }
}
