using System;

namespace LeetcodeSolutions.Array
{
    // LeetCode 283
    class MoveZeros
    {
        // Solution 1 : Clean code
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
