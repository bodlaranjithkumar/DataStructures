package BFS.Graph;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Set;

public class MinimumKnightMoves {
    // Leetcode 1197: https://leetcode.com/problems/minimum-knight-moves/

    // Input: (x = 1,y = 2)
    // Output: 1

    // Input: (x = 4,y = 4)
    // Output: 4

    // Tx = O(m*n) where m and n are the dimensions of the chessboard
    // Sx = O(m*n)
    public int minimumKnightMoves(int x, int y) {
        int[][] gridMoves = {{2,1}, {2,-1}, {-2,1}, {-2,-1},
                        {1,2}, {1,-2}, {-1,2}, {-1,-2}};

        Queue<int[]> nodes = new LinkedList<>();
        nodes.add(new int[]{0,0,0}); //(x,y) is index and z is number of moves so far to reach (x,y)

        Set<String> visited = new HashSet<>();
        visited.add(0 + "," + 0);

        while(!nodes.isEmpty()) {
            int[] node = nodes.poll();
            int nodeX = node[0], nodeY = node[1], moveCount = node[2];

            if(nodeX == x && nodeY == y) {
                return moveCount;
            }

            for(int[] gridMove: gridMoves) {
                int adjNodeX = nodeX + gridMove[0];
                int adjNodeY = nodeY + gridMove[1];
                String adjNode = adjNodeX + "," + adjNodeY;

                if(!visited.contains(adjNode)) {
                    visited.add(adjNode);
                    nodes.add(new int[] {adjNodeX, adjNodeY, moveCount+1});
                }
            }
        }

        return -1;
    }
}
