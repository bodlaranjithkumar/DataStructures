package DFS.Graph;

import java.util.ArrayList;
import java.util.List;

public class PacificAtlanticFlow {
    // Leetcode 417: https://leetcode.com/problems/pacific-atlantic-water-flow/description/
    // Submission Detail: https://leetcode.com/problems/pacific-atlantic-water-flow/submissions/1704098571

    //Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
    //Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
    //Explanation: The following cells can flow to the Pacific and Atlantic oceans, as shown below:
    //                [0,4]: [0,4] -> Pacific Ocean
    //                [0,4] -> Atlantic Ocean
    //                [1,3]: [1,3] -> [0,3] -> Pacific Ocean
    //                [1,3] -> [1,4] -> Atlantic Ocean
    //                [1,4]: [1,4] -> [1,3] -> [0,3] -> Pacific Ocean
    //                [1,4] -> Atlantic Ocean
    //                [2,2]: [2,2] -> [1,2] -> [0,2] -> Pacific Ocean
    //                [2,2] -> [2,3] -> [2,4] -> Atlantic Ocean
    //                [3,0]: [3,0] -> Pacific Ocean
    //                [3,0] -> [4,0] -> Atlantic Ocean
    //                [3,1]: [3,1] -> [3,0] -> Pacific Ocean
    //                [3,1] -> [4,1] -> Atlantic Ocean
    //                [4,0]: [4,0] -> Pacific Ocean
    //                [4,0] -> Atlantic Ocean
    //Note that there are other possible paths for these cells to flow to the Pacific and Atlantic oceans.

    //Example 2:
    //
    //Input: heights = [[1]]
    //Output: [[0,0]]
    //Explanation: The water can flow from the only cell to the Pacific and Atlantic oceans.

    // Tx = O(m*n)
    // Sx = O(m*n)
    public List<List<Integer>> pacificAtlantic(int[][] heights) {
        int rows = heights.length, cols = heights[0].length;
        boolean[][] pacific = new boolean[rows][cols];
        boolean[][] atlantic = new boolean[rows][cols];

        // Step 1: Start from the row boundaries: row 0 is pacific and row n-1 is atlantic
        for(int col=0; col<cols; col++) {
            dfs(heights, 0, col, heights[0][col], pacific);
            dfs(heights, rows-1, col, heights[rows-1][col], atlantic);
        }

        // Step 2: Start from the col boundaries: col 0 is pacific and col n-1 is atlantic
        for(int row = 0; row <rows; row++) {
            dfs(heights, row, 0, heights[row][0], pacific);
            dfs(heights, row, cols-1, heights[row][cols-1], atlantic);
        }

        List<List<Integer>> result = new ArrayList<>();
        // Step 3: Find the intersection of cells that can reach both pacific and atlantic ocean
        for(int row=0; row<rows; row++) {
            for(int col=0; col<cols; col++) {
                if(pacific[row][col] && atlantic[row][col]) {
                    result.add(List.of(row, col));
                }
            }
        }

        return result;
    }

    private void dfs(int[][] heights, int row, int col, int neighborHeight, boolean[][] visited) {
        // Base Case
        if(row < 0 || row >= heights.length || col < 0 || col >= heights[0].length || visited[row][col] || neighborHeight > heights[row][col])
            return;

        int currentHeight = heights[row][col];
        visited[row][col] = true;

        dfs(heights, row-1, col, currentHeight, visited); // go up
        dfs(heights, row, col-1, currentHeight, visited); // go left
        dfs(heights, row+1, col, currentHeight, visited); // go down
        dfs(heights, row, col+1, currentHeight, visited); // go right
    }
}
