using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Interview
{
    // a1 = {6,4,7,4,3,2}, a2 = {4,4}   -> true
    // a1 = {6,5,7,3,3,2}, a2 = {4,4}   -> false
    // a1 = {5,7,4,3,2}, a2 = {4,6}     -> false
    public class SubsetArray
    {
        // Bruteforce:
        // Method1: Tx = O(m*n), Sx = O(1)
        //  Foreach number in superset, check linearly if that number exists in the subset array.

        // Method2: Tx = O(mlogm + nlogm) = O((m+n)logm), Sx = O(1)
        //  Sort the SuperSet array in O(mlogm) Tx. Then parse the subset array, search the current in the superset using binarysearch.

        //public static void Main(string[] args)
        //{
        //    int[] a1 = { 6, 4, 7, 4, 3, 2 }, a2 = { 4, 4 };
        //    Console.WriteLine(IsSubset(a1, a2));

        //    int[] a3 = { 6, 5, 7, 3, 3, 2 }, a4 = { 4, 4 };
        //    Console.WriteLine(IsSubset(a3, a4));

        //    int[] a5 = { 5, 7, 4, 3, 2 }, a6 = { 4, 6 };
        //    Console.WriteLine(IsSubset(a5, a6));

        //    Console.ReadKey();
        //}

        // Thought: Find the superset, subset arrays. Calculate the frequencies of a number in the superset.
        //      Parse the subset array. If current is not present as a key in dictionary or frequency < 0, then return false, else decrement frequency by 1;
        // Tx = O(m+n)
        // Sx = O(max(m,n))
        public static bool IsSubset(int[] a1, int[] a2)
        {
            if (a1 == null || a2 == null) return true;

            int l1 = a1.Length, l2 = a2.Length;

            int[] superSet = l1 >= l2 ? a1 : a2;
            int[] subSet = l1 < l2 ? a1 : a2;

            IDictionary<int, int> frequencies = new Dictionary<int, int>();

            foreach (int num in superSet)
            {
                if (frequencies.ContainsKey(num))
                    frequencies[num]++;
                else
                    frequencies.Add(num, 1);
            }

            foreach (int num in subSet)
            {
                if (!frequencies.ContainsKey(num) || frequencies[num] == 0)
                    return false;
                else
                    frequencies[num]--;
            }

            return true;
        }

        // Idea : Find the difference betwen the 2 arrays using mathematical operaions and bitwise operations.
        //          Check if both the differences are same.
        // Fails for example 2 above because 5+3 = 4+4
        //public static bool IsSubset(int[] a1, int[] a2)
        //{
        //    if (a1 == null || a2 == null) return true;

        //    int diff = 0, xorDiff = 0, l1 = a1.Length, l2 = a2.Length;

        //    int[] superSet = l1 >= l2 ? a1 : a2;
        //    int[] subSet = l1 < l2 ? a1 : a2;

        //    foreach (int num in superSet)
        //        diff += num;

        //    foreach (int num in subSet)
        //        diff -= num;

        //    for (int i = 0; i < superSet.Length; i++)
        //    {
        //        int j = i < subSet.Length ? subSet[i] : 0;
        //        xorDiff += superSet[i] ^ j;
        //    }

        //    return diff == xorDiff;
        //}
    }
}
