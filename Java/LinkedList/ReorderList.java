package LinkedList;

import DataStructures.ListNode;

public class ReorderList {
  // Leetcode 143: https://leetcode.com/problems/reorder-list/description/
  // Submission Detail: https://leetcode.com/problems/reorder-list/submissions/1637710585

  // Input: [1,2,3,4,5] -> [1,5,2,4,3]
  // Input: [1,2,3,4] -> [1,4,2,3]
  // Input: [1] -> [1]

  // Tx = O(n)
  // Sx = O(1)
  public void reorderList(ListNode head) {
    // Step 1: Find the middle node of the list
    ListNode slow = head, fast = head;
    while(fast != null && fast.next != null) {
      slow = slow.next;
      fast = fast.next.next;
    }

    // Step 2: Reverse the 2nd half of the list
    ListNode prev = null, curr = slow;
    while(curr != null) {
      ListNode next = curr.next;
      curr.next = prev;
      prev = curr;
      curr = next;
    }

    // Step 3: Reorder list alternatively
    ListNode first = head, second = prev;
    while(second.next != null) {
      ListNode firstNext = first.next;
      first.next = second;
      first = firstNext;
      ListNode secondNext = second.next;
      second.next = first;
      second = secondNext;
    }
  }
}
