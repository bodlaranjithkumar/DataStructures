using System;
using System.Collections.Generic;
using System.Text;

namespace RandomProblemSolutions
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; }

        public BinaryTreeNode<T> Left { get; private set; }

        public BinaryTreeNode<T> Right { get; private set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public BinaryTreeNode<T> InsertLeft(T Value)
        {
            Left = new BinaryTreeNode<T>(Value);
            return Left;
        }

        public BinaryTreeNode<T> InsertRight(T Value)
        {
            Right = new BinaryTreeNode<T>(Value);
            return Right;
        }
    }
}
