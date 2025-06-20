package TwoPointers;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class ReverseVowelsofAString {
    // Leetcode 305: https://leetcode.com/problems/reverse-vowels-of-a-string/description/
    // Submission Detail: https://leetcode.com/problems/reverse-vowels-of-a-string/submissions/1667687477

    //Input: s = "IceCreAm"
    //Output: "AceCreIm"
    //Explanation:
    //The vowels in s are ['I', 'e', 'e', 'A']. On reversing the vowels, s becomes "AceCreIm".

    //Input: s = "leetcode"
    //Output: "leotcede"

    static Set<Character> vowels = new HashSet<>(List.of('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'));
    public String reverseVowels(String s) {
        int left = 0, right = s.length()-1;
        StringBuilder sb = new StringBuilder(s);

        while(left < right) {
            while(left < right && !vowels.contains(s.charAt(left))) {
                left++;
            }

            while(left < right && !vowels.contains(s.charAt(right))) {
                right--;
            }

            swap(left, right, sb);
            left++;
            right--;
        }

        return sb.toString();
    }

    private void swap(int i, int j, StringBuilder sb) {
        char temp = sb.charAt(i);
        sb.setCharAt(i, sb.charAt(j));
        sb.setCharAt(j, temp);
    }
}
