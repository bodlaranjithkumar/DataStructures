using System;

namespace LeetcodeSolutions.String
{
    // Leetcode 516 - https://leetcode.com/problems/longest-palindromic-subsequence/description/
    // Submission Detail - https://leetcode.com/submissions/detail/171142369/
    
    // Ref: https://www.youtube.com/watch?v=TLaGwTnd3HY
    //      https://www.geeksforgeeks.org/longest-palindromic-subsequence-dp-12/
    //      https://www.youtube.com/watch?v=_nCsPn7_OgI

    // Bottom-Up Dynamic Programming

    public class LongestPalindromicSubsequence
    {
        // Tx = O(n^2)
        // Sx = O(n^2)
        public int LongestPalindromeSubseq(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            int length = s.Length;
            int[,] dp = new int[length, length];

            for (int i = 0; i < length; i++)
                dp[i, i] = 1;    //A single character is always a palindrome of length 1.

            for (int l = 2; l <= length; l++)        // l - length of the string from 2 to length.
            {
                for (int start = 0; start < length - l + 1; start++)
                {
                    int end = start + l - 1;

                    if (s[start] == s[end])
                    {
                        if (l == 2)
                            dp[start, end] = 2;
                        else
                            dp[start, end] = dp[start + 1, end - 1] + 2;
                    }
                    else
                    {
                        dp[start, end] = System.Math.Max(dp[start, end - 1], dp[start + 1, end]);
                    }
                }
            }

            return dp[0, length - 1];
        }
    }
}
