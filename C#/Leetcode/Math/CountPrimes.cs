using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Math
{
    // Leecode 204 - https://leetcode.com/problems/count-primes/description/
    // Submission Detail - https://leetcode.com/submissions/detail/189692073/

    // Sieve of Eratosthenes
    // Explanation: https://www.geeksforgeeks.org/sieve-of-eratosthenes/

    // Potential Follow-Up Question: Find all the primes less than n
    // Iterate through the IsNotPrime boolean array and add the index+1 value to the list.

    public class CountPrimes
    {
        // Tx = O(n log(logn))
        // Sx = O(n)

        public int CountPrimesLessThanN(int n)
        {
            bool[] isNotPrime = new bool[n];
            int count = 0;

            for (int i = 2; i < n; i++)
            {
                if (!isNotPrime[i])
                { // i.e. i is prime
                    count++;

                    for (int j = 2; j * i < n; j++)
                    {
                        isNotPrime[j * i] = true;
                    }
                }
            }

            return count;
        }
    }
}
