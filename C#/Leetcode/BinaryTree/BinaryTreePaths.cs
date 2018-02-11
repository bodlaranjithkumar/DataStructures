using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 257
    // Depth-First Traversal
    public class BinaryTreePaths
    {
        public IList<string> FindBinaryTreePaths(BinaryTreeNode root)
        {
            IList<string> result = new List<string>();
            if (root != null) Helper(root, result, "");

            return result;
        }

        // The key is to use a string instead of string builder to avoid addition and deletion of value, arrow.
        // Tx = O(n)
        // Sx = O(n + d)
        private void Helper(BinaryTreeNode node, IList<string> result, string sb)
        {
            if (node.Left == null && node.Right == null) result.Add(sb.ToString() + node.Val);
            if (node.Left != null) Helper(node.Left, result, sb + node.Val + "->");
            if (node.Right != null) Helper(node.Right, result, sb + node.Val + "->");
        }
    }
}
