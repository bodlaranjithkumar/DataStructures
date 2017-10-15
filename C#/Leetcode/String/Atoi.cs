using System;

namespace LeetcodeSolutions.String
{
    // Leetcode 8
    class Atoi
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine($"Input: {""},\tOutput: {MyAtoi("")},\tExpected:0");
        //    Console.WriteLine($"Input: {".25"}, Output: {MyAtoi(".25")}\tExpected:0");
        //    Console.WriteLine($"Input: {"+123"}, Output: {MyAtoi("123")}\tExpected:123");
        //    Console.WriteLine($"Input: {"-123"}, Output: {MyAtoi("-123")}\tExpected:-123");
        //    Console.WriteLine($"Input: {"-123.25"}, Output: {MyAtoi("-123")}\tExpected:-123");
        //    Console.WriteLine($"Input: {"    010"}, Output: {MyAtoi("10")}\tExpected:10");
        //    Console.WriteLine($"Input: {"+-2"}, Output: {MyAtoi("+-2")}\tExpected:0");
        //    Console.WriteLine($"Input: {"     +004500"}, Output: {MyAtoi("     +004500")}\tExpected:4500");
        //    Console.WriteLine($"Input: {"   +0 123"}, Output: {MyAtoi("   +0 123")}\tExpected:0");
        //    Console.WriteLine($"Input: {"   - 321"}, Output: {MyAtoi("   - 321")}\tExpected:0");
        //    Console.WriteLine($"Input: {"2147483648"}, Output: {MyAtoi("2147483648")}\tExpected:2147483647");
        //    Console.WriteLine($"Input: {"-2147483648"}, Output: {MyAtoi("-2147483648")}\tExpected:-2147483648");
        //    Console.WriteLine($"Input: {"    10522545459"}, Output: {MyAtoi("    10522545459")}\tExpected:2147483647");
        //    Console.WriteLine($"Input: {"-9223372036854775809"}, Output: {MyAtoi("-9223372036854775809")}\tExpected:-2147483648");
        //    Console.WriteLine($"Input: {"9223372036854775809"}, Output: {MyAtoi("9223372036854775809")}\tExpected:2147483647");
        //    Console.ReadLine();
        //}

        // Cases to consider
        //  1. whitespace
        //  2. Repeated +/- symbols.
        //  3. Integer overflow.
        //  4. Empty string


        // Runtime : 138 ms.
        // Tx = O(n) {n : length of the string}
        // Sx = O(1)
        public static int MyAtoi(string str)
        {
            bool isNegative = false;
            bool posNeg = false;    // boolean flag to check if a positive or negative seen before.
            bool digitSeenBefore = false;
            int result = 0;

            for (int startIndex = 0; startIndex < str.Length; startIndex++)
            {
                char currentChar = str[startIndex];

                if (char.IsDigit(currentChar))
                {
                    int newResult = result * 10 + currentChar - 48;
                    if (newResult < 0 || (startIndex < str.Length && result > int.MaxValue / 10))
                    {
                        result = isNegative ? int.MinValue : int.MaxValue;
                        break;
                    }
                    else
                    {
                        result = newResult;    // CurrentChar's value is ASCII value of the character.
                    }

                    digitSeenBefore = true;
                }
                else if (currentChar == '-' || currentChar == '+')
                {
                    if (posNeg)
                    {
                        break;
                    }
                    else
                    {
                        posNeg = true;
                        isNegative = currentChar == '-' ? true : false;
                    }
                }
                else if (currentChar == ' ')
                {
                    if (!digitSeenBefore && !posNeg)
                        continue;
                    else
                        break;
                }
                else
                {
                    break;
                }
            }

            return result * (isNegative ? -1 : 1);
        }
    }
}
