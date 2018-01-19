using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    public class LongestSubstringwithAtMostTwoDistinctCharacters
    {
        public int FindLength(string s)
        {
            HashSet<char> visited = new HashSet<char>();

            int i = 0, j = 0, maxLength = 0;

            while (j < s.Length)
            {
                if (!visited.Contains(s[j]) && visited.Count == 2)
                {
                    i++;
                    j = i;
                    visited.Clear();
                }
                else
                {
                    if (!visited.Contains(s[j]))
                        visited.Add(s[j]);

                    maxLength = System.Math.Max(j - i + 1, maxLength);
                    j++;
                }
            }

            return maxLength;
        }
    }
}
