using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 141 - https://leetcode.com/problems/linked-list-cycle/
    // Submission Detail - https://leetcode.com/submissions/detail/142760194/
    // Slow runner and fast runner technique.

    public class LinkedListCycle
    {
        // Runtime = 146 ms
        // Tx = O(n)
        // Sx = O(1)        
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.Next != null)
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
