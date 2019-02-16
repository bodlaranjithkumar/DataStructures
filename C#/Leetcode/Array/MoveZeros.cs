using System;

namespace LeetcodeSolutions.Array
{
    // LeetCode 283 - https://leetcode.com/problems/move-zeroes/description/
    // Submission Detail - https://leetcode.com/submissions/detail/206232536/

    // Input: [0, 1, 0, 3, 12]
    // Output: [1, 3, 12, 0, 0]     
    public class MoveZeros
    {
        // Solution 1 - Clean code
        // Two pointers
        public void MoveZeroes(int[] nums)
        {
            for (int lastZeroFoundAt = 0, current = 0; current < nums.Length; current++)
            {
                if (nums[current] != 0)
                {
                    Swap(nums, lastZeroFoundAt++, current);
                }
            }
        }

        private static void Swap(int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }

        // Solution 2 - worst case Tx = O(2n) although it is clean code
        // Submission Detail - https://leetcode.com/submissions/detail/140502304/
        public void MoveZeroesCleanCode(int[] nums)
        {
            if (nums == null)
                return;

            int pos = 0;
            foreach (var num in nums)
                if (num != 0) nums[pos++] = num;

            while (pos < nums.Length)
                nums[pos++] = 0;
        }

        // Optimized operations.
        public void MoveZereos(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;

            int i = 0, j = 0;
            while (j < nums.Length)
            {
                while (i < nums.Length && nums[i] != 0)
                {
                    i++;
                }

                while (j < nums.Length && j <= i)
                {
                    j++;
                }

                if (j < nums.Length && nums[j] != 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }

                j++;
            }
        }

        
        // Solution2 : Runtime = 678 ms
        // Tx = O(n)
        // Sx = O(1)
        // Leetcode Article - https://leetcode.com/articles/move-zeroes/
        public void MoveZeroesToLast(int[] nums)
        {
            int zeroIndex = 0, nonZeroIndex = 0;
            int length = nums.Length;

            if (nums.Length > 1)
            {
                for (int index = 0; index < length; index++)
                {
                    if (nums[index] == 0 && zeroIndex == 0)
                    {
                        zeroIndex = index;
                        index++;
                    }

                    if (index < length && nums[index] != 0)
                    {
                        nonZeroIndex = index;

                        int temp = nums[nonZeroIndex];
                        nums[nonZeroIndex] = nums[zeroIndex];
                        nums[zeroIndex] = temp;

                        index = zeroIndex;
                        zeroIndex += 1;
                    }
                }
            }
        }
    }
}
