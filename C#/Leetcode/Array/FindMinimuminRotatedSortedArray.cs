using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 153
    // Submission Detail: https://leetcode.com/submissions/detail/164427129/
    public class FindMinimuminRotatedSortedArray
    {
        //[4,5,6,7,0,1,2]
        //[7,0,1,2,4,5,6]
        //[1]
        //[2,1]
        //[1,2] - Array not rotated

        // Tx = O(logn)
        // Sx = O(1)
        public int FindMin(int[] nums)
        {
            int start = 0, end = nums.Length - 1;

            while (start < end)
            {
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
