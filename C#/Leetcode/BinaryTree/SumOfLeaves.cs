using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.BinaryTree
{
    //https://www.geeksforgeeks.org/sum-leaf-nodes-binary-tree/
    public class SumOfLeaves
    {
        // Tx = O(n)
        // Sx = O(d)
        public int LeavesSum(BinaryTreeNode root)
        {
            if (root == null) return 0;

            int sum = 0;
            if (root.Left == null && root.Right == null)
            {
                sum += root.Val;
            }
            else
            {
                sum += LeavesSum(root.Left);
                sum += LeavesSum(root.Right);
            }

            return sum;
        }
    }
}
