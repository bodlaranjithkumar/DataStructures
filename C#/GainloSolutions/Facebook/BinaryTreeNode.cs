using System;
using System.Collections.Generic;
using System.Text;

namespace GainloSolutions.Facebook
{
    public class BinaryTreeNode
    {
        public int Value { get; private set; }

        public BinaryTreeNode Left { get; private set; }

        public BinaryTreeNode Right { get; private set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public void InsertLeft(BinaryTreeNode left)
        {
            Left = left;
        }

        public void InsertRight(BinaryTreeNode right)
        {
            Right = right;
        }
    }
}
