using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 153 - https://leetcode.com/problems/find-minimum-in-rotated-sorted-array
    // Submission Detail -  https://leetcode.com/submissions/detail/164427129/
    // Other potential way of asking the question - Find the rotation point in a sorted array.

    public class FindMinimumInRotatedSortedArray
    {
        //[4,5,6,7,0,1,2]
        //[7,0,1,2,4,5,6]
        //[7,6,5,4,3,2,1]
        //[1,2,3,4,5,6,7]
        //[1]
        //[2,1]
        //[1,2] - Array not rotated

        // Modified binary search.
        // Tx = O(logn)
        // Sx = O(1)
        public int FindMin(int[] nums)
        {
            int start = 0, end = nums.Length - 1;

            while (start < end)
            {
                // Breaking condition. Also, covers the case when the array is not rotated.
                if (nums[start] < nums[end])
                    break;

                int mid = start + (end - start) / 2;

                if (nums[mid] >= nums[start])
                    start = mid + 1;
                else
                    end = mid;
            }

            return nums[start];
        }
    }
}
