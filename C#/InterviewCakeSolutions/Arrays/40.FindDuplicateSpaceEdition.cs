using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewCakeSolutions.Arrays
{
    class ArrayDuplicates
    {
        List<int> duplicates;
        int[] duplicatesArray;

        public ArrayDuplicates()
        {
            duplicates = new List<int>();
        }

        public ArrayDuplicates(int length)
        {
            duplicatesArray = new int[length];
        }

        //public static void Main(string[] args)
        //{
        //    ArrayDuplicates arrayDuplicate = new ArrayDuplicates();

        //    int[] elements = { 1, 4, 3, 1, 5, 2, 1, 6, 2 };
        //    //arrayDuplicate.FindDuplicatesInArray(elements);
        //    //arrayDuplicate.FindDuplicatesInArrayTimeOptimized(elements);
        //    //arrayDuplicate.FindDuplicatesInArrayTimeOptimizedSpaceDeoptimized(elements);

        //    //foreach (int element in arrayDuplicate.duplicates)
        //    //{
        //    //    Console.WriteLine($"{element}");
        //    //}

        //    // Range of array elements given. So use Array with given range as capacity.
        //    ArrayDuplicates arrayDuplicate1 = new ArrayDuplicates(6);
        //    arrayDuplicate1.FindDuplicatesInArrayWithRangeGivenTimeOptimized(elements);

        //    foreach (int element in arrayDuplicate1.duplicatesArray)
        //    {
        //        if(element != 0)
        //            Console.WriteLine($"{element}");
        //    }

        //    Console.ReadKey();
        //}

        //Tx = O(n2), Sx = O(n) for Output List
        public List<int> FindDuplicatesInArray(int[] inputArray)
        {
            if (inputArray.Length == 1)
                return null;

            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[i] == inputArray[j] && !duplicates.Contains(inputArray[j]))
                    {
                        duplicates.Add(inputArray[j]);
                    }
                }
            }

            return duplicates;
        }

        //Tx = O(nlgn), Sx = O(n) for Output List
        //Destroys input i.e. does in-place sorting. Sometimes undesired.
        public List<int> FindDuplicatesInArrayUsingSorting(int[] inputArray)
        {
            if (inputArray.Length == 1)
                return null;

            Array.Sort(inputArray); // O(nlgn)

            for (int i = 0; i < inputArray.Length - 1; i++) //O(n)
            {
                int j = i + 1;

                if (inputArray[i] == inputArray[j] && !duplicates.Contains(inputArray[j]))
                {
                    duplicates.Add(inputArray[j]);
                }
            }

            return duplicates;
        }

        //Tx = O(nlgn), Sx = O(n) for Output List
        public int[] FindDuplicatesInArrayWithRangeGivenTimeOptimized(int[] inputArray)
        {
            if (inputArray.Length == 1)
                return null;

            Array.Sort(inputArray); // O(nlgn)

            for (int i = 0; i < inputArray.Length - 1; i++) //O(n)
            {
                int j = i + 1;

                if (inputArray[i] == inputArray[j] && duplicatesArray[inputArray[j] - 1] == 0)
                {
                    duplicatesArray[inputArray[j] - 1] = inputArray[j];
                }
            }

            return duplicatesArray;
        }

        //Tx = O(n), Sx=O(n) in fact O(2n). n for dictionary and n for output list.
        public List<int> FindDuplicatesInArrayTimeOptimizedSpaceDeoptimized(int[] inputArray)
        {
            if (inputArray.Length == 1)
                return null;

            Dictionary<int, int> duplicatesCount = new Dictionary<int, int>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                int element = inputArray[i];

                if(!duplicatesCount.ContainsKey(element))
                {
                    duplicatesCount.Add(element, 1);
                }
                else
                {
                    duplicatesCount[element]++;
                }
            }

            duplicates = duplicatesCount.Where(ele => ele.Value > 1).Select(ele => ele.Key).ToList();
            return duplicates;
        }               
    }
}
