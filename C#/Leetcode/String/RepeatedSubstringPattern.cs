using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 459
    // Submission Detail: https://leetcode.com/submissions/detail/170043524/
    public class RepeatedSubstringPattern
    {
        // Tx = O(1). Contains function needs constant time
        // Sx = O(1) It is given that the string length will not exceed 10000. O(n) if this constraint is not given.

        // Algorithm: For a given string to have repititions, that string must be contained in the substring of the string appended with itself except the first and last characters.
        // 1. Create a new string by concatenating the input string with itself.
        // 2. Check if the input string is contained in the substring of the concatenatedstring without the first and last characters.

        public bool RepeatedSubstringPatternExists(string s)
        {
            string concatenatedString = s + s;

            return concatenatedString.Substring(1, concatenatedString.Length - 2).Contains(s);
        }
    }
}
