package TwoPointers;

import java.util.Arrays;

public class ValidTriangleNumbers {
    // Leetcode 611: https://leetcode.com/problems/valid-triangle-number/description/
    // Submission Detail: https://leetcode.com/problems/valid-triangle-number/submissions/1622508570


    // Input: nums = [11,4,9,6,15,18]
    // Output: 10

    // Sum of length of 2 sides > 3rd side length
    // [4,6,9,11,15,18]
    // 18 15 4
    // 18 15 6
    // 18 15 9
    // 18 15 11
    // 18 11 9
    // 15 11 6
    // 15 11 9
    // 11 9 4
    // 11 9 6
    // 9 6 4

    // Tx = O(n2)
    // Sx = O(1)
    public int triangleNumber(int[] nums) {
        int result = 0;
        Arrays.sort(nums);

        for(int index = nums.length-1; index > 1; index--) {
            int left = 0, right = index-1;

            while(left < right) {
                if(nums[left]+nums[right] > nums[index]) {
                    result += right - left; // All the numbers between left & right will be greater than numAtIndex.
                    right--;
                } else {
                    left++;
                }
            }
        }

        return result;
    }
}
