using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 281
    // Explanation: http://www.cnblogs.com/grandyang/p/5212785.html
    // v1 = [1, 2], v2 = [3, 4, 5, 6] -> [1, 3, 2, 4, 5, 6]
    public class ZigZagIterator
    {
        int[] nums;
        int index;
            
        //public static void Main(string[] args)
        //{
        //    int[] nums1 = { 1, 2 }, nums2 = { 3, 4, 5, 6 };
        //    ZigZagIterator zzi = new ZigZagIterator(nums1, nums2);
        //    while (zzi.HasNext())
        //    {
        //        Console.WriteLine(zzi.Next());
        //    }
        //}

        // TODO: Additional space avoided?
        // TODO: Work on the follow-up question.
        // Tx = O(max(n,m))
        // Sx = O(n+m);
        public ZigZagIterator(int[] nums1, int[] nums2)
        {
            int length1 = nums1.Length, length2 = nums2.Length,j = 0;
            int maxLength = System.Math.Max(length1, length2);

            nums = new int[length1 + length2];
            for (int i = 0; i < maxLength; i++)
            {
                if (i < length1) nums[j++] = nums1[i];
                if (i < length2) nums[j++] = nums2[i];
            }
        }

        int Next()
        {
            return nums[index++];
        }

        bool HasNext()
        {
            return index < nums.Length;
        }
    }
}
