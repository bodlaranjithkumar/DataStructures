using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeSolutions.String
{
    public class PermutationString
    {
        public static void Main(string[] args)
        {
            PermutationString p = new PermutationString();
            //var permutations = p.PermutationsOfAString("abc");
            var permutations = p.PermutationsOfAStringUsingCharArray("abc");

            Console.ReadKey();
        }

        private IList<string> permutations;

        public PermutationString()
        {
            permutations = new List<string>();
        }

        // Similar to Permuations of an Array - LCD 46 - https://leetcode.com/problems/permutations/description/
        // Works when the characters in the string are unique.
        public IList<string> PermutationsOfAStringUsingCharArray(string s)
        {
            char[] chars = s.ToCharArray();

            PermutationsOfAStringUsingCharArray(chars, new List<char>());

            return permutations;
        }

        private void PermutationsOfAStringUsingCharArray(char[] chars, IList<char> permuteChars)
        {
            if(permuteChars.Count == chars.Length)
            {
                permutations.Add(new string(permuteChars.ToArray()));
            }

            for(int i = 0; i < chars.Length; i++)
            {
                if (permuteChars.Contains(chars[i]))
                    continue;

                permuteChars.Add(chars[i]);
                PermutationsOfAStringUsingCharArray(chars, permuteChars);
                permuteChars.RemoveAt(permuteChars.Count - 1);
            }
        }

        // Reference: http://javabypatel.blogspot.com/2015/08/program-to-print-permutations-of-string-without-repetition.html
        public IList<string> PermutationsOfAString(string s)
        {
            return PermutationsOfAString(s, "");
        }

        // Tx = O(n!)
        // Sx = O(n!) for output list. Recursive call stack takes additional space.
        private IList<string> PermutationsOfAString(string s, string p)
        {
            if (s.Length == 0)
                permutations.Add(p);

            for (int i = 0; i < s.Length; i++)
            {
                char left = s[i];
                string right = s.Substring(0, i) + s.Substring(i + 1);

                PermutationsOfAString(right, p + left);
            }

            return permutations;
        }
    }
}
