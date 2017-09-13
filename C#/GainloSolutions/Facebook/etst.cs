using System;
using System.Collections.Generic;
using System.Text;

namespace GainloSolutions.Facebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node();
            node1.Data = "Lion";
            Node node2 = new Node();
            node2.Data = "Tiger";
            Node node3 = new Node();
            node3.Data = "Cat";
            Node node4 = new Node();
            node4.Data = "Dog";

            //MyLinkedList myLinkedList = new MyLinkedList();

            //myLinkedList.AddFirst(node1);
            //myLinkedList.AddLast(node2);
            //myLinkedList.AddFirst(node3);
            //myLinkedList.AddLast(node4);

            //myLinkedList.RemoveFirst();
            //myLinkedList.RemoveLast();
            //myLinkedList.RemoveFirst();
            //myLinkedList.RemoveLast();



            MyLinkedList stackLinkedList = new MyLinkedList();
            MyLinkedList queueLinkedList = new MyLinkedList();

            // stack operations
            MyStack myStack = new MyStack();

            myStack.Push(stackLinkedList, node1);
            myStack.Push(stackLinkedList, node2);
            myStack.Push(stackLinkedList, node3);
            myStack.Push(stackLinkedList, node4);
            myStack.Pop(stackLinkedList);
            myStack.Peek(stackLinkedList);

            //Queue operations

            MyQueue myQueue = new MyQueue();
            myQueue.EnQueue(queueLinkedList, node1);
            myQueue.EnQueue(queueLinkedList, node2);
            myQueue.EnQueue(queueLinkedList, node3);
            myQueue.EnQueue(queueLinkedList, node4);
            myQueue.DeQueue(queueLinkedList);
            myQueue.Peek(queueLinkedList);

        }
    }
    public class Node
    {
        public string Data { get; set; }

        public Node Next { get; set; }
    }

    public class MyLinkedList
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int NodeCount { get; set; }

        public void AddFirst(Node node)
        {
            if (NodeCount == 0)
            {
                Head = node;
                Tail = node;
                NodeCount++;
            }
            else
            {
                var temp = Head;
                Head = node;
                Head.Next = temp;

                NodeCount++;
            }
        }
        public void AddLast(Node node)
        {
            if (NodeCount == 0)
            {
                Head = node;
                Tail = node;
                NodeCount++;
            }
            else
            {
                Tail.Next = node;
                Tail = Tail.Next;
                NodeCount++;
            }
        }
        public void RemoveFirst()
        {
            if (NodeCount == 0)
            {
                throw new Exception("No nodes in linkedlist to remove");
            }
            else if (NodeCount == 1)
            {
                Head = null;
                Tail = null;
                NodeCount--;
            }
            else
            {
                Head = Head.Next;
                NodeCount--;
            }

        }
        public void RemoveLast()
        {
            if (NodeCount == 0)
            {
                throw new Exception("No Nodes in linkedlist to remove");
            }
            else if (NodeCount == 1)
            {
                Head = null;
                Tail = null;
                NodeCount--;
            }
            else
            {
                var temp2 = Head;

                while (temp2.Next != Tail)
                {
                    temp2 = temp2.Next;
                }
                Tail = temp2;
                Tail.Next = null;
                NodeCount--;
            }

        }

    }
    class MyStack
    {
        public void Push(MyLinkedList linked, Node node)
        {
            linked.AddFirst(node);// for stack second inserted element will store the address of the first so we need to add first to linkedlist
        }
        public void Pop(MyLinkedList linked)
        {
            linked.RemoveFirst();
        }
        public void Peek(MyLinkedList linked)
        {
            var firstnode = linked.Head.Data;
        }
    }

    public class MyQueue
    {
        public void EnQueue(MyLinkedList linked, Node node)
        {
            linked.AddLast(node);
        }
        public void DeQueue(MyLinkedList linked)
        {
            linked.RemoveLast();
        }
        public void Peek(MyLinkedList linked)
        {
            var firstnode = linked.Tail.Data;

        }
    }
}
