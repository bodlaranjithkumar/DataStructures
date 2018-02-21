using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 98
    // Submission Detail: https://leetcode.com/submissions/detail/141736401/
    public class BinaryTreeIsBST
    {
        // Method 1
        // Tx = O(n)
        // Sx = O(d)
        // Note: Left node's value shouldn't be equal to root's value.
        public bool IsValidBST(BinaryTreeNode root)
        {
            return IsValidBST(root, null, null);
        }

        public bool IsValidBST(BinaryTreeNode root, BinaryTreeNode min, BinaryTreeNode max)
        {
            if (root == null) return true;

            return (min == null || root.Val > min.Val)
                    && (max == null || root.Val < max.Val)
                    && IsValidBST(root.Left, min, root)
                    && IsValidBST(root.Right, root, max);
        }

        // Method 2
        // Fails for the case of :[ int.MIN_VALUE , null , int.MAX_VALUE ]
        public bool IsBST(BinaryTreeNode root)
        {
            return IsBST(root, int.MinValue, int.MaxValue);
        }

        private bool IsBST(BinaryTreeNode node, int min, int max)
        {
            if (node == null)
                return true;

            return node.Val <= max 
                    && node.Val > min
                    && IsBST(node.Left, min, node.Val)
                    && IsBST(node.Right, node.Val, max);
        }
    }
}
