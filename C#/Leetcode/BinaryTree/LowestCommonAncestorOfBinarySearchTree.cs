using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 235
    class LowestCommonAncestorOfBinarySearchTree
    {
        // Runtime = 209 ms
        // Tx = O(h) {h: height of the BST}
        // Sx = O(1)
        // Assumption : p,q nodes exists in the BST.
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
                return LowestCommonAncestorRecursive(root.Right,p,q);
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
