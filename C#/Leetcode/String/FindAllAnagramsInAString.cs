using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode 438 - https://leetcode.com/problems/find-all-anagrams-in-a-string
    // Submission Detail - https://leetcode.com/submissions/detail/136847326/
    // Sliding Window Technique & Counting/Frequency

    public class FindAllAnagramsInAString
    {
        //public static void Main(string[] args)
        //{
        //    FindAllAnagramsInAString f = new FindAllAnagramsInAString();
        //    var output1 = f.FindAnagramsOptimized("cbaebabacd", "abc"); //[0,6]
        //    var output2 = f.FindAnagramsOptimized("abab", "ab"); //[0,1,2]

        //    Console.ReadKey();
        //}

        //Input - s: "cbaebabacd" p: "abc"
        //Output- [0, 6]

        //Input - s: "abab" p: "ab"
        //Output- [0, 1, 2]

        // Tx = O(n) {n : length(s)}.
        // Sx = O(1)
        public IList<int> FindAnagramsOptimized(string s, string p)
        {
            int m = p.Length;
            int n = s.Length;

            IList<int> indices = new List<int>();

            if (n < m)
                return indices;

            int[] sFreq = new int[26];
            int[] pFreq = new int[26];

            // calculate the character frequenices for both s,p.
            CharFrequencies(p, pFreq, 0, m);
            CharFrequencies(s, sFreq, 0, m);

            for (int i = m; i < n; i++)
            {
                if (Compare(pFreq, sFreq))
                    indices.Add(i-m);

                sFreq[s[i]-'a']++;  

                sFreq[s[i - m] - 'a']--;
            }

            if (Compare(pFreq, sFreq))
                indices.Add(n - m);

            return indices;
        }

        //public IList<int> FindAnagrams(string s, string p)
        //{
        //    if (s.Length < p.Length)
        //        return null;

        //    IList<int> indices = new List<int>();

        //    int[] sFreq = new int[26];
        //    int[] pFreq = new int[26];

        //    CharFrequencies(p, pFreq, 0, p.Length - 1);

        //    for (int i = 0, j = p.Length - 1; j < s.Length - 1; i++, j++)
        //    {
        //        CharFrequencies(s, sFreq, i, j);

        //        if (Compare(pFreq, sFreq))
        //            indices.Add(i);
        //    }

        //    return indices;
        //}

        private static bool Compare(int[] freq1, int[] freq2)
        {
            for (int i = 0; i < freq1.Length; i++)
            {
                if (freq1[i] != freq2[i])
                    return false;
            }

            return true;
        }

        private static void CharFrequencies(string s, int[] freq, int start, int end)
        {
            while (start < end)
            {
                freq[s[start++] - 'a']++;                
            }
            //foreach (char c in s)
            //    freq[c - 'a']++;
        }
    }
}
