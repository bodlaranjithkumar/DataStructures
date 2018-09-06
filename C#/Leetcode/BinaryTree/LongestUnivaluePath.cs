using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 687 - https://leetcode.com/problems/longest-univalue-path
    // Submission Detail - https://leetcode.com/submissions/detail/142000453/
    // Based on the intuition from LCD-543 Diameter of a Binary Tree

    public class LongestUnivaluePath
    {
        private int maxLength;

        // Tx = O(n)
        // Sx = O(d) for call stack

        public int FindLongestUnivaluePath(BinaryTreeNode root)
        {
            if (root != null) 
                FindLongestUnivaluePath(root, root.Val);

            return maxLength;
        }

        public int FindLongestUnivaluePath(BinaryTreeNode node, int parentValue)
        {
            if (node == null) return 0;

            int left = FindLongestUnivaluePath(node.Left,  node.Val);
            int right = FindLongestUnivaluePath(node.Right, node.Val);

            maxLength = System.Math.Max(left + right, maxLength);

            return node.Val == parentValue ?  1 + System.Math.Max(left, right): 0;
        }
    }
}
