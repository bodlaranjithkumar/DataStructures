using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.Trie
{
    // Leetcode 208 - https://leetcode.com/problems/implement-trie-prefix-tree/description/
    // Submission Detail - https://leetcode.com/submissions/detail/137204060/

    public class Trie
    {
        //public static void Main(string[] args)
        //{
        //    Trie trie = new Trie();
        //    trie.Insert("there");
        //    trie.Insert("their");
        //    trie.Insert("answer");
        //    trie.Insert("any");
        //    trie.Insert("a");
        //    trie.Insert("by");
        //    trie.Insert("bye");

        //    bool search1 = trie.Search("the");
        //    bool search2 = trie.Search("theirs");
        //    bool search3 = trie.Search("answer");
        //    bool search4 = trie.Search("there");
        //    bool search5 = trie.Search("answe");

        //    bool startswith1 = trie.StartsWith("an");
        //    bool startswith2 = trie.StartsWith("the");
        //    bool startswith3 = trie.StartsWith("bye");
        //}

        TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        // Tx = O(n) {n = length of the word}
        // Sx = O(n) worst case
        // Sx = O(1) best case
        public void Insert(string word)
        {
            TrieNode node = root;

            for (int i = 0; i < word.Length; i++)
            {
                int level = word[i] - 'a';

                if (node.Children[level] == null)
                    node.Children[level] = new TrieNode();

                node = node.Children[level];
            }

            node.IsEndOfWord = true;
        }

        /** Returns if the word is in the trie. */
        // Tx = O(n)
        // Sx = O(1)
        public bool Search(string word)
        {
            TrieNode node = root;

            for (int i = 0; i < word.Length; i++)
            {
                int level = word[i] - 'a';

                if (node.Children[level] == null)
                    return false;

                node = node.Children[level];
            }

            return node.IsEndOfWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        // Tx = O(n)
        // Sx = O(1)
        public bool StartsWith(string prefix)
        {
            TrieNode node = root;

            for (int i = 0; i < prefix.Length; i++)
            {
                int level = prefix[i] - 'a';

                if (node.Children[level] == null)
                    return false;

                node = node.Children[level];
            }

            return true;
            //return node != null && (node.IsEndOfWord || node.Children.Any(n => n != null));
        }
    }
}
