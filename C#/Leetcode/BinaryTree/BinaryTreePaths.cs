using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 257 - https://leetcode.com/problems/binary-tree-paths/
    // Submission Detail - https://leetcode.com/submissions/detail/140351424/
    // Depth-First Traversal

    public class BinaryTreePaths
    {
        IList<string> result = new List<string>();

        public IList<string> FindBinaryTreePaths(BinaryTreeNode root)
        {
            if (root != null)
                Helper(root, "");

            return result;
        }

        // Use a string instead of string builder to avoid addition and deletion of value, arrow.
        // Tx = O(n)
        // Sx = O(n + d)
        private void Helper(BinaryTreeNode node, string str)
        {
            // Base Condition - Leaf Node. Add to the list.
            if (node.Left == null && node.Right == null)
                result.Add(str.ToString() + node.Val);

            if (node.Left != null)
                Helper(node.Left, str + node.Val + "->");

            if (node.Right != null)
                Helper(node.Right, str + node.Val + "->");
        }
    }
}
