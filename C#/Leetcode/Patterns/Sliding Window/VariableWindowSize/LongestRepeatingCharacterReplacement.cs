public class Solution {
    
    // Leetcode 424 - https://leetcode.com/problems/longest-repeating-character-replacement/description/
    // Submission Detail - https://leetcode.com/problems/longest-repeating-character-replacement/submissions/1541362583
    // Explanation here - https://www.hellointerview.com/learn/code/sliding-window/longest-repeating-character-replacement
    // Variable Sliding Window
    
    // Tx = O(n)
    // Sx = O(n)
    public int CharacterReplacement(string s, int k) {
        int start = 0, maxFrequencyOfAChar = 0, maxLength = 0;
        IDictionary<char, int> charFrequency = new Dictionary<char, int>(s.Length);

        for(int end = 0; end < s.Length; end++) {
            if(!charFrequency.ContainsKey(s[end])) {
                charFrequency.Add(s[end], 0);
            }
            charFrequency[s[end]]++;
            maxFrequencyOfAChar = Math.Max(maxFrequencyOfAChar, charFrequency[s[end]]);

            // This is the key observation: if max frequency of a char in current window + k exceeds the window length, we need to increment the start index.
            if(k + maxFrequencyOfAChar < end - start + 1) {
                charFrequency[s[start]]--;
                start++;
            }
            maxLength = Math.Max(maxLength, end-start+1);
        }

        return maxLength;
    }
}