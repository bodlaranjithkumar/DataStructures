using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;

namespace LeetcodeSolutions.Patterns.DFS
{
    // Leetcode 133 - https://leetcode.com/problems/clone-graph/description
    // Submission Detail - https://leetcode.com/submissions/detail/140663824/

    // Example : {0,1,2#1,2#2,2}    // # is the delimiter for nodes and , is for neighbors
    //   1
    //  / \
    // /   \
    //0 --- 2
    //     / \
    //     \_/

    public class GraphClone
    {
        // Using BFS
        // Tx = O(n)
        // Sx = O(n)
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null)
                return node;

            Queue<UndirectedGraphNode> nodes = new Queue<UndirectedGraphNode>();
            nodes.Enqueue(node);

            IDictionary<UndirectedGraphNode, UndirectedGraphNode> clone = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();
            clone.Add(node, new UndirectedGraphNode(node.label));

            while (nodes.Count > 0)
            {
                var curr = nodes.Dequeue();

                foreach (var neighbor in curr.neighbors)
                {
                    if (!clone.ContainsKey(curr))
                    {
                        clone.Add(neighbor, new UndirectedGraphNode(neighbor.label));
                        nodes.Enqueue(neighbor);
                    }

                    clone[curr].neighbors.Add(neighbor);
                }
            }

            return clone[node];
        }

        private Dictionary<UndirectedGraphNode, UndirectedGraphNode> nodes = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();

        // Using DFS
        // Tx = O(n)
        // Sx = O(n)
        // Caveat: Possibility of stack overflow exception.
        public UndirectedGraphNode CloneGraphDFS(UndirectedGraphNode node)
        {
            return Clone(node);
        }

        private UndirectedGraphNode Clone(UndirectedGraphNode node)
        {
            if (node == null)
                return node;

            if (nodes.ContainsKey(node))
                return nodes[node];

            UndirectedGraphNode clone = new UndirectedGraphNode(node.label);
            nodes.Add(node, clone);
            foreach(var curr in node.neighbors)
            {
                clone.neighbors.Add(Clone(curr));
            }

            return clone;
        }
    }
}
