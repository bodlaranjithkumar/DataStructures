using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 349 - https://leetcode.com/problems/intersection-of-two-arrays/description/
    // Submission Detail - https://leetcode.com/submissions/detail/182415531/

    public class IntersectionOfTwoArrays
    {
        // Alternative solution to below which optimizes space to O(1) and makes time worse to O(nlogn)
        // Sort any array and iterating through the array, search for the number in the sorted
        //  array in O(logn). If the number is found, add it to a hashset. In the end, iterate through the
        //  values in the hashset and add it to the common hashset. Finally, iterate throught the common
        // hashset and add it to the resultant array.

        // Optimized for time.
        // Tx = (m+n)
        // Sx = O(m) or O(n). Best case complexity can be optimized by adding shortest array values to hashset.
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> nums1Set = new HashSet<int>();
            HashSet<int> common = new HashSet<int>();

            // Add the array1 values to the hashset for constant look up.
            foreach (int num in nums1)
                nums1Set.Add(num);

            // Iterate through the array2 values and add it to common if exists in nums1set.
            foreach (int num in nums2)
            {
                if (nums1Set.Contains(num))
                {
                    common.Add(num);
                    nums1Set.Remove(num);   // Remove so that duplicate in nums2 won't be added to common.
                }
            }

            // Store the values in the hashset to array.
            int[] result = new int[common.Count];
            int i = 0;
            foreach (int num in common)
                result[i++] = num;

            return result;
        }
    }
}
