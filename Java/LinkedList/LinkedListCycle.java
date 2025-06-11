package LinkedList;

import DataStructures.ListNode;

public class LinkedListCycle {
  // Leecode 141: https://leetcode.com/problems/linked-list-cycle/
  // Submission Detail: https://leetcode.com/problems/linked-list-cycle/submissions/1631612864

  public boolean hasCycle(ListNode head) {
    ListNode slow = head, fast = head;

    while(fast != null && fast.next != null) {
      slow = slow.next;
      fast = fast.next.next;

      if(slow == fast) {
        return true;
      }
    }

    return false;
  }
}
