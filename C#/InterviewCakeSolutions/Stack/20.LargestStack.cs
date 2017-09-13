using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.Stack
{
    class LargestStack
    {
        //public static void Main(string[] args)
        //{
        //    MaxStack maxStack = new MaxStack();
        //    maxStack.Push(-15);
        //    maxStack.Push(10);
        //    maxStack.Push(-10);
        //    maxStack.Push(5);
        //    maxStack.Push(20);
        //    maxStack.Push(-30);
        //    maxStack.Push(40);
        //    maxStack.Push(30);
        //    maxStack.Push(1);

        //    Console.WriteLine($"Max Value {maxStack.GetMax()}");    //40

        //    maxStack.Pop();
        //    maxStack.Pop();
        //    maxStack.Pop();

        //    Console.WriteLine($"Max Value {maxStack.GetMax()}");    //20

        //    maxStack.Pop();
        //    maxStack.Pop();
        //    maxStack.Pop();

        //    Console.WriteLine($"Max Value {maxStack.GetMax()}");    //10
            
        //    Console.ReadKey();

        //}
    }

    class MaxStack
    {
        Stack<int> _stack = new Stack<int>();
        Stack<int> _maxStack = new Stack<int>();

        public int Push(int item)
        {
            _stack.Push(item);

            if(_maxStack.Count == 0 || item > _maxStack.Peek())
            {
                _maxStack.Push(item);
            }

            return item;
        }

        public int Pop()
        {
            int item;
                
            if(_stack.Count > 0)
            {
                item = _stack.Pop();
            }
            else
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            if(_maxStack.Count > 0 && item == _maxStack.Peek())
            {
                _maxStack.Pop();
            }

            return item;
        }

        public int GetMax()
        {
            return _maxStack.Count > 0 ? _maxStack.Peek() : _stack.Peek() ;
        }
    }
}
