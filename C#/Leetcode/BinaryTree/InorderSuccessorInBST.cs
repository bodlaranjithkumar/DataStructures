using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    //          20
    //          / \
    //         8   22
    //        / \
    //       4   12
    //           /\
    //         10  14

    //  10 -> 12
    //  8  -> 20
    //  14 -> 20
    //  22 -> null

    // Leetcode 285
    // Ref: https://www.geeksforgeeks.org/inorder-successor-in-binary-search-tree/

    public class InorderSuccessorInBST
    {
        public BinaryTreeNode InorderSuccessor(BinaryTreeNode root, BinaryTreeNode p)
        {
            if (root == null || p == null) return null;

            if (p.Right != null)
                return GetLeftMostChildNode(p.Right);

            BinaryTreeNode successor = null;

            while(root != null)
            {
                if (p.Val < root.Val)
                {
                    successor = root;
                    root = root.Left;
                }
                else if (p.Val > root.Val)
                    root = root.Right;
                else
                    break;
            }

            return successor;
        }

        private BinaryTreeNode GetLeftMostChildNode(BinaryTreeNode node)
        {
            while(node.Left != null)
                node = node.Left;

            return node;
        }
    }
}