using System;

namespace LeetcodeSolutions.Algorithms
{
    public class MergeSort
    {
        //public static void Main(string[] args)
        //{
        //    int[] A = { 5, 2, 4, 7, 1, 3, 2 };

        //    Sort(A, 0, A.Length - 1);

        //    PrintArray(A);
        //}

        static void PrintArray(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine("Element at index {0} is : {1} \n", i, A[i]);
            }
        }

        static void Sort(int[] A, int start, int end)
        {
            if (start < end)
            {
                //int mid = (int)(Math.Floor((Convert.ToDouble(start) + Convert.ToDouble(end))/2));
                int mid = (start + end) / 2;
                Sort(A, start, mid);
                Sort(A, mid + 1, end);
                //Console.WriteLine("{0}\t{1}\t{2}",start,mid,end);
                Merge(A, start, mid, end);
            }
        }

        static void Merge(int[] A, int start, int mid, int end)
        {
            int length1 = mid - start + 1;
            int length2 = end - mid;

            int[] Left = new int[length1];
            int[] Right = new int[length2];

            int i = 0, j = 0;
            //Console.WriteLine("start {0}",start);
            for (; i < length1; i++)
                Left[i] = A[start + i];

            for (; j < length2; j++)
                Right[j] = A[mid + j + 1];

            i = j = 0;

            for (int k = start; k < end && k > start; k++)
            {
                if (Left[i] <= Right[j])
                {
                    A[k] = Left[i];
                    i++;
                }
                else
                {
                    A[k] = Right[j];
                    j++;
                }
            }
        }
    }
}
