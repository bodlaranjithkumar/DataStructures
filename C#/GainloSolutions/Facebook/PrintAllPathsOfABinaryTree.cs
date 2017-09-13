using System;
using System.Collections.Generic;
using System.Text;

namespace GainloSolutions.Facebook
{
    class AllPathsOfABinaryTree
    {
        //public static void Main(string[] args)
        //{
        //    //          10
        //    //      5       15
        //    //    3   7         20

        //    BinaryTreeNode root = new BinaryTreeNode(10);

        //    BinaryTreeNode left = new BinaryTreeNode(5);
        //    root.InsertLeft(left);

        //    BinaryTreeNode right = new BinaryTreeNode(15);
        //    root.InsertRight(right);

        //    left.InsertLeft(new BinaryTreeNode(3));
        //    left.InsertRight(new BinaryTreeNode(7));

        //    right.InsertRight(new BinaryTreeNode(20));

        //    AllPathsOfABinaryTree allPaths = new AllPathsOfABinaryTree();
        //    allPaths.PrintAllPathsOfBinaryTree(root);

        //    Console.ReadKey();
        //}


        public void PrintAllPathsOfBinaryTree(BinaryTreeNode root)
        {
            // Edge Cases

            StringBuilder path = new StringBuilder();

            Stack<NodePath> nodes = new Stack<NodePath>();
            nodes.Push(new NodePath(root, "", null));

            while (nodes.Count > 0)
            {
                var nodepath = nodes.Pop();
                var currentNode = nodepath.Node;
                var currentPath = nodepath.Path;

                if (currentNode.Left == null && currentNode.Right == null)
                {
                    Console.WriteLine(currentPath.Append(" ").Append(currentNode.Value));
                    //nodes.Pop();
                }

                if (currentNode.Right != null)
                {
                    nodes.Push(new NodePath(currentNode.Right, currentPath.ToString(),currentNode.Value));
                }

                if (currentNode.Left != null)
                {
                    nodes.Push(new NodePath(currentNode.Left, currentPath.ToString(),currentNode.Value));
                }
            }

            nodes.Clear();
        }
    }

    public class NodePath
    {
        public BinaryTreeNode Node { get; private set; }

        public StringBuilder Path { get; private set; }

        public NodePath(BinaryTreeNode node, string path, int? value)
        {
            Node = node;

            Path = new StringBuilder();
            Path.Append(path).Append(" ").Append(value);
        }
    }
}
