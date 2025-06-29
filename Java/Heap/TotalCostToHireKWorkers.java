package Heap;

import java.util.PriorityQueue;

public class TotalCostToHireKWorkers {
    // Leetcode 2463: https://leetcode.com/problems/total-cost-to-hire-k-workers/submissions/1679806865/
    // Submission Detail: https://leetcode.com/problems/total-cost-to-hire-k-workers/submissions/1679806865

    //Input: costs = [17,12,10,2,7,2,11,20,8], k = 3, candidates = 4
    //Output: 11
    //Explanation: We hire 3 workers in total. The total cost is initially 0.
    //        - In the first hiring round we choose the worker from [17,12,10,2,7,2,11,20,8]. The lowest cost is 2, and we break the tie by the smallest index, which is 3. The total cost = 0 + 2 = 2.
    //        - In the second hiring round we choose the worker from [17,12,10,7,2,11,20,8]. The lowest cost is 2 (index 4). The total cost = 2 + 2 = 4.
    //        - In the third hiring round we choose the worker from [17,12,10,7,11,20,8]. The lowest cost is 7 (index 3). The total cost = 4 + 7 = 11. Notice that the worker with index 3 was common in the first and last four workers.
    //The total hiring cost is 11.

    //Input: costs = [1,2,4,1], k = 3, candidates = 3
    //Output: 4
    //Explanation: We hire 3 workers in total. The total cost is initially 0.
    //        - In the first hiring round we choose the worker from [1,2,4,1]. The lowest cost is 1, and we break the tie by the smallest index, which is 0. The total cost = 0 + 1 = 1. Notice that workers with index 1 and 2 are common in the first and last 3 workers.
    //- In the second hiring round we choose the worker from [2,4,1]. The lowest cost is 1 (index 2). The total cost = 1 + 1 = 2.
    //        - In the third hiring round there are less than three candidates. We choose the worker from the remaining workers [2,4]. The lowest cost is 2 (index 0). The total cost = 2 + 2 = 4.
    //The total hiring cost is 4.

    //Input: costs = [31,25,72,79,74,65,84,91,18,59,27,9,81,33,17,58], k = 11, candidates = 2
    //Output: 423

    // Java
    public long totalCost(int[] costs, int k, int candidates) {
        PriorityQueue<Integer> leftMinHeap = new PriorityQueue<>();
        PriorityQueue<Integer> rightMinHeap = new PriorityQueue<>();

        int left = 0, right = costs.length - 1;
        long totalCost = 0;

        // Fill initial candidates
        for (int i = 0; i < candidates && left <= right; i++) {
            leftMinHeap.offer(costs[left++]);
        }
        for (int i = 0; i < candidates && left <= right; i++) {
            rightMinHeap.offer(costs[right--]);
        }

        for (int hire = 0; hire < k; hire++) {
            if (!leftMinHeap.isEmpty() && (rightMinHeap.isEmpty() || leftMinHeap.peek() <= rightMinHeap.peek())) {
                totalCost += leftMinHeap.poll();
                if (left <= right) {
                    leftMinHeap.offer(costs[left]);
                    left++;
                }
            } else {
                totalCost += rightMinHeap.poll();
                if (left <= right) {
                    rightMinHeap.offer(costs[right]);
                    right--;
                }
            }
        }
        return totalCost;
    }


    // Partially Correct
    public long totalCost1(int[] costs, int k, int candidates) {
        PriorityQueue<Integer> leftMinHeap = new PriorityQueue<>();
        PriorityQueue<Integer> rightMinHeap = new PriorityQueue<>();

        int left = 0, length = costs.length, right = length-1, totalCost = 0;

        for(int hiringRoundNumber = 0; hiringRoundNumber < k; hiringRoundNumber++) {
            while(left < length && leftMinHeap.size() < candidates) {
                leftMinHeap.offer(costs[left]);
                left++;
            }

            while(right > left && rightMinHeap.size() < candidates) {
                rightMinHeap.offer(costs[right]);
                right--;
            }

            if(!rightMinHeap.isEmpty() && rightMinHeap.peek() < leftMinHeap.peek()) {
                totalCost += rightMinHeap.poll();
            } else {
                totalCost += leftMinHeap.poll();
            }
        }

        return totalCost;
    }
}
