using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 79 - https://leetcode.com/problems/minimum-window-substring/description/
    // Submission Detail - https://leetcode.com/submissions/detail/202525531/

    public class MinWindowSubstring
    {
        //public static void Main(string[] args)
        //{
        //    MinWindowSubstring s1 = new MinWindowSubstring();

        //    string result1 = s1.MinWindow("ADOBECODEBANC", "ABC");  // BANC            
        //}

        // Tx = O(m*n) {m: length of s}
        // Sx = O(n) {n: length of t}

        // Algorithm: There could be multiple substrings. To identify these substrings, track the 
        // number of characters already included in the substring. For this, first count the 
        // number of characters present in t using an array. Use 2 pointers (L,R) to point to the
        // start and end of the substring. Iterate through s array using the right pointer, decrement
        // the current character no matter what. If the count in map for the current character is greater
        // than one, it means that character present in t is now included in our substring.
        // when the all the characters are included, find the length (R-L) and update the min length.
        // We may find new min substring. So, keep moving left pointer till all characters in t are present
        // in the substring. At the end, if the calculated min length is still the max value, chars in t are not in s.

        public string MinWindow(string s, string t)
        {
            int left = 0, right = 0, tCharsRemainingInSubstring = t.Length;
            int subStringStartIndex = 0, subStringMinLength = int.MaxValue; // This could also be s.Length+1 but overflows if length = MaxValue

            int[] map = new int[128];

            for (int i = 0; i < t.Length; i++)
                map[t[i] - 'A']++;

            while (right < s.Length)
            {
                if (map[s[right] - 'A'] > 0)
                    tCharsRemainingInSubstring--;

                map[s[right] - 'A']--;
                right++;

                while (tCharsRemainingInSubstring == 0)
                { // found a substring in s with all chars in t
                    if (right - left < subStringMinLength)
                    {
                        subStringMinLength = right - left;
                        subStringStartIndex = left;
                    }

                    if (map[s[left] - 'A'] == 0)
                        tCharsRemainingInSubstring++;

                    map[s[left] - 'A']++;
                    left++;
                }
            }

            return subStringMinLength == int.MaxValue ? "" : s.Substring(subStringStartIndex, subStringMinLength);
        }
    }
}
