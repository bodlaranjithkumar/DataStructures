using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.DataStructures
{
    public class TrieNode
    {
        private static int AlphabetSize = 26;

        public TrieNode[] Children = new TrieNode[AlphabetSize];

        public bool IsEndOfWord = false;

        public TrieNode()
        {
            for (int i = 0; i < AlphabetSize; i++)
                Children[i] = null;
        }
    }
}
