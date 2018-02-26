using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 300
    // Dynamic Programming - Common subproblems
    // Reference - Explanation: https://www.youtube.com/watch?v=CE2b_-XfVDk
    //           - Code : https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/LongestIncreasingSubsequence.java
    // Submission - https://leetcode.com/submissions/detail/140963157/
    public class LongestIncreasingSubsequence
    {
        //public static void Main(string[] args)
        //{
        //    LongestIncreasingSubsequence LIS = new LongestIncreasingSubsequence();

        //    int[] arr1 = { 3, 4, -1, 0, 6, 2, 3 }; // 4
        //    Console.WriteLine(LIS.LengthOfLIS(arr1));

        //    int[] arr2 = { 3, 4, 5, 6, 7, 8, 9 }; // 7
        //    Console.WriteLine(LIS.LengthOfLIS(arr2));

        //    int[] arr3 = { 1, 3, -1, 0, 2, -2 }; // 4
        //    Console.WriteLine(LIS.LengthOfLIS(arr3));

        //    int[] arr4 = { 6, 5, 4 }; // 1
        //    Console.WriteLine(LIS.LengthOfLIS(arr4));

        //    int[] arr5 = { }; // 0
        //    Console.WriteLine(LIS.LengthOfLIS(arr5));

        //    Console.ReadKey();
        //}

        // TODO: There is a O(nlogn) solution.
        // Tx = O(n^2)
        // Sx = O(n)
        public int LengthOfLIS(int[] nums)
        {
            int length = nums.Length;

            int[] LIS = new int[length];

            // Each number has a sequence of 1.
            for (int i = 0; i < length; i++)
                LIS[i] = 1;

            // Initialize to 0 to cover the case of array is empty
            int maxLIS = length == 0 ? 0 : 1;

            for (int i = 1; i < length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        // Max of the previously computed LIS of J and current number LIS.
                        LIS[i] = System.Math.Max(LIS[i], LIS[j] + 1);
                        maxLIS = System.Math.Max(maxLIS, LIS[i]);
                    }
                }
            }
            
            return maxLIS;
        }
    }
}
