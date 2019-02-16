using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode  - https://leetcode.com/problems/wiggle-sort/description/
    // Submission Detail - https://leetcode.com/submissions/detail/185919227/

    public class WiggleSort
    {
        //public static void Main(string[] args)
        //{
        //    WiggleSort ws = new WiggleSort();

        //    int[] nums1 = { 3, 5, 2, 1, 6, 4 };
        //    //ws.WiggleSortBF(nums1);
        //    //Helper.PrintArray(nums1); // 1,3,2,5,4,6

        //    ws.WiggleSortt(nums1);
        //    Helper.PrintArray(nums1);   // 3,5,1,6,2,4

        //    Console.ReadLine();
        //}

        // Algorithm: For every alternate positions starting with index 1 do:
        //      1. if the current number is less than previous, then swap
        //      2. if the current number if less than next, then swap
        // Tx = O(n)
        // Sx = O(1)
        public void WiggleSortt(int[] nums)
        {
            for (int i = 1; i < nums.Length; i += 2)
            {
                if (i >= 0 && nums[i] < nums[i - 1])
                    Helper.Swap(nums, i, i - 1);

                if (i + 1 < nums.Length && nums[i] < nums[i + 1])
                    Helper.Swap(nums, i, i + 1);
            }
        }

        // Bruteforce: Sort array. Merge sort or heap sort
        // Tx = O(nlogn)
        // Sx = O(1)
        public void WiggleSortBF(int[] nums)
        {
            System.Array.Sort(nums);

            for(int i = 2; i< nums.Length; i += 2)
                Helper.Swap(nums, i, i - 1);
        }
    }
}
