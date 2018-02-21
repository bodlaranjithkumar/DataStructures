using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode 139
    // Submission Detail : https://leetcode.com/submissions/detail/136149063/
    // Dynamic Programming
    public class WordBreak
    {
        // Bottom-up dynamic programming
        // Tx = O(n^2)
        // Sx = O(n)
        public bool BreakWordsDp(string s, IList<string> wordDict)
        {
            bool[] f = new bool[s.Length + 1];
            f[0] = true;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (f[j] && wordDict.Contains(s.Substring(j, i-j)))
                    {
                        f[i] = true;
                        break;
                    }
                }
            }

            return f[s.Length];
        }

        // Not optimal solution because of duplicate work.
        // Time limit exceed for the following input 
        //"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab"
        //["a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"]
        public bool BreakWords(string s, IList<string> wordDict)
        {
            if (s.Length == 0 || wordDict.Contains(s))
                return true;

            for (int i = 1; i < s.Length; i++)
            {
                string s1 = s.Substring(0, i);
                string s2 = s.Substring(i);

                if (wordDict.Contains(s1) && (wordDict.Contains(s2) || BreakWords(s2, wordDict)))
                    return true;
            }

            return false;
        }
    }
}
