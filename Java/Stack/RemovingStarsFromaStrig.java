package Stack;

import java.util.Stack;

public class RemovingStarsFromaStrig {
    // Leetcode 2390: https://leetcode.com/problems/removing-stars-from-a-string/description/?envType=study-plan-v2&envId=leetcode-75

    //Input: s = "leet**cod*e"
    //Output: "lecoe"
    //Explanation: Performing the removals from left to right:
    //        - The closest character to the 1st star is 't' in "leet**cod*e". s becomes "lee*cod*e".
    //        - The closest character to the 2nd star is 'e' in "lee*cod*e". s becomes "lecod*e".
    //        - The closest character to the 3rd star is 'd' in "lecod*e". s becomes "lecoe".
    //There are no more stars, so we return "lecoe".

    //Input: s = "erase*****"
    //Output: ""
    //Explanation: The entire string is removed, so we return an empty string.

    // Submission Detail: https://leetcode.com/problems/removing-stars-from-a-string/submissions/1672080391
    // Tx = O(n)
    // Sx = O(1)
    public String removeStarsInPlace(String s) {
        char[] chars = s.toCharArray();
        int i=0;
        for(char ch:chars) {
            if(ch=='*')
                i--;
            else
                chars[i++]=ch;
        }

        return new String(chars, 0, i);
    }

    // Submission Detail: https://leetcode.com/problems/removing-stars-from-a-string/submissions/1672078522
    // Tx = O(n)
    // Sx = O(n)
    public String removeStars(String s) {
        Stack<Character> chars = new Stack<>();

        for(char c:s.toCharArray()) {
            if(c == '*') {
                if(!chars.isEmpty()) {
                    chars.pop();
                }
            } else {
                chars.push(c);
            }
        }

        StringBuilder sb = new StringBuilder(chars.size());
        while(!chars.isEmpty()) {
            sb.insert(0, chars.pop());
        }

        return sb.toString();
    }
}
