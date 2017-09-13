using System;

namespace InterviewCakeSolutions.LinkedList
{    
    public class KthToLastNode
    {
		//public static void Main(string[] args)
  //      {
  //          var a = new LinkedListNode(1);
  //          var b = new LinkedListNode(2);
  //          var c = new LinkedListNode(3);
  //          var d = new LinkedListNode(4);
  //          var e = new LinkedListNode(5);

  //          a.Next = b;
  //          b.Next = c;
  //          c.Next = d;
  //          d.Next = e;

  //          KthToLastNode linkedList = new KthToLastNode();
  //          int k = 2;

  //          LinkedListNode kthToLastNode = linkedList.FindKthToLastNode(k, a);

  //          // Returns the node with value 4 (the 2nd to last node)
  //          Console.WriteLine($"{k} nd/rd/th last node is {kthToLastNode.Value}");
  //          Console.ReadKey();
  //      }

		public LinkedListNode FindKthToLastNode(int k, LinkedListNode head)
        {
            LinkedListNode slower = head;
            LinkedListNode faster = head;

            int count = 1;

			while(count != k && faster != null)
            {
                faster = faster.Next;

                // Reached end of the list before reaching the kth index.
                if (faster == null)
                    throw new ArgumentOutOfRangeException(nameof(k), "Given index is out of range");

                count++;                
            }

            // Faster.Next is required to void runtime exception when faster is set to null after exiting above while loop.
            while (faster != null && faster.Next != null) 
            {
                slower = slower.Next;
                faster = faster.Next;
            }

            return slower;
        }
    }
}
