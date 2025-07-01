package Stack.MonotonicStack;

import java.util.Stack;

public class OnlineStockSpan {
    // Leetcode 901: https://leetcode.com/problems/online-stock-span/description/
    // Submission Detail: https://leetcode.com/problems/online-stock-span/submissions/1682022413

    //Input
    //["StockSpanner", "next", "next", "next", "next", "next", "next", "next"]
    //    [[], [100], [80], [60], [70], [60], [75], [85]]
    //Output
    //[null, 1, 1, 1, 2, 1, 4, 6]
    //
    //Explanation
    //StockSpanner stockSpanner = new StockSpanner();
    //stockSpanner.next(100); // return 1
    //stockSpanner.next(80);  // return 1
    //stockSpanner.next(60);  // return 1
    //stockSpanner.next(70);  // return 2
    //stockSpanner.next(60);  // return 1
    //stockSpanner.next(75);  // return 4, because the last 4 prices (including today's price of 75) were less than or equal to today's price.
    //stockSpanner.next(85);  // return 6

    // monotonicallyDecreasingStackCount[0] -> price
    // monotonicallyDecreasingStackCount[1] -> count of values that are lower than current price
    Stack<int[]> monotonicallyDecreasingStackCount;
    public OnlineStockSpan() {
        monotonicallyDecreasingStackCount = new Stack<>();
    }

    public int next(int price) {
        int count = 1;  // default: current span

        while(!monotonicallyDecreasingStackCount.isEmpty() && monotonicallyDecreasingStackCount.peek()[0] <= price)
            count += monotonicallyDecreasingStackCount.pop()[1];    // pop till the highest price is found and aggregate count

        monotonicallyDecreasingStackCount.push(new int[]{price, count});

        return count;
    }
}
