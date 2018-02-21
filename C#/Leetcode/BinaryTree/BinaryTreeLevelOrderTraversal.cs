using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 102
    // Submission Detail: https://leetcode.com/submissions/detail/123797239/
    // Depth first traversal, Queue
    public class BinaryTreeLevelOrderTraversal
    {
        // Runtime : 535 ms
        // Tx = O(n) {n: number of nodes in the binary tree}
        // Sx = O(n) {O(2n) - n for queue and n for the resultant list}
        // Breadth First Traversal
        public List<List<int>> LevelOrder(BinaryTreeNode root)
        {
            List<List<int>> result = new List<List<int>>();
            Queue<BinaryTreeNode> nodes = new Queue<BinaryTreeNode>();

            if (root != null)
                nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                List<int> currentLevelNodeValues = new List<int>();
                int level = nodes.Count;

                // Run the for loop for number of nodes at the current level so that we add all the node values into same list.
                for (int lvl = 0; lvl < level; lvl++)
                {
                    BinaryTreeNode node = nodes.Dequeue();
                    currentLevelNodeValues.Add(node.Val);

                    if (node.Left != null)
                        nodes.Enqueue(node.Left);

                    if (node.Right != null)
                        nodes.Enqueue(node.Right);
                }

                result.Add(currentLevelNodeValues);
            }

            return result;
        }
    }
}
