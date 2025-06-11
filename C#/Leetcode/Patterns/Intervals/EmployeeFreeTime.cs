using System;
using System.Collections.Generic;

namespace Leetcode.Patterns.Intervals {
    // Leetcode 759 - https://leetcode.com/problems/employee-free-time/
    // Tx = O(n*logn)
    // Sx = O(n)
    public class EmployeeFreeTime {
        // Step 1: Combine all the intervals of all the employees.
        // Step 2: Sort the intervals based on the start time.
        // Step 3: Merge the intervals.
        // Step 4: Find the free time between the merged intervals which is the combination of end of one interval and start of the next interval.
        public int[][] EmployeeFreeTime(int[][] schedule) {
            // Step 1
            IList<int[]> combinedIntervals = new List<int[]>();
            foreach (var employee in schedule) {
                foreach (var interval in employee) {
                    combinedIntervals.Add(interval);
                }
            }
            
            // Step 2
            combinedIntervals.Sort((i1, i2) => i1[0].CompareTo(i2[0]));

            // Step 3: Merge Intervals
            IList<int[]> mergedIntervals = new List<int[]>();
            mergedIntervals.Add(combinedIntervals[0]);
            int mergedIndex = 0, intervalIndex = 1, length = combinedIntervals.GetLength(0);

            while(intervalIndex < length) {
                if(mergedIntervals[mergedIndex][1] >= combinedIntervals[intervalIndex][0]) {
                    mergedIntervals[mergedIndex][1] = Math.Max(mergedIntervals[mergedIndex][1], combinedIntervals[intervalIndex][1]);
                } else {
                    mergedIntervals.Add(combinedIntervals[intervalIndex]);
                    mergedIndex++;
                }
                intervalIndex++;
            }

            // Step 4
            List<int[]> result = new List<int[]>();
            for(int index = 1; index < mergedIntervals.Count; index++ ) {
                int[] start = mergedIntervals[index-1];
                int[] end = mergedIntervals[index];
                result.Add(new int[](start[1], end [0]));
            }

            return result.ToArray();
        }
    }
}
