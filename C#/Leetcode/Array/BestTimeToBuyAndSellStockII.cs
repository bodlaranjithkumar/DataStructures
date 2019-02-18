using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 122 - https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/
    // Submission Detail - https://leetcode.com/submissions/detail/208723639/

    // [7,1,5,3,6,4] -> 7
    // [1,2,3,4,5] -> 4
    // [7,6,4,3,1] -> 0

    public class BestTimeToBuyandSellStockII
    {
        // Based on the intuition from the 2nd example, if the next index value is greater than 
        // current, then add the difference to the total.

        // Tx = O(n)
        // Sx = O(1)
        public int MaxProfit(int[] prices)
        {
            int total = 0;

            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i + 1] > prices[i])
                    total += prices[i + 1] - prices[i];
            }

            return total;
        }
    }
}
