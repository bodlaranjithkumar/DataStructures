using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 88 - https://leetcode.com/problems/merge-sorted-array/description/
    // Submission Detail - https://leetcode.com/submissions/detail/140383438/

    public class MergeSortedArray
    {
        // Runtime : 448 ms
        // Tx = O(m+n)
        // Sx = O(1)
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int index1 = m - 1;
            int index2 = n - 1;
            int mergedIndex = m + n - 1;

            while (index2 >= 0)
            {
                nums1[mergedIndex--] = index1 >= 0 && nums1[index1] > nums2[index2] ? nums1[index1--] : nums2[index2--];
            }
        }
    }
}
