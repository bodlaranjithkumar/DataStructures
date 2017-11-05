using System;
using System.Collections.Generic;

namespace InterviewCakeSolutions.Strings
{
    class BracketValidator
    {
        static Dictionary<char, char> bracketsPair = new Dictionary<char, char>{
            {'{', '}'},
            {'[', ']'},
            {'(', ')'}
        };

        //public static void Main(string[] args)
        //{
        //    //{[]()} - TRUE
        //    //{[(])} - FALSE
        //    //{[} - FALSE
        //    //[({})[]] - TRUE
        //    string str = "{[}";
        //    BracketValidator bracketValidator = new BracketValidator();
        //    Console.WriteLine(bracketValidator.ValidateBrackets(str));
        //    Console.Read();
        //}

        private bool ValidateBracketsOptimized(string str)
        {
            Stack<char> brackets = new Stack<char>();
            foreach(var c in str)
            {
                if (c == '(')
                    brackets.Push(')');
                else if (c == '{')
                    brackets.Push('}');
                else if (c == '[')
                    brackets.Push(']');
                else if (brackets.Count == 0 || brackets.Pop() != c)
                    return false;
            }

            return brackets.Count == 0;
        }
    
        private bool ValidateBrackets(string str)
        {
            Stack<char> openBrackets = new Stack<char>();
            //openBrackets.Push(str[0]);

            foreach(char c in str)
            {
                if (bracketsPair.ContainsValue(c))
                {
                    if (openBrackets.Count == 0 || c != bracketsPair[openBrackets.Peek()])
                        return false;
                    else
                        openBrackets.Pop();
                }
                // Push to the stack if it is either empty or the current character is present in the key. 
                // 1st condition doesn't let other characters not in dictionary keys to insert into stack.
                else if (bracketsPair.ContainsKey(c) || openBrackets.Count == 0  )
                {
                    openBrackets.Push(c);
                }
            }

            return openBrackets.Count == 0;
        }

        // Understood question incorrectly.
        private bool validateBrackets1(string str)
        {
            int length = str.Length;

            if (length == 0)
                return true;
            else if (length == 1)
                return false;
            if(str[0] != '{' || str[length - 1] != '}')
                throw new ArgumentException("String must start with { and end with }");

            List<char> opener = new List<char>();
            opener.Add('[');
            opener.Add('(');

            List<char> closer = new List<char>();
            closer.Add(']');
            closer.Add(')');

            bool isOpened = false;

            for(int i = 1; i < length - 1; i++)
            {
                if (opener.Contains(str[i]) || closer.Contains(str[i]))
                {
                    if (!isOpened && opener.Contains(str[i]))
                    {
                        isOpened = true;
                    }
                    else if (isOpened && closer.Contains(str[i]))
                    {
                        isOpened = false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return isOpened ? false : true;
        }
    }
}
