using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 617
    // Submission Detail: https://leetcode.com/submissions/detail/129120557/
    public class MergeTwoBinaryTrees
    {
        // Runtime = 212 ms
        // Tx = O(n)
        // Sx = O(n) for the recursive call stack
        public BinaryTreeNode MergeTrees(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            if (t1 == null && t2 == null)    // leaf node
                return null;
            else if (t1 == null)
                t1 = new BinaryTreeNode(t2.Val);
            else if (t1 != null && t2 != null)
                t1.Val += t2.Val;

            t1.Left = MergeTrees(t1.Left, t2?.Left);
            t1.Right = MergeTrees(t1.Right, t2?.Right);

            return t1;
        }
    }
}
