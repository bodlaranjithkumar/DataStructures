package TwoPointers;

public class MergeStringsAlternatively {
    // Leetcode 1768:https://leetcode.com/problems/merge-strings-alternately/description/
    // Submission Detail: https://leetcode.com/problems/merge-strings-alternately/submissions/1667651985

    //Input: word1 = "abc", word2 = "pqr"
    //Output: "apbqcr"
    //Explanation: The merged string will be merged as so:
    //word1:  a   b   c
    //word2:    p   q   r
    //merged: a p b q c r

    //Input: word1 = "ab", word2 = "pqrs"
    //Output: "apbqrs"
    //Explanation: Notice that as word2 is longer, "rs" is appended to the end.
    //        word1:  a   b
    //word2:    p   q   r   s
    //merged: a p b q   r   s

    //Input: word1 = "abcd", word2 = "pq"
    //Output: "apbqcd"
    //Explanation: Notice that as word1 is longer, "cd" is appended to the end.
    //        word1:  a   b   c   d
    //word2:    p   q
    //merged: a p b q c   d

    // Tx = O(m+n)
    // Sx = O(m+n)
    public String mergeAlternately(String word1, String word2) {
        int index1 = 0, index2 = 0, length1 = word1.length(), length2 = word2.length();
        StringBuilder sb = new StringBuilder();

        while(index1 < length1 || index2 < length2) {
            if(index1 < length1) {
                sb.append(word1.charAt(index1));
                index1++;
            }

            if(index2 < length2) {
                sb.append(word2.charAt(index2));
                index2++;
            }
        }

        return sb.toString();
    }
}
