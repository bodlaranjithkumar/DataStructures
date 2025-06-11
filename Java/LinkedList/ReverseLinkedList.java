package LinkedList;

import DataStructures.ListNode;

public class ReverseLinkedList {
  // Leetcode 206: https://leetcode.com/problems/reverse-linked-list/description/
  // Submission Detail: https://leetcode.com/problems/reverse-linked-list/submissions/1631625777

  //  Input: head = [1,2,3,4,5]
  //  Output: [5,4,3,2,1]

  public ListNode reverseList(ListNode head) {
    ListNode prev = null, current = head, next = null;

    while(current != null) {
      next = current.next;
      current.next = prev;
      prev = current;
      current = next;
    }

    return prev;
  }
}
