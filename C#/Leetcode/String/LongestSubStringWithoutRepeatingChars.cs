using sys = System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode 3 - https://leetcode.com/problems/longest-substring-without-repeating-characters/
    // Submission Detail - https://leetcode.com/submissions/detail/136532273/

    public class LongestSubStringWithoutRepeatingChars
    {
        // Runtime: 154ms
        // Tx = O(n)
        // Sx = O(n)
        public int LengthOfLongestSubstringReadable(string s)
        {
            int i = 0, j = 0, maxLength = 0;
            HashSet<char> charsSeenBefore = new HashSet<char>();

            while(j < s.Length)
            {
                if (!charsSeenBefore.Contains(s[j]))
                {
                    charsSeenBefore.Add(s[j++]);
                    maxLength = System.Math.Max(charsSeenBefore.Count, maxLength);
                }
                else
                {
                    charsSeenBefore.Remove(s[i++]);
                }
            }

            return maxLength;
        }

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
                    maxLength = sys.Math.Max(maxLength, currentStrLength);
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
