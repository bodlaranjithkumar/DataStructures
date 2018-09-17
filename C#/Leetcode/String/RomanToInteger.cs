using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode 13 - https://leetcode.com/problems/roman-to-integer/
    // Submission Detail - https://leetcode.com/submissions/detail/123691683/
    // 2 pointers

    public class RomanToInteger
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

        // 1-5000 Numerals - http://romannumerals.babuo.com/roman-numerals-1-5000
        private static Dictionary<char, int> values = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

        // Runtime : 156 ms
        // Tx = O(n) {n: n is the length of the input string}
        // Sx = O(1)
        // TODO: Add validation for allowed roman numerals combination
        public static int RomanToInt(string s)
        {
            int computedValue = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!values.TryGetValue(s[i], out int val))
                    throw new ArgumentNullException("Invalid character found.");

                if (i == s.Length - 1 || values[s[i + 1]] <= val)
                {
                    computedValue += val;
                }
                else if (values[s[i + 1]] > val)
                {
                    computedValue += values[s[i + 1]] - val;
                    i++;
                }
            }

            return computedValue;
        }
    }
}
