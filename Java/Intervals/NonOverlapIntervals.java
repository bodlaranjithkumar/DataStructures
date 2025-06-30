package Intervals;

import java.util.Arrays;
import java.util.Comparator;

public class NonOverlapIntervals {
    // Leetcode 435: https://leetcode.com/problems/non-overlapping-intervals/description/

    // Intuition: if we had sorted by start_time, there could be cases where start_time is small but end_time is quite large
    // which can overlap with multiple future intervals: [[1,9], [2,4], [4,6], [5,7],[8,9]].
    // By sorting with smaller end_time, it will itself ensure that start < end & we get more non-overlapping intervals

    //Input: intervals = [[1,2],[2,3],[3,4],[1,3]]
    //Output: 1
    //Explanation: [1,3] can be removed and the rest of the intervals are non-overlapping.

    //Input: intervals = [[1,2],[1,2],[1,2]]
    //Output: 2
    //Explanation: You need to remove two [1,2] to make the rest of the intervals non-overlapping.

    //Input: intervals = [[1,2],[2,3]]
    //Output: 0
    //Explanation: You don't need to remove any of the intervals since they're already non-overlapping

    // Submission Detail: https://leetcode.com/problems/non-overlapping-intervals/submissions/1681983339
    public int eraseOverlapIntervalsAlternative(int[][] intervals) {
        // Sort by end time
        Arrays.sort(intervals, Comparator.comparingInt(interval -> interval[1]));
        int length = intervals.length, overlappingIntervalsCount = 0;
        int end = intervals[0][1];

        for(int index=0; index < length; index++) {
            if(intervals[index][0] < end)
                overlappingIntervalsCount++;
            else
                end = intervals[index][1];
        }

        return overlappingIntervalsCount;
    }

    // Tx = O(nlogn)
    // Sx = O(1)
    // Submission Detail: https://leetcode.com/problems/non-overlapping-intervals/submissions/1626702282
    public int eraseOverlapIntervals(int[][] intervals) {
        // Sort by end time
        Arrays.sort(intervals, Comparator.comparingInt(interval -> interval[1]));
        int length = intervals.length, index = 0, nonOverlappingIntervalsCount = 1;
        int end = intervals[index++][1];

        while(index < length) {
            if(intervals[index][0] >= end) {
                end = intervals[index][1];
                nonOverlappingIntervalsCount++;
            }
            index++;
        }

        return length - nonOverlappingIntervalsCount;
    }
}
