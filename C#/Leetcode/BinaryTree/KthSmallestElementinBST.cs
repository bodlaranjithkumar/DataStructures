using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 230 - https://leetcode.com/problems/kth-smallest-element-in-a-bst/description/
    // Submission Detail - https://leetcode.com/submissions/detail/208674130/

    public class KthSmallestElementinBST
    {
        private int kthSmallest = 0, count = 0;

        public int KthSmallest(BinaryTreeNode root, int k)
        {
            count = k;

            Helper(root);

            return kthSmallest;
        }

        private void Helper(BinaryTreeNode node)
        {
            if (node.Left != null)
                Helper(node.Left);

            count--;

            if (count == 0)
            {
                kthSmallest = node.Val;
                return;
            }

            if (node.Right != null)
                Helper(node.Right);
        }
    }
}
