using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 238
    // Input:  [1,2,3,4]
    // Output: [24,12,8,6]
    class ProductofArrayExceptSelf
    {
        // Runtime : 472 ms
        // Tx = O(n) {O(2n), n: length of nums} 
        // Sx = O(1)
        public int[] ProductExceptSelf(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return nums;

            int length = nums.Length;
            int[] output = new int[length];
            output[0] = 1;

            int productSoFar = nums[0];

            for (int index = 1; index < length; index++)
            {
                output[index] = productSoFar;
                productSoFar *= nums[index];
            }

            productSoFar = nums[length - 1];
            for (int index = length - 2; index >= 0; index--)
            {
                output[index] *= productSoFar;
                productSoFar *= nums[index];
            }

            return output;
        }
    }
}
