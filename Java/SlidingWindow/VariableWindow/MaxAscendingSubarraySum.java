package SlidingWindow.VariableWindow;

public class MaxAscendingSubarraySum {
  // Leetcode 1800: https://leetcode.com/problems/maximum-ascending-subarray-sum/
  // Submission Detail: https://leetcode.com/problems/maximum-ascending-subarray-sum/submissions/1638814031

  //  Input: nums = [10,20,30,5,10,50]
  //  Output: 65
  //
  //  Input: nums = [10,20,30,40,50]
  //  Output: 150
  //
  //  Input: nums = [12,17,15,13,10,11,12]
  //  Output: 33

  // Tx = O(n)
  // Sx = O(1)
  public int maxAscendingSum(int[] nums) {
    int maxSum = 0, currentSum = 0;

    for(int end=0; end < nums.length; end++) {
      if(end > 0 && nums[end] > nums[end-1]) {
        currentSum += nums[end];
      } else {
        currentSum = nums[end]; // set/reset the currentSum
      }

      maxSum = Math.max(maxSum, currentSum);
    }

    return maxSum;
  }
}
