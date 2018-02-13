using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 203
    class RemoveLinkedListElements
    {
        // Runtime = 159ms
        // Tx = O(n) {n : number of nodes}
        // Sx = O(1)
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode tempNode = new ListNode(0){
                Next = head
            };
            ListNode prev = tempNode;

            while (head != null)
            {
                if (head.Val == val) prev.Next = head.Next;
                else prev = prev.Next;

                head = head.Next;
            }

            return tempNode.Next;
        }
    }
}
