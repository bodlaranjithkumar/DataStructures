using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 238
    class ProductofArrayExceptSelf
    {
        // Runtime : 472 ms
        // Tx = O(n) {O(2n), n: length of nums} 
        // Sx = O(1)
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] output = new int[nums.Length];

            int productSoFar = nums[0];
            output[0] = 1;
            int length = nums.Length;

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
