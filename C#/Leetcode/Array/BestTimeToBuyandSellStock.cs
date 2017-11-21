using sys = System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 121
    class BestTimeToBuyandSellStock
    {
        // Runtime = 172ms
        // Tx = O(n) {n:length of the array}
        // Sx = O(1) 
        // Greedy Algorithm
        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2)
            {
                return 0;
            }

            int min = prices[0];
            int maxProfit = prices[1] - prices[0];

            for (int index = 1; index < prices.Length; index++)
            {
                maxProfit = sys.Math.Max(maxProfit, prices[index] - min);

                min = sys.Math.Min(min, prices[index]);
            }

            // Given : Return 0 when the stock price is decreasing constantly.
            return maxProfit < 0 ? 0 : maxProfit;
        }
    }
}
