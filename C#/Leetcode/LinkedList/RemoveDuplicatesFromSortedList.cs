using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 83 - https://leetcode.com/problems/remove-duplicates-from-sorted-list/
    // Submission Detail - https://leetcode.com/submissions/detail/171622213/

    public class RemoveDuplicatesFromSortedList
    {
        // Tx = O(n)
        // Sx = O(1)

        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode current = head;

            while (current != null)
            {
                ListNode prev = current;
                while (current.Next != null && current.Val == current.Next.Val)
                {
                    current = current.Next;
                }

                if (prev.Next != current.Next)
                    prev.Next = current.Next;

                current = current.Next;
            }

            return head;
        }
    }
}
