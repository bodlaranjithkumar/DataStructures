using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 669

    // Submission Detail: https://leetcode.com/submissions/detail/154047945/
    public class TrimBST
    {
        public BinaryTreeNode TrimBSTRange(BinaryTreeNode root, int L, int R)
        {
            if (root == null) return root;
            else if (root.Val > R) return TrimBSTRange(root.Left, L, R); // Go Left
            else if (root.Val < L) return TrimBSTRange(root.Right, L, R); // Go Right

            root.Left = TrimBSTRange(root.Left, L, R);
            root.Right = TrimBSTRange(root.Right, L, R);
            return root;
        }
    }
}
