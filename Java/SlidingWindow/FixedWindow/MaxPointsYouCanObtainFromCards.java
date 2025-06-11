package SlidingWindow.FixedWindow;

public class MaxPointsYouCanObtainFromCards {
    // Leetcode 1423: https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/
    // Submission Detail: https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/submissions/1625774509

    // Input: cards = [2,11,4,5,3,9,2], k = 3
    // Output: 17
    public int maxScore(int[] cardPoints, int k) {
        int total = 0;
        for(int cardPoint: cardPoints)
            total += cardPoint;

        if(cardPoints.length == k)
            return total;

        int start=0, maxSum = 0, currentSum = 0;

        for(int end=0; end<cardPoints.length; end++) {
            currentSum += cardPoints[end];

            if(end-start+1 == cardPoints.length-k) {
                maxSum = Math.max(total-currentSum, maxSum);
                currentSum -= cardPoints[start];
                start++;
            }
        }

        return maxSum;
    }
}
