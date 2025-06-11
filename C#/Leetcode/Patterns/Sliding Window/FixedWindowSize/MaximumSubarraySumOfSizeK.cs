public class solution {
    // nums = [2, 1, 5, 1, 3, 2]
    // k = 3
    // Output =  9

    // Fixed Sliding Window

    // Tx = O(n)
    // Sx = O(1)
    public long MaxSubarraySum(int[] nums, int k) {
        int maxSum = 0, start = 0, currentSum = 0;

        for(int end = 0; end < nums.Length; end++) {
            currentSum += nums[end];

            if(end - start + 1 == k) {
                maxSum = Math.Max(maxSum, currentSum);
                currentSum -= nums[start];
                start++;
            }
        }

        return maxSum;
    }
}