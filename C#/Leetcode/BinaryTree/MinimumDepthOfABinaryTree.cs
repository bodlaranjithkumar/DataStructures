using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 111 -  https://leetcode.com/problems/minimum-depth-of-binary-tree/description/
    // Submission Detail - https://leetcode.com/submissions/detail/187271162/

    public class MinimumDepthOfABinaryTree
    {
        public int MinDepth(BinaryTreeNode root)
        {
            if (root == null) return 0;

            int left = MinDepth(root.Left);
            int right = MinDepth(root.Right);

            return 1 + ((left == 0 || right == 0) 
                        ? System.Math.Max(left, right) : System.Math.Min(left, right));
        }
    }
}
