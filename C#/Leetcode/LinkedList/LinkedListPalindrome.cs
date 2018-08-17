using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 234
    // Submission Detail: https://leetcode.com/submissions/detail/169952869/

    public class LinkedListPalindrome
    {
        // Tx = O(n)
        // Sx = O(1)

        //Two Pointers or runner technique
        //Idea: Find the mid point using 2 pointers.
        //      Reverse the right half. Slow now points to the head of the reversed 2nd half. Point the fast node to head of the list.
        //      Now compare both the halves node by node until the 2nd half is null.

        public bool IsPalindrome(ListNode head)
        {
            ListNode slow = head, fast = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            // Odd length: point slow to the node Next to the middle one.
            if (fast != null)
                slow = slow.Next;

            slow = Reverse(slow);
            fast = head;

            while (slow != null)
            {
                if (slow.Val != fast.Val)
                    return false;

                slow = slow.Next;
                fast = fast.Next;
            }

            return true;
        }

        private ListNode Reverse(ListNode node)
        {
            ListNode prev = null;

            while (node != null)
            {
                ListNode Next = node.Next;
                node.Next = prev;
                prev = node;
                node = Next;
            }

            return prev;
        }
    }
}
