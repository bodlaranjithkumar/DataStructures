using sys = System;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeSolutions.Array
{
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    //Leetcode 56
    class MergeIntervals
    {
        //[[4,5],[2,4],[4,6],[3,4],[0,0],[1,1],[3,5],[2,2]]
        //[[1,4],[2,3]]
        //[[2,3],[5,5],[2,2],[3,4],[3,4]]
        //[[4,4],[3,5],[2,3],[1,1],[3,3],[1,3],[2,2],[0,0],[5,5],[0,0],[4,6]] - sorted [[0,0],[0,0],[1,1],[1,3],[2,2],[2,3],[3,3],[3,5],[4,4],[4,6],[5,5]]

        // Runtime = 655 ms
        // Tx = O(nlogn)
        // Sx = O(n) for output list
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count == 0)
            {
                return intervals;
            }

            // Sort the array on the start time.
            intervals = intervals
                            .OrderBy(i => i.start)
                            .ThenBy(i => i.end)
                            .ToList();

            IList<Interval> mergedIntervals = new List<Interval>{
            intervals[0]
        };

            foreach (var currentInterval in intervals)
            {
                Interval lastMergedInterval = mergedIntervals.Last();

                if (lastMergedInterval.end >= currentInterval.start)
                {
                    lastMergedInterval.end = sys.Math.Max(currentInterval.end, lastMergedInterval.end);
                }
                else
                {
                    // Last and current intervals do not overlap. So, add current interval at last in the list.
                    mergedIntervals.Add(currentInterval);
                }
            }

            return mergedIntervals;
        }
    }
}
