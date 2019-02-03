using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;

namespace LeetcodeSolutions.Intervals
{
    // Leetcode 57 - https://leetcode.com/problems/insert-interval/description/
    // Submission Detail - https://leetcode.com/submissions/detail/205544134/

    public class InsertInterval
    {
        // TODO: Optimize for space

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
