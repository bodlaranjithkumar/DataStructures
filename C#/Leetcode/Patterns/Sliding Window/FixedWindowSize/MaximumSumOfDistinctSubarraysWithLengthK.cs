public class Solution {
    // Leetcode 2461 - https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k/description/
    // Submission Detail - https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k/submissions/1541459500
    // Fixed Window Size
    // nums = [3, 2, 2, 3, 4, 6, 7, 7, -1]
    // k = 4
    // Output = 13

    // Tx = O(n)
    // Sx = O(n)
    public long MaximumSubarraySum(int[] nums, int k) {
        long currentSum = 0, maxSum = 0;
        int start = 0, length = nums.Length;
        IDictionary<int, int> numFrequency = new Dictionary<int, int>(length);

        for(int end = 0; end < length; end++) {
            currentSum += nums[end];
            if(!numFrequency.ContainsKey(nums[end]))
                numFrequency.Add(nums[end], 0);
            numFrequency[nums[end]]++;

            // Window Size is k
            if(end-start+1 == k) {
                // Distinct numbers in the window found
                if(numFrequency.Keys.Count == k) {
                    maxSum = Math.Max(maxSum, currentSum);
                }
                currentSum -= nums[start];
                numFrequency[nums[start]]--;
                if(numFrequency[nums[start]] == 0)
                    numFrequency.Remove(nums[start]);
                start++;
            }
        }

        return maxSum;
    }
}