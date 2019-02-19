namespace LeetcodeSolutions.DynamicProgramming
{
    // Leetcode 518 - https://leetcode.com/problems/coin-change-2/description/
    // Submission Detail - https://leetcode.com/submissions/detail/208999305/
    // Bottom-Up Dynamic Programming

    public class CoinChange2
    {
        public int Change(int amount, int[] coins)
        {
            int[] totalWays = new int[amount + 1];
            totalWays[0] = 1;

            foreach (int coin in coins)
            {
                for (int i = 1; i <= amount; i++)
                {
                    if (i - coin >= 0)
                    {
                        totalWays[i] += totalWays[i - coin];
                    }
                }
            }

            return totalWays[amount];
        }
    }
}
