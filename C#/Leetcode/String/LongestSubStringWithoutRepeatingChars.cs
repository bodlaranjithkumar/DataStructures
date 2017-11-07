using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 3
    class LongestSubStringWithoutRepeatingChars
    {
        // Sliding window technique
        // Runtime: 336ms (This is changing on resubmission of the same code)
        // Tx = O(n)
        // Sx = O(n)
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return s.Length;

            int startIndex = 0;
            int maxLength = 1, currentStrLength = 1;
            HashSet<char> charsSeenBefore = new HashSet<char>{
                s[startIndex]
            };

            for (int endIndex = 1; endIndex < s.Length; endIndex++)
            {
                if (!charsSeenBefore.Contains(s[endIndex]))
                {
                    currentStrLength++;
                    charsSeenBefore.Add(s[endIndex]);
                    maxLength = Math.Max(maxLength, currentStrLength);
                }
                else
                {
                    startIndex = startIndex + 1;
                    endIndex = startIndex;
                    currentStrLength = 1;
                    charsSeenBefore = new HashSet<char>{
                        s[startIndex]
                    };
                }
            }

            return maxLength;
        }
    }
}
