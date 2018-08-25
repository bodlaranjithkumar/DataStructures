using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 203 - https://leetcode.com/problems/remove-linked-list-elements/
    // Submission Detail - https://leetcode.com/submissions/detail/171620045/

    public class RemoveLinkedListElements
    {
        // Runtime = 159ms
        // Tx = O(n) {n : number of nodes}
        // Sx = O(1)
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummyHead = new ListNode(0){
                Next = head
            };
            ListNode prev = dummyHead;

            while (head != null)
            {
                if (head.Val == val)
                    prev.Next = head.Next;
                else
                    prev = prev.Next;

                head = head.Next;
            }

            return dummyHead.Next;
        }
    }
}
