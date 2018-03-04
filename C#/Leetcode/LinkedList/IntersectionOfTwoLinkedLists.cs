using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 160
    // Submission Detail: https://leetcode.com/submissions/detail/143348438/
    //          Readable : https://leetcode.com/submissions/detail/143350817/
    public class IntersectionOfTwoLinkedLists
    {
        //public static void Main(string[] args)
        //{
        //    IntersectionOfTwoLinkedLists i = new IntersectionOfTwoLinkedLists();

        //    ListNode node1 = Helper.CreateListNode(new int[] { 1 });
        //    ListNode node2 = null;

        //    Console.WriteLine(i.GetIntersectionNode(node1,node2).Val);

        //    Console.ReadLine();
        //}

        // Solution1: Readable solution withouth using length but same Tx, Sx as using length
        // Ref: https://leetcode.com/problems/intersection-of-two-linked-lists/discuss/49785/Java-solution-without-knowing-the-difference-in-len!
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode a = headA;
            ListNode b = headB;

            while(a != b)
            {
                a = a == null ? headB : a.Next;
                b = b == null ? headA : b.Next;
            }

            return a;
        }

        // Solution 2
        // Tx = O(m + n)
        // Sx = O(1)
        public ListNode GetIntersectionNodeLen(ListNode headA, ListNode headB)
        {
            int l1 = FindLength(headA), l2 = FindLength(headB);
            int diff = System.Math.Abs(l1 - l2);

            if (l1 > l2) headA = GoForward(headA, diff);
            else if (l1 < l2) headB = GoForward(headB, diff);


            while (headA != headB)
            {
                headA = headA.Next;
                headB = headB.Next;
            }

            return headA;
        }

        private static int FindLength(ListNode node)
        {
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.Next;
            }

            return count;
        }

        private static ListNode GoForward(ListNode node, int count)
        {
            while (count > 0)
            {
                node = node.Next;
                count--;
            }

            return node;
        }
    }
}
