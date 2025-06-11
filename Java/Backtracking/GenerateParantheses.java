package Backtracking;

import java.util.ArrayList;
import java.util.List;

public class GenerateParantheses {
    // Leetcode 22: https://leetcode.com/problems/generate-parentheses/description/
    // Submission Detail: https://leetcode.com/problems/generate-parentheses/submissions/1660507056
    // Observation is in order for the parantheses to be valid, the number of open parantheses should be less than n and number
    // of closed parantheses should be less than open parantheses added to the string so far.

    //Input: n = 3
    //Output: ["((()))","(()())","(())()","()(())","()()()"]

    //Input: n = 1
    //Output: ["()"]

    List<String> result;
    public List<String> generateParenthesis(int n) {
        result = new ArrayList<>();

        backtrack(n, 0, 0, "");

        return result;
    }

    private void backtrack(int n, int open, int close, String s) {
        // Base Case: when the string s's length is equal to 2*n. 2 because of 2 parantheses (open + close)
        if(s.length() == 2*n) {
            result.add(s);
            return;
        }

        // Check the number of open parantheses is less than n. Using stringbuilder because strings are immutable in java.
        if(open < n) {
            backtrack(n, open + 1, close, new StringBuilder(s).append('(').toString());
        }

        // Check the number of closed parantheses is less than open parantheses
        if(close < open) {
            backtrack(n, open, close + 1, new StringBuilder(s).append(')').toString());
        }
    }
}
