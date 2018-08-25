using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 325
    // Ref - http://buttercola.blogspot.com/2016/01/leetcode-maximum-size-subarray-sum.html

    // Array=[-2,-1,2,1,1]          K=1   
    // 0,j = 0,i + i,j => 0,j - 0,i = i,j
    // Dictionary   Len             MaxLen
    // 0,-1  
    // -2,0
    // -3,1
    // -1,2		    2-0 = 2         2
    //  			3-2 = 1         2
    // 1,4			4-(-1) = 5      5

    // Array=[-2,-1,3,1,1,1,0]          K=3

    // 0,-1
    // -2,0
    // -3,1
    //              2-1 = 1         1
    // 1,3          3-0 = 3         3
    // 2,4
    // 3,5          5-(-1)       6

    public class MaximumSizeSubarraySumEqualsK
    {
        //public static void Main(string[] args)
        //{
        //    MaximumSizeSubarraySumEqualsK sub = new MaximumSizeSubarraySumEqualsK();

        //    int[] array1 = { -2, -1, 2, 1, 1 };
        //    Console.WriteLine(sub.MaxSubArrayLength(array1, 1)); //5 - The whole array

        //    int[] array2 = { -2, -1, 2, 1 };
        //    Console.WriteLine(sub.MaxSubArrayLength(array2, 1)); //2 - [-1,2]

        //    Console.ReadKey();
        //}

        // Tx = O(n)
        // Sx = O(n)
        // Algorithm: Calculate the carried sum for each index and save <sum,index> pair to the dictionary if doesn't exist
        //            because the index needs to be the left most to get the max length. Why? Answered in next line.
        //            if sum-k at an index exists in the dictionary, it basically means the sum of sub array starting 
        //            from that index+1 to the current index equals k. Check if this is the max length.

        // Logically speaking sum(i,j) = sum(0,j) - sum(0,i)    // This is the key. 

        public int MaxSubArrayLength(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            IDictionary<int, int> sumIndices = new Dictionary<int, int>(nums.Length + 1)
            {
                { 0, -1 }
            };

            int maxLen = 0, sum_I = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum_I += nums[i];

                if (!sumIndices.ContainsKey(sum_I))
                    sumIndices.Add(sum_I, i);

                if (sumIndices.ContainsKey(sum_I - k))
                    maxLen = System.Math.Max(maxLen, i - sumIndices[sum_I - k]);
            }

            return maxLen;
        }
    }
}
