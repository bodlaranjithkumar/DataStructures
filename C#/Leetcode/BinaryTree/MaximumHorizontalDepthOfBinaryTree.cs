using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 662
    // Submission Detail: https://leetcode.com/submissions/detail/169779901/
    public class MaximumHorizontalDepthOfBinaryTree
    {
        // Tx = O(n)
        // Sx = O(n)

        // BFS
        // Idea: Since the given tree is a binary tree, for a given node it's left child node position is the 
        //          current node position*2 and right childe node position is current node position*2+1. 
        //          With this observation, the depth at current level is the rightmost node's 
        //          position-left most node position+1. left value is set when the first node in a given level is visited.
        //          To hold the depth, position for a node, a custom datastructure is needed with props - node, 
        //          depth, position.
        public int WidthOfBinaryTree(BinaryTreeNode root)
        {
            Queue<TreeNodeDepthPosition> nodes = new Queue<TreeNodeDepthPosition>();

            if (root != null)
                nodes.Enqueue(new TreeNodeDepthPosition(root, 0, 0));

            int currentDepth = 0, left = 0, maxDepth = 0;

            while (nodes.Count > 0)
            {
                TreeNodeDepthPosition tdNode = nodes.Dequeue();

                if (tdNode.node != null)
                {
                    nodes.Enqueue(new TreeNodeDepthPosition(tdNode.node.Left, tdNode.depth + 1, tdNode.position * 2));
                    nodes.Enqueue(new TreeNodeDepthPosition(tdNode.node.Right, tdNode.depth + 1, tdNode.position * 2 + 1));

                    if (tdNode.depth != currentDepth)
                    {
                        currentDepth = tdNode.depth;
                        left = tdNode.position;
                    }

                    maxDepth = System.Math.Max(maxDepth, tdNode.position - left + 1);
                }
            }

            return maxDepth;
        }

        private class TreeNodeDepthPosition
        {
            public readonly BinaryTreeNode node;
            public readonly int depth;
            public readonly int position;

            public TreeNodeDepthPosition(BinaryTreeNode Node, int Depth, int Position)
            {
                node = Node;
                depth = Depth;
                position = Position;
            }
        }
    }
}
