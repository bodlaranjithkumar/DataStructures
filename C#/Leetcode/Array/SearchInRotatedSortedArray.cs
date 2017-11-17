using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 33
    class SearchInRotatedSortedArray
    {
        // Examples = [4,5,6,7,0,1,2], [3,4,0,1,2], [4,5,6,7,2], [3,1]
        // Runtime = 182ms
        // Tx = O(logn)
        // Sx = O(1)
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            int start = 0;
            int end = nums.Length - 1;

            while (start < end)
            {
                int mid = start + (end - start) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[start] <= nums[mid])
                {
                    if (target >= nums[start] && target < nums[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    if (target > nums[mid] && target <= nums[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }

            return nums[start] == target ? start : -1;
        }
    }
}
