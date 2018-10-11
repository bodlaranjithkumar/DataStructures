using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 560
    // Submission Detail: https://leetcode.com/submissions/detail/181998316/

    public class SubArraySumEqualsK
    {
        // Tx = O(n)
        // Sx = O(n)
        // Algorithm: 1. If the current sum - k exists in the dictionary, add the number of frequencies (value) to previous count.
        //            2. Count the frequency of the current sum and add it to the dictionary.

        // Example: [1,-1,7,2,-2,-7,9], 9        ->    5
        //          [1,1,1], 2                   ->    2

        public int SubarraySum(int[] nums, int k)
        {
            IDictionary<int, int> sumFrequencies = new Dictionary<int, int>(){
                {0,1}
            };

            int count = 0, sumSoFar = 0;

            foreach (int num in nums)
            {
                sumSoFar += num;

                if (sumFrequencies.ContainsKey(sumSoFar - k))
                {
                    count += sumFrequencies[sumSoFar - k];
                }

                if (!sumFrequencies.ContainsKey(sumSoFar))
                {
                    sumFrequencies.Add(sumSoFar, 0);
                }

                sumFrequencies[sumSoFar]++;
            }

            return count;
        }
    }
}
