using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InterviewCakeSolutions.Strings
{
    class ReverseWords
    {
        //public static void Main(string[] args)
        //{
        //    string wordsToReverse = "find you will pain only go you recordings security the into if";
        //    ReverseWords wordsReverse = new ReverseWords();
        //    wordsToReverse = wordsReverse.ReverseWordsInPlace2(wordsToReverse);

        //    foreach (char c in wordsToReverse)
        //        Console.Write($"{c}");

        //    Console.ReadKey();
        //}

        // Method1: Using c# library methods - Regex.Split, String.Join.
        private string ReverseWordsInPlace(string str)
        {
            string pattern = " ";
            string[] words = Regex.Split(str, pattern);

            int length = words.Length;  //Possibility of integer overflow for large string inputs.

            for (int i = 0; i < length / 2; i++)
            {
                string temp = words[i];
                words[i] = words[length - i - 1];
                words[length - i - 1] = temp;
            }

            str = String.Join(" ", words);
            return str;
        }

        // Method2: 
        private string ReverseWordsInPlace2(string str)
        {
            //Reverse characters from beginning to end.
            char[] chars = str.ToCharArray();
            int length = chars.Length;
            chars = ReverseCharsInPlace(chars, 0, length - 1);

            int startIndex = 0, endIndex = 0;

            for(int i = 0; i < length; i++)
            {
                if(chars[i] == ' ' || i == length-1)
                {
                    // endIndex is 1 index before blank space if i is not the last index. 
                    endIndex = i == length - 1 ? i : i - 1;
                    chars = ReverseCharsInPlace(chars, startIndex, endIndex);
                    startIndex = i + 1; // Set startIndex for next word.
                }
            }

            return new String(chars);
        }

        private static char[] ReverseCharsInPlace(char[] chars, int startIndex, int endIndex)
        {
            int length = endIndex - startIndex + 1;

            for(int i = 0; i < length/2; i++)
            {
                char temp = chars[startIndex + i];
                chars[startIndex + i] = chars[endIndex - i];
                chars[endIndex - i] = temp;
            }

            return chars;
        }
    }
}
