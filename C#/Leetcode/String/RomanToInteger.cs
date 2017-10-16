using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode 13
    class RomanToInteger
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine($"Input: {"MMCDXLII"}, Output: {RomanToInt("MMCDXLII")}\tExpected:2442");
        //    Console.WriteLine($"Input: {"MMDCCLXXIII"}, Output: {RomanToInt("MMDCCLXXIII")}\tExpected:2773");
        //    Console.WriteLine($"Input: {"DCCCLXXVI"}, Output: {RomanToInt("DCCCLXXVI")}\tExpected:876");
        //    Console.WriteLine($"Input: {"CMLVII"}, Output: {RomanToInt("CMLVII")}\tExpected:957");
        //    Console.WriteLine($"Input: {"MMCCCXXVIII"},\tOutput: {RomanToInt("MMCCCXXVIII")},\tExpected:2328");
        //    Console.WriteLine($"Input: {"MMDCXCIX"}, Output: {RomanToInt("MMDCXCIX")}\tExpected:2699");

        //    Console.ReadLine();
        //}

        // V    -   5
        // X    -   10
        // L    -   50
        // C    -   100
        // D    -   500
        // M    -   1000
        // 1-5000 Numerals - http://romannumerals.babuo.com/roman-numerals-1-5000

        private static Dictionary<char, int> GeneralNumerals { get; set; }

        // Runtime : 156 ms
        // Tx = O(n) {n: n is the length of the input string}
        // Sx = O(1)
        // TODO: Add validation for allowed roman numerals combination
        public static int RomanToInt(string s)
        {
            // Edge Cases

            GetNumerals();

            int computedValue = 0;

            for (int currentIndex = 0; currentIndex < s.Length; currentIndex++)
            {
                char currentChar = s[currentIndex];
                if (!GeneralNumerals.TryGetValue(currentChar, out int currentIndexValue))
                    throw new ArgumentNullException("Invalid character found.");

                if (currentIndex == s.Length - 1 || GeneralNumerals[s[currentIndex + 1]] <= currentIndexValue)
                {
                    computedValue += currentIndexValue;
                }
                else if (GeneralNumerals[s[currentIndex + 1]] > currentIndexValue)
                {
                    computedValue += GeneralNumerals[s[currentIndex + 1]] - currentIndexValue;
                    currentIndex++;
                }
            }

            return computedValue;
        }

        public static void GetNumerals()
        {
            GeneralNumerals = new Dictionary<char, int>();
            GeneralNumerals.Add('I', 1);
            GeneralNumerals.Add('V', 5);
            GeneralNumerals.Add('X', 10);
            GeneralNumerals.Add('L', 50);
            GeneralNumerals.Add('C', 100);
            GeneralNumerals.Add('D', 500);
            GeneralNumerals.Add('M', 1000);
        }
    }
}
