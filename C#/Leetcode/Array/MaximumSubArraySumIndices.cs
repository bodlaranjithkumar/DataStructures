using System;

namespace LeetcodeSolutions.Array
{
    public class MaximumSubArraySumIndices
    {
        // Potential Follow-Up question to leetcode 53
        public static void Main(string[] args)
        {
            int[] nums1 = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Helper.PrintArray(MaxSubArraySumIndices(nums1));

            Console.WriteLine();
            int[] nums2 = { -2, 1, -3, 4, -1, 2, 1, -5, 6 };
            Helper.PrintArray(MaxSubArraySumIndices(nums2));

            Console.ReadKey();
        }

        public static int[] MaxSubArraySumIndices(int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;
            else if (nums.Length == 1) return nums;

            int start = 0, end = 0, maxSoFar = nums[0], maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int current = nums[i];
                maxSoFar = System.Math.Max(maxSoFar + current, current); ;

                if (maxSoFar == current)
                {
                    start = i;
                    end = i;
                }

                maxSum = System.Math.Max(maxSoFar, maxSum);

                if (maxSum == maxSoFar)
                    end = i;
            }

            int[] maxSubArray = new int[end - start + 1];
            System.Array.Copy(nums, start, maxSubArray, 0, end - start + 1);

            return maxSubArray;
        }
    }
}
