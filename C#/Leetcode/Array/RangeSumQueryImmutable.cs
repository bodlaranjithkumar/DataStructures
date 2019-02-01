using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 303 - https://leetcode.com/problems/range-sum-query-immutable/description/
    // Submission Detail - https://leetcode.com/submissions/detail/205036911/

    public class RangeSumQueryImmutable
    {
        // Algorithm: Based on the intuition - sum(i,j) => sum(0,j) - sum(0,i-1). 
        // Calculate the sumSoFar array with sum incremented at each iteration and stored in 
        // the sumSoFar array of size = length+1. +1 because when SumRange is called instead of
        // doing i-1, we use i and instead of j, use j+1. This allows us to avoid any checks for
        // i >= 0;

        readonly int[] sumSoFar;

        // Tx = O(n)
        // Sx = O(n)
        public RangeSumQueryImmutable(int[] nums)
        {
            sumSoFar = new int[nums.Length + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                sumSoFar[i + 1] = sumSoFar[i] + nums[i];
            }
        }

        //Tx = O(1)
        public int SumRange(int i, int j)
        {
            return sumSoFar[j + 1] - sumSoFar[i];
        }
    }
}
