using LeetcodeSolutions.DataStructures;
using sys = System;
using System.Collections.Generic;

namespace LeetcodeSolutions.BinaryTree
{
    public class MaximumDepthOfBinaryTree
    {
        // Solution 1: Recursive with depth returned from leaf node with increment of 1 while traversing to root.
        // Runtime: 156 ms
        // Tx = O(n) {n: n is the number of nodes in the binary tree}
        // Sx = O(n) for call stack
        public int MaxDepthRecursiveOptimized(BinaryTreeNode root)
        {
            return root == null ? 0 : 1 + sys.Math.Max(MaxDepthRecursiveOptimized(root.Left), MaxDepthRecursiveOptimized(root.Right));
        }

        // Solution 2: Recursive with depth computed from root to leaf.
        public int MaxDepth(BinaryTreeNode root)
        {
            return root == null ? 0 : MaxDepth(root, 1);
        }

        // Runtime : 172ms
        // Tx = O(n) {n: n is the number of nodes in the binary tree}
        // Sx = O(n) for call stack
        public int MaxDepth(BinaryTreeNode node, int depth)
        {
            // Base Case
            if (node == null || (node.Left == null && node.Right == null))
            {
                return depth;
            }

            // Recursive Case
            return sys.Math.Max(MaxDepth(node.Left, depth + 1), MaxDepth(node.Right, depth + 1));
        }

        // Solution 3: Depth First Traversal using Iterative approach
        public class DepthTreeNode
        {
            public BinaryTreeNode node;
            public int depth;
        }

        public int MaxDepthIterative(BinaryTreeNode root)
        {
            DepthTreeNode rootNode = new DepthTreeNode()
            {
                node = root,
                depth = 1
            };

            return MaxDepthIterative(rootNode);
        }

        // Runtime : 176ms
        // Tx = O(n) {n: n is the number of nodes in the binary tree}
        // Sx = O(2*n) for new binarytreenode and stack
        public int MaxDepthIterative(DepthTreeNode root)
        {
            if (root.node == null)
            {
                return root.depth - 1;
            }

            Stack<DepthTreeNode> depthNodes = new Stack<DepthTreeNode>();
            depthNodes.Push(root);

            int maxDepth = 0;

            while (depthNodes.Count > 0)
            {
                var depthNode = depthNodes.Pop();

                maxDepth = sys.Math.Max(depthNode.depth, maxDepth);

                if (depthNode.node.Left != null)
                {
                    depthNodes.Push(new DepthTreeNode() { node = depthNode.node.Left, depth = depthNode.depth + 1 });
                }

                if (depthNode.node.Right != null)
                {
                    depthNodes.Push(new DepthTreeNode() { node = depthNode.node.Right, depth = depthNode.depth + 1 });
                }
            }

            return maxDepth;
        }
    }
}
