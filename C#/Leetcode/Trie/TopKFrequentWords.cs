using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Trie
{
    // Leetcode 692
    // Submission Detail: https://leetcode.com/submissions/detail/170057850/

    public class TopKFrequentWords
    {
        //public static void Main(string[] args)
        //{
        //    TopKFrequentWords topKFrequentWords = new TopKFrequentWords();

        //    string[] words1 = { "a", "aa", "aaa" };

        //    Helper.PrintListElements<string>(topKFrequentWords.TopKFrequent(words1, 2)); // a, aa
        //}

        TrieNode root = new TrieNode();
        IDictionary<string, int> wordsFrequency = new Dictionary<string, int>();
        IList<string>[] frequencyWords;
        IList<string> KFrequentWords = new List<string>();
        int maxFrequency;

        public IList<string> TopKFrequent(string[] words, int k)
        {

            foreach (var word in words)
            {
                if (!wordsFrequency.ContainsKey(word))
                    wordsFrequency.Add(word, 0);

                wordsFrequency[word]++;
                maxFrequency = System.Math.Max(wordsFrequency[word], maxFrequency);
            }

            foreach (var word in wordsFrequency.Keys)
            {
                CreateTrie(word, wordsFrequency[word]);
            }

            frequencyWords = new List<string>[maxFrequency + 1];

            GroupWordsWithSameFrequency(root);

            FindTopKFrequentWords(k);

            return KFrequentWords;
        }

        private void FindTopKFrequentWords(int k)
        {
            for (int i = frequencyWords.Length - 1; i >= 0; i--)
            {
                IList<string> words = frequencyWords[i];

                if (words != null)
                {
                    foreach (var word in words)
                    {
                        if (KFrequentWords.Count == k)
                            return;

                        KFrequentWords.Add(word);
                    }
                }
            }
        }

        private void GroupWordsWithSameFrequency(TrieNode curr)
        {
            if (curr.IsEndOfWord)
            {
                if (frequencyWords[curr.Frequency] == null)
                    frequencyWords[curr.Frequency] = new List<string>();

                frequencyWords[curr.Frequency].Add(curr.Word);
                //return;   Do not return as we may find words further down. Example: a, aa, aaa
            }

            for (int i = 0; i < curr.Children.Length; i++)
            {
                if (curr.Children[i] != null)
                    GroupWordsWithSameFrequency(curr.Children[i]);
            }
        }

        private void CreateTrie(string word, int freq)
        {
            TrieNode curr = root;

            foreach (char c in word)
            {
                if (curr.Children[c - 'a'] == null)
                    curr.Children[c - 'a'] = new TrieNode();

                curr = curr.Children[c - 'a'];
            }

            curr.Word = word;
            curr.Frequency = freq;
            curr.IsEndOfWord = true;
        }

        public class TrieNode
        {
            public string Word;
            public int Frequency;
            public bool IsEndOfWord;
            public TrieNode[] Children;

            public TrieNode()
            {
                Children = new TrieNode[26];
            }
        }
    }
}
