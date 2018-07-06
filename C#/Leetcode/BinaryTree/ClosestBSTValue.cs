using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 270
    //          20
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
        //    Console.WriteLine(closest.FindClosestBSTValue(root, 4));
        //    Console.WriteLine(closest.FindClosestBSTValue(root, 7));
        //    Console.WriteLine(closest.FindClosestBSTValue(root, 11));
        //    Console.WriteLine(closest.FindClosestBSTValue(root, 46));

        //    Console.ReadKey();
        //}

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
