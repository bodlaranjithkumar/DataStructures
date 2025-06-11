package SlidingWindow.FixedWindow;

import java.util.HashMap;
import java.util.Map;

public class MaximumSumofDistinctSubarraysWithLengthK {
    // Leetcode 2461: https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k/
    // Submission Detail: https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k/submissions/1625794122

    //Input: nums = [3, 2, 2, 3, 4, 6, 7, 7, -1], k = 4
    //Output: 20
    public long maximumSubarraySum(int[] nums, int k) {
        int start = 0;
        long maxSum = 0, currentSum = 0;
        Map<Integer, Integer> numCount = new HashMap<>();
        for(int end = 0; end < nums.length; end++) {
            currentSum += nums[end];
            int endIndexCount = numCount.getOrDefault(nums[end], 0);
            numCount.put(nums[end], endIndexCount+1);

            if(end-start+1 == k) {
                if(numCount.size() == k) {
                    maxSum = Math.max(maxSum, currentSum);
                }
                currentSum -= nums[start];

                int startIndexCount = numCount.get(nums[start]);
                if(startIndexCount <= 1)
                    numCount.remove(nums[start]);
                else
                    numCount.put(nums[start], startIndexCount-1);

                start++;
            }
        }

        return maxSum;
    }
}
