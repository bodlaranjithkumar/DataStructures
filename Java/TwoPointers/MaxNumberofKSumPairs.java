package TwoPointers;

import java.util.Arrays;
import java.util.HashMap;

public class MaxNumberofKSumPairs {
    // Leetcode 1679:https://leetcode.com/problems/max-number-of-k-sum-pairs/description/

    //Input: nums = [1,2,3,4], k = 5
    //Output: 2
    //Explanation: Starting with nums = [1,2,3,4]:
    //        - Remove numbers 1 and 4, then nums = [2,3]
    //        - Remove numbers 2 and 3, then nums = []
    //There are no more pairs that sum up to 5, hence a total of 2 operations.

    //Input: nums = [3,1,3,4,3], k = 6
    //Output: 1
    //Explanation: Starting with nums = [3,1,3,4,3]:
    //        - Remove the first two 3's, then nums = [1,4,3]
    //There are no more pairs that sum up to 6, hence a total of 1 operation.

    // Solution 1: Sorting & two pointers similar to two-sum. Space optimized
    // Submission Detail: https://leetcode.com/problems/max-number-of-k-sum-pairs/submissions/1670947331
    // Tx = O(nlogn)
    // Sx = O(1)
    public int maxOperations(int[] nums, int k) {
        Arrays.sort(nums);
        int count = 0, left = 0, right = nums.length-1;
        while(left < right) {
            if(nums[left]+nums[right] == k) {
                count++;
                left++;
                right--;
            } else if(nums[left]+nums[right] > k) {
                right--;
            } else {
                left++;
            }
        }

        return count;
    }

    // Solution 2: Use HashMap to store the num frequency. Time optimized
    // Submission Detail: https://leetcode.com/problems/max-number-of-k-sum-pairs/submissions/1670953666
    // Tx = O(n)
    // Sx = O(n)
    public int maxOperationsTimeOptimized(int[] nums, int k) {
        HashMap<Integer, Integer> numCount = new HashMap<>();
        int result=0;

        // Step 1: count num frequency
        for(int num:nums) {
            int count = numCount.getOrDefault(num, 0);
            numCount.put(num, count+1);
        }

        // Step 2: count max pairs by looking up in the hashmap. When a pair is found, remove that from map.
        for(int num:nums) {
            int diff = k-num;
            if(numCount.containsKey(num) && numCount.containsKey(diff)) {
                result++;
                if(numCount.get(num) == 1)
                    numCount.remove(num);
                else
                    numCount.put(num, numCount.get(num)-1);

                if(numCount.containsKey(diff)) { // num == diff
                    if (numCount.get(diff) == 1)
                        numCount.remove(diff);
                    else
                        numCount.put(diff, numCount.get(diff) - 1);
                }
            }
        }

        return result;
    }
}
