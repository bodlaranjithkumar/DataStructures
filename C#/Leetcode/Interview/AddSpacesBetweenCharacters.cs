using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Interview
{
    // Input : " coding  is fu n   "
    // Output: " c o d i n g  i s f u n   "
    public class AddSpacesBetweenCharacters
    {
        //public static void Main(string[] args)
        //{
        //    string input1 = " coding  is fu n   ";
        //    Console.WriteLine($"input:{input1}.\t expected:{" c o d i n g  i s f u n   "}.\t output:{AddSpaces(input1)}.");

        //    string input2 = "s  ";
        //    Console.WriteLine($"input:{input2}.\t expected:{input2}.\t output:{AddSpaces(input2)}.");

        //    string input3 = "";
        //    Console.WriteLine($"input:{input3}.\t expected:{input3}.\t output:{AddSpaces(input3)}.");

        //    Console.ReadKey();
        //}

        public static string AddSpaces(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
                return input;

            StringBuilder output = new StringBuilder();

            for(int index = 0; index < input.Length; index++)
            {
                char charAtIndex = input[index];
                bool charAtNextIndexIsNotSpace = false;
                
                if (charAtIndex != ' ')
                {
                    if (index < input.Length - 1 && input[index + 1] != ' ')
                        charAtNextIndexIsNotSpace = true;

                    output.Append(charAtIndex);
                }   

                if (charAtNextIndexIsNotSpace || charAtIndex == ' ')
                    output.Append(' ');
            }

            return output.ToString();
        }
    }
}
