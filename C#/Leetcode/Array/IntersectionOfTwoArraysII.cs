using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 350 - https://leetcode.com/problems/intersection-of-two-arrays-ii/description/
    // Submission Detail - https://leetcode.com/submissions/detail/182418042/

    public class IntersectionOfTwoArraysII
    {
        // Alternative solution to below which optimizes space to O(1) and makes time worse to O(nlogn)
        // Sort any array and iterating through the array, search for the number in the sorted
        //  array in O(logn). If the number is found, add it to a dictionary with frequency as value.
        // In the end, iterate through the  values in the dictionary and add it to a list, decrement the 
        // frequency in dictionary. In the end, add the values in the list to an array.

        // Optimized for time. Best case space complexity could be optimized by adding the shortest array numbers to dictionary.
        // Tx = O(m+n)
        // Sx = O(m) or O(n)
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            IDictionary<int, int> nums1Frequency = new Dictionary<int, int>();

            // Count the frequency of numbers in first array.
            foreach (int num in nums1)
            {
                if (!nums1Frequency.ContainsKey(num))
                    nums1Frequency.Add(num, 0);

                nums1Frequency[num]++;
            }

            // Iterate through 2nd array and add it to list if exists in dictionary with frequency >1.
            IList<int> common = new List<int>();
            foreach (int num in nums2)
            {
                if (nums1Frequency.ContainsKey(num))
                {
                    common.Add(num);

                    if (nums1Frequency[num] > 1)
                        nums1Frequency[num]--;
                    else
                        nums1Frequency.Remove(num);
                }
            }

            int[] result = new int[common.Count];
            for (int i = 0; i < common.Count; i++)
                result[i] = common[i];

            return result;
        }
    }
}
