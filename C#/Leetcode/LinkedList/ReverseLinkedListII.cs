using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 92 - https://leetcode.com/problems/reverse-linked-list-ii/description/
    // Submission Detail - https://leetcode.com/submissions/detail/183972700/

    public class ReverseLinkedListII
    {
        //public static void Main(string[] args)
        //{
        //    ReverseLinkedListII rev = new ReverseLinkedListII();

        //    ListNode head1 = new ListNode(1)
        //    {
        //        Next = new ListNode(2)
        //        {
        //            Next = new ListNode(3)
        //            {
        //                Next = new ListNode(4)
        //                {
        //                    Next = new ListNode(5)
        //                }
        //            }
        //        }
        //    };
            
        //    ListNode reverseHead1 = rev.ReverseBetween(head1, 2, 4);

        //    Console.ReadKey();
        //}

        // 1->2->3->4->5       =>    1->4->3->2->5
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            ListNode dummyHead = new ListNode(0);
            dummyHead.Next = head;

            int length = n - m;

            ListNode prev = dummyHead;

            while (m > 1 && prev != null)
            {
                prev = prev.Next;
                m--;
            }

            if (prev != null)
                prev.Next = Reverse(prev, length);

            return dummyHead.Next;
        }

        private ListNode Reverse(ListNode prev, int n)
        {
            ListNode head = prev.Next, current = head, next = null;

            while (current != null && n >= 0)
            {
                next = current.Next;
                current.Next = prev;

                prev = current;
                current = next;

                n--;
            }

            head.Next = current;

            return prev;
        }
    }
}
