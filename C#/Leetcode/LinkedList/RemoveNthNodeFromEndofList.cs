using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 19 - https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    // Submission Detail - https://leetcode.com/submissions/detail/171616939/

    public class RemoveNthNodeFromEndofList
    {
        // Tx = O(n) {n : number of nodes in the linked list}
        // Sx = O(1)
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummyNode = new ListNode(0)
            {
                Next = head
            };

            ListNode slower = dummyNode;
            ListNode faster = dummyNode;

            while (n > 0 && faster.Next != null)
            {
                faster = faster.Next;
                n--;
            }

            while (faster.Next != null)
            {
                faster = faster.Next;
                slower = slower.Next;
            }

            slower.Next = slower.Next.Next;

            return dummyNode.Next;
        }
    }
}
