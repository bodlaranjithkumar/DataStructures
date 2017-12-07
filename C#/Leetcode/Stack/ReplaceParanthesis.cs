using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Stack
{
    //Implement a function that returns an alternate representation of the string where the following is true:
 
    //1. A letter is translated directly; it appears exactly as it did in the original string in the same location
    //2. A matched parenthesis is represented as the number 0
    //3. An unmatched left parenthesis is represented as the number 1
    //4. An unmatched right parenthesis is represented as the number 2
    //5. Parentheses are matched from the inside out
 
    //So the following string:
 
    //(a) -> 0a0
    //(a  -> 1a
    //a) -> a2
    //(a(b)) -> 0a0b00
    //(a(b) -> 1a0b0
    public class ReplaceParanthesis
    {
        public string ReplaceParanthesisWithDigit(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder output = new StringBuilder(input);
            Stack<int> paranthesisIndices = new Stack<int>(input.Length);

            for(int index=0; index<input.Length; index++)
            {
                char c = input[index];

                if(c == '(')
                {
                    paranthesisIndices.Push(index);
                }
                else if(c == ')')
                {
                    if(paranthesisIndices.Count > 0)
                    {
                        int leftParanIndex = paranthesisIndices.Pop();
                        output[leftParanIndex] = '0';
                        output[index] = '0';
                    }

                    output[index] = '2';
                }
            }

            while(paranthesisIndices.Count > 0)
            {
                int leftParanIndex = paranthesisIndices.Pop();
                output[leftParanIndex] = '1';
            }

            return output.ToString();
        }
    }
}
