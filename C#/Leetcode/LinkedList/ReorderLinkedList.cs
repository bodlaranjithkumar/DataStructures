using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 143 - https://leetcode.com/problems/reorder-list/description/
    // Submission Detail - https://leetcode.com/submissions/detail/204415401/

    // 1->2->3->4 => 1->4->2->3
    // 1->2->3->4->5 => 1->5->2->4->3

    public class ReorderLinkedList
    {
        // Algorithm: 1. Iterate through the linked list using the slow and fast runner until the mid is found or the fast has reached the end of the list. 
        //            2. Reverse the 2nd half of the list. 
        //            3. Reorder the list using slow, fast till fast has reached slow.


        // Tx = O(n)
        // Sx = O(1)
        public void ReorderList(ListNode head)
        {
            if (head == null)
                return;

            ListNode dummyHead = new ListNode(0)
            {
                Next = head
            };

            ListNode slow = dummyHead, fast = dummyHead;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            if (slow.Next != null)
            {
                slow.Next = Reverse(slow.Next);
            }

            fast = head;

            ReorderList(slow, fast);
        }

        private ListNode Reverse(ListNode head)
        {
            ListNode prev = null, current = head;

            while (current != null)
            {
                ListNode NextNode = current.Next;
                current.Next = prev;

                prev = current;
                current = NextNode;
            }

            return prev;
        }

        private void ReorderList(ListNode slow, ListNode fast)
        {
            while (slow != fast)
            {
                ListNode fastNext = fast.Next;
                fast.Next = slow.Next;

                ListNode slowNextNext = slow.Next.Next;
                slow.Next = slowNextNext;

                fast.Next.Next = fastNext;

                fast = fastNext;
                //slow = slowNextNext;            
            }
        }
    }
}
