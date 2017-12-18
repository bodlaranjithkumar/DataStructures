using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    public class ReverseStringPreservingSpecialCharacterPosition
    {
        public static void Main(string[] args)
        {
            string str1 = "b$";
            Console.WriteLine($"input:{str1}, expected:{str1}, actual:{ReverseString(str1)}");

            string str2 = "ab";
            Console.WriteLine($"input:{str2}, expected:ba, actual:{ReverseString(str2)}");

            string str3 = "abc$de%f";
            Console.WriteLine($"input:{str3}, expected:fed$cb%a, actual:{ReverseString(str3)}");

            string str4 = "a(&fdgh*fdf";
            Console.WriteLine($"input:{str4}, expected:f(&dfhg*dfa, actual:{ReverseString(str4)}");

            Console.ReadKey();
        }

        //Tx = O(n)
        //Sx = O(n)
        public static string ReverseString(string input)
        {
            //edge cases
            if (string.IsNullOrEmpty(input) || input.Length == 1)
                return input;

            char[] chars = input.ToCharArray();
            int left = 0;
            int right = input.Length - 1;

            while (left < right)
            {
                while (left < right && !Char.IsLetterOrDigit(chars[left]))
                {
                    left++;
                }

                while (left < right && !Char.IsLetterOrDigit(chars[right]))
                {
                    right--;
                }

                if (left < right)
                {
                    char temp = chars[left];
                    chars[left] = chars[right];
                    chars[right] = temp;

                    left++;
                    right--;
                }
            }

            return new string(chars);
        }
    }
}
