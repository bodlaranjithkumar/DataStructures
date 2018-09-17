using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 647 - https://leetcode.com/problems/palindromic-substrings/description/
    // Submission Detail - https://leetcode.com/submissions/detail/171122845/
    // ref: https://leetcode.com/problems/palindromic-substrings/discuss/105688/Very-Simple-Java-Solution-with-Detail-Explanation
    // Similar to LCD 5 - LongestPalindromicSubstring

    public class PalindromicSubstrings
    {
        // case sensitive
        int count = 0;
        public int CountSubstrings(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            for (int i = 0; i < s.Length; i++)
            {
                CountSubstrings(s, i, i);   // Palindromic substring of odd length.
                CountSubstrings(s, i, i + 1); // Palindromic substring of even length.
            }

            return count;
        }

        private void CountSubstrings(string s, int start, int end)
        {
            while (start >= 0 && end < s.Length && s[start] == s[end])
            {
                count++;
                start--;
                end++;
            }
        }
    }
}
