using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 545 - https://leetcode.com/problems/boundary-of-binary-tree/description/
    // Submission Detail - https://leetcode.com/submissions/detail/185762858/
    // Ref - https://www.geeksforgeeks.org/boundary-traversal-of-binary-tree/

    public class BoundaryOfBinaryTree
    {
        //          ______20_________
        //         /                 \
        //    ____8_____              22
        //   /          \               \           =>      20,8,4,10,14,25,22
        //  4        ___12____           25   
        //          /         \
        //         10          14 

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
        //        Right = new BinaryTreeNode(22)
        //        {
        //            Right = new BinaryTreeNode(25)
        //        }
        //    };

        //    BoundaryOfBinaryTree boundary = new BoundaryOfBinaryTree();

        //    Helper.PrintListElements<int>(boundary.BoundaryOfABinaryTree(root));    //20 8 4 10 14 25 22

        //    Console.ReadKey();
        //}

        IList<int> boundaryNodes = new List<int>();

        // Tx = O(n)
        // Sx = O(n + d)  d for call stack

        // Idea: Break the problem to 3 parts
        //       1. Traverse and add all the left boundary nodes to the list except leaf node.
        //       2. Add all leaf nodes to the list.
        //       3. Traverse recursively to the last right boundary node and add to the list.

        // ClockWise. For Anti-Clockwise, call the modular functions from this method in reverse order.
        public IList<int> BoundaryOfABinaryTree(BinaryTreeNode root)
        {
            if (root == null) return boundaryNodes;

            boundaryNodes.Add(root.Val);

            LeftBoundary(root.Left);

            Leaves(root.Left);
            Leaves(root.Right);

            RightBoundary(root.Right);

            return boundaryNodes;
        }

        private void LeftBoundary(BinaryTreeNode node)
        {
            if (node == null || (node.Left == null && node.Right == null))
                return;

            boundaryNodes.Add(node.Val);

            if (node.Left != null)
                LeftBoundary(node.Left);
            else if (node.Right != null)
                LeftBoundary(node.Right);
        }

        private void Leaves(BinaryTreeNode node)
        {
            if (node == null)
                return;

            if (node.Left == null && node.Right == null)
                boundaryNodes.Add(node.Val);

            Leaves(node.Left);
            Leaves(node.Right);
        }

        private void RightBoundary(BinaryTreeNode node)
        {
            if (node == null || (node.Left == null && node.Right == null))
                return;

            if (node.Right != null)
                RightBoundary(node.Right);
            else if (node.Left != null)
                RightBoundary(node.Left);

            boundaryNodes.Add(node.Val);
        }
    }
}
