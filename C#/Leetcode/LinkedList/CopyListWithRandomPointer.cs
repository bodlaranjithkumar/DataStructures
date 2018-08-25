using System;

namespace LeetcodeSolutions.LinkedList
{
    public class RandomListNode
    {
        public int Label;
        public RandomListNode Next, Random;
        public RandomListNode(int x)
        {
            Label = x;
        }
    };

    // Leetcode 138 - https://leetcode.com/problems/copy-list-with-random-pointer/
    // Reference - https://leetcode.com/problems/copy-list-with-random-pointer/discuss/43491/A-solution-with-constant-space-complexity-O(1)-and-linear-time-complexity-O(N)/42652
    // Submission Detail - https://leetcode.com/submissions/detail/143476574/

    public class CopyListWithRandomPointer
    {
        //public static void Main(string[] args)
        //{
        //    RandomListNode n1 = new RandomListNode(1);
        //    RandomListNode n2 = new RandomListNode(2);
        //    RandomListNode n3 = new RandomListNode(3);
        //    RandomListNode n4 = new RandomListNode(4);
        //    RandomListNode n5 = new RandomListNode(5);

        //    n1.Next = n2;
        //    n1.Random = n3;

        //    n2.Next = n3;
        //    n2.Random = n1;

        //    n3.Next = n4;
        //    n3.Random = n5;

        //    n4.Next = n5;
        //    n4.Random = n3;

        //    n5.Random = n2;

        //    var copyNode = CopyRandomList(n1);

        //    Console.ReadLine();
        //}

        public static RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null) return head;

            RandomListNode current = head;

            //Step1: Create new node and insert it between current and current's next.
            while (current != null)
            {
                RandomListNode next = current.Next;
                RandomListNode copy = new RandomListNode(current.Label);
                current.Next = copy;
                copy.Next = next;
                current = next;
            }

            //Step2: Update random pointers on the copied list.
            current = head;
            while (current != null)
            {
                if (current.Random != null)
                    current.Next.Random = current.Random.Next;

                current = current.Next.Next;
            }

            //Step3: Separate original list and copy list.
            current = head;
            RandomListNode copyHead = current.Next;
            RandomListNode copyCurrent = copyHead;
            while (copyCurrent.Next != null)
            {
                current.Next = current.Next.Next;   // or copyCurrent.Next;
                current = current.Next;

                copyCurrent.Next = copyCurrent.Next.Next; //or current.Next;
                copyCurrent = copyCurrent.Next;
            }
            current.Next = current.Next.Next;   // Needed when the the list has just one node.

            return copyHead;
        }

        /// Copies just the list without the random pointer
        //public static RandomListNode CopyList(RandomListNode head)
        //{
        //    RandomListNode origDummyHead = new RandomListNode(0);
        //    origDummyHead.Next = head;
        //    RandomListNode origCurrent = head;

        //    RandomListNode copyDummyHead = new RandomListNode(0);
        //    RandomListNode copyCurrent = copyDummyHead;

        //    while(origCurrent != null)
        //    {
        //        copyCurrent.Next = new RandomListNode(origCurrent.Label);

        //        origCurrent = origCurrent.Next;
        //        copyCurrent = copyCurrent.Next;
        //    }

        //    return copyDummyHead.Next;
        //}
    }
}
