package GreedyAlgorithms;

public class BestTimeToBuyAndSellStocks {
  // Leetcode 121 :https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
  // Submission Detail: https://leetcode.com/problems/assign-cookies/submissions/1652345120

  //  Input: prices = [7,1,5,3,6,4]
  //  Output: 5
  //
  //  Input: prices = [7,6,4,3,1]
  //  Output: 0

  // Tx = O(n)
  // Sx = O(1)
  public int maxProfit(int[] prices) {
    int minSoFar = prices[0], maxProfit = 0;

    for(int index = 1; index < prices.length; index++) {
      int currentProfit = prices[index] - minSoFar;
      maxProfit = Math.max(maxProfit, currentProfit);
      minSoFar = Math.min(minSoFar, prices[index]);
    }

    return maxProfit;
  }
}
