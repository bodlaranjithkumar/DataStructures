using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.Strings
{
    class StringPermutation
    {
        List<string> permutations = null;

        // Constructor
        StringPermutation()
        {
            permutations = new List<string>();
        }

        //public static void Main(string[] args)
        //{
        //    StringPermutation stringPermutation = new StringPermutation();
        //    stringPermutation.RecursiveStringPermutations("abc");
        //    foreach (string str in stringPermutation.permutations)
        //        Console.WriteLine($"{str},");
        //    Console.ReadKey();
        //}

        public List<string> RecursiveStringPermutations(string str)
        {
            return RecursiveStringPermutations(str, "");
        }

        private List<string> RecursiveStringPermutations(string str, string permutation)
        {
            //base case
            if(str.Length == 0)
            {
                permutations.Add(permutation);
                return permutations;
            }

            for(int index = 0; index < str.Length; index++)
            {
                char charToAppendToPermutation = str[index];
                string remainingString = str.Substring(0, index) + str.Substring(index+1);

                RecursiveStringPermutations(remainingString, permutation + charToAppendToPermutation);
            }

            return permutations;
        }
    }
}
