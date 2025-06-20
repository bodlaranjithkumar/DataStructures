package SlidingWindow.FixedWindow;

import java.util.Set;

public class MaximumNumberofVowelsinaSubstringofGivenLength {
    // Leetcode 1456: https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/
    // Submission Detail: https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/submissions/1670967947

    //Input: s = "abciiidef", k = 3
    //Output: 3
    //Explanation: The substring "iii" contains 3 vowel letters.
    //
    //Input: s = "aeiou", k = 2
    //Output: 2
    //Explanation: Any substring of length 2 contains 2 vowels.
    //
    //Input: s = "leetcode", k = 3
    //Output: 2
    //Explanation: "lee", "eet" and "ode" contain 2 vowels.

    static final Set vowels = Set.of('a', 'e', 'i', 'o', 'u');
    public int maxVowels(String s, int k) {
        int maxVowelCount = 0, currentVowelCount = 0, start = 0, end = 0;

        while(end < s.length()) {
            if(vowels.contains(s.charAt(end)))
                currentVowelCount++;

            if(end-start+1 == k) {
                maxVowelCount = Math.max(maxVowelCount, currentVowelCount);
                if(vowels.contains(s.charAt(start)))
                    currentVowelCount--;
                start++;
            }
            end++;
        }

        return maxVowelCount;
    }
}
