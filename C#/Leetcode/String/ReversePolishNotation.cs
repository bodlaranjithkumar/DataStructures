using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // RPN Wiki - https://en.wikipedia.org/wiki/Polish_notation
    // aka Postfix notation
    // Leetcode - 150
    public class ReversePolishNotation
    {
        //static void Main(string[] args)
        //{
        //    string[] str1 = new string[] { "2", "1", "+", "3", "*" };
        //    Console.WriteLine($"Input: {str1},\tOutput: {EvalRPN(str1)},\tExpected:9");

        //    string[] str2 = new string[] { "4", "13", "5", "/", "+" };
        //    Console.WriteLine($"Input: {str2},\tOutput: {EvalRPN(str2)},\tExpected:6");

        //    string[] str3 = new string[] { "18" };
        //    Console.WriteLine($"Input: {str3},\tOutput: {EvalRPN(str3)},\tExpected:18");

        //    Console.ReadLine();
        //}

        static Stack<int> operands = new Stack<int>();
        static HashSet<string> ValidOperators = new HashSet<string>
            {
                "+",
                "-",
                "*",
                "/"
            };

        // Runtime : 188 ms
        // Tx = O(n) { n : Lenth of the string}
        // Sx = O(n) for storing in the stack
        public static int EvalRPN(string[] tokens)
        {
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int operand))
                {
                    operands.Push(operand);
                }
                else if (ValidOperators.Contains(token))
                {
                    if (operands.Count > 1)
                    {
                        Compute(token);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid RPN.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Invalid operator found.");
                }
            }

            return operands.Pop();
        }

        private static void Compute(string op)
        {
            int operand2 = operands.Pop();
            int operand1 = operands.Pop();

            switch (op)
            {
                case "+":
                    operands.Push(operand1 + operand2);
                    break;
                case "-":
                    operands.Push(operand1 - operand2);
                    break;
                case "*":
                    operands.Push(operand1 * operand2);
                    break;
                case "/":
                    if (operand2 == 0)
                        throw new DivideByZeroException("Cannot perform / operation with denominator as 0.");

                    operands.Push(operand1 / operand2);
                    break;
            }
        }
    }
}
