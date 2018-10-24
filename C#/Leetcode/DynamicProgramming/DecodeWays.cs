using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 91
    // Dynamic Programming
    // Submission Detail: https://leetcode.com/submissions/detail/144408535/
    public class DecodeWays
    {
        //public static void Main(string[] args)
        //{
        //    DecodeWays dw = new DecodeWays();
        //    Console.WriteLine(dw.NumDecodings("123")); //3
        //    Console.WriteLine(dw.NumDecodings("0"));   //0
        //    Console.WriteLine(dw.NumDecodings("1"));   //1

        //    Console.ReadKey();
        //}

        public int NumDecodings(string s)
        {
            if (s == null || s.Length == 0) return 0;

            int length = s.Length;
            int[] dp = new int[length + 1];
            dp[0] = 1;                          // One way to decode empty string
            dp[1] = s[0] == '0' ? 0 : 1;        // 0 has zero decode ways

            for(int i = 2; i <= length; i++)
            {
                int singleDigit = Convert.ToInt32(s.Substring(i - 1, 1));
                int doubleDigit = Convert.ToInt32(s.Substring(i - 2, 2));

                if (singleDigit > 0 && singleDigit < 10)
                    dp[i] += dp[i - 1];

                if (doubleDigit > 9 && doubleDigit < 27)
                    dp[i] += dp[i - 2];
            }

            return dp[length];
        }
    }
}
