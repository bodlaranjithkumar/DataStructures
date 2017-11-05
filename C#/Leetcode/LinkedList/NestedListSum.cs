using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 339
    public class NestedListSum
    {
        //static void Main(string[] args)
        //{
        //    NestedInteger first = new NestedInteger()
        //    {
        //        List = new List<NestedInteger>()
        //        {
        //            new NestedInteger() { Number = 1 },
        //            new NestedInteger() { Number = 1 }
        //        }
        //    };

        //    NestedInteger second = new NestedInteger()
        //    {
        //        Number = 2
        //    };

        //    NestedInteger third = new NestedInteger()
        //    {
        //        List = new List<NestedInteger>()
        //        {
        //            new NestedInteger() { Number = 1 },
        //            new NestedInteger() { Number = 1 }
        //        }
        //    };

        //    List<NestedInteger> firstList = new List<NestedInteger>
        //    {
        //        first,
        //        second,
        //        third
        //    };

        //    Console.WriteLine($"sum:{ComputeNestedListSum(firstList)}\t expected:10");
        //    Console.WriteLine($"using recursion: sum:{ComputeNestedListSumRecursive(firstList)}\t expected:10");

        //    first = new NestedInteger() { Number = 1 };

        //    second = new NestedInteger()
        //    {
        //        List = new List<NestedInteger>()
        //        {
        //           new NestedInteger()
        //           {
        //                Number = 4
        //           },
        //           new NestedInteger()
        //           {
        //                List = new List<NestedInteger>()
        //                {
        //                    new NestedInteger()
        //                    {
        //                        Number = 6
        //                    }
        //                }
        //           }
        //        }
        //    };

        //    List<NestedInteger> secondList = new List<NestedInteger>
        //    {
        //        first,
        //        second
        //    };

        //    Console.WriteLine($"sum:{ComputeNestedListSum(secondList)}\t expected:27");
        //    Console.WriteLine($"using recursion: sum:{ComputeNestedListSumRecursive(secondList)}\t expected:27");

        //    Console.ReadKey();
        //}

        // Tx = O(n) {n: number of nested integers}
        // Sx = O(2n)
        // [[1,1],2,[1,1]] = 10
        // [1,[4,[6]]] = 27
        public static int ComputeNestedListSum(List<NestedInteger> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            else if (list.Count == 0)
                return 0;

            int depth = 1, sum = 0;

            Queue<NestedInteger> nestedIntegers = new Queue<NestedInteger>();

            foreach (var ni in list)
                nestedIntegers.Enqueue(ni);

            while (nestedIntegers.Count > 0)
            {
                int size = nestedIntegers.Count;

                for (int index = 0; index < size; index++)
                {
                    NestedInteger nestedInteger = nestedIntegers.Dequeue();

                    if (nestedInteger.List != null)
                    {
                        foreach (var ni in nestedInteger.List)
                            nestedIntegers.Enqueue(ni);
                    }
                    else
                    {
                        sum += nestedInteger.Number * depth;
                    }
                }

                depth++;
            }

            return sum;
        }

        // Tx = O(n)
        // Sx = O(n) for recursive call stack.
        public static int ComputeNestedListSumRecursive(List<NestedInteger> list)
        {
            return ComputeNestedListSumRecursive(list, 1);
        }

        private static int ComputeNestedListSumRecursive(List<NestedInteger> list, int depth)
        {
            int sum = 0;

            foreach(var ni in list)
            {
                sum += ni.List == null ? ni.Number * depth : ComputeNestedListSumRecursive(ni.List, depth + 1);
            }

            return sum;
        }
    }
}
