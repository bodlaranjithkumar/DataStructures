using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 24 - https://leetcode.com/problems/swap-nodes-in-pairs/description/
    // Submission Detail - https://leetcode.com/submissions/detail/171618975/

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
            ListNode dummyHead = new ListNode(0)
            {
                Next = head
            };

            // 2 iterating pointers
            ListNode prev = dummyHead;
            ListNode current = head;

            while (current != null && current.Next != null)
            {
                ListNode nextNode = current.Next;
                prev.Next = nextNode;

                ListNode temp = nextNode.Next;
                nextNode.Next = current;
                current.Next = temp;

                // update prev and current for Next iteration
                prev = current;
                current = current.Next;
            }

            return dummyHead.Next;
        }
    }
}
