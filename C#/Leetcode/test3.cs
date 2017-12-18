using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions
{
    using System;
    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");

    class Solution
    {
        //public static void Main(string[] args)
        //{
        //    string S = "codility";
        //    char[] chars = S.ToCharArray();
        //    //Console.WriteLine($"{new string(RotateArray(chars, 2))}");

        //    int TotalCyclicAutomorphs = 1;  // count 1 for 0th cylic shift.
        //    for (int position = 1; position < S.Length; position++)
        //    {
        //        string output = RotateString(chars, 1);

        //        if (string.Equals(S, output))
        //            TotalCyclicAutomorphs++;
        //    }

        //    Console.WriteLine($"TotalCyclicAutomorphs: {TotalCyclicAutomorphs }");

        //        Console.ReadKey();
        //}
        
        private static string RotateString(char[] chars, int position)
        {
            char[] temp = new char[position];
            for (int index = 0; index < position; index++)
            {
                temp[index] = chars[index];
            }

            //
            
            for(int rotateIndex = position, index=0; rotateIndex < chars.Length; rotateIndex++, index++)
            {
                chars[index] = chars[rotateIndex];
            }

            for(int index = chars.Length-position, tempIndex = 0 ; index < chars.Length; index++, tempIndex++)
            {
                chars[index] = temp[tempIndex];
            }

            return new string(chars);
        }
    }
}
