using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetcodeSolutions.String
{
    // Leetcode 819 - https://leetcode.com/problems/most-common-word/description/
    // Submission Detail - https://leetcode.com/submissions/detail/163003918/

    public class MostCommonWord
    {
        public string FindMostCommonWord(string paragraph, string[] banned)
        {
            HashSet<string> bannedWords = new HashSet<string>(banned);
            string[] words = Regex.Split(paragraph, "[^a-zA-Z]");
            IDictionary<string, int> wordFrequency = new Dictionary<string, int>();

            int maxFrequency = 0;
            foreach (string w in words)
            {
                string word = w.ToLower();
                if (bannedWords.Contains(word) || string.IsNullOrWhiteSpace(word)) continue;

                if (!wordFrequency.ContainsKey(word))
                    wordFrequency.Add(word, 0);

                wordFrequency[word]++;

                maxFrequency = System.Math.Max(maxFrequency, wordFrequency[word]);
            }

            string wordWithMaxFrequency = " ";
            foreach (string word in wordFrequency.Keys)
            {
                if (wordFrequency[word] == maxFrequency)
                    wordWithMaxFrequency = word;
            }

            return wordWithMaxFrequency;
        }
    }
}
