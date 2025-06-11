package PrefixSum;

import java.util.HashMap;

public class SubArraySumEqualsK {
  // Leetcode 560: https://leetcode.com/problems/subarray-sum-equals-k/description/
  // Submission Detail: https://leetcode.com/problems/subarray-sum-equals-k/submissions/1651383225

  //  Example 1: Input:
  //  nums = [3, 4, 7, 2, -3, 1, 4, 2]
  //  k = 7
  //  Output: 4
  //  Explanation: The subarrays that sum to 7 are:
  //          [3, 4], [7], [7, 2, -3, 1], [1, 4, 2]

  //  Example 2: Input:
  //  nums = [1, -1, 0]
  //  k = 0

  //  Output: 3
  //  Explanation: The subarrays that sum to 0 are:
  //          [-1, 1], [0], [1, -1, 0]

  // Tx = Sx = O(n)
  public int subarraySum(int[] nums, int k) {
    int count = 0, sumSoFar = 0;
    HashMap<Integer, Integer> subArraySum = new HashMap<>();
    subArraySum.put(0,1); // when sumSoFar == k

    for(int num : nums) {
      sumSoFar += num;

      if(subArraySum.containsKey(sumSoFar -k))
        count += subArraySum.get(sumSoFar -k);

      subArraySum.put(sumSoFar, subArraySum.getOrDefault(sumSoFar, 0) + 1);
    }

    return count;
  }
}
