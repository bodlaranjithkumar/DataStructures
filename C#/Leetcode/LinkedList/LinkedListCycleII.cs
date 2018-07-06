using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 142
    // Submission Detail: https://leetcode.com/submissions/detail/142762203/
    // Slow runner and fast runner technique
    public class LinkedListCycleII
    {
        //public static void Main(string[] args)
        //{
        //    LinkedListCycleII cycle = new LinkedListCycleII();

        //    ListNode head1 = new ListNode(1);
        //    head1.Next = head1;

        //    ListNode cycleHead1 = cycle.DetectCycle(head1);

        //    Console.ReadKey();
        //}

        // Method1
        // Tx = O(n) // O(2n) worst case
        // Sx = O(1)
        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (fast == slow) break;
            }

            if (fast == null || fast.Next == null) return null;   // no cycle

            slow = head;

            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            return slow;
        }

        // Method 2
        public ListNode DetectCycleSiri(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    slow = head;
                    while (slow != fast)
                    {
                        slow = slow.Next;
                        fast = fast.Next;                        
                    }

                    if (slow == fast)
                    {
                        return slow;
                    }
                }
            }

            return null;
        }
    }
}
