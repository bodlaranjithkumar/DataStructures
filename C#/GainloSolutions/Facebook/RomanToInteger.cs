using System;
using System.Collections.Generic;
using System.Text;

namespace GainloSolutions.Facebook
{
    class RomanToInteger
    {
        //public static void Main(string[] args)
        //{
        //    RomanToInteger romanToInteger = new RomanToInteger();

        //    string str1 = "XIV";
        //    Console.WriteLine($"Integer value of {str1} is : {romanToInteger.romanToInt(str1)}");

        //    string str2 = "XCIX";
        //    Console.WriteLine($"Integer value of {str2} is : {romanToInteger.romanToInt(str2)}");

        //    string str3 = "XCD";   // MMMMCMXCIX = 4999
        //    Console.WriteLine($"Integer value of {str3} is : {romanToInteger.romanToInt(str3)}");

        //    Console.ReadKey();
        //}

        // Method1: Fails for invalid inputs like VX and returns XCD as 590 instead of 390
        public int GetIntegerValueOfRomanNumeral(string RomanNumeral)
        {
            int result = 0;

            for(int index = 0; index < RomanNumeral.Length; index++)
            {
                int currentIndexValue = GetRomanCharacterIntegerValue(RomanNumeral[index]);

                if(index + 1 < RomanNumeral.Length)
                {
                    int nextIndexValue = GetRomanCharacterIntegerValue(RomanNumeral[index + 1]);

                    if(currentIndexValue >= nextIndexValue)
                    {
                        result += currentIndexValue;
                    }
                    else
                    {
                        result += nextIndexValue - currentIndexValue;
                        index++;
                    }
                }
                else
                {
                    result += currentIndexValue;
                    index++;
                }
            }

            return result;
        }

        private int GetRomanCharacterIntegerValue(char c)
        {
            switch(c)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return 0;
            }
        }

        // Method2: Fails for invalid inputs like VX  but returns correct value for XCD
        // https://discuss.leetcode.com/topic/821/my-solution-for-this-question-but-i-don-t-know-is-there-any-easier-way
        public int romanToInt(String s)
        {
            int sum = 0;
            if (s.IndexOf("IV") != -1) { sum -= 2; }
            if (s.IndexOf("IX") != -1) { sum -= 2; }
            if (s.IndexOf("XL") != -1) { sum -= 20; }
            if (s.IndexOf("XC") != -1) { sum -= 20; }
            if (s.IndexOf("CD") != -1) { sum -= 200; }
            if (s.IndexOf("CM") != -1) { sum -= 200; }

            char[] c = s.ToCharArray();
            int count = 0;

            for (; count <= s.Length - 1; count++)
            {
                if (c[count] == 'M') sum += 1000;
                if (c[count] == 'D') sum += 500;
                if (c[count] == 'C') sum += 100;
                if (c[count] == 'L') sum += 50;
                if (c[count] == 'X') sum += 10;
                if (c[count] == 'V') sum += 5;
                if (c[count] == 'I') sum += 1;

            }

            return sum;

        }
    }
}
