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

    // Submission: https://leetcode.com/submissions/detail/141066933/
    // Use custom MinStackElement class with the number, min so far properties.
    // Sx = O(2n)
    public class MinStack
    {
        private class MinStackElement
        {
            public int Min { get; }
            public int Element { get; }

            public MinStackElement(int element, int min)
            {
                Element = element;
                Min = min;
            }
        }

        private Stack<MinStackElement> stack;

        /** initialize your data structure here. */
        public MinStack()
        {
            stack = new Stack<MinStackElement>();
        }

        public void Push(int x)
        {
            int min = stack.Count == 0 ? x : System.Math.Min(stack.Peek().Min, x);
            stack.Push(new MinStackElement(x, min));
        }

        public void Pop()
        {
            stack.Pop();
        }

        public int Top()
        {
            return stack.Peek().Element;
        }

        public int GetMin()
        {
            return stack.Peek().Min;
        }
    }

    // Sx = O(3n)
    //public class MinStack
    //{
    //    private Stack<int> minimumStack;
    //    private Stack<int> stack;
    //    private Stack<int> minimumStackIndex;

    //    /** initialize your data structure here. */
    //    public MinStack()
    //    {
    //        minimumStack = new Stack<int>();
    //        stack = new Stack<int>();
    //        minimumStackIndex = new Stack<int>();
    //    }

    //    public void Push(int x)
    //    {
    //        stack.Push(x);

    //        if (minimumStack.Count == 0 || minimumStack.Peek() > x)
    //        {
    //            minimumStack.Push(x);
    //            minimumStackIndex.Push(stack.Count);
    //        }
    //    }

    //    public void Pop()
    //    {
    //        int x = stack.Pop();

    //        if (x == minimumStack.Peek() && minimumStackIndex.Peek() == stack.Count + 1)
    //        {
    //            minimumStack.Pop();
    //            minimumStackIndex.Pop();
    //        }
    //    }

    //    public int Top()
    //    {
    //        return stack.Peek();
    //    }

    //    public int GetMin()
    //    {
    //        return minimumStack.Peek();
    //    }
    //}
}
