using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeSolutions.Patterns.Intervals
{
    // Leetcode 986 - https://leetcode.com/problems/interval-list-intersections/description/
    // Submission Detail - https://leetcode.com/submissions/detail/208376247/

    public class IntervalListIntersections
    {
        // Input:  A = [[0,2],[5,10],[13,23],[24,25]] , B = [[1,5],[8,12],[15,24],[25,26]]
        // Output: [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]

        // Tx = O(m+n)
        // Sx = O(m+n)
        public Interval[] IntervalIntersection(Interval[] A, Interval[] B)
        {
            if (A == null || A.Length == 0 || B == null || B.Length == 0)
                return new Interval[0];

            int i = 0, j = 0;
            int m = A.Length, n = B.Length;
            IList<Interval> intervalIntersections = new List<Interval>();

            while (i < m && j < n)
            {
                Interval a = A[i], b = B[j];

                int startMax = System.Math.Max(a.start, b.start);
                int endMin = System.Math.Min(a.end, b.end);

                if (startMax <= endMin)
                {
                    intervalIntersections.Add(new Interval(startMax, endMin));
                }

                if (a.end == endMin) i++;
                if (b.end == endMin) j++;
            }

            return intervalIntersections.ToArray();
        }
    }
}
