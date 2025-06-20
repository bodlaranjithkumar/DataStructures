package SlidingWindow.FixedWindow;

public class MaxAverageSubarrayI {
    // Leetcode 643: https://leetcode.com/problems/maximum-average-subarray-i/
    // Submission Detail: https://leetcode.com/problems/maximum-average-subarray-i/submissions/1670963265

    //Input: nums = [1,12,-5,-6,50,3], k = 4
    //Output: 12.75000
    //Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

    //Input: nums = [5], k = 1
    //Output: 5.00000

    public double findMaxAverage(int[] nums, int k) {
        double maxAverage = Integer.MIN_VALUE, currentAverage = Integer.MIN_VALUE;
        int start = 0, end = 0, length = nums.length, currentSum = 0;

        while(end < length) {
            currentSum += nums[end];

            if(end-start+1 == k) {
                currentAverage = (double)currentSum/k;
                currentSum -= nums[start];
                start++;
            }

            end++;
            maxAverage = Math.max(currentAverage, maxAverage);
        }

        return maxAverage;
    }
}
