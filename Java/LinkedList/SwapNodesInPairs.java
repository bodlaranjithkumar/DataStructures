package LinkedList;

import DataStructures.ListNode;

public class SwapNodesInPairs {
  // Leetcode 24: https://leetcode.com/problems/swap-nodes-in-pairs/
  // Submission Detail: https://leetcode.com/problems/swap-nodes-in-pairs/submissions/1638805199

  // [1,2,3,4,5] -> [2,1,4,3,5]
  // [1,2,3,4] -> [2,1,4,3]
  // [] -> []
  // [1] -> [1]

  // Tx = O(n)
  // Sx = O(1)
  public ListNode swapPairs(ListNode head) {
    ListNode dummyHead = new ListNode(0);
    dummyHead.next = head;

    ListNode curr = dummyHead;

    while(curr != null && curr.next != null && curr.next.next != null) {
      ListNode nextNext = curr.next.next;
      ListNode next = curr.next;

      curr.next = nextNext;
      next.next = nextNext.next;
      nextNext.next = next;
      curr = next;
    }

    return dummyHead.next;
  }
}
