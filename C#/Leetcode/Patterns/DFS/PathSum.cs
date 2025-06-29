﻿using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.Patterns.DFS
{
    // Leetcode 112 - https://leetcode.com/problems/path-sum/description/
    // Submission Detail - https://leetcode.com/submissions/detail/141729452/

    public class PathSum
    {
        // Tx = O(n)
        // Sx = O(d)    // for call stack
        public bool HasPathSum(BinaryTreeNode root, int sum)
        {
            if (root == null) return false;
            if (root.Left == null && root.Right == null) return root.Val == sum;

            return HasPathSum(root.Left, sum - root.Val) || HasPathSum(root.Right, sum - root.Val);
        }
    }
}
