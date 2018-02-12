using sys = System;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeSolutions.String
{
    // Leetcode 49
    // Sort & Dictionary
    class GroupAnagrams
    {
        // Input = ["eat", "tea", "tan", "ate", "nat", "bat"]
        // Output = [ ["ate", "eat","tea"], ["nat","tan"], ["bat"]]
        // Runtime = 545 ms
        // Tx = O(m * nlogn) {m: length of strs, n: length of a string in the collection}
        // Sx = O(m)
        public IList<IList<string>> GroupAnagramss(string[] strs)
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
