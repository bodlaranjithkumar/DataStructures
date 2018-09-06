using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 101 - https://leetcode.com/problems/symmetric-tree/
    // Submission Detail - https://leetcode.com/submissions/detail/171708245/

    public class SymmetricTree
    {
        public bool IsSymmetric(BinaryTreeNode root)
        {
            if (root == null)
                return true;

            return IsSymmetric(root.Left, root.Right);
        }

        public bool IsSymmetric(BinaryTreeNode root1, BinaryTreeNode root2)
        {
            if (root1 == null && root2 == null) return true;
            else if (root1 == null || root2 == null || root1.Val != root2.Val) return false;

            return IsSymmetric(root1.Left, root2.Right) && IsSymmetric(root1.Right, root2.Left);

            //bool leftRight = IsSymmetric(root1.Left, root2.Right);
            //bool rightLeft = IsSymmetric(root1.Right, root2.Left);

            //return leftRight && rightLeft;
        }
    }
}
