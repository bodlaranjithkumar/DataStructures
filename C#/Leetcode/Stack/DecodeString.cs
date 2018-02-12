using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Stack
{
    // Leetcode 394
    public class DecodeString
    {
        //public static void Main(string[] args)
        //{
        //    DecodeString d = new DecodeString();
        //    var result1 = d.DecodeEncodedString("3[a2[c]]");
        //    var result2 = d.DecodeEncodedString("2[abc]3[cd]ef");
        //    var result3 = d.DecodeEncodedString("3[a]2[bc]");
        //    var result4 = d.DecodeEncodedString("3[a2[c]]2[b]");
        //    var result5 = d.DecodeEncodedString("100[a]");
        //}

        //3[a2[c]]
        //2[abc]3[cd]ef
        //3[a]2[bc]
        //3[a2[c]]2[b]
        //100[a]
        // Runtime: 158ms

        public string DecodeEncodedString(string s)
        {
            Stack<int> frequencies = new Stack<int>();
            Stack<char> chars = new Stack<char>();

            StringBuilder decodedString = new StringBuilder();

            for (int j = 0; j < s.Length; j++)
            {
                char c = s[j];

                if (char.IsDigit(c))
                {
                    // Calculate the number with > 1 digit
                    int count = 0;
                    while (s[j] >= '0' && s[j] <= '9')
                    {
                        count = count * 10 + s[j] - '0';
                        j++;
                    }

                    j--;
                    frequencies.Push(count);
                }
                else if (char.IsLetter(c) || c == '[')
                {
                    if (frequencies.Count == 0)
                        decodedString.Append(c);    // This is a letter since the assumption is the string is well formed.
                    else
                        chars.Push(c);  // letter or [
                }
                else if (c == ']')
                {
                    int frequency = frequencies.Pop();

                    // Append the characters to the stringbuilder.
                    StringBuilder str = new StringBuilder();
                    while (Char.IsLetter(chars.Peek()))
                    {
                        char charToAppend = chars.Pop();
                        str.Insert(0, charToAppend);    // append char in the beginning.
                    }

                    chars.Pop();    // Remove [

                    // Push the appended characters into the stack 
                    for (int i = 0; i < frequency; i++)
                    {
                        foreach (char charToInsert in str.ToString())
                            chars.Push(charToInsert);
                    }

                    // Append to the decoded string.
                    if (frequencies.Count == 0)
                    {
                        if (decodedString.Length == 0 && j != s.Length-1)
                        {
                            while (chars.Count > 0)
                                decodedString.Insert(0, chars.Pop());
                        }
                        else
                        {
                            int length = decodedString.Length;
                            while (chars.Count > 0)
                                decodedString.Insert(length, chars.Pop());
                        }
                    }
                } 
            }

            return decodedString.ToString();
        }
    }
}
