using System;

namespace LeetcodeSolutions.DynamicProgramming
{
    // Extension to Length of Longest Increasing Substring.
    // Algorithm: Track the maxLenth so that the the index at which this 
    //      can be used to traverse the given input string backwards diagonally
    //      until a 0 is encountered in the dp matrix.

    // Bottom-Up Dynamic Programming

    public class LongestCommonSubstring
    {
        //public static void Main(string[] args)
        //{
        //    LongestCommonSubstring lcs = new LongestCommonSubstring();
        //    string LIS1 = lcs.FindLongestCommonSubstring("abcdef", "yuxcdeaf");    // cde

        //    Console.ReadKey();
        //}

        // TODO: There is a space optimized solution in O(2*n)

        // Tx = O(m*n  + n)
        // Sx = O(m*n)
        public string FindLongestCommonSubstring(string s1, string s2)
        {
            int l1 = s1.Length, l2 = s2.Length;

            int[,] dp = new int[l1+1,l2+1];

            int maxLen=0, maxLenRow=0, maxLenColumn=0;

            for(int i=1; i<=l1; i++)
            {
                for(int j=1; j<=l2; j++)
                {
                    if(s1[i-1] == s2[j-1])
                    {
                        dp[i,j] = dp[i - 1, j - 1] + 1;

                        if(dp[i,j] > maxLen)
                        {
                            maxLen = dp[i, j];   // Found new LIS.

                            maxLenRow = i;
                            maxLenColumn = j;
                        }
                    }
                }
            }

            string LCS = "";

            while(dp[maxLenRow, maxLenColumn] != 0)
            {
                LCS = s2[maxLenColumn - 1] + LCS;

                maxLenRow--;
                maxLenColumn--;
            }

            return LCS;
        }
    }
}
