using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 449 - https://leetcode.com/problems/serialize-and-deserialize-bst/
    // Submission Detail: https://leetcode.com/submissions/detail/170396771/

    public class SerializeAndDeserializeBST
    {
        // Encodes a tree to a single string.
        public string Serialize(BinaryTreeNode root)
        {
            if (root == null)
                return null;

            var nodes = new Queue<BinaryTreeNode>();
            nodes.Enqueue(root);

            StringBuilder str = new StringBuilder();

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();

                if (node != null)
                {
                    str.Append(node.Val);

                    // TODO: Optimization - Leaf nodes doesn't need to be added to the queue and to the seriazlized string

                    nodes.Enqueue(node.Left);
                    nodes.Enqueue(node.Right);
                }
                else
                {
                    str.Append("#");
                }

                if (nodes.Count > 0)
                    str.Append(",");
            }

            return str.ToString();
        }

        // Decodes your encoded data to tree.
        public BinaryTreeNode Deserialize(string data)
        {
            if (data == null)
                return null;

            var values = data.Split(new char[] { ',' });
            if (values.Length == 0)
                return null;

            var root = new BinaryTreeNode(int.Parse(values[0]));

            var queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);

            for (int i = 1; i < values.Length; i = i + 2)
            {
                var node = queue.Dequeue();

                if (!values[i].Equals("#"))
                {
                    node.Left = new BinaryTreeNode(int.Parse(values[i]));
                    queue.Enqueue(node.Left);
                }

                if (!values[i + 1].Equals("#"))
                {
                    node.Right = new BinaryTreeNode(int.Parse(values[i + 1]));
                    queue.Enqueue(node.Right);
                }
            }

            return root;
        }
    }
}
