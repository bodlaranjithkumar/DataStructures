package Heap;

import java.util.PriorityQueue;

public class KthLargestElementInArray {
  // Leetcode 215: https://leetcode.com/problems/kth-largest-element-in-an-array/description/
  // Submission Detail: https://leetcode.com/problems/kth-largest-element-in-an-array/submissions/1647630058

  // Tx = O(n logk). logk for heapifying for n iterations of array elements
  // Sx = O(k) space for storing the heap
  public int findKthLargest(int[] nums, int k) {
    PriorityQueue<Integer> minHeap = new PriorityQueue<>(k);
    for (int num: nums) {
      if(minHeap.size() < k) {
        minHeap.offer(num);
      } else if(num > minHeap.peek()) {
        minHeap.poll();
        minHeap.offer(num);
      }
    }

    return minHeap.peek();
  }
}
