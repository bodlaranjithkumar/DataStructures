using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 108 - https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
    // Submission Detail - https://leetcode.com/submissions/detail/129110833/
    // Modified Binary Search

    public class ConvertSortedArrayToBinarySearchTree
    {
        //public static void Main(string[] args)
        //{
        //    ConvertSortedArrayToBinarySearchTree BST1 = new ConvertSortedArrayToBinarySearchTree();
        //    int[] ex1 = { 2, 3, 4, 5, 6, 7, 8 };
        //    BST1.SortedArrayToBST(ex1);

        //    Console.ReadKey();
        //}

        // Input: [2,3,4,5,6,7,8]
        // Output:
        //           5
        //         /   \
        //        3     7
        //       / \   / \
        //      2   4  6  8   
        
        // Runtime = 155 ms
        // Tx = O(n)
        // Sx = O(d) for call stack

        public BinaryTreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        private BinaryTreeNode SortedArrayToBST(int[] nums, int start, int end)
        {
            // base case
            if (start > end)
                return null;

            int mid = start + (end - start)/2;
            BinaryTreeNode node = new BinaryTreeNode(nums[mid])
            {
                Left = SortedArrayToBST(nums, start, mid - 1),
                Right = SortedArrayToBST(nums, mid + 1, end)
            };

            return node;
        }
    }
}