using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    public class PermutationString
    {
        public static void Main(string[] args)
        {
            PermutationString p = new PermutationString();
            var permutations = p.PermutationsOfAString("abc");
        }

        private IList<string> Permutations;

        public PermutationString()
        {
            Permutations = new List<string>();
        }

        public IList<string> PermutationsOfAString(string s)
        {
            return PermutationsOfAString(s, "");
        }

        // Tx = O(n!)
        // Sx = O(n!) for output list. Recursive call stack takes additional space.
        private IList<string> PermutationsOfAString(string s, string p)
        {
            if (s.Length == 0)
                Permutations.Add(p);

            for (int i = 0; i < s.Length; i++)
            {
                char left = s[i];
                string right = s.Substring(0, i) + s.Substring(i + 1);

                PermutationsOfAString(right, p + left);
            }

            return Permutations;
        }
    }
}
