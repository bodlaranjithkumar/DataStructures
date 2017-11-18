using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 141
    class LinkedListCycle
    {
        // Runtime = 146 ms
        // Tx = O(n)
        // Sx = O(1)
        // Slow runner and fast runner technique.
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (slow != null && fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                    return true;
            }

            return false;
        }
    }
}
