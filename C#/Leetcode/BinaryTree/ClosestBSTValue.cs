using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 270 - https://leetcode.com/problems/closest-binary-search-tree-value/description/
    // Submission Detail - https://leetcode.com/submissions/detail/185766978/

    //           20
    //          / \
    //         8   25
    //        / \    \
    //       4   12   35
    //           /\
    //         10  14

    // Input:   4   -> 4
    //          7   -> 8
    //          11  -> 12
    //          46  -> 35

    public class ClosestBSTValue
    {
        //public static void Main(string[] args)
        //{
        //    BinaryTreeNode root = new BinaryTreeNode(20)
        //    {
        //        Left = new BinaryTreeNode(8)
        //        {
        //            Left = new BinaryTreeNode(4),
        //            Right = new BinaryTreeNode(12)
        //            {
        //                Left = new BinaryTreeNode(10),
        //                Right = new BinaryTreeNode(14)
        //            }
        //        },
        //        Right = new BinaryTreeNode(25)
        //        {
        //            Right = new BinaryTreeNode(35)
        //        }
        //    };

        //    ClosestBSTValue closest = new ClosestBSTValue();
        //    Console.WriteLine(closest.ClosestValueOptimized(root, 4));
        //    Console.WriteLine(closest.ClosestValueOptimized(root, 7));
        //    Console.WriteLine(closest.ClosestValueOptimized(root, 11));
        //    Console.WriteLine(closest.ClosestValueOptimized(root, 46));

        //    Console.ReadKey();
        //}

        // Sx = O(1)
        public int ClosestValueOptimized(BinaryTreeNode root, double target)
        {
            int closestValue = root.Val;

            // Traverse through a path. So, Tx = O(d).
            while (root != null)
            {
                if (System.Math.Abs(root.Val - target) < System.Math.Abs(closestValue - target))
                    closestValue = root.Val;    // Found new closest value

                // if target value is less than nodes value, then check if it is closest to it's left child node, else right node.
                root = root.Val > target ? root.Left : root.Right;
            }

            return closestValue;
        }

        public int FindClosestBSTValue(BinaryTreeNode root, int value)
        {
            if (root.Val == value
                    || (value > root.Val && root.Right == null)
                    || (value < root.Val && root.Left == null))
            {
                return root.Val;
            }
            else if (value > root.Val)
            {
                if (value >= root.Right.Val)
                    return FindClosestBSTValue(root.Right, value);
                else
                    return FindClosest(root, root.Right, value);
            }
            else if (value < root.Val)
            {
                if (value <= root.Left.Val)
                    return FindClosestBSTValue(root.Left, value);
                else
                    return FindClosest(root, root.Left, value);
            }

            return -1;
        }

        private int FindClosest(BinaryTreeNode root, BinaryTreeNode childNode, int value)
        {
            int val1 = System.Math.Abs(root.Val - value);
            int val2 = System.Math.Abs(childNode.Val - value);

            return val1 > val2 ? childNode.Val : root.Val;
        }
    }
}
