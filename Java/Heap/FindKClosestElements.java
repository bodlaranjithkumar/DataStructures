package Heap;

import java.util.ArrayList;
import java.util.List;
import java.util.PriorityQueue;

public class FindKClosestElements {
  // Leetcode 658: https://leetcode.com/problems/find-k-closest-elements/description/
  // Submission Detail: https://leetcode.com/problems/find-k-closest-elements/submissions/1647725219

  public List<Integer> findClosestElements(int[] arr, int k, int x) {
    PriorityQueue<Integer> maxHeap = new PriorityQueue<>((a, b) -> getDistance(b,x) - getDistance(a,x));

    for(int num:arr) {
      if(maxHeap.size() < k) {
        maxHeap.offer(num);
      } else if(getDistance(num, x) < getDistance(maxHeap.peek(), x)) {
        maxHeap.poll();
        maxHeap.offer(num);
      }
    }

    List<Integer> result = new ArrayList<>(maxHeap.size());
    while(!maxHeap.isEmpty()) {
      result.add(maxHeap.poll());
    }

    result.sort();

    return result;
  }

  private int getDistance(int num, int x) {
    return Math.abs(num - x);
  }
}
