package Backtracking;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class LetterCombinationsOfAPhoneNumber {
    // Leetcode 17: https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
    // Submission Detail: https://leetcode.com/problems/letter-combinations-of-a-phone-number/submissions/1680736350

    private static final Map<Integer, List<Character>> phoneNumberCharacters = Map.of(
        2, List.of('a', 'b', 'c'),
        3, List.of('d', 'e', 'f'),
        4, List.of('g', 'h', 'i'),
        5, List.of('k', 'l', 'm'),
        6, List.of('n', 'o', 'p'),
        7, List.of('q', 'r', 's'),
        8, List.of('t', 'u', 'v'),
        9, List.of('w', 'x', 'y', 'z')
    );

    private List<String> result = new ArrayList<>();
    public List<String> letterCombinations(String digits) {
        backtrack(digits, 0, new StringBuilder());

        return result;
    }

    private void backtrack(String digits, int index, StringBuilder sb) {
        // Base case: Add to the list when index = digits.length;
        if(index == digits.length()) {
            result.add(sb.toString());
            return;
        }

        List<Character> chars = phoneNumberCharacters.get(digits.charAt(index)-'0');

        for(char c: chars) {
            sb.append(c);
            backtrack(digits, index+1, sb);
            sb.deleteCharAt(sb.length()-1);
        }
    }
}
