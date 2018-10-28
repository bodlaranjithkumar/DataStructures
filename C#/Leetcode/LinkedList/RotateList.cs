using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 61 - https://leetcode.com/problems/rotate-list/description/
    // Submission Detail - https://leetcode.com/submissions/detail/184090592/

    public class RotateList
    {
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.Next == null)
                return head;

            int totalNodes = 0;
            ListNode current = head, lastNode = null;

            // Count the total number of nodes in the list.
            while (current != null)
            {
                if (current.Next == null)
                    lastNode = current;

                current = current.Next;

                totalNodes++;
            }

            // If total nodes = 5, k = 7, now rotating 2 times will suffice.        
            k = k % totalNodes;

            if (k == 0)
                return head;

            int newHeadIndex = totalNodes - k; // The new head index
            ListNode newHead;
            current = head;

            // Find the node before the newHeadIndex
            while (newHeadIndex > 1)
            {
                current = current.Next;
                newHeadIndex--;
            }

            // Set the next pointer of the node before the newHeadIndex to null.
            newHead = current.Next;
            current.Next = null;

            // Set the old head as the next node of the lastNode present before rotating.
            lastNode.Next = head;

            return newHead;
        }
    }
}
