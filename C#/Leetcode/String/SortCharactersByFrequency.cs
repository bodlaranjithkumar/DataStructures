using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 451
    // Submission Detail: https://leetcode.com/submissions/detail/169459985/

    public class SortCharactersByFrequency
    {
        // Similar to Leetcode 347 https://leetcode.com/problems/top-k-frequent-elements/description/
        // Implementation of Bucket Sort Algorithm.

        // Tx = O(n) {n: length of string s}
        // Sx = O(n) for the sorted string

        // Idea: 1. Count the character frequencies.
        //       2. Group the characters with same frequencies.
        //       3. Since the order of characters doesn't matter for same frequencies, for each frequency from right to left (decreasing frequency) append the character in the list to an ouput string builder.
        public string FrequencySort(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            int[] charFrequencies = new int[256];   // Using dictionary instead, allows to add chars besides extended ascii.
            int maxFrequency = 0;

            foreach (char c in s)
            {
                charFrequencies[c]++;
                maxFrequency = System.Math.Max(maxFrequency, charFrequencies[c]);
            }

            IList<char>[] frequenciesChar = GroupCharByFrequencies(charFrequencies, maxFrequency);

            return BuildSortedCharsByFrequency(frequenciesChar, s.Length);
        }

        private IList<char>[] GroupCharByFrequencies(int[] charFrequencies, int maxFrequency)
        {
            IList<char>[] frequenciesChar = new List<char>[maxFrequency + 1];

            for (int i = 0; i < charFrequencies.Length; i++)
            {
                int freq = charFrequencies[i];

                if (frequenciesChar[freq] == null)
                    frequenciesChar[freq] = new List<char>();

                frequenciesChar[freq].Add((char)i);
            }

            return frequenciesChar;
        }

        private string BuildSortedCharsByFrequency(IList<char>[] frequenciesChar, int length)
        {
            StringBuilder str = new StringBuilder(length);

            for (int i = frequenciesChar.Length - 1; i > 0; i--)    // each frequency
                if (frequenciesChar[i] != null)
                    foreach (char c in frequenciesChar[i])   //each character for the current frequency
                        for (int j = 0; j < i; j++)    //#of frequency
                            str.Append(c);

            return str.ToString();
        }
    }
}
