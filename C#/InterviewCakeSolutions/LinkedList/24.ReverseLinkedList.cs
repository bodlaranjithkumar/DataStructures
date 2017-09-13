using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.LinkedList
{
    class LinkedList
    {
        //Input:  1 -> 2 -> 3 -> 4 -> 5
        //Output: 5 -> 4 -> 3 -> 2 -> 1

        public void ReverseLinkedListInPlace(LinkedListNode node)
        {
            LinkedListNode previous = null;
            LinkedListNode nextNode = null;
            LinkedListNode current = node;

            while (current != null)
            {
                nextNode = current.Next;

                current.Next = previous;

                previous = current;

                current = nextNode;
            }
        }
    }
}
