using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;

namespace LeetcodeSolutions.Patterns.BFS
{
    // Leetcode 103 - https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal
    // Submission Detail - https://leetcode.com/submissions/detail/123636957/
    // Use 2 Stacks

    public class ZigZagBinaryTreeTraversal
    {
        // Tx: O(n) { n: n is the number of nodes in the binary tree}
        // Sx: O(n) { n: n is the number of nodes in the binary tree}
        public static IList<IList<int>> ZigzagLevelOrder(BinaryTreeNode root)
        {
            IList<IList<int>> outerList = new List<IList<int>>();

            Stack<BinaryTreeNode> stack1 = new Stack<BinaryTreeNode>();
            Stack<BinaryTreeNode> stack2 = new Stack<BinaryTreeNode>();

            if(root != null)
                stack1.Push(root);

            while (stack1.Count != 0 || stack2.Count != 0)
            {
                IList<int> innerList1 = new List<int>();
                while (stack1.Count != 0)
                {
                    BinaryTreeNode node = stack1.Pop();

                    innerList1.Add(node.Val);

                    if (node.Left != null)
                        stack2.Push(node.Left);

                    if (node.Right != null)
                        stack2.Push(node.Right);
                }

                IList<int> innerList2 = new List<int>();
                while (stack2.Count != 0)
                {
                    BinaryTreeNode node = stack2.Pop();

                    innerList2.Add(node.Val);

                    if (node.Right != null)
                        stack1.Push(node.Right);

                    if (node.Left != null)
                        stack1.Push(node.Left);
                }

                if (innerList1.Count > 0)
                    outerList.Add(innerList1);

                if (innerList2.Count > 0)
                    outerList.Add(innerList2);
            }

            return outerList;
        }
    }
}
