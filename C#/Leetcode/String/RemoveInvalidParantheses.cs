using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode 301 - https://leetcode.com/problems/remove-invalid-parentheses/description/
    // Submission Details - https://leetcode.com/submissions/detail/183039472/
    // Reference - https://leetcode.com/problems/remove-invalid-parentheses/discuss/75027/Easy-Short-Concise-and-Fast-Java-DFS-3-ms-solution

    // Follow-up: Write algorithm to add parantheses to make given parantheses sequence valid.

    public class RemoveInvalidParantheses
    {
        public class Solution
        {
            public IList<string> RemoveInvalidParentheses(string s)
            {
                IList<string> result = new List<string>();
                RemoveInvalidParantheses(s, result, 0, 0, new char[] { '(', ')' });

                return result;
            }

            private void RemoveInvalidParantheses(string s, IList<string> result, int last_i, int last_j, char[] paran)
            {
                int counter = 0;
                for (int i = last_i; i < s.Length; i++)
                {
                    if (s[i] == paran[0]) counter++;
                    else if (s[i] == paran[1]) counter--;

                    if (counter >= 0) continue;

                    for (int j = last_j; j <= i; j++)
                    {
                        if (s[j] == paran[1] && (j == last_j || s[j - 1] != paran[1]))
                            RemoveInvalidParantheses(s.Substring(0, j) + s.Substring(j + 1), result, i, j, paran);
                    }

                    return;
                }

                char[] chars = s.ToCharArray();
                System.Array.Reverse(chars);
                string reverse = new string(chars);

                if (paran[0] == '(')
                    RemoveInvalidParantheses(reverse, result, 0, 0, new char[] { ')', '(' });
                else
                    result.Add(reverse);
            }
        }
    }
}
