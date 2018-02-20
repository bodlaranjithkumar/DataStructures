namespace LeetcodeSolutions.Math
{
    // Leetcode 279
    // Submission Details : https://leetcode.com/submissions/detail/141588006/
    // Dynamic Programming. Similar to Coin change problem.
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
                    numSquares[i] = int.MaxValue;   // Initialize to max value to find the min required.
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
