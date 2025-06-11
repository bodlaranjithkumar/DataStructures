package Stack;

import java.util.Stack;

public class DecodeString {
    // Leetcode 394: https://leetcode.com/problems/decode-string/
    // Submission Detail: https://leetcode.com/problems/decode-string/submissions/1660002062

    //    Input: s = "3[a]2[bc]"
    //    Output: "aaabcbc"
    //
    //    Input: s = "3[a2[c]]"
    //    Output: "accaccacc"
    //
    //    Input: s = "2[abc]3[cd]ef"
    //    Output: "abcabccdcdcdef"

    // Tx = O(n)
    // Sx = O(n)
    public String decodeString(String s) {
        String currentString = "";
        int currentNumber = 0;
        Stack<String> stack = new Stack<>();

        for(int index=0; index<s.length(); index++) {
            char ch = s.charAt(index);

            if(ch == '[') {
                stack.push(currentString);
                stack.push(String.valueOf(currentNumber));
                currentString = "";
                currentNumber = 0;
            } else if(ch == ']') {
                int num = Integer.parseInt(stack.pop());
                String prevString = stack.pop();

                currentString = prevString + currentString.repeat(num);
            } else if(Character.isDigit(ch)) {
                currentNumber = currentNumber * 10 + Character.getNumericValue(ch);
            } else {
                currentString += ch;
            }
        }

        return currentString;
    }
}
