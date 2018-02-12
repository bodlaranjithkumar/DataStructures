using System;

namespace LeetcodeSolutions.String
{
    // Leetcode 125
    // empty string is a palindrome
    // 0p - false
    // a. - true
    // "A man, a plan, a canal: Panama" - true
    // "race a car" - false

    //2 pointers
    public class ValidPalindrome
    {
        // Runtime = 132 ms
        // Tx = O(n) {n : length of string}
        // Sx = O(1)
        // Two Pointers
        public bool IsPalindromeOptimized(string s)
        {
            int start = 0;
            int end = s.Length - 1;

            while (start < end)
            {
                while (start < end && !Char.IsLetterOrDigit(s[start]))
                    start++;

                while (start < end && !Char.IsLetterOrDigit(s[end]))
                    end--;

                if (Char.ToLower(s[start]) != Char.ToLower(s[end]))
                    return false;

                start++;
                end--;
            }

            return true;
        }

        // Runtime = 145 ms
        // Tx = O(n) {n : length of string}
        // Sx = O(1)
        // Two Pointers
        public bool IsPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;

            while (start < end)
            {
                if (!Char.IsLetterOrDigit(s[start]))
                {
                    start++;
                }

                if (!Char.IsLetterOrDigit(s[end]))
                {
                    end--;
                }

                if (Char.IsLetterOrDigit(s[start]) && Char.IsLetterOrDigit(s[end]))
                {
                    if (Char.ToLower(s[start]) == Char.ToLower(s[end]))
                    {
                        start++;
                        end--;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
