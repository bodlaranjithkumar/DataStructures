using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 173
    // Submission Detail: https://leetcode.com/submissions/detail/137909876/
    // Inorder traversal, stack
    public class BinarySearchTreeIterator
    {
        Stack<BinaryTreeNode> nodes;

        public BinarySearchTreeIterator(BinaryTreeNode root)
        {
            nodes = new Stack<BinaryTreeNode>();
            PushNodes(root);
        }

        // Tx = O(1)
        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return nodes.Count > 0;
        }

        // Tx = O(h)
        /** @return the next smallest number */
        public int Next()
        {
            BinaryTreeNode node = nodes.Pop();

            // Push all the left nodes of the right subtree to the stack.
            PushNodes(node.Right);

            return node.Val;
        }

        private void PushNodes(BinaryTreeNode node)
        {
            while (node != null)
            {
                nodes.Push(node);
                node = node.Left;
            }
        }
    }
}
