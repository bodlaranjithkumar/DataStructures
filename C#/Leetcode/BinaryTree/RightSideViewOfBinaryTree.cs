using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 199
    // Submission Detail: https://leetcode.com/submissions/detail/169375206/

    public class RightSideViewOfBinaryTree
    {
        // Tx = O(n) {n: # of nodes in the tree}
        // Sx = O(m) {m: max nodes at a level. This is the #of nodes at last level in case the tree is a complete binary tree}

        // Breadth-First Traversal
        // Idea: Extension/Modification of level-order traversal of a binary tree problem. If node values are enqueued to a queue from Left to Right, the last node in the queue is after dequeue is the node on the Right side view for that level. 

        public IList<int> RightSideView(BinaryTreeNode root)
        {
            IList<int> rightSideValues = new List<int>();
            Queue<BinaryTreeNode> nodes = new Queue<BinaryTreeNode>();

            if (root != null)
                nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                int count = nodes.Count;

                while (count > 0)
                {
                    if (count == 1)   // Since then nodes are enqueued from L -> R. The last node at current level is the Right most node
                        rightSideValues.Add(nodes.Peek().Val);

                    BinaryTreeNode node = nodes.Dequeue();

                    if (node.Left != null)
                        nodes.Enqueue(node.Left);

                    if (node.Right != null)
                        nodes.Enqueue(node.Right);

                    count--;
                }
            }

            return rightSideValues;
        }
    }
}
