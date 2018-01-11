using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    //Leetcode 98
    public class BinaryTreeIsBST
    {
        public bool IsBST(BinaryTreeNode root)
        {
            return IsBST(root, int.MinValue, int.MaxValue);
        }

        private bool IsBST(BinaryTreeNode node, int min, int max)
        {
            if (node == null)
                return true;

            return node.Val <= max 
                    && node.Val > min
                    && IsBST(node.Left, min, node.Val)
                    && IsBST(node.Right, node.Val, max);
        }
    }
}
