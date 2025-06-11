package SlidingWindow.FixedWindow;

public class MaximumSumofSubarrayWithSizeK {

    //Input: nums=[2,1,5,1,3,2] k=3
    //Output: 9
    public int SubarraySum(int[] nums, int k) {
        int maxSum=0, currentSum=0;

        for(int start=0, end=0; end<nums.length; end++) {
            currentSum += nums[end];
            if(end-start+1 == k) {
                maxSum = Math.max(maxSum, currentSum);
                currentSum -= nums[start];
                start++;
            }
        }

        return maxSum;
    }
}
