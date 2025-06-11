package Heap;

import DataStructures.ListNode;

import java.util.PriorityQueue;

public class MergeKSortedLists {
  // Leetcode 23: https://leetcode.com/problems/merge-k-sorted-lists/description/
  // Submission Detail:

  //  Input: lists = [[1,4,5],[1,3,4],[2,6]]
  //  Output: [1,1,2,3,4,4,5,6]
  //  Explanation: The linked-lists are:
  //          [
  //          1->4->5,
  //          1->3->4,
  //          2->6
  //          ]
  //  merging them into one sorted list:
  //          1->1->2->3->4->4->5->6

  //  Input: lists = []
  //  Output: []

  //  Input: lists = [[]]
  //  Output: []

  // Tx = O(n logk) where n = size of list and k is the size of heap
  // Sx = O(k)
  public ListNode mergeKLists(ListNode[] lists) {
    PriorityQueue<ListNode> minHeap = new PriorityQueue<>((a, b) -> a.val - b.val);
    for(ListNode head: lists) {
      if(head != null)
        minHeap.offer(head);
    }

    ListNode head, tail;
    head = tail = new ListNode(-1);

    while(!minHeap.isEmpty()) {
      ListNode root = minHeap.poll();
      tail.next = root;

      if(root.next != null) {
        minHeap.offer(root.next);
      }

      tail = tail.next;
    }

    return head.next;
  }
}
