using sys = System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 152 - https://leetcode.com/problems/maximum-product-subarray
    // Submission Detail - https://leetcode.com/submissions/detail/128118146/

    // [2,3,-2,4] -> 6
    // [-3,2,3,-1,4] -> 72
    // Contiguous subarray with maximum product = [2, 3]

    public class MaximumSubArrayProduct
    {
        //public static void Main(string[] args)
        //{
        //    MaximumSubArrayProduct max = new MaximumSubArrayProduct();

        //    int[] arr1 = { -3, 3, -1, 4 };
        //    max.MaxProduct(arr1);
        //}

        // Runtime = 155ms
        // Tx = O(n)
        // Sx = O(1)
        // Greedy Algorithm. Key is to swap the computed values when the current value is -ve 
        // This allows us to get max value when even -ve values are present.
        public int MaxProduct(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int maxProduct = nums[0];
            int maxSoFar = maxProduct, minSoFar = maxProduct;

            for (int index = 1; index < nums.Length; index++)
            {
                // swap the values so that when we find even number of -ve value, we get the max product.
                if (nums[index] < 0)
                {
                    int temp = maxSoFar;
                    maxSoFar = minSoFar;
                    minSoFar = temp;
                }

                maxSoFar = sys.Math.Max(nums[index], maxSoFar * nums[index]);
                minSoFar = sys.Math.Min(nums[index], minSoFar * nums[index]);

                maxProduct = sys.Math.Max(maxProduct, maxSoFar);
            }

            return maxProduct;
        }
    }
}
