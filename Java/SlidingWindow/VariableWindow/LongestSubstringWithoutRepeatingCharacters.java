package SlidingWindow.VariableWindow;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

public class LongestSubstringWithoutRepeatingCharacters {
    // Leetcode 3: https://leetcode.com/problems/longest-substring-without-repeating-characters/
    // Submission Detail: https://leetcode.com/problems/longest-substring-without-repeating-characters/submissions/1625396885

    // Input: s = "substring"
    // Output: 8

    // Input: bbbbb
    // Output: 1

    // Tx = O(n)
    // Sx = O(1)
    public int lengthOfLongestSubstring(String s) {
        int start = 0, maxWindowSize = 0;
        Map<Character, Integer> characterCount = new HashMap<>();

        for(int end=0; end < s.length(); end++) {
            char currentChar = s.charAt(end);
            int count = characterCount.getOrDefault(currentChar, 0);
            characterCount.put(currentChar, count+1);

            while(characterCount.get(currentChar) > 1) {
                characterCount.put(s.charAt(start), characterCount.get(s.charAt(start))-1);
                start++;
            }

            maxWindowSize = Math.max(maxWindowSize, end-start+1);
        }

        return maxWindowSize;
    }
}
