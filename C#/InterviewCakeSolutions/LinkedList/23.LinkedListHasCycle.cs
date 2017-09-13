using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.LinkedList
{
    public class LinkedListNode
    {
        public int Value { get; set; }

        public LinkedListNode Next { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }
    }

    class Cycle
    {
        //public static void Main(string[] args)
        //{
        //    LinkedListNode head = new LinkedListNode(1);
        //    LinkedListNode startOfCycle = new LinkedListNode(2);
        //    head.Next = startOfCycle;
        //    startOfCycle.Next = new LinkedListNode(3);
        //    startOfCycle.Next.Next = new LinkedListNode(4);
        //    startOfCycle.Next.Next.Next = new LinkedListNode(5);
        //    startOfCycle.Next.Next.Next.Next = startOfCycle;

        //    Cycle cycle = new Cycle();

        //    Console.WriteLine($"Cycle Exists? : {cycle.ContainsCycle(head)}");
        //    Console.ReadKey();
        //}

        public bool ContainsCycle(LinkedListNode head)
        {

            LinkedListNode slower = head;
            LinkedListNode faster = head;

            while (faster != null && faster.Next != null)
            {
                slower = slower.Next;
                faster = faster.Next.Next;

                if (slower == faster)
                    return true;
            }           

            return false;
        }
    }
}
