using System;

namespace LeetcodeSolutions.String
{
    // Leetcode 5 - https://leetcode.com/problems/longest-palindromic-substring/
    // Submission Detail - https://leetcode.com/submissions/detail/128760175/
    // "babad" -> "bab"
    // "cbbd" -> "bb"

    public class LongestPalindromicSubstring
    {
        // Runtime = 159ms
        // Tx = O(n^2)
        // Sx = O(1)
        // Reference : https://discuss.leetcode.com/topic/23498/very-simple-clean-java-solution

        int start = 0, maxLen = 0;
        public string LongestPalindrome(string s)
        {
            int length = s.Length;
            if (length < 2)
                return s;

            for (int index = 0; index < length - 1; index++)
            {
                ValidatePalindrome(s, index, index); // length of palindrome is odd
                ValidatePalindrome(s, index, index + 1); // length of palindrome is even
            }

            return s.Substring(start, maxLen);
        }

        private void ValidatePalindrome(string s, int leftIndex, int rightIndex)
        {
            while (leftIndex >= 0 && rightIndex < s.Length && s[leftIndex] == s[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }

            if (maxLen < rightIndex - leftIndex - 1)    // rightIndex-leftIndex+1-2
            {
                start = leftIndex + 1;  // Found the new max length - Update the start position of the new palindromic substring.
                maxLen = rightIndex - leftIndex - 1;
            }
        }
    }
}
