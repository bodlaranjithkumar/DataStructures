using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.DSandAlgorithms
{
    // Theory - https://www.youtube.com/watch?v=COk73cpQbFQ
    public class QuickSort
    {
        //public static void Main(string[] args)
        //{
        //    QuickSort QS = new QuickSort();

        //    int[] A = { 7, 2, 1, 6, 8, 5, 3, 4 };
        //    QS.Sort(A);
        //    Helper.PrintArray(A);

        //    Console.ReadLine();
        //}

        // Tx = O(nlogn) Best and average case
        // Tx = O(n^2) Worst case
        // Sx =O(1) because it is in-place.
        public void Sort(int[] A)
        {
            Sort(A, 0, A.Length - 1);
        }

        public void Sort(int[] A, int start, int end)
        {
            if (start < end)
            {
                int pIndex = Partition(A, start, end);
                Sort(A, start, pIndex - 1);
                Sort(A, pIndex + 1, end);
            }
        }

        public int Partition(int[] A, int start, int end)
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
    }
}
