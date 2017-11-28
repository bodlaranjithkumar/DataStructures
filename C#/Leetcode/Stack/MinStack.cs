using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Stack
{
    // Leetcode 155
    //      MinStack minStack = new MinStack();
    //      minStack.push(-2);
    //      minStack.push(0);
    //      minStack.push(-3);
    //      minStack.getMin();   --> Returns -3.
    //      minStack.pop();
    //      minStack.top();      --> Returns 0.
    //      minStack.getMin();   --> Returns -2.
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
