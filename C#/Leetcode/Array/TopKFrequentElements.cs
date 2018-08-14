using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 347
    // Submission Detail: https://leetcode.com/submissions/detail/169465911/

    public class TopKFrequentElements
    {
        // Extension of Bucket Sort Algorithm
        // Similar to Leetcode https://leetcode.com/problems/sort-characters-by-frequency/description/

        // Tx = O(n) {n : length(nums)}
        // Sx = O(n)

        // Idea: 1. Count the number frequencies.
        //       2. Group the numbers with same frequencies.
        //       3. Since the order of numbers doesn't matter for same frequencies, for each frequency from right to left (decreasing frequency) add the number to an output list until the list count reaches the given number k.
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            IDictionary<int, int> numFrequencies = new Dictionary<int, int>();
            int maxFrequency = 0;

            foreach (int num in nums)
            {
                if (!numFrequencies.ContainsKey(num))
                    numFrequencies.Add(num, 0);

                numFrequencies[num]++;
                maxFrequency = System.Math.Max(maxFrequency, numFrequencies[num]);
            }

            IList<int>[] frequenciesNum = GroupNumsByFrequencies(numFrequencies, maxFrequency);

            return TopKFrequent(frequenciesNum, k);
        }

        private IList<int>[] GroupNumsByFrequencies(IDictionary<int, int> numFrequencies, int maxFrequency)
        {
            IList<int>[] frequenciesNum = new List<int>[maxFrequency + 1];

            foreach (var num in numFrequencies.Keys)
            {
                int freq = numFrequencies[num];

                if (frequenciesNum[freq] == null)
                    frequenciesNum[freq] = new List<int>();

                frequenciesNum[freq].Add(num);
            }

            return frequenciesNum;
        }

        private IList<int> TopKFrequent(IList<int>[] frequenciesNum, int k)
        {
            IList<int> topKFrequentNums = new List<int>();

            for (int i = frequenciesNum.Length - 1; i >= 0; i--)
            {
                IList<int> nums = frequenciesNum[i];
                if (nums != null)
                {
                    foreach (var num in nums)
                    {
                        if (topKFrequentNums.Count == k)
                            return topKFrequentNums;

                        topKFrequentNums.Add(num);
                    }
                }
            }

            return topKFrequentNums;
        }
    }
}
