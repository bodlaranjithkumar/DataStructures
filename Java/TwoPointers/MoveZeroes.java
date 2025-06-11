package TwoPointers;

public class MoveZeroes {
    // Leetcode 281: https://leetcode.com/problems/move-zeroes/description/
    // Submission Detail: https://leetcode.com/problems/move-zeroes/submissions/1622524159

    // Input: nums = [0,1,0,3,12]
    // Output: [1,3,12,0,0]

    // Input: nums = [2,0,4,0,9]
    // Output: [2,4,9,0,0]

    // Tx = O(n)
    // Sx = O(1)
    public void moveZeroes(int[] nums) {
        for(int firstZeroIndex=0, index=0; index < nums.length; index++) {
            if(nums[index] != 0) {
                int temp = nums[index];
                nums[index] = 0;
                nums[firstZeroIndex] = temp;
                firstZeroIndex++;
            }
        }
    }
}
