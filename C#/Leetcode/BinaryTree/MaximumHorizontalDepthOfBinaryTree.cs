using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 662 - https://leetcode.com/problems/maximum-width-of-binary-tree/
    // Submission Detail - https://leetcode.com/submissions/detail/169779901/

    public class MaximumHorizontalDepthOfBinaryTree
    {
        // Tx = O(n)
        // Sx = O(n)
 
        // Solution 1: BFS. Follow's level order traversal. Cleaner Code.
        // Left node's position is current node's positions*2 and right is *2+1
        public int WidthOfBinaryTree(TreeNode root)
        {
            int result = 1;
            
            Queue<QueueNode> queue = new Queue<QueueNode>();
            queue.Enqueue(new QueueNode(root, 0));

            while(queue.Count > 0)
            {
                int count = queue.Count, first = queue.Peek().position, last = first;

                for (int i = 0; i < count; i++)
                {
                    var top = queue.Dequeue();
                    last = top.position; // this will be set to the last node in the current level at final ith index.

                    if(top.node.left != null)
                        queue.Enqueue(new QueueNode(top.node.left, 2 * top.position));

                    if(top.node.right != null)
                        queue.Enqueue(new QueueNode(top.node.right, 2 * top.position + 1));    
                }
                result = Math.Max(result, last - first +  1);
            }


            return result;
        }

        private class QueueNode
        {
            public TreeNode node;
            public int position;
            public QueueNode(TreeNode node, int position)
            {
                this.node = node;
                this.position = position;
            }
        }

        // Solution 2: BFS
        // Algorithm: Since the given tree is a binary tree, for the 
        //  current level and for the current node, it's left child node 
        //  position is the current node position*2 and right child node 
        //  position is current node position*2+1. With this observation,
        //  the depth at current level is the rightmost node's 
        //  position-left most node's position+1. Left value is set  
        //  when the first node in a given level is visited.
        //  Hold the depth, position for a node, a custom 
        //  datastructure is needed with the properties - node, depth, position.
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

                    // This is to get the first left most node's position for the current depth/level.
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
