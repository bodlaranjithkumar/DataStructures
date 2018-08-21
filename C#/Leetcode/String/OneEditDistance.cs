using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 161 - https://leetcode.com/problems/one-edit-distance/
    // Ref - https://www.programcreek.com/2014/05/leetcode-one-edit-distance-java/

    public class OneEditDistance
    {
        public static void Main(string[] args)
        {
            OneEditDistance OED = new OneEditDistance();
            Console.WriteLine(OED.IsOneEditDistance("kit", "kitten"));      //false
            Console.WriteLine(OED.IsOneEditDistance("kitten", "kiten"));    //true
            Console.WriteLine(OED.IsOneEditDistance("kitten", "kitte"));    //true
            Console.WriteLine(OED.IsOneEditDistance("kitten", "kidten"));   //true
            Console.WriteLine(OED.IsOneEditDistance("kitten", "kidden"));   //false

            Console.ReadKey();
        }

        // Tx = O(m) or O(n)
        // Sx = O(1)

        // Algorithm: There are 3 main operations that keep two strings at one edit distance - insert, delete, edit.
        //     Cases: 1. If the different in length between 2 strings is greater than 1, then it is a false.
        //            2. Else, use 2 pointers one for each string to compare the characters at those pointers.
        //               If equal, increment both, else
        //                  increment count which holds the edit distance.
        //                  a. if m == n, increment both pointers
        //                  b. if m < n, increment 2nd pointer
        //                  c. if m > n, increment 1st pointer

        // After the iterative block, there is a possibility for the last character to be the edit character. So,
        // increment the count one more time if either i < m or j < n.

        public bool IsOneEditDistance(string s, string t)
        {
            if (s == null || t == null)
                return false;

            int m = s.Length;
            int n = t.Length;

            if (System.Math.Abs(m - n) > 1)
                return false;

            int count = 0, i = 0, j = 0;

            while (i < m && j < n)
            {
                if (s[i] == t[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    count++;

                    if (count > 1)
                        return false;

                    if (m == n)
                    {
                        i++;
                        j++;
                    }
                    else if (m > n)
                        i++;
                    else
                        j++;
                }
            }

            if (i < m || j < n) // To cover the case when the last character in s or t is a delete or insert.
                count++;

            return count == 1;
        }
    }
}
