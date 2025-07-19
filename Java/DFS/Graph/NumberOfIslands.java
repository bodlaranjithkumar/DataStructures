package DFS.Graph;

public class NumberOfIslands {
    // Leetcode 200: https://leetcode.com/problems/number-of-islands/

    //Example 1:
    //Input: grid = [
    //                ["1","1","1","1","0"],
    //                ["1","1","0","1","0"],
    //                ["1","1","0","0","0"],
    //                ["0","0","0","0","0"]
    //             ]
    //Output: 1

    //Example 2:
    //Input: grid = [
    //                ["1","1","0","0","0"],
    //                ["1","1","0","0","0"],
    //                ["0","0","1","0","0"],
    //                ["0","0","0","1","1"]
    //              ]
    //Output: 3

    // Submission Detail: https://leetcode.com/problems/number-of-islands/submissions/1703925135
    // Tx = O(m*n)
    // Sx = O(1)
    public int numIslandsSpaceOptimized(char[][] grid) {
        int count = 0;

        for(int row=0; row<grid.length; row++) {
            for(int col=0; col<grid[0].length; col++) {
                if(grid[row][col] == '1') {
                    count++;
                    dfs(grid, row, col);
                }
            }
        }

        return count;
    }

    private void dfs(char[][] grid, int row, int col) {
        // Base Case
        if(row < 0 || row >= grid.length || col < 0 || col >= grid[0].length
                || grid[row][col] != '1')
            return;

        grid[row][col] = '0';
        dfs(grid, row+1, col); // go down
        dfs(grid, row-1, col); // go up
        dfs(grid, row, col+1); // go right
        dfs(grid, row, col-1); // go left
    }

    // Submission Detail: https://leetcode.com/problems/number-of-islands/submissions/1703920298
    // Tx = O(m*n)
    // Sx = O(m*n)
    public int numIslands(char[][] grid) {
        boolean[][] visited = new boolean[grid.length][grid[0].length];
        int count = 0;

        for(int row=0; row<grid.length; row++) {
            for(int col=0; col<grid[0].length; col++) {
                if(!visited[row][col] && grid[row][col] == '1') {
                    count++;
                    dfs(grid, row, col, visited);
                }
            }
        }

        return count;
    }

    private void dfs(char[][] grid, int row, int col, boolean[][] visited) {
        // Base Case
        if(row < 0 || row >= grid.length || col < 0 || col >= grid[0].length
                || visited[row][col] || grid[row][col] != '1')
            return;

        visited[row][col] = true;
        dfs(grid, row+1, col, visited); // go down
        dfs(grid, row-1, col, visited); // go up
        dfs(grid, row, col+1, visited); // go right
        dfs(grid, row, col-1, visited); // go left
    }
}
