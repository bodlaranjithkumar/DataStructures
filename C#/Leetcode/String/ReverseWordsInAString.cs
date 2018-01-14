using sys = System;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 151
    class ReverseWordsInAString
    {
        //public static void Main(string[] args)
        //{
        //    sys.Console.WriteLine($"Input:{"a"},Output:{ReverseWords("a")}, Expected:a");
        //    sys.Console.WriteLine($"Input:{""}, Output:{ReverseWords("")}, Expected:{""}");
        //    sys.Console.WriteLine($"Input:{"  Coding is   Fun    "}, Output:{ReverseWords("  Coding is   Fun    ")}, Expected:Fun is Coding");
        //    sys.Console.WriteLine($"Input:{"Coding is Fun"}, Output:{ReverseWords("Coding is Fun")}, Expected:Fun is Coding");

        //    sys.Console.ReadKey();
        //}

        // Tx = O(n)
        // Sx = O(1) not considering the output string
        public static string ReverseWordsOptimized(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            StringBuilder reversedWord = new StringBuilder();
            int endOfWord = str.Length;

            for (int index = str.Length - 1; index >= 0; index--)
            {
                if (str[index] == ' ')
                    endOfWord = index;
                else if (index == 0 || str[index - 1] == ' ')
                {
                    if (reversedWord.Length != 0)
                        reversedWord.Append(' ');

                    reversedWord.Append(str.Substring(index, endOfWord - index));
                }
            }

            return reversedWord.ToString();
        }

        // Runtime = 145 ms
        // Tx = O(n) 
        // Sx = O(n) for stringbuilder object
        // TODO: Optimize space
        public static string ReverseWords(string str)
        {
            str = CleanUpSpaces(str);

            //Reverse characters from beginning to end.        
            char[] chars = str.ToCharArray();
            int length = chars.Length;
            ReverseCharsInWord(chars, 0, length - 1);

            int startIndex = 0, endIndex = 0;

            for (int i = 0; i < length; i++)
            {
                if (chars[i] == ' ' || i == length - 1)
                {
                    // endIndex is 1 index before blank space if i is not the last index. 
                    endIndex = i == length - 1 ? i : i - 1;
                    ReverseCharsInWord(chars, startIndex, endIndex);
                    startIndex = i + 1; // Set startIndex for next word.
                }
            }

            return new sys.String(chars);
        }

        // Reverse Characters in a word
        private static void ReverseCharsInWord(char[] chars, int startIndex, int endIndex)
        {
            // not needed to reverse the word when it is a single charcter
            if (startIndex != endIndex)
            {
                int length = endIndex - startIndex + 1;

                for (int i = 0; i < length / 2; i++)
                {
                    char temp = chars[startIndex + i];
                    chars[startIndex + i] = chars[endIndex - i];
                    chars[endIndex - i] = temp;
                }
            }
        }

        // Removes trailng, heading spaces and converts multiple spaces between words to one space.
        private static string CleanUpSpaces(string str)
        {
            StringBuilder builder = new StringBuilder();
            char lastAppendedChar = ' ';

            foreach (char c in str)
            {
                if (c != ' ')
                {
                    builder.Append(c);
                    lastAppendedChar = c;
                }
                else
                {
                    if (lastAppendedChar != ' ')
                    {
                        lastAppendedChar = ' ';
                        builder.Append(lastAppendedChar);
                    }
                }
            }

            return builder.Length > 0 && lastAppendedChar == ' ' ? builder.ToString().Remove(builder.Length - 1) : builder.ToString();
        }
    }
}