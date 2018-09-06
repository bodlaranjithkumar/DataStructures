namespace LeetcodeSolutions.Math
{
    // Leetcode 279 - https://leetcode.com/problems/perfect-squares
    // Submission Detail - https://leetcode.com/submissions/detail/174152816/
    // Bottom-Up Dynamic Programming. Similar to Coin change problem.

    public class PerfectSquares
    {
        // Bottom up dynamic programming
        public int NumSquares(int n)
        {
            int[] numSquares = new int[n + 1];
            
            for (int i = 1; i <= n; i++)
            {
                numSquares[i] = n + 1;   // Initialize to n+1 as n cannot have more than n perfect squares.

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
