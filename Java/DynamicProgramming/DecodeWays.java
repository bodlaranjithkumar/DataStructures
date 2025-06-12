package DynamicProgramming;

public class DecodeWays {
    // Leetcode 91: https://leetcode.com/problems/decode-ways/
    // Submission Detail: https://leetcode.com/problems/decode-ways/submissions/1662231568

    // Tx = O(n)
    // Sx = O(n). Can be further optimized by using 2 variables.
    public int numDecodings(String s) {
        int[] dp = new int[s.length()+1];
        dp[0] = 1;  // one way to do nothing. base case in DP.
        dp[1] = s.charAt(0) == '0' ? 0 : 1;

        for(int i=2; i<dp.length; i++) {
            int singleDigitValue = Integer.valueOf(s.substring(i-1, i));
            if(singleDigitValue != 0)
                dp[i] += dp[i-1];

            int doubleDigitValue = Integer.valueOf(s.substring(i-2, i));
            if(10 <= doubleDigitValue && doubleDigitValue <= 26)
                dp[i] = dp[i-2];
        }

        return dp[s.length()];
    }
}
