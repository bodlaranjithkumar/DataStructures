using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 538 - https://leetcode.com/problems/convert-bst-to-greater-tree/
    // Submission Detail - https://leetcode.com/submissions/detail/160509921/

    public class ConvertBSTtoGreaterTree
    {
        //[0,-1,2,-3,null,null,4] => [6,5,6,2,null,null,4]
        //[2,0,3,-4,1] => [5,6,3,2,6]
        //[1,0,4,-2,null,3] => [8,8,4,6,null,7]
        //[2,0,4,-4,1,3] => [9,10,4,6,10,7]

        // Explanation: if going to right node: 1.  in a left subtree, pass the node value because the right node's value in left subtree is less than all the node's value starting from it's parent to all the node's on it's parent subtree.
        //                                      2.  in a right subtree, pass 0. 
        //              if going to left node: pass the current node value and do nothing. This value is added to the left node's value after it is passed to the left node's right node and then returned. Eventually return this value.
        //                                      1. if this left node is present in the right subtree of a node, then node value needs to be added to the parent node.
        //                                      2. if this left node is present in the left subtree of a node, do nothing.
        public BinaryTreeNode ConvertBST(BinaryTreeNode root)
        {
            ConvertBST(root, 0);

            return root;
        }

        private int ConvertBST(BinaryTreeNode node, int val)
        {
            // Base Condition
            if (node == null)
                return val;

            int rightSubTreeSum = ConvertBST(node.Right, val);
            node.Val += rightSubTreeSum;

            int SumToReturnToGrandParent = ConvertBST(node.Left, node.Val);
            return SumToReturnToGrandParent;
        }
    }
}
