using sys = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 49
    // Submission Detail: https://leetcode.com/submissions/detail/168055013/

    // Counting & Dictionary
    public class GroupAnagrams
    {
        // Input = ["eat", "tea", "tan", "ate", "nat", "bat"]
        // Output = [ ["ate", "eat","tea"], ["nat","tan"], ["bat"]]
        // Runtime = 545 ms


        // Optimization: Instead of sorting each word, count the number of characters and create a string 
        //              with a combination of the character and frequency appended next to each other 
        //              like a2-b3-c0.........z1 . Use this as the dictionary key. 
        //              This brings down the time complexity to O(k*n)
        public IList<IList<string>> GroupAnagramsOptimal(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return new List<IList<string>>();

            IDictionary<string, IList<string>> groupedAnagrams = new Dictionary<string, IList<string>>();

            int[] charCount = new int[26];

            foreach (string str in strs)
            {
                Fill(charCount, 0);

                foreach (char c in str)
                    charCount[c - 'a']++;

                StringBuilder anagramKey = new StringBuilder();

                for (int i = 0; i < charCount.Length; i++)
                    anagramKey.Append('a' + i).Append(charCount[i]).Append('-');

                string key = anagramKey.ToString();

                if (!groupedAnagrams.ContainsKey(key))
                    groupedAnagrams.Add(key, new List<string>());

                groupedAnagrams[key].Add(str);
            }

            return groupedAnagrams.Values.ToList();
        }

        private static void Fill<T>(T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = value;
        }

        // Bruteforce Solution 
        // Tx = O(m * nlogn) {m: length of strs, n: length of a string in the collection}
        // Sx = O(m)
        public IList<IList<string>> GroupAnagramsBruteforce(string[] strs)
        {
            Dictionary<string, IList<string>> result = new Dictionary<string, IList<string>>();

            foreach (string str in strs)
            {
                char[] chars = str.ToCharArray();
                sys.Array.Sort(chars);
                string sortedStr = new sys.String(chars);

                if (result.Keys.Contains(sortedStr))
                {
                    result[sortedStr].Add(str);
                }
                else
                {
                    result[sortedStr] = new List<string> { str };
                }
            }

            return result.Values.ToList();
        }
    }
}
