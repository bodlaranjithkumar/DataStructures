using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 314

    //    _3_
    //   /   \
    //  9    20     ->      [[4], [9], [3,5,2], [20], [7]]
    // / \   / \
    //4   5 2   7 

    //  3
    // / \
    //9  20         ->      [[9],[3,15],[20],[7]]
    //  /  \
    // 15   7
    public class BinaryTreeVerticalOrderTraversal
    {
        // Bruteforce: Create a new datastructure with col property and update
        //      create new binary tree with col value as col-1 for left child and col+1 for right child.
        //      Then traverse the tree and add the col as key, list as values into a dictionary.

        //public static void Main(string[] args)
        //{
        //    BinaryTreeNode root = new BinaryTreeNode(3)
        //    {
        //        Left = new BinaryTreeNode(9)
        //        {
        //            Left = new BinaryTreeNode(4),
        //            Right = new BinaryTreeNode(5)
        //        },
        //        Right = new BinaryTreeNode(20)
        //        {
        //            Left = new BinaryTreeNode(2),
        //            Right = new BinaryTreeNode(7)
        //        }
        //    };

        //    BinaryTreeVerticalOrderTraversal t = new BinaryTreeVerticalOrderTraversal();

        //    var list = t.VerticalTraversal(root);

        //    foreach (var l in list)
        //        Helper.PrintListElements(l);

        //    Console.ReadKey();
        //}

        Dictionary<int, IList<int>> nodes;
        public BinaryTreeVerticalOrderTraversal()
        {
            nodes = new Dictionary<int, IList<int>>();
        }

        // Tx = O(n)    {actually O(2n)}
        // Sx = O(n+d)    
        public IList<IList<int>> VerticalTraversal(BinaryTreeNode root)
        {
            VerticalTraversal(root, 0);

            return nodes.OrderBy(n => n.Key)
                        .Select(n => n.Value)
                        .ToList();
        }

        private void VerticalTraversal(BinaryTreeNode node, int col)
        {
            if (node == null) return;

            if (!nodes.ContainsKey(col))
                nodes.Add(col, new List<int>());

            nodes[col].Add(node.Val);

            //if (node.Left != null)
            VerticalTraversal(node.Left, col - 1);

            //if (node.Right != null)
            VerticalTraversal(node.Right, col + 1);
        }
    }
}
