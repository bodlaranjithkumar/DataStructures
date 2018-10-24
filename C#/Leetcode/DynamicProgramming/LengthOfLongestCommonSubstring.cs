using System;

namespace LeetcodeSolutions.DynamicProgramming
{
    // Ref: https://www.geeksforgeeks.org/longest-common-substring-dp-29/
    //      https://www.youtube.com/watch?v=BysNXJHzCEs

    public class LengthOfLongestCommonSubstring
    {
        //public static void Main(string[] args)
        //{
        //    LengthOfLongestCommonSubstring lcs = new LengthOfLongestCommonSubstring();
        //    int l1 = lcs.LongestCommonSubstringLength("abcdef", "yuxcdeaf");    // 3 - cde

        //    Console.ReadKey();
        //}

        public int LongestCommonSubstringLength(string s1, string s2)
        {
            int l1 = s1.Length, l2 = s2.Length, maxLength = 0; ;
            int[,] dp = new int[l1 + 1, l2 + 1];

            for (int i = 1; i <= l1; i++)
            {
                for (int j = 1; j <= l2; j++)
                {
                    if (s1[i-1] == s2[j-1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                        maxLength = System.Math.Max(maxLength, dp[i, j]);
                    }
                }
            }

            return maxLength;
        }
    }
}
