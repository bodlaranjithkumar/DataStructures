using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.LinkedList
{
    class LinkedListDeleteNode
    {
        //public static void Main(string[] args)
        //{
        //    var a = new LinkedListNode(1);
        //    var b = new LinkedListNode(2);
        //    var c = new LinkedListNode(3);

        //    a.Next = b;
        //    b.Next = c;

        //    LinkedListDeleteNode linkedList = new LinkedListDeleteNode();
        //    c = linkedList.DeleteNode(c);

        //    Console.WriteLine(b.Next.Value);

        //    Console.ReadKey();
        //}

        public LinkedListNode DeleteNode(LinkedListNode node)
        {
            if (node == null)
                throw new ArgumentNullException("input is empty.");

            if (node.Next != null)
            {
                node.Value = node.Next.Value;
                node.Next = node.Next.Next;
            }
            else
            {
                // This is the last node. Assigning the value null to the node doesn't change the next pointer value of the 2nd last node. 
                // We can consider throwing error instead of assigning null value.
                node = null;
            }

            return node;
        }
    }
}
