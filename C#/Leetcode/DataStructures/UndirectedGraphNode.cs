using System.Collections.Generic;

namespace LeetcodeSolutions.DataStructures
{
    public class UndirectedGraphNode
    {
        public int label { get; set; }
        public IList<UndirectedGraphNode> neighbors { get; set; }

        public UndirectedGraphNode(int value)
        {
            label = value;
            neighbors = new List<UndirectedGraphNode>();
        }
    }
}
