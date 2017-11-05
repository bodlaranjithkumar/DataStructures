using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Stack
{
    // Leetcode 155
    public class MinStack
    {
        private Stack<int> minimumStack;
        private Stack<int> stack;
        private Stack<int> minimumStackIndex;

        /** initialize your data structure here. */
        public MinStack()
        {
            minimumStack = new Stack<int>();
            stack = new Stack<int>();
            minimumStackIndex = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);

            if (minimumStack.Count == 0 || minimumStack.Peek() > x)
            {
                minimumStack.Push(x);
                minimumStackIndex.Push(stack.Count);
            }
        }

        public void Pop()
        {
            int x = stack.Pop();

            if (x == minimumStack.Peek() && minimumStackIndex.Peek() == stack.Count + 1)
            {
                minimumStack.Pop();
                minimumStackIndex.Pop();
            }
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minimumStack.Peek();
        }
    }
}
