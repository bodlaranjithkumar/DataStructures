﻿using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 543
    public class DiameterOfABinaryTree
    {
        private int MaxDiameter = 0;

        // Tx = O(n)
        // Sx = O(d) for the recursive call stack
        public int DiameterOfBinaryTree(BinaryTreeNode root)
        {
            Helper(root);

            return MaxDiameter;
        }

        private int Helper(BinaryTreeNode root)
        {
            if (root == null)
                return 0;

            int leftMaxDepth = Helper(root.Left);
            int rightMaxDepth = Helper(root.Right);

            MaxDiameter = System.Math.Max(MaxDiameter, leftMaxDepth + rightMaxDepth);

            return 1 + System.Math.Max(leftMaxDepth, rightMaxDepth);
        }
    }
}
