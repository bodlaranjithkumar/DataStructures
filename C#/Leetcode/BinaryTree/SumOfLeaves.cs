using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    //https://www.geeksforgeeks.org/sum-leaf-nodes-binary-tree/
    public class SumOfLeaves
    {
        // Tx = O(n)
        // Sx = O(d)    // for call stack
        public int LeavesSum(BinaryTreeNode root)
        {
            if (root == null) return 0;

            // Leaf node
            if (root.Left == null && root.Right == null) return root.Val;

            int sum = 0;
            sum += LeavesSum(root.Left);
            sum += LeavesSum(root.Right);

            return sum;
        }
    }
}
