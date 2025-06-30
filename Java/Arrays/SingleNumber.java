package Arrays;

public class SingleNumber {
    // Leetcode 136: https://leetcode.com/problems/single-number/description/
    // Submission Detail: https://leetcode.com/problems/single-number/submissions/1680872330/

    //Input: nums = [2,2,1]
    //Output: 1

    //Input: nums = [4,1,2,1,2]
    //Output: 4

    //Input: nums = [1]
    //Output: 1

    // Intuition: xor operator when performed on 2 same numbers yields 0. And 0 xor on any number leads to the same number.
    public int singleNumber(int[] nums) {
        int nonDuplicate = 0;

        for(int num:nums) {
            nonDuplicate ^= num;
        }

        return nonDuplicate;
    }
}
