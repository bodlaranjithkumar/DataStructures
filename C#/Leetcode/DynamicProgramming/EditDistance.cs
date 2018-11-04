using System;

namespace LeetcodeSolutions.Strings
{
    // Leetcode 72 - https://leetcode.com/problems/edit-distance/
    // Submission Detail: https://leetcode.com/submissions/detail/142221965/
    // Referene : https://www.geeksforgeeks.org/dynamic-programming-set-5-edit-distance/

    // Dynamic Programming

    public class EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            // Bruteforce
            //return MinDistance(word1, word2, word1.Length, word2.Length);

            return MinDistanceDP(word1, word2, word1.Length, word2.Length);
        }

        // Tx = O(m*n)
        // Sx = O(m*n) 
        // TODO: Space can be further optimized as per the post - https://leetcode.com/problems/edit-distance/discuss/25846/20ms-Detailed-Explained-C++-Solutions-(O(n)-Space)
        public int MinDistanceDP(string word1, string word2, int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];

            for(int i=0; i<=m; i++)
            {
                for(int j=0; j<=n; j++)
                {
                    // Given string is empty
                    if (i == 0) dp[i, j] = j;

                    // Resultant string is empty
                    else if (j == 0) dp[i, j] = i;

                    // characters are same, so copy the value previous comparision as no operations are needed.
                    else if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                    else
                        dp[i, j] = 1 + System.Math.Min(dp[i, j - 1],       //insert
                                            System.Math.Min(dp[i - 1, j],  //delete
                                                    dp[i - 1, j - 1]));//replace
                }
            }

            return dp[m, n];
        }

        // Bruteforce
        // Tx = O(n^3)
        // Sx = O(max(m,n))
        public int MinDistance(string word1, string word2, int m, int n)
        {
            // If given string is empty, n operations are needed
            if (m == 0) return n;

            // If resultant string is empty, m operations are needed
            else if (n == 0) return m;

            else if (word1[m - 1] == word2[n - 1])
                return MinDistance(word1, word2, m - 1, n - 1);

            else
                return 1 + System.Math.Min(MinDistance(word1, word2, m, n - 1),    // Insert
                                        System.Math.Min(MinDistance(word1, word2, m - 1, n),    // Delete
                                        MinDistance(word1, word2, m - 1, n - 1)));  // Replace
        }
    }
}
