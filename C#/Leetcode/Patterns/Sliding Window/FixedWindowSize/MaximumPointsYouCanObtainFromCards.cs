public class Solution {

    // Leetcode 1423 - https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/description/
    // Submission Detail - https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/submissions/1541425928
    // Explanation - https://www.hellointerview.com/learn/code/sliding-window/maximum-points-you-can-obtain-from-cards
    // Observation - To follow the similar pattern problems for fixed window size, we need to exclude n-k elements from the array.

    // Tx = O(n)
    // Sx = O(1)
    public int MaxScore(int[] cardPoints, int k) {
        int totalSum = 0, currentSum = 0, maxSum = 0, start = 0, length = cardPoints.Length;

        foreach(int cardPoint in cardPoints)
            totalSum += cardPoint;
        
        if(k >= length)
            return totalSum;

        for(int end = 0; end < length; end++) {
            currentSum += cardPoints[end];

            // Window of size n-k
            if(end-start+1 == length-k) {
                // Deduct the sum of window n-k from the total sum and see if it's the max sum.
                maxSum = Math.Max(maxSum, totalSum - currentSum);
                currentSum -= cardPoints[start];
                start++;
            }
        }

        return maxSum;
    }
}