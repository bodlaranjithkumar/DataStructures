package Strings;

import java.util.Arrays;

public class DetermineIfTwoStringsAreEqual {
    // Leetcode 1657: https://leetcode.com/problems/determine-if-two-strings-are-close/
    // Submission Detail: https://leetcode.com/problems/determine-if-two-strings-are-close/submissions/1671938493

    //Input: word1 = "abc", word2 = "bca"
    //Output: true
    //Explanation: You can attain word2 from word1 in 2 operations.
    //Apply Operation 1: "abc" -> "acb"
    //Apply Operation 1: "acb" -> "bca"

    //Input: word1 = "a", word2 = "aa"
    //Output: false
    //Explanation: It is impossible to attain word2 from word1, or vice versa, in any number of operations.

    //Input: word1 = "cabbba", word2 = "abbccc"
    //Output: true
    //Explanation: You can attain word2 from word1 in 3 operations.
    //Apply Operation 1: "cabbba" -> "caabbb"
    //Apply Operation 2: "caabbb" -> "baaccc"
    //Apply Operation 2: "baaccc" -> "abbccc"

    public boolean closeStrings(String word1, String word2) {
        int [] word1Count = new int[26];
        int [] word2Count = new int[26];

        for(char c:word1.toCharArray())
            word1Count[c-'a']++;

        for(char c:word2.toCharArray())
            word2Count[c-'a']++;

        // Step 1: Check if all the unique characters are present in both the strings
        for(int index=0; index<26; index++) {
            if((word1Count[index] == 0 && word2Count[index] != 0) || (word1Count[index] != 0 && word2Count[index] == 0))
                return false;
        }

        Arrays.sort(word1Count);
        Arrays.sort(word2Count);

        // Step 2: Check if the frequency of characters is different. Doesn't matter what characters do the frequency correspond to.
        for(int index=0; index<26; index++) {
            if(word1Count[index] != word2Count[index])
                return false;
        }

        return true;
    }
}
