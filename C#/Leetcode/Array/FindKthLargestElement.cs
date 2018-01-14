using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 215
    public class FindKthLargestElement
    {
        public static void Main(string[] args)
        {
            FindKthLargestElement ele = new FindKthLargestElement();

            int[] A = { 3, 2, 1, 5, 6, 6, 4 };
            int value = ele.FindKthLargestOptimized(A, 2);   //5
            Console.WriteLine(value);

            int[] B = { -1, 0, 2 };
            value = ele.FindKthLargestOptimized(B, 3);   //-1
            Console.WriteLine(value);

            int[] C = { 1 };
            value = ele.FindKthLargestOptimized(C, 1);   //1
            Console.WriteLine(value);

            Console.ReadKey();
        }

        // Modification of Quick Sort Algorithm
        // Tx = O(n) best case
        // Tx = O(nlogn) worst case
        // Sx = O(1)
        public int FindKthLargestOptimized(int[] nums, int k)
        {
            return QuickSort(nums, 0, nums.Length - 1, nums.Length - k); // Find 2nd largest. So, length-k.            
        }

        private static int QuickSort(int[] A, int start, int end, int k)
        {
            if (start < end)
            {
                int pIndex = Partition(A, start, end);
                if (pIndex == k)
                    return A[pIndex];
                else if (pIndex > k)
                    return QuickSort(A, start, pIndex - 1, k);
                else
                    return QuickSort(A, pIndex + 1, end, k);
            }

            return A[k];
        }

        private static int Partition(int[] A, int start, int end)
        {
            int pivot = A[end];
            int pIndex = start;

            for (int i = start; i < end; i++)
            {
                if (A[i] <= pivot)
                {
                    Helper.Swap(A, i, pIndex);
                    pIndex++;
                }
            }

            Helper.Swap(A, pIndex, end);
            return pIndex;
        }

        // Tx = O(nlogn)
        // Sx = O(1)
        // Not optimal
        public int FindKthLargest(int[] nums, int k)
        {
            System.Array.Sort(nums);

            return nums[nums.Length - k];

            //for (int i = nums.Length - 1; i >= 0; i--)
            //{
            //    if (k == 1)
            //        return nums[i];

            //    k--;
            //}

            //return 0;
        }
    }
}
