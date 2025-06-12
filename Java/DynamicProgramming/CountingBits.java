package DynamicProgramming;

public class CountingBits {
    // Leetcode 338: https://leetcode.com/problems/counting-bits/description/
    // Submission Detail: https://leetcode.com/problems/counting-bits/submissions/1661539094

    public int[] countBits(int n) {
        int[] dp = new int[n+1];
        dp[0] = 0; // number 0 has zero 1 bits

        for(int i=1;i<=n; i++) {
            // i/2 is the quotient
            // i%2 is the remainder which tells about the least significant bit being 0/1.
            dp[i] = dp[i/2] + (i%2);
        }

        return dp;
    }
}
