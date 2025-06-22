package LinkedList;

import DataStructures.ListNode;

public class OddEvenLinkedList {
    // Leetcode 328: https://leetcode.com/problems/odd-even-linked-list/description/
    // Submission Detail: https://leetcode.com/problems/odd-even-linked-list/submissions/1673085411

    //Input: head = [1,2,3,4,5]
    //Output: [1,3,5,2,4]
    //
    //Input: head = [2,1,3,5,6,4,7]
    //Output: [2,3,6,7,1,5,4]

    public ListNode oddEvenList(ListNode head) {
        if(head == null || head.next == null)
            return head;

        ListNode odd = head, even = head.next, evenHead = even;

        while(even != null && even.next != null) {
            odd.next = even.next;
            odd = odd.next;
            even.next = even.next.next;
            even = even.next;
        }
        odd.next = evenHead; // link the final odd node's next to the even node's head.

        return head;
    }
}
