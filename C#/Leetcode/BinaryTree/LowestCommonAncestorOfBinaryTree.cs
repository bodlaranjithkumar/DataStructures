using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 236
    class LowestCommonAncestorOfBinaryTree
    {
        //      _______3______
        //     /              \
        //  ___5__          ___1__
        // /      \        /      \
        // 6      _2       0       8
        //       /  \
        //       7   4
         
        // Explanation: Given root node recursively call the left and right sub trees.
        //              if the root node is either equal to p or q, then it is not required to check
        //              it's sub tree since if the 2nd node exists in it's subtrees, LCA is the root node.
        //              So, instead check rest of the other subtrees to make sure that the other
        //              node doesn't exist in that.
        
            // Tx = O(n)
        // Sx = O(n) for recursive call stack
        public BinaryTreeNode LowestCommonAncestor(BinaryTreeNode root, BinaryTreeNode p, BinaryTreeNode q)
        {
            if (root == null || root == p || root == q)
                return null;

            BinaryTreeNode left = LowestCommonAncestor(root.Left, p, q);
            BinaryTreeNode right = LowestCommonAncestor(root.Right, p, q);

            return left != null && right != null
                        ? root :
                        left ?? right;
        }
    }
}
