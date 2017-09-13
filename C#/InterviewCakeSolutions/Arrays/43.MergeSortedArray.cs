using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InterviewCakeSolutions.Arrays
{
    class MergeSortedArray
    {
        //public static void Main(string[] args)
        //{
        //    int[] myArray = { 5, 6, 9, 10, 11, 12, 14, 20 };
        //    int[] alicesArray = { 1, 4, 7, 8, 10, 13, 17, 18 };

        //    MergeSortedArray mergeArray = new MergeSortedArray();

        //    // Output: {1,4,5,6,7,8,9,10,11,12,13,14,17,18,20}
        //    int[] mergedArray = mergeArray.mergeSortedArrays(myArray, alicesArray);

        //    foreach (int order in mergedArray)
        //        Console.Write($"{order}, ");

        //    Console.ReadKey();
        //}


        public int[] mergeSortedArrays(int[] myArray, int[] alicesArray)
        {
            int myArrayLength = myArray.Length;
            int alicesArrayLength = alicesArray.Length;

            if (myArrayLength == 0 && alicesArrayLength == 0)
                throw new ArgumentNullException("input arrays cannot be empty");

            //return mergeSortedArrays(myArray, myArrayLength, alicesArray, alicesArrayLength);

            return mergeSortedArrays2(myArray, myArrayLength, alicesArray, alicesArrayLength);

            //return mergeSortedArraysReadable(myArray, myArrayLength, alicesArray, alicesArrayLength);
        }

        // Method1
        private int[] mergeSortedArrays(int[] myArray, int myArrayLength, int[] alicesArray, int alicesArrayLength)
        {
            int[] mergedArray = new int[myArrayLength + alicesArrayLength];

            int myArrayIndex = 0, alicesArrayIndex = 0;

            while (myArrayIndex < myArrayLength || alicesArrayIndex < alicesArrayLength)
            {
                int mergedArrayIndex = myArrayIndex + alicesArrayIndex;

                if (myArrayIndex == myArrayLength && alicesArrayIndex != alicesArrayLength)
                {
                    mergedArray[mergedArrayIndex] = alicesArray[alicesArrayIndex];
                    alicesArrayIndex++;
                }
                else if (myArrayIndex != myArrayLength && alicesArrayIndex == alicesArrayLength)
                {
                    mergedArray[mergedArrayIndex] = myArray[myArrayIndex];
                    myArrayIndex++;
                }
                else
                {
                    if (myArray[myArrayIndex] <= alicesArray[alicesArrayIndex])
                    {
                        mergedArray[mergedArrayIndex] = myArray[myArrayIndex];
                        myArrayIndex++;
                    }
                    else
                    {
                        mergedArray[mergedArrayIndex] = alicesArray[alicesArrayIndex];
                        alicesArrayIndex++;
                    }
                }
            }

            return mergedArray;
        }

        // Method2 :
        private int[] mergeSortedArrays2(int[] myArray, int myArrayLength, int[] alicesArray, int alicesArrayLength)
        {
            int[] mergedArray = new int[myArrayLength + alicesArrayLength];

            int myArrayIndex = 0, alicesArrayIndex = 0;

            while (myArrayIndex < myArrayLength || alicesArrayIndex < alicesArrayLength)
            {
                int mergedArrayIndex = myArrayIndex + alicesArrayIndex;

                if (alicesArrayIndex != alicesArrayLength && (myArrayIndex == myArrayLength
                                                        || alicesArray[alicesArrayIndex] <= myArray[myArrayIndex]))
                {
                    mergedArray[mergedArrayIndex] = alicesArray[alicesArrayIndex];
                    alicesArrayIndex++;
                }
                else if (myArrayIndex != myArrayLength && (alicesArrayIndex == alicesArrayLength
                                                            || myArray[myArrayIndex] <= alicesArray[alicesArrayIndex]))
                {
                    mergedArray[mergedArrayIndex] = myArray[myArrayIndex];
                    myArrayIndex++;
                }
            }

            return mergedArray;
        }

        // Method3 : Readable and implementing DRY (Do Not Repeat Yourself)
        private int[] mergeSortedArraysReadable(int[] myArray, int myArrayLength, int[] alicesArray, int alicesArrayLength)
        {
            int mergedArrayLength = myArrayLength + alicesArrayLength;
            int[] mergedArray = new int[mergedArrayLength];

            int myArrayIndex = 0, alicesArrayIndex = 0, mergedArrayIndex = 0;

            while( mergedArrayIndex < mergedArrayLength)
            {
                bool myArrayExhausted = myArrayIndex >= myArrayLength;
                bool alicesArrayExhausted = alicesArrayIndex >= alicesArrayLength;

                if(!myArrayExhausted && (alicesArrayExhausted 
                                        || (myArray[myArrayIndex] <= alicesArray[alicesArrayIndex])))
                {
                    mergedArray[mergedArrayIndex] = myArray[myArrayIndex];
                    myArrayIndex++;
                }
                else
                {
                    mergedArray[mergedArrayIndex] = alicesArray[alicesArrayIndex];
                    alicesArrayIndex++;
                }

                mergedArrayIndex++;
            }

            return mergedArray;
        }
    }
}
