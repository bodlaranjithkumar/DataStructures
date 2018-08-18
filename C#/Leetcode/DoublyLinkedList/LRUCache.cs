using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.DoublyLinkedList
{
    // Leetcode 146
    // Submission Detail: https://leetcode.com/submissions/detail/170193604/
    // Ref: https://medium.com/@krishankantsinghal/my-first-blog-on-medium-583159139237

    public class LRUCache
    {
        public class DoublyLinkedListNode
        {
            public int Key;
            public int Value;
            public DoublyLinkedListNode Left;
            public DoublyLinkedListNode Right;
        }

        IDictionary<int, DoublyLinkedListNode> keyDLLNode;
        DoublyLinkedListNode start;
        DoublyLinkedListNode end;
        int capacity;

        public LRUCache(int cap)
        {
            keyDLLNode = new Dictionary<int, DoublyLinkedListNode>(capacity);
            capacity = cap;
        }

        public int Get(int key)
        {
            if (keyDLLNode.ContainsKey(key))
            {
                var node = keyDLLNode[key];

                RemoveNode(node);
                AddNodeAtTop(node);

                return node.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (keyDLLNode.ContainsKey(key))
            {
                var node = keyDLLNode[key];
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

                if (keyDLLNode.Count == capacity)
                {
                    keyDLLNode.Remove(end.Key);
                    RemoveNode(end);
                }

                AddNodeAtTop(newNode);
                keyDLLNode.Add(key, newNode);
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
