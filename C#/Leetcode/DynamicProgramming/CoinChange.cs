namespace LeetcodeSolutions.Array
{
    // Leetcode 322 - https://leetcode.com/problems/coin-change/
    // Submission Detail - https://leetcode.com/submissions/detail/141580435/
    // Dynamic Programming
    public class CoinChange
    {
        // Bottom-up dynamic programming
        // Tx = O(amount * n) { n : total number of coins}
        // Sx = O(amount) 
        public int MinCoinChangeBottomUp(int[] coins, int amount)
        {
            int[] minCoinsAmount = new int[amount + 1];

            // Base case is minCoinsAmount[0] = 0;
            for (int i = 1; i < minCoinsAmount.Length; i++)
                minCoinsAmount[i] = amount + 1;

            for (int i = 1; i <= amount; i++)
            {
                foreach (var coin in coins)
                {
                    if(coin <= i)
                        minCoinsAmount[i] = System.Math.Min(minCoinsAmount[i], minCoinsAmount[i - coin] + 1);
                }
            }

            return minCoinsAmount[amount] > amount ? -1 : minCoinsAmount[amount];
        }

        // Memoization, Top-Down Dynamic Programming. Doesn't return -1 for failing cases.
        // Tx = O(amount ^ n) { n : total number of coins}
        // Sx = O(amount)   for call stack
        public int MinCoinChangeTopDown(int[] coins, int amount)
        {
            int[] minCoinsAmount = new int[amount + 1];

            for (int i = 0; i < minCoinsAmount.Length; i++)
                minCoinsAmount[i] = -1;

            return MinCoinChangeTopDown(coins, minCoinsAmount, amount);
        }

        public int MinCoinChangeTopDown(int[] coins, int[] minCoinsAmount, int amount)
        {
            if (minCoinsAmount[amount] >= 0)
                return minCoinsAmount[amount];

            int minCoins = int.MaxValue;

            foreach (int coin in coins)
            {
                if (amount - coin >= 0)
                {
                    int coinsRequried = MinCoinChange(coins, amount - coin);
                    minCoins = System.Math.Min(minCoins, coinsRequried);
                }
            }

            minCoinsAmount[amount] = minCoins + 1;
            return minCoinsAmount[amount];
        }

        // Bruteforce. Doesn't return -1 for failing cases.
        // Tx = O(amount ^ n) { n : total number of coins}
        // Sx = O(amount)   for call stack
        public int MinCoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;

            int minCoins = amount + 1;

            foreach (int coin in coins)
            {
                if (amount - coin >= 0)
                {
                    int coinsRequried = MinCoinChange(coins, amount - coin);
                    minCoins = System.Math.Min(minCoins, coinsRequried);
                }
            }

            return minCoins > amount ? -1 : minCoins + 1;
        }
    }
}
