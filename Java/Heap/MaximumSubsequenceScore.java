package Heap;

import java.util.Arrays;
import java.util.PriorityQueue;

public class MaximumSubsequenceScore {
    // Leetcode 2542: https://leetcode.com/problems/maximum-subsequence-score/description/
    // Submission Detail: https://leetcode.com/problems/maximum-subsequence-score/submissions/1679764506

    //Input: nums1 = [1,3,3,2], nums2 = [2,1,3,4], k = 3
    //Output: 12
    //Explanation:
    //The four possible subsequence scores are:
    //        - We choose the indices 0, 1, and 2 with score = (1+3+3) * min(2,1,3) = 7.
    //        - We choose the indices 0, 1, and 3 with score = (1+3+2) * min(2,1,4) = 6.
    //        - We choose the indices 0, 2, and 3 with score = (1+3+2) * min(2,3,4) = 12.
    //        - We choose the indices 1, 2, and 3 with score = (3+3+2) * min(1,3,4) = 8.
    //Therefore, we return the max score, which is 12.

    //Input: nums1 = [4,2,3,1,1], nums2 = [7,5,10,9,6], k = 1
    //Output: 30
    //Explanation:
    //Choosing index 2 is optimal: nums1[2] * nums2[2] = 3 * 10 = 30 is the maximum possible score.

    //Input: nums1 = [4,8,3,1,1], nums2 = [7,5,10,9,6], k = 2
    //Output: 60

    // Tx = O(nlogn + nlogk)
    // Sx = O(n)
    public long maxScore(int[] nums1, int[] nums2, int k) {
        int length = nums2.length;
        int[][] numsPair = new int[length][2];

        for(int index=0; index<length; index++) {
            numsPair[index][0] = nums2[index];
            numsPair[index][1] = nums1[index];
        }

        Arrays.sort(numsPair, (a,b) -> b[0]-a[0]); // descending order of nums2
        PriorityQueue<Integer> pq = new PriorityQueue<>(k, (a, b) -> a-b);

        long sumSoFar = 0, maxScore = 0;
        for(int index=0; index<length; index++) {
            sumSoFar += numsPair[index][1];
            pq.offer(numsPair[index][1]);

            // size is greater than the desired capacity k. Remove the smallest of nums2 so that the score can be maximum.
            if(pq.size() > k)
                sumSoFar -= pq.poll();

            // When the size is k and given numsPair is sorted in descending order, the value at index in numsPair is the min.
            if(pq.size() == k)
                maxScore = Math.max(maxScore, numsPair[index][0] * sumSoFar);
        }

        return maxScore;
    }
}
