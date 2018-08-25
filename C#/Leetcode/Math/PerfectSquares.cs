namespace LeetcodeSolutions.Math
{
    // Leetcode 279 - https://leetcode.com/problems/perfect-squares
    // Submission Detail - https://leetcode.com/submissions/detail/141588006/
    // Bottom-Up Dynamic Programming. Similar to Coin change problem.

    public class PerfectSquares
    {
        // Bottom up dynamic programming
        public int NumSquares(int n)
        {
            int[] numSquares = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                if (i * i == n)
                    return 1;   
                else
                    numSquares[i] = n + 1;   // Initialize to n+1 as n cannot have more than n perfect squares.
            }

            for (int i = 1; i <= n; i++)
            {
                // Run for each perfect square less than i.
                for (int j = 1; j * j <= i; j++)
                {
                    numSquares[i] = System.Math.Min(numSquares[i], numSquares[i - j * j] + 1);
                }
            }

            return numSquares[n];
        }
    }
}
