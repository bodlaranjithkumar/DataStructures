package LinkedList;

import DataStructures.ListNode;

public class MaximumTwinSumofaLinkedList {
    // Leetcode 2130: https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/description/
    // Submission Detail: https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/submissions/1673093653

    //Input: head = [5,4,2,1]
    //Output: 6
    //Explanation:
    //Nodes 0 and 1 are the twins of nodes 3 and 2, respectively. All have twin sum = 6.
    //There are no other nodes with twins in the linked list.
    //        Thus, the maximum twin sum of the linked list is 6.

    //Input: head = [4,2,2,3]
    //Output: 7
    //Explanation:
    //The nodes with twins present in this linked list are:
    //        - Node 0 is the twin of node 3 having a twin sum of 4 + 3 = 7.
    //        - Node 1 is the twin of node 2 having a twin sum of 2 + 2 = 4.
    //Thus, the maximum twin sum of the linked list is max(7, 4) = 7.

    //Input: head = [1,100000]
    //Output: 100001
    //Explanation:
    //There is only one node with a twin in the linked list having twin sum of 1 + 100000 = 100001.

    public int pairSum(ListNode head) {
        ListNode dummyNode = new ListNode(0, head), slow = dummyNode, fast = dummyNode;

        // Step 1: Identify the middle node of the linked list
        while(fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        // Step 2: Reverse the second half of the list
        ListNode prev = null, curr = slow;
        while(curr != null) {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        //Step 3: Calculate the sum of twin nodes and track the maximum
        ListNode reverseHeadNode = prev, node = head;
        int maxTwinSum = 0;
        while(reverseHeadNode != null && node != null) {
            int currentTwinSum = reverseHeadNode.val + node.val;
            maxTwinSum = Math.max(maxTwinSum, currentTwinSum);

            reverseHeadNode = reverseHeadNode.next;
            node = node.next;
        }

        return maxTwinSum;
    }
}
