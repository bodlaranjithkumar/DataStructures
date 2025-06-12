package DynamicProgramming;

public class UniquePaths {
    // Leetcode 62: https://leetcode.com/problems/unique-paths/
    // Submission Detail: https://leetcode.com/problems/unique-paths/submissions/1662256127

    //Input: m = 3, n = 7
    //Output: 28

    //Input: m = 3, n = 2
    //Output: 3
    //Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
    //          1. Right -> Down -> Down
    //          2. Down -> Down -> Right
    //          3. Down -> Right -> Down

    // Tx = O(m*n)
    // Sx = O(m*n)
    public int uniquePaths(int m, int n) {
        int[][] dp = new int[m][n];

        // All first column values are 1
        for (int i = 0; i < m; i++) {
            dp[i][0] = 1;
        }

        // All first row values are 1
        for (int j = 0; j < n; j++) {
            dp[0][j] = 1;
        }

        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {
                int top = dp[i-1][j];
                int left = dp[i][j-1];
                dp[i][j] = left + top;
            }
        }

        return dp[m-1][n-1];
    }
}
