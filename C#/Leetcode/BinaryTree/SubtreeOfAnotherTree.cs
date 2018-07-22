using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 572
    // Submission Details: https://leetcode.com/submissions/detail/165071916/
    public class SubtreeOfAnotherTree
    {
        public bool IsSubtree(BinaryTreeNode s, BinaryTreeNode t)
        {
            if (s == null) return false;

            if (IsSameTree(s, t)) return true;

            return IsSubtree(s.Left, t) || IsSubtree(s.Right, t);
        }

        private bool IsSameTree(BinaryTreeNode p, BinaryTreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null || p.Val != q.Val) return false;

            return IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right);
        }

        // Failed for duplicate values in s tree. Example: s = [1,1], t = 1
        //     public bool IsSubtree(BinaryTreeNode s, BinaryTreeNode t) {
        //         if(t == null && (s == null || s != null)) return true;

        //         BinaryTreeNode sRoot_t = FindSTRoot(s, t.Val);

        //         if(sRoot_t != null)
        //             return IsSameTree(sRoot_t, t);

        //         return false;        
        //     }

        //     private BinaryTreeNode FindSTRoot(BinaryTreeNode s, int t_val)
        //     {
        //         if(s == null) return null;
        //         if(s.Val == t_val) return s;

        //         BinaryTreeNode Left = FindSTRoot(s.Left, t_val);

        //         if(Left != null)
        //             return Left;

        //         return FindSTRoot(s.Right, t_val);
        //     }
    }
}
