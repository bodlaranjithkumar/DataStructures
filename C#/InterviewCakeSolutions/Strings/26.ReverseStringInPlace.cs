using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.Arrays
{
    class StringReverse
    {
        //public static void Main(string[] args)
        //{
        //    string stringToReverse = "Microsoft";
        //    StringReverse stringReverse = new StringReverse();
        //    stringToReverse = stringReverse.ReverseStringInPlace(stringToReverse);

        //    foreach (char c in stringToReverse)
        //        Console.Write($"{c}");

        //    Console.ReadKey();
        //}

        // TO DO: What if the length of the string is large?
        private string ReverseStringInPlace(string str)
        {
            if (str.Length == 0)
                throw new ArgumentException("String cannot be empty", nameof(str));
            else if (str.Length == 1)
                return str;

            char[] chars = str.ToCharArray();
            int length = chars.Length;

            for(int i = 0; i < length / 2; i++)
            {
                char temp = chars[i];
                chars[i] = chars[length - i - 1];
                chars[length - i - 1] = temp;
            }

            return new String(chars);   //Does this violate inplace constraint given in the problem?
        }
    }
}
