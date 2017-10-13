using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions
{
    public class Helper
    {
        public static void PrintArray(int[] result)
        {
            foreach (var val in result)
            {
                Console.Write($"{val}\t");
            }
        }

        public static void Print<T>(T val)
        {
            Console.WriteLine($"{val}");
        }

        public static ListNode CreateListNode(int[] values)
        {
            ListNode head = new ListNode(0);
            ListNode node = head;

            foreach(var val in values)
            {
                node.Next = new ListNode(val);
                node = node.Next;                
            }

            return head.Next;
        }

        public static void PrintListNodes(ListNode head)
        {
            while (head != null)
            {
                Console.WriteLine($"{head.Val} \t");
                head = head.Next;
            }
        }
    }
}
