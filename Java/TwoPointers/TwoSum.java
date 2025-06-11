package TwoPointers;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class TwoSum {
    // Leetcode 1: https://leetcode.com/problems/two-sum/
    // Submission Detail: https://leetcode.com/problems/two-sum/submissions/1619916309

    // If the input array is not sorted
    public int[] TwoSumInputArrayUnsosrted(int[] nums, int target) {
        Map<Integer, Integer> numIndexes = new HashMap<>();
        int[] result = new int[2];
        for(int index=0; index<nums.length; index++) {
            int currentValue = nums[index];
            int diff = target - currentValue;
            if(numIndexes.containsKey(diff)) {
                result[0] = index;
                result[1] = numIndexes.get(diff);
                break;
            } else {
                numIndexes.put(currentValue, index);
            }
        }

        return result;
    }

    // If the input Array is Sorted
    public int[] TwoSumInputArraySorted(int[] nums, int target) {
        int[] result = new int[2];
        int left = 0, right = nums.length-1;
        while(left < right) {
            int currentSum = nums[left] + nums[right];

            if (currentSum > target) {
                right--;
            } else if (currentSum < target) {
                left++;
            } else {
                result[0] = left;
                result[1] = right;
                break;
            }
        }

        return result;
    }
}
