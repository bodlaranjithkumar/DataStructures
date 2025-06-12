package DynamicProgramming;

public class DecodeWays {
    // Leetcode 91: https://leetcode.com/problems/decode-ways/
    // Submission Detail: https://leetcode.com/problems/decode-ways/submissions/1662231568

    //Input: s = "12"
    //Output: 2
    //Explanation:
    //        "12" could be decoded as "AB" (1 2) or "L" (12).

    //Input: s = "226"
    //Output: 3
    //Explanation:
    //        "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).

    //Input: s = "06"
    //Output: 0
    //Explanation:
    //        "06" cannot be mapped to "F" because of the leading zero ("6" is different from "06"). In this case, the string is not a valid encoding, so return 0.

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
