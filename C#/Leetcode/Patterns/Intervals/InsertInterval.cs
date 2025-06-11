using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;

namespace LeetcodeSolutions.Patterns.Intervals
{
    // Leetcode 57 - https://leetcode.com/problems/insert-interval/description/

    public class InsertInterval
    {
        // Explanation - https://www.hellointerview.com/learn/code/intervals/insert-interval
        // 3-step approach 
        // 1. Merge all non-overlapping intervals with newInterval to a new list.
        // 2. Merge all overlapping intervals with newInterval and add it to the list.
        // 3. Merge all the remaining intervals higher than newInterval to the list.
        // Submission Detail - https://leetcode.com/problems/insert-interval/submissions/1542369981
        // Tx = O(n)
        // Sx = O(n)
        public int[][] Insert(int[][] intervals, int[] newInterval) {
            IList<int[]> mergedIntervals = new List<int[]>();

            int index = 0, length = intervals.Length;

            // Step 1
            while(index < length && intervals[index][1] < newInterval[0]) {
                mergedIntervals.Add(intervals[index]);
                index++;
            }

            // Step 2
            while(index < length && intervals[index][0] <= newInterval[1]) {
                newInterval[0] = Math.Min(newInterval[0], intervals[index][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[index][1]);
                index++;
            }

            // Got the merged interval. Add it to the list.
            mergedIntervals.Add(newInterval);

            // Step 3
            while(index < length) {
                mergedIntervals.Add(intervals[index]);
                index++;
            }

            // Convert the list to an array before returning
            return mergedIntervals.ToArray();
        }
        
        // TODO: Optimize for space
        
        // Submission Detail - https://leetcode.com/submissions/detail/205544134/
        // Explanation - leetcode.com/problems/insert-interval/discuss/21600/Short-java-code/112354
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            IList<Interval> result = new List<Interval>();

            foreach (Interval i in intervals)
            {
                if (newInterval == null || i.end < newInterval.start)
                {
                    result.Add(i);
                }
                else if (i.start > newInterval.end)
                {
                    result.Add(newInterval);
                    result.Add(i);
                    newInterval = null;
                }
                else
                {
                    newInterval.start = System.Math.Min(i.start, newInterval.start);
                    newInterval.end = System.Math.Max(i.end, newInterval.end);
                }
            }

            // If new interval needs to be inserted at last index;
            if (newInterval != null)
                result.Add(newInterval);

            return result;
        }
    }
}
