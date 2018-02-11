using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 206
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
