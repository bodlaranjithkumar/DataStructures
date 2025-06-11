package Stack;

import java.util.HashMap;
import java.util.Map;
import java.util.Stack;

public class ValidParantheses {
    // Leetcode 20: https://leetcode.com/problems/valid-parentheses/description/
    // Submission Detail: https://leetcode.com/problems/valid-parentheses/submissions/1659898684

    static Map<Character, Character> paranthesesMap = Map.of(
    '(', ')',
    '{', '}',
    '[', ']'
    );

    public boolean isValid(String s) {
        Stack<Character>  paranthesesSeenSoFar = new Stack<>();

        for(int index = 0; index<s.length(); index++) {
            char currentChar = s.charAt(index);

            if(paranthesesMap.containsKey(currentChar)) {
                paranthesesSeenSoFar.push(currentChar);
            } else {
                if(paranthesesSeenSoFar.size() == 0 ||
                    paranthesesMap.get(paranthesesSeenSoFar.pop()) != currentChar)
                    return false;
            }
        }

        return paranthesesSeenSoFar.size() == 0;
    }
}
