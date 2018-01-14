using System.Collections.Generic;

namespace LeetcodeSolutions.Stack
{
    // Leetcode 20
    public class ValidParanthesis
    {        
        // Runtime = 147ms
        // Tx = O(n)
        // Sx = O(1)
        public bool IsValid(string s)
        {
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>
            {
                { '{', '}' },
                { '(', ')' },
                { '[', ']' }
            };
            Stack<char> openBrackets = new Stack<char>();

            foreach (char c in s)
            {
                if (bracketPairs.ContainsKey(c))
                {
                    openBrackets.Push(c);
                }
                else if (bracketPairs.ContainsValue(c))
                {
                    if (openBrackets.Count == 0 || c != bracketPairs[openBrackets.Pop()])
                        return false;
                }
                else
                {
                    return false;
                }
            }

            return openBrackets.Count == 0;
        }
    }
}
