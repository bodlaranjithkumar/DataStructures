package DFS.Graph;

import DataStructures.Node;

import java.util.HashMap;
import java.util.Map;

public class CloneGraph {
    // Leetcode 133: https://leetcode.com/problems/clone-graph/
    // Submission Detail: https://leetcode.com/problems/clone-graph/submissions/1702904479

    //Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
    //Output: [[2,4],[1,3],[2,4],[1,3]]
    //Explanation: There are 4 nodes in the graph.
    //        1st node (val = 1)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
    //        2nd node (val = 2)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
    //        3rd node (val = 3)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
    //        4th node (val = 4)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).

    //Input: adjList = [[]]
    //Output: [[]]
    //Explanation: Note that the input contains one empty list. The graph consists of only one node with val = 1 and it does not have any neighbors.

    //Input: adjList = []
    //Output: []
    //Explanation: This an empty graph, it does not have any nodes.

    public Node cloneGraph(Node node) {
        if(node == null)
            return node;

        Map<Node, Node> visitedNodes = new HashMap<>();
        return dfs(node, visitedNodes);
    }

    private Node dfs(Node node, Map<Node, Node> visitedNodes) {
        if(visitedNodes.containsKey(node))
            return visitedNodes.get(node);

        Node clonedNode = new Node(node.val);
        visitedNodes.put(node, clonedNode);

        for(Node neighborNode: node.neighbors) {
            Node clonedNeighborNode = dfs(neighborNode, visitedNodes);
            clonedNode.neighbors.add(clonedNeighborNode);
        }

        return clonedNode;
    }
}
