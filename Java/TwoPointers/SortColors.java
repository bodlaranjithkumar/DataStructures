package TwoPointers;

public class SortColors {
    // Leetcode 75: https://leetcode.com/problems/sort-colors/
    // Submission Detail: https://leetcode.com/problems/sort-colors/submissions/1624509923

    // Input: nums = [2,1,2,0,1,0,1,0,1]
    // Output: [0,0,0,1,1,1,1,2,2]

    // Tx = O(n)
    // Sx = O(1)
    public void sortColors(int[] nums) {
        int left = 0, right = nums.length-1, index = 0;

        while(index <= right) {
            if(nums[index] == 0) {
                swap(left, index, nums);
                left++;
                index++;
            } else if(nums[index] == 2) {
                swap(right, index, nums);
                right--;
            } else {
                index++;
            }
        }
    }

    private static void swap(int i, int j, int[] nums) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
