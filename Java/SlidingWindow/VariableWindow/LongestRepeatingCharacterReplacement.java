package SlidingWindow.VariableWindow;

import java.util.HashMap;
import java.util.Map;

public class LongestRepeatingCharacterReplacement {
    // Leetcode 424: https://leetcode.com/problems/longest-repeating-character-replacement/description/
    // Submission Detail: https://leetcode.com/problems/longest-repeating-character-replacement/submissions/1625386394

    //Input: s = "AABABBA", k = 1
    //Output: 4
    //Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA". The substring "BBBB" has the longest repeating letters, which is 4.
    //             There may exists other ways to achieve this answer too.

    //Input: s = "BCBABCCCCA", k = 2
    //Output: 6
    public int characterReplacement(String s, int k) {
        int start = 0, maxFreq = 0, longestLength = 0;
        Map<Character, Integer> characterCount = new HashMap<>();

        for(int end = 0;end < s.length(); end++) {
            char currentChar = s.charAt(end);
            int count = characterCount.getOrDefault(currentChar, 0);
            characterCount.put(currentChar, count+1);
            maxFreq = Math.max(maxFreq, characterCount.get(currentChar));

            if(k+maxFreq < end-start+1) {
                characterCount.put(s.charAt(start), characterCount.get(s.charAt(start))-1);
                start++;
            }

            longestLength = Math.max(longestLength, end-start+1);
        }

        return longestLength;
    }
}
