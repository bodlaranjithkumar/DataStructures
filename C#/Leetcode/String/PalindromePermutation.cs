using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode: 266 - https://leetcode.com/problems/palindrome-permutation
    // "code" -> False
    // "aab" -> True
    // "carerac" -> True

    public class PalindromePermutation
    {
        // Bruteforce: 
        //  1.  Tx = O(n*n!), Sx = O(1)
        //      Find all the permutations of the given string 
        //      and check if the current string is a palindrome.
        //  2. Tx = O(n), Sx = O(1) {128/256}
        //      Use int array: 
        //          Count the frequencies of all the characters.
        //          and check if > 1 frequencies are odd.
        //  3. Tx = O(n), Sx = O(1) {128/256}
        //      Use int array with 0s/1s: Initialize all the values to -1
        //          Count the frequencies of all the characters by setting to 0s/1s.
        //          and check if > 1 frequencies value is 1.

        //public static void Main(string[] args)
        //{
        //    PalindromePermutation p = new PalindromePermutation();
        //    Console.WriteLine(p.CanPermutePalindrome("aab"));
        //    Console.WriteLine(p.CanPermutePalindrome("code"));
        //    Console.WriteLine(p.CanPermutePalindrome("carerac"));
        //    Console.WriteLine(p.CanPermutePalindrome("aaaaa"));

        //    Console.ReadKey();
        //}

        // Use hashtable to toggle the characters seen before.
        // Tx = O(n)
        // Sx = O(1)    {128/256}
        // Question: Case sensitive?
        public bool CanPermutePalindrome(string s)
        {
            HashSet<char> visited = new HashSet<char>();

            foreach (char c in s)
            {
                if (visited.Contains(c))
                    visited.Remove(c);
                else
                    visited.Add(c);
            }

            return visited.Count <= 1;
        }
    }
}
