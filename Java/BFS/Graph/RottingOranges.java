package BFS.Graph;

import java.util.LinkedList;
import java.util.Queue;

public class RottingOranges {
    // Leetcode 994: https://leetcode.com/problems/rotting-oranges/
    // Submission Detail: https://leetcode.com/problems/rotting-oranges/submissions/1711523845

    //Example 1:
    //Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
    //Output: 4

    //Example 2:
    //Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
    //Output: -1
    //Explanation: The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.

    //Example 3:
    //Input: grid = [[0,2]]
    //Output: 0
    //Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.

    public int orangesRotting(int[][] grid) {
        int freshOrangesCount = 0, minutes = 0;

        Queue<int[]> rottenOranges = new LinkedList<>();

        // Step 1: Iterate through grid and count freshOranges, queue all the rotten oranges
        for(int row=0; row<grid.length; row++) {
            for(int col=0; col<grid[0].length; col++) {
                if(grid[row][col] == 1)
                    freshOrangesCount++;
                else if(grid[row][col] == 2)
                    rottenOranges.offer(new int[]{row, col});
            }
        }

        int[][] directions = {{0,1},{0,-1},{1,0},{-1,0}};

        // Step 2: Iterate through rottenOranges queue and mark adjacent ones rotten per minute and do it repeatedly for the new rotten.
        while(!rottenOranges.isEmpty() && freshOrangesCount > 0) {
            int levelSize = rottenOranges.size();
            minutes++;

            for(int i=0; i<levelSize; i++) {
                int[] currentRottenOrange = rottenOranges.poll();

                for(int[] direction:directions) {
                    int adjRow = currentRottenOrange[0]+direction[0];
                    int adjCol = currentRottenOrange[1]+direction[1];

                    if(adjRow >= 0 && adjCol >= 0 && adjRow < grid.length && adjCol < grid[0].length && grid[adjRow][adjCol] == 1) {
                        grid[adjRow][adjCol] = 2;
                        freshOrangesCount--;
                        rottenOranges.offer(new int[]{adjRow, adjCol});
                    }
                }
            }
        }

        return freshOrangesCount == 0 ? minutes : -1;
    }
}
