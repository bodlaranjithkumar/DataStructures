package Stack;

import java.util.Stack;

public class LongestValidParantheses {
    // Leetcode 32: https://leetcode.com/problems/longest-valid-parentheses/description/
    // Submission Detail: https://leetcode.com/problems/longest-valid-parentheses/submissions/1660097513
    // Good explanation: https://www.hellointerview.com/learn/code/stack/longest-valid-parentheses

    //    Input: s = "(()"
    //    Output: 2
    //    Explanation: The longest valid parentheses substring is "()".
    //
    //    Input: s = ")()())"
    //    Output: 4
    //    Explanation: The longest valid parentheses substring is "()()".
    //
    //    Input: s = ""
    //    Output: 0

    // Tx = O(n)
    // Sx = O(n)
    public int longestValidParentheses(String s) {
        Stack<Integer> stack = new Stack<>();
        stack.push(-1);
        int maxLength = 0;

        for(int index = 0; index < s.length(); index++) {
            char ch = s.charAt(index);

            if(ch == '(') {
                stack.push(index);
            } else {
                int top = stack.pop();

                if(stack.isEmpty()) {
                    stack.push(index); // start of the new valid substring
                } else {
                    maxLength = Math.max(maxLength, index - stack.peek());
                }
            }
        }

        return maxLength;
    }
}
