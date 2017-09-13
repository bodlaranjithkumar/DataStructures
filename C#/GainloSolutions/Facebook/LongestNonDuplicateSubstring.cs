using System;
using System.Collections.Generic;
using System.Text;

namespace GainloSolutions.Facebook
{
    class LongestNonDuplicateSubstring
    {
        //static void Main(string[] args)
        //{
        //    LongestNonDuplicateSubstring subString = new LongestNonDuplicateSubstring();
        //    // Test Case1: abcadbef
        //    string inputStr1 = "abcadbef";
        //    Console.WriteLine($"Longest Substring without repeating characters in {inputStr1} " +
        //        $"is {subString.FindLongestNonDuplicateSubstring(inputStr1)}");

        //    // Test Case2: abac
        //    string inputStr2 = "abac";
        //    Console.WriteLine($"Longest Substring without repeating characters in {inputStr2} " +
        //        $"is {subString.FindLongestNonDuplicateSubstring(inputStr2)}");

        //    // Test Case3: aaaaa
        //    string inputStr3 = "aaaaa";
        //    Console.WriteLine($"Longest Substring without repeating characters in {inputStr3} " +
        //        $"is {subString.FindLongestNonDuplicateSubstring(inputStr3)}");

        //    Console.ReadKey();
        //}

        /// <summary>
        /// Finds the longest non-duplicate substring
        /// </summary>
        /// <param name="str">Input string with possibly duplicate characters</param>
        /// <returns>Longest Non-duplicate substring</returns>
        /// Tx = O(n), Sx = O(n)
        /// Technique/Pattern: Sliding Window
        /// http://blog.gainlo.co/index.php/2016/10/07/facebook-interview-longest-substring-without-repeating-characters/
        public string FindLongestNonDuplicateSubstring(string str)
        {
            if (str.Length == 0)
                return str;
            else if (str.Length == 1 || (str.Length == 2 && str[0] == str[1]))
                return str[0].ToString();

            HashSet<char> charsVisited = new HashSet<char>();
            StringBuilder potentialLongestSubstring = new StringBuilder();
            string longestSubstring = String.Empty;

            char currentCharacter, nextCharacter;

            for(int index = 0; index < str.Length - 1; index++) // index can overflow for long strings.
            {
                currentCharacter = str[index];
                nextCharacter = str[index+1];

                charsVisited.Add(currentCharacter);
                potentialLongestSubstring.Append(currentCharacter);

                if(charsVisited.Contains(nextCharacter))
                {
                    if(potentialLongestSubstring.Length > longestSubstring.Length)
                    {
                        longestSubstring = potentialLongestSubstring.ToString();    //found new longestsubstring.
                    }

                    charsVisited.Clear();
                    potentialLongestSubstring.Clear();
                }
            }

            return longestSubstring;
        }
    }
}