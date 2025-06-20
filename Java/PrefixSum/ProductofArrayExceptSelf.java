package PrefixSum;

public class ProductofArrayExceptSelf {
    // Leetcode 238: https://leetcode.com/problems/product-of-array-except-self/description/
    // Submission Detail: https://leetcode.com/problems/product-of-array-except-self/submissions/1670802006

    //Input: nums = [1,2,3,4]
    //Output: [24,12,8,6]

    //Input: nums = [-1,1,0,-3,3]
    //Output: [0,0,9,0,0]

    public int[] productExceptSelf(int[] nums) {
        int length = nums.length, productSoFar = nums[0];
        int[] result = new int[length];
        result[0] = 1;

        // Step 1: Store the multipled values from left to right at all indexes except first
        for(int index=1; index<length; index++) {
            result[index] = productSoFar;
            productSoFar *= nums[index];
        }

        // Step 2: Store the multipled values from left to right at all indexes except last
        productSoFar = nums[length-1];
        for(int index=length-2; index>=0; index--) {
            result[index] *= productSoFar;
            productSoFar *= nums[index];
        }

        return result;
    }
}
