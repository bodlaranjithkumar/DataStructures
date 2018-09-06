using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 235 - https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
    // Submission Detail - https://leetcode.com/submissions/detail/128927057/

    public class LowestCommonAncestorOfBinarySearchTree
    {
        //      _______10_____
        //     /              \
        //  ___5__          ___13__
        // /      \        /       \
        // 3       7      11        18
        //        / \
        //        6  8

        // Runtime = 209 ms
        // Tx = O(h) {h: height of the BST}
        // Sx = O(1)
        // Assumption : p,q nodes exist in the BST.

        public BinaryTreeNode LowestCommonAncestor(BinaryTreeNode root, BinaryTreeNode p, BinaryTreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;

            while (true)
            {
                if (root.Val < p.Val && root.Val < q.Val)
                {
                    root = root.Right;
                }
                else if (root.Val > p.Val && root.Val > q.Val)
                {
                    root = root.Left;
                }
                else
                {
                    return root;
                }
            }
        }

        // Tx = O(h)
        // Sx = O(h) {for call stack}
        public BinaryTreeNode LowestCommonAncestorRecursive(BinaryTreeNode root, BinaryTreeNode p, BinaryTreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;

            if (root.Val < p.Val && root.Val < q.Val)
            {
                return LowestCommonAncestorRecursive(root.Right, p, q);
            }
            else if (root.Val > p.Val && root.Val > q.Val)
            {
                return LowestCommonAncestorRecursive(root.Left, p, q);
            }
            else
            {
                return root;
            }
        }
    }
}
