using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 21 - https://leetcode.com/problems/merge-two-sorted-lists/
    // Submission Detail - https://leetcode.com/submissions/detail/171613955/
    // Input : 5->10->15    and    2->3->20
    // Output: 2->3->5->10->15->20

    public class Merge2SortedLinkedLists
    {
        //public static void Main(string[] args)
        //{
        //    ListNode head1 = Helper.CreateListNode(new[] { 5, 10, 15 });
        //    ListNode head2 = Helper.CreateListNode(new[] { 2, 3, 20 });
        //    Helper.PrintListNodes(Merge(head1, head2));
        //    Console.WriteLine();

        //    ListNode head3 = Helper.CreateListNode(new[] { 5, 10 });
        //    ListNode head4 = Helper.CreateListNode(new[] { 2, 3, 20 });
        //    Helper.PrintListNodes(Merge(head3, head4));
        //    Console.WriteLine();

        //    ListNode head5 = Helper.CreateListNode(new[] { 5, 10, 15 });
        //    ListNode head6 = Helper.CreateListNode(new[] { 2, 20 });
        //    Helper.PrintListNodes(Merge(head5, head6));
        //    Console.WriteLine();

        //    ListNode head7 = Helper.CreateListNode(new[] { 1 });
        //    Helper.PrintListNodes(Merge(head7, null));
        //    Console.WriteLine();

        //    Console.ReadKey();
        //}

        public static ListNode Merge(ListNode head1, ListNode head2)
        {
            ListNode mergedHead = new ListNode(0);
            ListNode mergedCurrentNode = mergedHead;

            while (head1 != null || head2 != null)
            {
                if (head1 == null || (head2 != null && head1.Val > head2.Val))
                {
                    mergedCurrentNode.Next = head2;
                    head2 = head2.Next;
                }
                else if (head2 == null || (head1 != null && head2.Val >= head1?.Val))
                {
                    mergedCurrentNode.Next = head1;
                    head1 = head1.Next;
                }
                mergedCurrentNode = mergedCurrentNode.Next;
            }

            return mergedHead.Next;
        }
    }
}
