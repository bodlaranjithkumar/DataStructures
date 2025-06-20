package SlidingWindow.VariableWindow;

public class MaxConsecutiveOnesIII {
    // Leetcode 1004: https://leetcode.com/problems/max-consecutive-ones-iii/submissions/1670979196/
    // Submission Detail: https://leetcode.com/problems/max-consecutive-ones-iii/submissions/1670979196

    //Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
    //Output: 6
    //Explanation: [1,1,1,0,0,1,1,1,1,1,1]
    //Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

    //Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
    //Output: 10
    //Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
    //Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

    // Tx = O(n)
    // Sx = O(1)
    public int longestOnes(int[] nums, int k) {
        int start=0, end=0, zeroesSoFar = 0, maxLength = 0;

        while(end < nums.length) {
            if(nums[end] == 0)
                zeroesSoFar++;

            if(zeroesSoFar <= k) {
                int currentLength = end-start+1;
                maxLength = Math.max(currentLength,maxLength);
            } else {
                if(nums[start] == 0)
                    zeroesSoFar--;
                start++;
            }

            end++;
        }

        return maxLength;
    }
}
