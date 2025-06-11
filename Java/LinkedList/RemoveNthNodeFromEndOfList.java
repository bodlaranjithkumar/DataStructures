package LinkedList;

import DataStructures.ListNode;

public class RemoveNthNodeFromEndOfList {
  // Leetcode 19: https://leetcode.com/problems/remove-nth-node-from-end-of-list/
  // Submission Detail: https://leetcode.com/problems/remove-nth-node-from-end-of-list/submissions/1633443400

  //  Input: head = [1,2,3,4,5], n = 2
  //  Output: [1,2,3,5]

  //  Input: head = [1], n = 1
  //  Output: []

  //  Input: head = [1,2], n = 1
  //  Output: [1]

  // Tx = O(n)
  // Sx = O(1)
  public ListNode removeNthFromEnd(ListNode head, int n) {
    ListNode dummyNode = new ListNode(0);
    dummyNode.next = head;

    // Step 1: Since we added a dummyNode at the beginning, traverse till fast reaches the nth node
    ListNode slow = dummyNode, fast = dummyNode;
    for(int index = 0; index <= n; index++) {
      fast = fast.next;
    }

    // Step 2: Iterate till fast reaches the end. Thus, slow points to the node before nth node.
    while(fast != null) {
      slow = slow.next;
      fast = fast.next;
    }

    slow.next = slow.next.next;

    return dummyNode.next;
  }
}
