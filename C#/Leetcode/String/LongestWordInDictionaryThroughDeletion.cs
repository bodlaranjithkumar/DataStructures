using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode 524 - https://leetcode.com/problems/longest-word-in-dictionary-through-deleting/description/
    // Submission Detail - https://leetcode.com/submissions/detail/141833363/
    // Comparision problem

    public class LongestWordInDictionaryThroughDeletion
    {
        // Input: s = "abpcplea", d = ["ale","apple","monkey","plea"]
        // Output: "apple"

        // Input: s = "abpcplea", d = ["apple","abple","monkey","plea"]
        // Output: "abple"

        // Intput: s = "abpcplea", d = ["z","y","x","d"]
        // Output: ""

        // Tx = O(n * k) {n: d.Count, k: s.Length}
        // Sx = O(k) for longest string    
        public string FindLongestWord(string s, IList<string> d)
        {
            string longest = string.Empty;

            foreach (string word in d)
            {
                int i = 0;

                // count number of characters in the current dictionary word present in sequence in s.
                foreach (char c in s)
                    if (i < word.Length && c == word[i])
                        i++;

                // check if the current word in dictionary is a subsequence of s
                // and if the word length is >= longest length.aa
                // = condition is required to check lexicographical order (compareTo in nested if)
                if (i == word.Length && word.Length >= longest.Length)
                    if (word.Length > longest.Length || word.CompareTo(longest) < 0)
                        longest = word;
            }

            return longest;
        }
    }
}
