package Strings;

import java.util.Map;

public class RomanToInteger {
    // Leetcode 13: https://leetcode.com/problems/roman-to-integer/description/
    // Submission Detail: https://leetcode.com/problems/roman-to-integer/submissions/1708930622

    //Example 1:
    //Input: s = "III"
    //Output: 3
    //Explanation: III = 3.

    //Example 2:
    //Input: s = "LVIII"
    //Output: 58
    //Explanation: L = 50, V= 5, III = 3.

    //Example 3:
    //Input: s = "MCMXCIV"
    //Output: 1994
    //Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

    private static final Map<Character, Integer> romanToIntMapping = Map.of(
        'I', 1,
        'V', 5,
        'X', 10,
        'L', 50,
        'C', 100,
        'D', 500,
        'M', 1000
    );

    public int romanToInt(String s) {
        int result=0;
        for(int index=0; index<s.length(); index++) {
            int currentCharValue = romanToIntMapping.get(s.charAt(index));
            int nextCharValue = index+1 < s.length() ? romanToIntMapping.get(s.charAt(index+1)) : 0;

            if(currentCharValue < nextCharValue) {
                result -= currentCharValue;
            } else {
                result += currentCharValue;
            }
        }

        return result;
    }
}
