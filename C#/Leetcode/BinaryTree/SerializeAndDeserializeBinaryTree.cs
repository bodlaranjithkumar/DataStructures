using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 297 - https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
    // NOTE: Same solution as Serialize and Deserialize Binary Search Tree
    // Submission Detail: https://leetcode.com/submissions/detail/169155362/

    public class SerializeAndDeserializeBinaryTree
    {
        //static char Delimiter = ',';

        //static void Main(string[] args)
        //{
        //    BinaryTreeNode root = new BinaryTreeNode(1)
        //    {
        //        Left = null,
        //        Right = new BinaryTreeNode(3)
        //    };

        //    string s = Serialize(root);
        //    BinaryTreeNode droot = Deserialize(s);
        //}

        // Serialize using , as the delimiter
        // Encodes a tree to a single string.
        //public static string Serialize(BinaryTreeNode root)
        //{
        //    StringBuilder serializedTree = new StringBuilder();
        //    Queue<BinaryTreeNode> nodes = new Queue<BinaryTreeNode>();

        //    if (root != null)
        //        nodes.Enqueue(root);

        //    while (nodes.Count > 0)
        //    {
        //        BinaryTreeNode node = nodes.Dequeue();

        //        if (node != null)
        //        {
        //            serializedTree.Append(node.Val);
        //            nodes.Enqueue(node.Left);
        //            nodes.Enqueue(node.Right);
        //        }
        //        else
        //        {
        //            serializedTree.Append("null");
        //        }

        //        serializedTree.Append(Delimiter);
        //    }

        //    // Remove the delimiter appended in the last
        //    // TODO: Add logic in the loop to avoid appending this.
        //    if (serializedTree.Length > 0)
        //        serializedTree.Remove(serializedTree.Length - 1, 1);

        //    return serializedTree.ToString();
        //}

        // Decodes your encoded data to tree.
        //public static BinaryTreeNode Deserialize(string data)
        //{
        //    BinaryTreeNode root = null;

        //    Queue<BinaryTreeNode> nodes = new Queue<BinaryTreeNode>();
        //    nodes.Enqueue(root);

        //    StringBuilder currentNodeValue = new StringBuilder();

        //    for (int index = 0; index < data.Length; index++)
        //    {
        //        char currentChar = data[index];
                
        //        if (currentChar != Delimiter)
        //        {
        //            currentNodeValue.Append(currentChar);
        //        }
        //        else
        //        {
        //            BinaryTreeNode node = nodes.Dequeue();
                    
        //            if (int.TryParse(currentNodeValue.ToString(), out int value))
        //            {
        //                if (root == null)
        //                {
        //                    root = new BinaryTreeNode(value);
        //                    node = root;
        //                }
        //                else
        //                {
        //                    node = new BinaryTreeNode(value);
        //                }

        //                nodes.Enqueue(node.Left);
        //                nodes.Enqueue(node.Right);
        //            }

        //            currentNodeValue.Clear();
        //        }
        //    }

        //    return root;
        //}
    }
}
