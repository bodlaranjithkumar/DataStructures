using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Algorithms
{
    public class QueueUsingLinkedList
    {
        ListNode front;
        ListNode rear;

        int count = 0;

        public void Enqueue(int item)
        {
            ListNode newRear = new ListNode(item);

            if (rear == null)
            {
                front = newRear;
                rear = newRear;
            }
            else
            {
                rear.Next = newRear;
                rear = rear.Next;
            }

            count++;
        }

        public int Dequeue()
        {
            if (front == null)
                throw new InvalidOperationException("Queue is Empty.");

            ListNode dequeueNode = front;
            front = front.Next;

            // If the queue is empty update rear to null
            if (front == null)
                rear = null;

            count--;

            return dequeueNode.Val;
        }
        
        public int Peek()
        {
            if (front == null)
                throw new InvalidOperationException("Queue is Empty.");

            return front.Val;
        }
    }
}
