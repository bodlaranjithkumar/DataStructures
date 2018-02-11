using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 404
    public class SumOfLeftLeaves
    {
        // Tx = O(n)
        // Sx = O(d)
        public int CalculateSumOfLeftLeaves(BinaryTreeNode node)
        {
            if (node == null) return 0;

            int sum = 0;
            if (node.Left != null)
            {
                if (node.Left.Left == null && node.Left.Right == null)
                    sum += node.Left.Val;
                else
                    sum += CalculateSumOfLeftLeaves(node.Left);
            }

            sum += CalculateSumOfLeftLeaves(node.Right);

            return sum;
        }
    }
}
