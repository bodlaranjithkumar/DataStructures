using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.BitWise
{
    // Leetcode 191 - https://leetcode.com/problems/number-of-1-bits/
    // Submission Detail - https://leetcode.com/submissions/detail/164583126/

    public class NumberOf1Bits
    {
        // Ref: https://www.geeksforgeeks.org/count-set-bits-in-an-integer/
        public int HammingWeight(uint n)
        {
            int count = 0;

            while (n > 0)
            {
                count++;
                n = n & n - 1;
            }

            return count;
        }
    }
}
