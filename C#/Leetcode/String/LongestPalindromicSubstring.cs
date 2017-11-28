using System;

namespace LeetcodeSolutions.String
{
    // Leetcode 5
    // Input: "babad"
    // Output: "bab"

    // Input: "cbbd"
    // Output: "bb"
    class LongestPalindromicSubstring
    {
        // Runtime = 159ms
        // Tx = O(n^2)
        // Sx = O(1)
        // Reference : https://discuss.leetcode.com/topic/23498/very-simple-clean-java-solution
        public string LongestPalindrome(string s)
        {
            int length = s.Length;
            if (length < 2)
                return s;

            int start = 0, maxLen = 0;

            for (int index = 0; index < length - 1; index++)
            {
                ValidatePalindrome(s, index, index, ref start, ref maxLen); // assume length of palindrome is odd
                ValidatePalindrome(s, index, index + 1, ref start, ref maxLen); // assume length of palindrome is even
            }

            return s.Substring(start, maxLen);
        }

        private void ValidatePalindrome(string s, int leftIndex, int rightIndex, ref int start, ref int maxLen)
        {
            while (leftIndex >= 0 && rightIndex < s.Length && s[leftIndex] == s[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }

            if (maxLen < rightIndex - leftIndex - 1)
            {
                start = leftIndex + 1;
                maxLen = rightIndex - leftIndex - 1;
            }
        }
    }
}
