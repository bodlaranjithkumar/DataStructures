package TwoPointers;

import java.util.ArrayList;
import java.util.List;

public class StringCompression {
    // Leetcode 443: https://leetcode.com/problems/string-compression/description/
    // Submission Detail: https://leetcode.com/problems/string-compression/submissions/1670931053

    //Input: chars = ["a","a","b","b","c","c","c"]
    //Output: Return 6, and the first 6 characters of the input array should be: ["a","2","b","2","c","3"]
    //Explanation: The groups are "aa", "bb", and "ccc". This compresses to "a2b2c3".

    //Input: chars = ["a"]
    //Output: Return 1, and the first character of the input array should be: ["a"]
    //Explanation: The only group is "a", which remains uncompressed since it's a single character.

    //Input: chars = ["a","b","b","b","b","b","b","b","b","b","b","b","b"]
    //Output: Return 4, and the first 4 characters of the input array should be: ["a","b","1","2"].
    //Explanation: The groups are "a" and "bbbbbbbbbbbb". This compresses to "ab12".

    public int compress(char[] chars) {
        int read=0, write=0;
        while(read < chars.length) {
            char currentChar = chars[read];
            int count=0;
            while(read < chars.length && chars[read]==currentChar) {
                read++;
                count++;
            }
            chars[write] = currentChar;
            write++;
            if(count > 1) {
                for(char c : String.valueOf(count).toCharArray()) {
                    chars[write] = c;
                    write++;
                }
            }
        }
        return write;
    }

    // Not in place
    List<Character> compressedChars = new ArrayList<>();
    public int compresss(char[] chars) {
        for(int start=0, end=0; end<chars.length; end++) {
            if(chars.length == 1 || (end>0 && chars[end] != chars[end-1]) || end==chars.length-1) {
                compressCharacters(chars, start, end);
                start = end;
            }
        }

        return compressedChars.size();
    }

    private void compressCharacters(char[] chars, int start, int end) {
        compressedChars.add(chars[start]);
        int count = end-start;

        if(count <= 1)
            return;

        String strCount = String.valueOf(count);

        for(int index = 0; index< strCount.length(); index++)
            compressedChars.add(strCount.charAt(index));
    }
}
