using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 26
    // Submission Details: https://leetcode.com/submissions/detail/182410673/
    // Similar to remove duplicate nodes in a linked list

    public class RemoveDuplicatesFromSortedArray
    {
        // Tx = O(n)
        // Sx = O(1)
        public int RemoveDuplicates(int[] nums)
        {
            int i = 0, j = 0;

            while (j < nums.Length)
            {
                while (j + 1 < nums.Length && nums[i] == nums[j + 1])
                {
                    j++;
                }

                if (i != j && j + 1 < nums.Length)
                {
                    nums[i + 1] = nums[j + 1];
                }

                i++;
                j++;
            }

            return i;
        }
    }
}
