package DFS.Graph;

public class FloodHill {
    // Leetcode 733: https://leetcode.com/problems/flood-fill/
    // Submission Detail: https://leetcode.com/problems/flood-fill/submissions/1703891356

    //Example 1:
    //Input: image = [[1,1,1],[1,1,0],[1,0,1]], sr = 1, sc = 1, color = 2
    //Output: [[2,2,2],[2,2,0],[2,0,1]]

    //Example 2:
    //Input: image = [[0,0,0],[0,0,0]], sr = 0, sc = 0, color = 0
    //Output: [[0,0,0],[0,0,0]]
    //Explanation:
    //The starting pixel is already colored with 0, which is the same as the target color. Therefore, no changes are made to the image.

    // Edge Case: Need visited to handle the edge case where the color values is the same as the pixel value.
    // Tx = O(m*n) for call stack
    // Sx = O(m*n) for visited
    public int[][] floodFill(int[][] image, int sr, int sc, int color) {
        boolean[][] visited = new boolean[image.length][image[0].length];
        dfs(image, sr, sc, image[sr][sc], color, visited);

        return image;
    }

    private void dfs(int[][] image, int sr, int sc, int pixelValue, int color, boolean[][] visited) {
        if(sr < 0 || sr >= image.length || sc < 0 || sc >= image[0].length
                || image[sr][sc] != pixelValue || visited[sr][sc])
            return;

        image[sr][sc] = color;
        visited[sr][sc] = true;
        dfs(image, sr+1, sc, pixelValue, color, visited); // go down
        dfs(image, sr-1, sc, pixelValue, color, visited); // go up
        dfs(image, sr, sc+1, pixelValue, color, visited); // go right
        dfs(image, sr, sc-1, pixelValue, color, visited); // go left
    }
}
