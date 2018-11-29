using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Queue
{
    // Leetcode 295 - https://leetcode.com/problems/find-median-from-data-stream/description/
    // Submission Detail - https://leetcode.com/submissions/detail/192353772/
    // Note: This is written using java to use PriorityQueue which doesn't exist in C#.

    // Algorithm: If count is even, the median is average of middle 2 if the numbers are sorted.
    //      Sorting takes O(nlogn) for every add num. To avoid this, if the middle 2 nums
    //      can be tracked somehow, calculating median will take O(1).
    //      So, use 2 PriorityQueues - first for the first half, 2nd for the
    //      2nd half of the sorted array. So, every time a new number needs to be added
    //      if even, add the number to large and then add the large.polled value to small.
    //      if odd, add the number to small and then add the small.polled value to large.
    //      The PQs can be swapped in above 2 lines as well.

    public class FindMedianFromDataStream
    {
        //private PriorityQueue<Integer> firstHalfNums, secondHalfNums;
        //private boolean isEvenCount = true; // 0 is even

        ///** initialize your data structure here. */
        //public FindMedianFromDataStream()
        //{
        //    firstHalfNums = new PriorityQueue<Integer>(Collections.reverseOrder());
        //    secondHalfNums = new PriorityQueue<Integer>();
        //}

        //public void addNum(int num)
        //{
        //    if (isEvenCount)
        //    {
        //        secondHalfNums.offer(num);
        //        firstHalfNums.offer(secondHalfNums.poll());
        //    }
        //    else
        //    {
        //        firstHalfNums.offer(num);
        //        secondHalfNums.offer(firstHalfNums.poll());
        //    }

        //    isEvenCount = !isEvenCount;
        //}

        //public double findMedian()
        //{
        //    if (isEvenCount)
        //        return (firstHalfNums.peek() + secondHalfNums.peek()) / 2.0;
        //    else
        //        return firstHalfNums.peek();
        //}
    }
}
