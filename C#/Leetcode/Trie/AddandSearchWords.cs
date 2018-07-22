using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Trie
{
    // Leetcode 211
    // Submission Detail: https://leetcode.com/submissions/detail/165119811/
    public class AddandSearchWords
    {
        //      Input:["WordDictionary","addWord","addWord","addWord","search","search","search","search","search"]
        //            [[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."],[".ac"]]
        //      Output:[null,null,null,null,false,true,true,true,false]
        //      Expected:[null,null,null,null,false,true,true,true,false]

        //      Input:["WordDictionary","addWord","addWord","search","search","search","search","search","search"]
        //           [[],["a"],["a"],["."],["a"],["aa"],["a"],[".a"],["a."]]
        //      Output:  [null,null,null,true,true,false,true,false,false]
        //      Expected:[null,null,null,true,true,false,true,false,false]

        //      Input: ["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
        //             [[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
        //      Output:   [null,null,null,null,false,true,true,false]
        //      Expected: [null,null,null,null,false,true,true,true]

        private static int Size = 26;   // Alphabets a-z count

        private TrieNode root;
        /** Initialize your data structure here. */
        public AddandSearchWords()
        {
            root = new TrieNode();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            TrieNode node = root;

            foreach (char c in word)
            {
                int level = c - 'a';

                if (node.Children[level] == null)
                    node.Children[level] = new TrieNode();

                node = node.Children[level];
            }

            node.IsEndOfWord = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return Search(word, 0, root);
        }

        private bool Search(string word, int index, TrieNode node)
        {
            for (int i = index; i < word.Length; i++)
            {
                char c = word[i];

                if (c == '.')
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (node.Children[j] != null)
                            if (Search(word, i + 1, node.Children[j]))
                                return true;
                    }

                    return false;
                }
                else
                {
                    int level = c - 'a';

                    if (node.Children[level] == null)
                        return false;

                    node = node.Children[level];
                }
            }

            return node.IsEndOfWord;
        }
    }
}
