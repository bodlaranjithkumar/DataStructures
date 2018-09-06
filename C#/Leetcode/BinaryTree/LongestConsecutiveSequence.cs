using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 298
    // Explanation: https://www.geeksforgeeks.org/longest-consecutive-sequence-binary-tree/

    public class LongestConsecutiveSequence
    {
        private int max;

        //public static void Main(string[] args)
        //{
        //    LongestConsecutiveSequence ls = new LongestConsecutiveSequence();

        //    BinaryTreeNode root = new BinaryTreeNode(6);
        //    root.Right = new BinaryTreeNode(9)
        //    {
        //        Left = new BinaryTreeNode(7),
        //        Right = new BinaryTreeNode(10)
        //    };
        //    root.Right.Right.Right = new BinaryTreeNode(11);

        //    Console.WriteLine(ls.FindLongestConsecutiveSequence(root));

        //    BinaryTreeNode root1 = new BinaryTreeNode(1);
        //    root1.Left = new BinaryTreeNode(2)
        //    {
        //        Left = new BinaryTreeNode(3)
        //    };

        //    root1.Right = new BinaryTreeNode(4)
        //    {
        //        Left = new BinaryTreeNode(5),
        //        Right = new BinaryTreeNode(6)
        //    };
        //    root1.Right.Right.Left = new BinaryTreeNode(7);

        //    Console.WriteLine(ls.FindLongestConsecutiveSequence(root1));
        //    Console.ReadKey();
        //}

        // Tx = O(n)
        // Sx = O(d)    For call stack
        public int FindLongestConsecutiveSequence(BinaryTreeNode root)
        {
            if (root == null)
                return 0;

            FindLongestConsecutiveSequence(root, 0, root.Val);

            return max;
        }

        public void FindLongestConsecutiveSequence(BinaryTreeNode node, int length, int nodeValue)
        {
            if (node == null)
                return;

            if (node.Val == nodeValue)
                length++;   // increment length by 1.
            else
                length = 1; // reset length to 1.

            max = System.Math.Max(max, length); // update the global maximum.

            FindLongestConsecutiveSequence(node.Left, length, node.Val + 1);
            FindLongestConsecutiveSequence(node.Right, length, node.Val + 1);
        }
    }
}
