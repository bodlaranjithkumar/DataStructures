using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    /**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
    // Leetcode 341 - https://leetcode.com/problems/flatten-nested-list-iterator/description/
    // Submission Detail -  https://leetcode.com/submissions/detail/192528274/

    public class NestedListIterator
    {
        Stack<NestedInteger> values;

        public NestedListIterator(IList<NestedInteger> nestedList)
        {
            values = new Stack<NestedInteger>();

            for (int i = nestedList.Count - 1; i >= 0; i--)
                values.Push(nestedList[i]);
        }

        //public bool HasNext()
        //{
        //    while (values.Count > 0)
        //    {
        //        var peek = values.Peek();

        //        if (peek.IsInteger())
        //        {
        //            return true;
        //        }
        //        else
        //        {   // Iterate through all the nested lists.
        //            var top = values.Pop().GetList();

        //            for (int i = top.Count() - 1; i >= 0; i--)
        //                values.Push(top[i]);
        //        }
        //    }

        //    return false;
        //}

        //public int Next()
        //{
        //    return values.Pop().GetInteger();
        //}
    }
}
