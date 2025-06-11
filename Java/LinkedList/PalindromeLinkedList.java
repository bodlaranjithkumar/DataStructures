package LinkedList;

import DataStructures.ListNode;

public class PalindromeLinkedList {
  // Leetcode 234: https://leetcode.com/problems/palindrome-linked-list/
  // Submission Detail: https://leetcode.com/problems/palindrome-linked-list/submissions/1633425255

  //  Input: head = [1,2,2,1]
  //  Output: true

  //  Input: head = [1,2]
  //  Output: false

  //  Input: head = [5,4,3,4,5]
  //  Output: true

  // Tx = O(n)
  // Sx = O(1)
  public boolean isPalindrome(ListNode head) {
    // Step 1: Find the middle node of the linkedlist
    ListNode slow = head, fast = head;
    while(fast != null && fast.next != null) {
      slow = slow.next;
      fast = fast.next.next;
    }

    // Step 2: Reverse the 2nd half of the linkedlist
    ListNode prev = null, current = slow;
    while(current != null) {
      ListNode next = current.next;
      current.next = prev;
      prev = current;
      current = next;
    }

    // Step 3: Traverse from left to right and verify if any of the values is not equal
    ListNode left = head, right = prev;
    while(right != null) {
      if(left.val != right.val)
        return false;

      left = left.next;
      right = right.next;
    }

    return true;
  }
}
