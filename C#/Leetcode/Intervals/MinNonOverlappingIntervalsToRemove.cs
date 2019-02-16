using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.Intervals
{
    // Leetcode 435 - https://leetcode.com/problems/non-overlapping-intervals/description/
    // Submission Detail - https://leetcode.com/submissions/detail/208363363/

    public class MinNonOverlappingIntervalsToRemove
    {
        // Algorithm: To get the minimum overlapping intervals to remove from the intervals,
        //  sort the intervals by comparing the start times in ascending order and then calculate 
        //  the total non-overlapping intervals. Removing this from the total intervals gives the result.
        //  While calculating the count, if the next interval's start is > last interval's end then,
        //  it is a non-overlapping interval. Otherwise, update the lastEnd as the minimum of the 2 intervals.
        
        // Tx = O(nlogn)
        // Sx = O(1)
        public int EraseOverlapIntervals(Interval[] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return 0;

            System.Array.Sort(intervals, (a, b) => {
                return a.start.CompareTo(b.start);   // sort in ascending order
            });

            int lastEnd = intervals[0].end;
            int count = 1;  // holds the total number of non-overlapping intervals

            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i].start >= lastEnd)
                {   // non-overlapping interval
                    count++;
                    lastEnd = intervals[i].end;
                }
                else
                {
                    lastEnd = System.Math.Min(lastEnd, intervals[i].end);
                }
            }

            return intervals.Length - count;
        }
    }
}
