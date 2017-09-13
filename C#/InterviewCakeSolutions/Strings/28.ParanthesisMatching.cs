using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.Strings
{
    class ParanthesisMatching
    {
        //public static void Main(string[] args)
        //{
        //    string str = "Sometimes (when I nest them (my parentheticals) too much (like this (and this))) they get confusing.";
        //    ParanthesisMatching paranthesisMatching = new ParanthesisMatching();
        //    Console.WriteLine(paranthesisMatching.findMatchingParanthesisIndex(str,150));
        //    Console.ReadKey();
        //}

        // Tx = O(n)
        // Sx = O(1)
        private int findMatchingParanthesisIndex(string str, int index)
        {
            if (index > str.Length)
                throw new ArgumentOutOfRangeException("Given index is greater than string length.");
            else if (index == str.Length || str[index - 1] != '(')
                return -1;             

            int paranthesisCount = 0, indexMatchingOcurrence = 0;

            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] == '(')
                {
                    paranthesisCount++;

                    if(i == index)
                        indexMatchingOcurrence = paranthesisCount;
                }
                else if(str[i] == ')')
                {
                    if (paranthesisCount == indexMatchingOcurrence)
                        return i;

                    paranthesisCount--;
                }
            }

            return -1;
        }
    }
}
