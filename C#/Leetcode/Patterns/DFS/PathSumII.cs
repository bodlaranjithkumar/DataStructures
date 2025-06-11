using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;

namespace LeetcodeSolutions.Patterns.DFS
{
    // Leetcode 113 - https://leetcode.com/problems/path-sum-ii/
    // Submission Detail - https://leetcode.com/problems/path-sum-ii/discuss/36695/Java-Solution:-iterative-and-recursive

    public class PathSumII
    {
        public IList<IList<int>> PathSum(BinaryTreeNode root, int sum)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> list = new List<int>();

            Helper(root, result, list, sum);
            return result;
        }

        private void Helper(BinaryTreeNode node, IList<IList<int>> result, IList<int> list, int sum)
        {
            list.Add(node.Val);

            // Leaf node and node's value is equal to the remaining sum.
            if (node.Left == null && node.Right == null && node.Val == sum)
            {
                result.Add(new List<int>(list));
                return;
            }

            if (node.Left != null)
            {
                Helper(node.Left, result, list, sum - node.Val);
                list.RemoveAt(list.Count - 1);  // Remove the node added at line 22 after calling the above recursive function.
            }

            if (node.Right != null)
            {
                Helper(node.Right, result, list, sum - node.Val);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
