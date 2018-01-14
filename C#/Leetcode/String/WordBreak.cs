using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    public class WordBreak
    {
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
