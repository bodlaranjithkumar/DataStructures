package TwoPointers;

public class ReverseWordsInString {
    // Leetcode 151: https://leetcode.com/problems/reverse-words-in-a-string/
    // Submission Detail: https://leetcode.com/problems/reverse-words-in-a-string/submissions/1670770109

    //Input: s = "the sky is blue"
    //Output: "blue is sky the"

    //Input: s = "  hello world  "
    //Output: "world hello"
    //Explanation: Your reversed string should not contain leading or trailing spaces.

    //Input: s = "a good   example"
    //Output: "example good a"
    //Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.

    public String reverseWords(String s) {
        StringBuilder sb = new StringBuilder();
        final char EMPTY_LITERAL = ' ';
        int length = s.length();

        for(int start = length-1, end = length-1; start>=0; start--) {
            if(s.charAt(end) == EMPTY_LITERAL) {
                end--;
            } else if(start == 0 || s.charAt(start-1) == EMPTY_LITERAL) {
                sb.append(s.substring(start, end+1)).append(EMPTY_LITERAL);
                end = start-1;
            }
        }

        if(sb.charAt(sb.length()-1) == EMPTY_LITERAL)
            sb.deleteCharAt(sb.length()-1);

        return sb.toString();
    }
}
