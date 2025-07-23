package Strings;

public class MinimumNumberOfStepstoMakeTwoStringsAnagram {
    // Leetcode 1347: https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram/description/
    // Submission Detail: https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram/submissions/1708005314

    //Example 1:
    //Input: s = "bab", t = "aba"
    //Output: 1
    //Explanation: Replace the first 'a' in t with b, t = "bba" which is anagram of s.

    //Example 2:
    //Input: s = "leetcode", t = "practice"
    //Output: 5
    //Explanation: Replace 'p', 'r', 'a', 'i' and 'c' from t with proper characters to make t anagram of s.

    //Example 3:
    //Input: s = "anagram", t = "mangaar"
    //Output: 0
    //Explanation: "anagram" and "mangaar" are anagrams.

    public int minSteps(String s, String t) {
        int[] sCharCount = new int[26], tCharCount = new int[26];

        for(char c:s.toCharArray())
            sCharCount[c-'a']++;

        for(char c:t.toCharArray())
            tCharCount[c-'a']++;

        int diffCount = 0;

        for(int index=0; index<sCharCount.length; index++)
            diffCount += Math.abs(sCharCount[index]-tCharCount[index]);

        return diffCount/2;
    }
}
