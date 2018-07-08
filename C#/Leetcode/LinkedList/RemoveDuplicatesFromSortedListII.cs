using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 82
    // Submission Detail: https://leetcode.com/submissions/detail/162451150/
    public class RemoveDuplicatesFromSortedListII
    {
        // Tx = O(n)
        // Sx = O(1)

        // Idea: 2 pointers - current, previous.
        //      Start from head, traverse all the duplicate nodes of the current node until the last node and then append it's Next to previous's Next.
        //      If the current node is unique, update it to previous so that the Next current is appended to the current.

        // Reference: https://www.google.com/url?q=https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/discuss/28335/My-accepted-Java-code&sa=D&source=hangouts&ust=1530990480234000&usg=AFQjCNGS8AsITv2GjCr0Eiuj0z3FPOh5aw

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;

            ListNode dummyHead = new ListNode(0)
            {
                Next = head
            };

            ListNode previous = dummyHead;
            ListNode current = head;

            while (current != null)
            {
                while (current.Next != null && current.Val == current.Next.Val)
                {
                    current = current.Next;
                }

                if (previous.Next == current)
                    previous = previous.Next;
                else
                    previous.Next = current.Next;

                current = current.Next;
            }

            return dummyHead.Next;
        }
    }
}
