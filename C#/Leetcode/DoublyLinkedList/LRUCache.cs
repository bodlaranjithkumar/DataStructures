using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.DoublyLinkedList
{
    // Leetcode 146 - https://leetcode.com/problems/lru-cache/
    // Submission Detail - https://leetcode.com/submissions/detail/170193604/
    // Ref: https://medium.com/@krishankantsinghal/my-first-blog-on-medium-583159139237

    public class LRUCache
    {
        private class DoublyLinkedListNode
        {
            public int Key;
            public int Value;
            public DoublyLinkedListNode Left;
            public DoublyLinkedListNode Right;
        }

        IDictionary<int, DoublyLinkedListNode> cache;
        DoublyLinkedListNode start;
        DoublyLinkedListNode end;
        int capacity;

        public LRUCache(int cap)
        {
            cache = new Dictionary<int, DoublyLinkedListNode>(capacity);
            capacity = cap;
        }

        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                var node = cache[key];

                RemoveNode(node);
                AddNodeAtTop(node);

                return node.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                var node = cache[key];
                node.Value = value; // if the key already exists, update the value.

                RemoveNode(node);
                AddNodeAtTop(node);
            }
            else
            {
                DoublyLinkedListNode newNode = new DoublyLinkedListNode
                {
                    Key = key,
                    Value = value
                };

                if (cache.Count == capacity)
                {
                    cache.Remove(end.Key);
                    RemoveNode(end);
                }

                AddNodeAtTop(newNode);
                cache.Add(key, newNode);
            }
        }

        private void RemoveNode(DoublyLinkedListNode node)
        {
            // update left pointer - node could be at start or not at start
            if (node.Left != null)
                node.Left.Right = node.Right;
            else
                start = node.Right;

            // update right pointer - node could be at the end or not at end
            if (node.Right != null)
                node.Right.Left = node.Left;
            else
                end = node.Left;
        }

        private void AddNodeAtTop(DoublyLinkedListNode node)
        {
            node.Right = start;
            node.Left = null;

            if (start != null)
                start.Left = node;

            if (end == null) // Empty list
                end = node;

            start = node;
        }
    }
}
