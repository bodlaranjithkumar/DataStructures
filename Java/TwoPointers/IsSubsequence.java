package TwoPointers;

public class IsSubsequence {
    // Leetcode 392: https://leetcode.com/problems/is-subsequence/submissions/1670941355/
    // Submission Detail: https://leetcode.com/problems/is-subsequence/submissions/1670941355

    //Input: s = "abc", t = "ahbgdc"
    //Output: true

    //Input: s = "axc", t = "ahbgdc"
    //Output: false

    public boolean isSubsequence(String s, String t) {
        int indexOfS = 0, indexOfT = 0, lengthOfS = s.length(), lengthOfT = t.length();

        while(indexOfS < lengthOfS && indexOfT < lengthOfT) {
            if(s.charAt(indexOfS) == t.charAt(indexOfT)) {
                indexOfS++;
            }

            indexOfT++;
        }

        return indexOfS == lengthOfS;
    }
}
