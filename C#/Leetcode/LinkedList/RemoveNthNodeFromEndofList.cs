using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 19
    public class RemoveNthNodeFromEndofList
    {
        // Tx = O(n) {n : number of nodes in the linked list}
        // Sx = O(1)
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode slower = head;
            ListNode faster = head;

            ListNode prev = new ListNode(0)
            {
                Next = head
            };
            ListNode resultNode = prev;


            while (n > 1 && faster.Next != null)
            {
                faster = faster.Next;
                n--;
            }

            while (faster.Next != null)
            {
                faster = faster.Next;
                prev = prev.Next;
                slower = slower.Next;
            }

            prev.Next = slower.Next;

            return resultNode.Next;
        }
    }
}
