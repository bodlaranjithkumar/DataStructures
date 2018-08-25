using System;

namespace LeetcodeSolutions.Math
{
    // Leetcode 268 - https://leetcode.com/problems/missing-number/
    // Submission Detail:
    //      Sum : https://leetcode.com/submissions/detail/143644300/
    //      Bit Manipulation: https://leetcode.com/submissions/detail/143645339/

    // Input: [3,0,1] -> 2
    // Input: [9,6,4,2,3,5,7,0,1] -> 8
    public class MissingNumber
    {
        // Tx = O(n)
        // Sx = O(1)
        // Thought: x ^ x = 0
        public int FindMissingNumberBitManipulation(int[] nums)
        {
            int missingNumber = 0, current = 1;

            foreach (int num in nums)
            {
                missingNumber ^= current ^ num;
                current++;
            }

            return missingNumber;
        }

        // Tx = O(n)
        // Sx = O(1)
        // Possibility of integer overflow exception for big n.
        public int FindMissingNumber(int[] nums)
        {
            int n = nums.Length + 1;
            int expectedSum = n * (n - 1) / 2;

            int sum = 0;
            foreach (int num in nums)
                sum += num;

            return expectedSum - sum;
        }
    }
}
