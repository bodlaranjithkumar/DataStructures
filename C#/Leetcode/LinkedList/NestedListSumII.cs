using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 364
    public class NestedListSumII
    {
        //static void Main(string[] args)
        //{
        //    // [[1,1],2,[1,1]] = 8
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

        //    Console.WriteLine($"sum:{GetNestedListSumReverse(firstList)}\t expected:8");

        //    first = new NestedInteger() { Number = 1 };

        //    second = new NestedInteger()
        //    {
        //        List = new List<NestedInteger>()
        //        {
        //            new NestedInteger()
        //            {
        //                Number = 4
        //            },
        //            new NestedInteger()
        //            {
        //                List = new List<NestedInteger>()
        //                {
        //                    new NestedInteger()
        //                    {
        //                        Number = 6
        //                    }
        //                }
        //            }
        //        }
        //    };

        //    List<NestedInteger> secondList = new List<NestedInteger>()
        //    {
        //        first,
        //        second
        //    };

        //    Console.WriteLine($"sum:{GetNestedListSumReverse(secondList)}\t expected:17");

        //    Console.ReadKey();
        //}

        // Runtime : 98 ms
        // Tx = O(n) {number of nested integers (which are numbers) in the list}
        // Sx = O(n) {list of n nested integers stored in the next level}
        public static int GetNestedListSumReverse(List<NestedInteger> list)
        {
            int weightedSum = 0, unWeightedSum = 0;

            while (list.Count > 0)
            {
                List<NestedInteger> nextLevel = new List<NestedInteger>();

                foreach (var ni in list)
                {
                    if (ni.List != null)
                    {
                        foreach (var nni in ni.List)
                            nextLevel.Add(nni);
                    }
                    else
                    {
                        unWeightedSum += ni.Number;
                    }
                }

                weightedSum += unWeightedSum;
                list = nextLevel;
            }

            return weightedSum;
        }
    }
}
