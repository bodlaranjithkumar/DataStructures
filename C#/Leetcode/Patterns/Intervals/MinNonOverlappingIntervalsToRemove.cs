using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.Patterns.Intervals
{
    // Leetcode 435 - https://leetcode.com/problems/non-overlapping-intervals/description/

    // Explanation - https://www.hellointerview.com/learn/code/intervals/non-overlapping-intervals
    // Submission Detail - https://leetcode.com/problems/non-overlapping-intervals/submissions/1542423922

    // Idea is to find the minimum overlapping intervals to remove, sort the intervals
    // based on the end time in ascending order and calculate the overall
    // non-overlapping intervals count. Result is the total intervals - count.
    // Sorting in reverse order will ensure that one giant interval will be at the extreme. For example: [[1,3],[5,8],[4,10],[11,13]]

    // Tx = O(nlogn)
    // Sx = O(1)
    public int EraseOverlapIntervals(int[][] intervals) {
        // Sort in asc order based on end time
        Array.Sort(intervals, (i1, i2) => {
            return i1[1].CompareTo(i2[1]);
        });

        int index = 1, nonOverlapCount = 1, length = intervals.GetLength(0), end = intervals[0][1];
        while(index < length) {
            // non-overlap index found.
            // If start & end of consecutive are equal, it's still non-overlapping.
            if(end <= intervals[index][0]) {
                end = intervals[index][1];
                nonOverlapCount++;
            }
            
            index++;
        }

        return length - nonOverlapCount;
    }
    
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
