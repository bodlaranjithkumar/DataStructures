using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 24
    // Submission Detail: https://leetcode.com/submissions/detail/143435106/
    public class SwapNodeInPairs
    {
        //public static void Main(string[] args)
        //{
        //    ListNode node1 = new ListNode(1);
        //    ListNode node2 = new ListNode(2);
        //    ListNode node3 = new ListNode(3);
        //    ListNode node4 = new ListNode(4);

        //    node1.Next = node2;
        //    node2.Next = node3;
        //    node3.Next = node4;

        //    Helper.PrintListNodes(SwapPairs(node1));

        //    Console.ReadLine();
        //}

        // In place algorithm
        // Tx = O(n)
        // Sx = O(1)
        public static ListNode SwapPairs(ListNode head)
        {
            ListNode Prev = new ListNode(0)
            {
                Next = head
            };
            ListNode ResultNode = Prev;
            ListNode Current = head;

            while (Current != null && Current.Next != null)
            {
                ListNode NextNode = Current.Next;
                Prev.Next = NextNode;

                ListNode temp = NextNode.Next;
                NextNode.Next = Current;
                Current.Next = temp;

                //For next iteration
                Prev = Current;
                Current = Current.Next;
            }

            return ResultNode.Next;
        }
    }
}
