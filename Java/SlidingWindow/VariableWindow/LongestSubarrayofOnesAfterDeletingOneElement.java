package SlidingWindow.VariableWindow;

public class LongestSubarrayofOnesAfterDeletingOneElement {
    // Leetcode 1493: https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/description/
    // Submission Detail: https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/submissions/1670986459

    //Input: nums = [1,1,0,1]
    //Output: 3
    //Explanation: After deleting the number in position 2, [1,1,1] contains 3 numbers with value of 1's.

    //Input: nums = [0,1,1,1,0,1,1,0,1]
    //Output: 5
    //Explanation: After deleting the number in position 4, [0,1,1,1,1,1,0,1] longest subarray with value of 1's is [1,1,1,1,1].

    //Input: nums = [1,1,1]
    //Output: 2
    //Explanation: You must delete one element.

    // Tx = O(n)
    // Sx = O(1)
    public int longestSubarray(int[] nums) {
        int start=0, end=0, zerosSoFar=0, totalSum=0, maxLength=0, length=nums.length;

        while(end<length) {
            int currentNum = nums[end];
            totalSum += currentNum;

            if(currentNum == 0)
                zerosSoFar++;

            if(zerosSoFar <= 1) {
                maxLength = Math.max(maxLength, end-start); // not doing end-start+1 because one element has to be deleted. Either 0 or 1.
            } else {
                if(nums[start] == 0)
                    zerosSoFar--;
                start++;
            }

            end++;
        }

        return totalSum == length ? length-1 : maxLength;
    }
}
