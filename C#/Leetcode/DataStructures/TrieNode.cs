using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.DataStructures
{
    public class TrieNode
    {
        private static int AlphabetSize = 26;

        public TrieNode[] Children;

        public bool IsEndOfWord = false;

        public TrieNode()
        {
            Children = new TrieNode[AlphabetSize];

            for (int i = 0; i < AlphabetSize; i++)
                Children[i] = null;
        }

        public TrieNode(int alphabetSize) : this()
        {
            AlphabetSize = alphabetSize;
        }
    }
}
