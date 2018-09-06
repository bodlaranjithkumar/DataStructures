using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 100 - https://leetcode.com/problems/same-tree/
    // Submission Detail - https://leetcode.com/submissions/detail/165059153/

    public class SameTree
    {
        public bool IsSameTree(BinaryTreeNode p, BinaryTreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null || p.Val != q.Val) return false;

            return IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right);
        }
    }
}
