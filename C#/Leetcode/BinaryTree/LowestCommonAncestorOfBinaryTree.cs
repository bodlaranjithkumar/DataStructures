using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 236 - https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
    // submission detail: https://leetcode.com/submissions/detail/168752862/
    // ref: https://www.youtube.com/watch?v=13m9ZCB8gjw

    public class LowestCommonAncestorOfBinaryTree
    {
        //      _______3______
        //     /              \
        //  ___5__          ___1__
        // /      \        /      \
        // 6      _2       0       8
        //       /  \
        //       7   4

        // Tx: O(n)
        // Sx: O(d)
        public BinaryTreeNode LowestCommonAncestor(BinaryTreeNode root, BinaryTreeNode p, BinaryTreeNode q)
        {
            if (root == null || root == p || root == q) return root;

            BinaryTreeNode left = LowestCommonAncestor(root.Left, p, q);
            BinaryTreeNode right = LowestCommonAncestor(root.Right, p, q);

            if (left != null && right != null) return root;
            if (left == null && right == null) return null;
            return left ?? right;
        }


        // Explanation: Given root node recursively call the left and right sub trees.
        //              if the root node is either equal to p or q, then it is not required to check
        //              it's sub tree since if the 2nd node exists in it's subtrees, LCA is the root node.
        //              So, instead check rest of the other subtrees to make sure that the other
        //              node doesn't exist in that.

        // Tx = O(n)
        // Sx = O(d) for recursive call stack
        public BinaryTreeNode LowestCommonAncestor1(BinaryTreeNode root, BinaryTreeNode p, BinaryTreeNode q)
        {
            if (root == null || root == p || root == q)
                return null;

            BinaryTreeNode left = LowestCommonAncestor1(root.Left, p, q);
            BinaryTreeNode right = LowestCommonAncestor1(root.Right, p, q);

            return left != null && right != null
                        ? root :
                        left ?? right;
        }
    }
}
