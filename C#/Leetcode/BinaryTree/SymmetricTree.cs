using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 101
    // Submission Detail: https://leetcode.com/submissions/detail/162824216/

    public class SymmetricTree
    {
        public bool IsSymmetric(BinaryTreeNode root)
        {
            if (root == null) return true;

            return IsSymmetric(root.Left, root.Right);
        }

        public bool IsSymmetric(BinaryTreeNode root1, BinaryTreeNode root2)
        {
            if (root1 == null && root2 == null) return true;
            else if (root1 == null || root2 == null) return false;
            else if (root1.Val != root2.Val) return false;

            bool leftRight = IsSymmetric(root1.Left, root2.Right);
            bool rightLeft = IsSymmetric(root1.Right, root2.Left);

            return leftRight && rightLeft;
            //return IsSymmetric(root1.Left, root2.Right) && IsSymmetric(root1.Right, root2.Left);
        }
    }
}
