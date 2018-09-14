using System.Collections.Generic;

namespace LeetcodeSolutions.Stack
{
    // Leetcode 20 - https://leetcode.com/problems/valid-parentheses/
    // Submission Detail - https://leetcode.com/submissions/detail/136153280/
    //                     https://leetcode.com/submissions/detail/175228021/

    public class ValidParanthesis
    {
        // Runtime = 147ms
        // Tx = O(n)
        // Sx = O(1)
        public bool IsValid(string s)
        {
            Stack<char> chars = new Stack<char>();

            foreach(char c in s)
            {
                if (c == '{')
                    chars.Push('}');
                else if (c == '[')
                    chars.Push(']');
                else if (c == '(')
                    chars.Push(')');
                else if (chars.Count == 0 || chars.Pop() != c)
                    return false;
            }

            return chars.Count == 0;
        }


        public bool IsValidCoversMoreCases(string s)
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
