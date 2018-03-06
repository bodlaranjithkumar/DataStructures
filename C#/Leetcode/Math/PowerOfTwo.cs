using System;

namespace LeetcodeSolutions.Math
{
    // Leetcode 231
    // Submission Detail: https://leetcode.com/submissions/detail/143649183/
    public class PowerOfTwo
    {
        // Thought: Logical & between perfect square and 1 less than perfect square is always 0.
        // Example : 4 & 3 == 100 & 011 = 0 , 3 & 2 == 11 & 10 = 1
        public bool IsPowerOfTwoOptimal(int n)
        {
            return n > 0 ? (n & (n - 1)) == 0 : false;
        }

        // Thought: A power of Two has just a single occurrence of digit 1 in it's binary representation.
        public bool IsPowerOfTwo(int n)
        {
            int count = 0;

            // Count number of 1s.
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }

            return count == 1;
        }
    }
}
