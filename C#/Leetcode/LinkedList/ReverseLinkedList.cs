using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 206  - https://leetcode.com/problems/reverse-linked-list/
    // Submission Detail - https://leetcode.com/submissions/detail/140383800/

    public class ReverseLinkedList
    {
        // Tx = O(n)
        // Sx = O(1)
        // Inplace algorithm
        public ListNode ReverseList(ListNode head)
        {
            ListNode current = head;
            ListNode previous = null;
            ListNode nextNode = null;

            while (current != null)
            {
                nextNode = current.Next;
                current.Next = previous;
                previous = current;
                current = nextNode;
            }

            return previous;
        }
    }
}
