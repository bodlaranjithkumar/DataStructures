using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode 17
    public class PhoneNumberLettersCombination
    {
        //static void Main(string[] args)
        //{
        //    Helper.PrintListElements(LetterCombinations(""));
        //    Helper.PrintListElements(LetterCombinations("23"));
        //    Helper.PrintListElements(LetterCombinations("99"));
        //    Helper.PrintListElements(LetterCombinations("10"));
        //    Helper.PrintListElements(LetterCombinations("54675"));

        //    Console.ReadLine();
        //}

        // Runtime : 479 ms
        // Tx = O(n*pow(m,n)) {m: length of the digit's letters, n: length of digits}
        // Sx = O(pow(m,n))
        public static List<string> LetterCombinations(string digits)
        {
            List<string> combinations = new List<string>();

            string[] letters = { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            if (digits.Length != 0)
                combinations.Add("");   // Add empty string for while loop to pass at index = 0;

            for (int index = 0; index < digits.Length; index++)
            {
                int digit = digits[index] - '0';    // Compute the integer value from the ascii value by subtracting char 0.
                string currentDigitString = letters[digit];

                while (combinations[0].Length == index)
                {
                    string firstLetters = combinations[0];
                    // Remove string at index 0 to append to characters in the current string. This method returns void.
                    combinations.RemoveAt(0);

                    foreach (char c in currentDigitString)
                    {
                        combinations.Add(firstLetters + c);
                    }
                }
            }

            return combinations;
        }
    }
}
