package DynamicProgramming;

public class MaximalSquare {
    // Leetcode 221: https://leetcode.com/problems/maximal-square/
    // Submission Detail: https://leetcode.com/problems/maximal-square/submissions/1662352230
    // Explanation: https://www.hellointerview.com/learn/code/dynamic-programming/maximal-square
    // Intuition is that the bottom ending side of the square has a value of min of it's (top, left, diagonal)+1 and if this value is the maxSideSeenSoFar.

    //Input: matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
    //Output: 4

    //Input: matrix = [["0","1"],["1","0"]]
    //Output: 1

    //Input: matrix = [["0"]]
    //Output: 0

    // Tx = O(m*n)
    // Sx = O(m*n)
    public int maximalSquare(char[][] matrix) {
        int rows = matrix.length;
        int cols = matrix[0].length;
        int[][] dp = new int[rows+1][cols+1];
        int maxSide = 0;

        for(int row=1; row<rows+1; row++) {
            for(int col=1; col<cols+1; col++) {
                if(matrix[row-1][col-1] == '1') {
                    int top = dp[row-1][col];
                    int left = dp[row][col-1];
                    int diagonal = dp[row-1][col-1];
                    dp[row][col] = Math.min(Math.min(top, left), diagonal)+1;
                    maxSide = Math.max(maxSide, dp[row][col]);
                }
            }
        }

        return maxSide * maxSide;
    }
}
