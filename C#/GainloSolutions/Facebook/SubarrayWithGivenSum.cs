using System;
using System.Collections.Generic;
using System.Text;

namespace GainloSolutions.Facebook
{
    class SubArrayWithGivenSum
    {
        //public static void Main(string[] args)
        //{
        //    SubArrayWithGivenSum subArray = new SubArrayWithGivenSum();
        //    int[] A = {7,5,1,4,6,11,7,8,1,9};

        //    int[] result = subArray.FindSubArrayWithGivenSum(A, 10);
        //    Console.ReadKey();
        //}

        // T(x) = O(n), S(x) = O(n)
        public int[] FindSubArrayWithGivenSum(int[] A, int sum)
        {
            int startIndex = 0, endIndex = 1;
            int subArraySum = A[startIndex];

            int[] subArray = null;

            while (endIndex < A.Length)
            {
                subArraySum += A[endIndex];

                if(subArraySum < sum)
                {
                    endIndex++;
                }
                else if(subArraySum > sum)
                {
                    startIndex += 1;
                    endIndex = startIndex + 1;
                    subArraySum = A[startIndex];
                }
                else
                {   // Found subarray with given sum.
                    subArray = new int[endIndex - startIndex + 1];
                    int i = 0;
                    while(startIndex <= endIndex)
                    {
                        subArray[i] = A[startIndex];
                        startIndex++;
                        i++;
                    }
                    return subArray;
                }
            }

            return subArray;    // No SubArray Found. Interviewer makes the decision to throw exception or return null;
        }
    }
}
