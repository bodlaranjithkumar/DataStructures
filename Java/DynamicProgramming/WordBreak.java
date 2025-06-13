package DynamicProgramming;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class WordBreak {
    // Leetcode 139: https://leetcode.com/problems/word-break/description/
    // Submission Detail:

    //Input: s = "leetcode", wordDict = ["leet","code"]
    //Output: true
    //Explanation: Return true because "leetcode" can be segmented as "leet code".

    //Input: s = "applepenapple", wordDict = ["apple","pen"]
    //Output: true
    //Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
    //Note that you are allowed to reuse a dictionary word.

    //Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
    //Output: false

    // Tx = O(n*m)
    // Sx = O(n)
    public boolean wordBreak(String s, List<String> wordDict) {
        Set<String> words = new HashSet<>(wordDict); // copying for constant lookup instead of linear time with lists

        boolean[] dp = new boolean[s.length()+1];
        dp[0] = true; //empty string can always be assumed to exist in the list

        for(int i=1; i<dp.length; i++) {
            for(int j=0; j<i; j++) {
                String substring = s.substring(j, i);
                if(dp[j] && words.contains(substring)) {
                    dp[i] = true;   // indicates that string till index "i" can be segmented
                }
            }
        }

        return dp[dp.length-1];
    }
}
