package DFS.Graph;

import java.util.*;

public class GraphValidTree {
    // Neetcode 150: https://neetcode.io/problems/valid-tree


    // Example 1
    // Input: n = 5 and edges = [[0, 1], [1, 2], [2, 3], [1, 3], [1, 4]]
    // Output: false

    // Example 2
    // Input: n = 4 and edges = [[0, 1], [2, 3]]
    // Output: false

    // Example 3
    // Input: n = 5 and edges = [[0, 1], [1, 2], [1, 3], [1, 4]]
    // Output: true

    public boolean validTree(int n, int[][] edges) {
        if(edges.length == 0)
            return true;

        // Step 1: Build adjacency list
        Map<Integer, List<Integer>> adjList = buildAdjacencyList(n, edges);

        // Step 2: Check for cycles
        Set<Integer> visited = new HashSet<>();
        if(hasCycle(0, -1, visited, adjList))
            return false;

        // Step 3: In addition to cycles check if all the nodes are visited checking if connected graph
        return visited.size() == n;
    }

    private Map<Integer, List<Integer>> buildAdjacencyList(int n, int[][] edges) {
        Map<Integer, List<Integer>> adjList = new HashMap<>(n);

        for(int[] edge: edges) {
            List<Integer> adjNodes = adjList.getOrDefault(edge[0], new ArrayList<>());
            adjNodes.add(edge[1]);
            adjList.put(edge[0], adjNodes);

            List<Integer> adjNodes1 = adjList.getOrDefault(edge[1], new ArrayList<>());
            adjNodes1.add(edge[0]);
            adjList.put(edge[1], adjNodes1);
        }

        return adjList;
    }

    private boolean hasCycle(int node, int parentNode, Set<Integer> visited, Map<Integer, List<Integer>> adjList) {
        visited.add(node);

        for(Integer neighbor: adjList.get(node)) {
            if(visited.contains(neighbor) && neighbor != parentNode)
                return true;
            else if(!visited.contains(neighbor) && hasCycle(neighbor, node, visited, adjList))
                return true;
        }

        return false;
    }
}
