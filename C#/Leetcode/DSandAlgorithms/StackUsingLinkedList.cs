using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.DSandAlgorithms
{
    public class StackUsingLinkedList
    {
        ListNode head;
        int count = 0;

        public void Push(int item)
        {
            ListNode newHead = new ListNode(item);

            if (count == 0)
            {
                head = newHead;
            }
            else
            {
                newHead.Next = head;
                head = newHead;
            }

            count++;
        }
       
        public int Pop()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is Empty.");

            var popNode = head;
            head = head.Next;

            count--;

            return popNode.Val;
        }

        public int Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is Empty.");

            return head.Val;
        }
    }
}
