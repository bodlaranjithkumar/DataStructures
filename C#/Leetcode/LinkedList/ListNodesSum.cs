using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.LinkedList
{
    class ListNodesSum
    {
        //static void Main(string[] args)
        //{
        //    //ListNodesSum listNodesSum = new ListNodesSum();

        //    //ListNode node1 = Helper.CreateListNode(new int[] { 2, 4, 3 });
        //    //ListNode node2 = Helper.CreateListNode(new int[] { 5, 6, 4 });

        //    //// Expected Output : 7  ->  0   ->  8
        //    //Helper.PrintListNodes(listNodesSum.AddTwoNumbers(node1, node2));

        //    //ListNode node3 = Helper.CreateListNode(new int[] { 2, 4, 3 });
        //    //ListNode node4 = Helper.CreateListNode(new int[] { 5 });

        //    //// Expected Output : 7  ->  4  ->  3
        //    //Helper.PrintListNodes(listNodesSum.AddTwoNumbers(node3, node4));

        //    //ListNode node5 = Helper.CreateListNode(new int[] { 5 });
        //    //ListNode node6 = Helper.CreateListNode(new int[] { 5 });

        //    //// Expected Output : 0  ->  1
        //    //Helper.PrintListNodes(listNodesSum.AddTwoNumbers(node5, node6));

        //    //ListNode node7 = Helper.CreateListNode(new int[] { 1 });
        //    //ListNode node8 = Helper.CreateListNode(new int[] { 9, 9 });

        //    //// Expected Output : 0  ->  0   ->  1
        //    //Helper.PrintListNodes(listNodesSum.AddTwoNumbers(node7, node8));

        //    Console.ReadLine();
        //}

        // Runtime : 192 ms
        // Tx = O(max(m,n)) { m: size of l1, n: size of l2}
        // Sx = O(max(m,n))
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode sumNode = new ListNode(0);
            ListNode currentNode = sumNode;
            int carryOver = 0, sum = 0;

            while (l1 != null || l2 != null)
            {
                int val1 = l1 != null ? l1.Val : 0;
                int val2 = l2 != null ? l2.Val : 0;

                sum = carryOver + val1 + val2;
                carryOver = sum / 10;
                currentNode.Next = new ListNode(sum % 10);
                currentNode = currentNode.Next;
                
                l1 = l1 != null ? l1.Next : l1;
                l2 = l2 != null ? l2.Next : l2;
            }

            if (carryOver > 0)
            {
                currentNode.Next = new ListNode(carryOver);
            }

            return sumNode.Next;
        }
    }
}
