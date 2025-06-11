package Intervals;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

public class MergeIntervals {
    // Leetcode 56: https://leetcode.com/problems/merge-intervals/description/
    // Submission Detail: https://leetcode.com/problems/merge-intervals/submissions/1626710995

    // Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
    // Output: [[1,6],[8,10],[15,18]]
    // Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
    //
    // Input: intervals = [[1,4],[4,5]]
    // Output: [[1,5]]
    // Explanation: Intervals [1,4] and [4,5] are considered overlapping.

    // Tx = O(nlogn)
    // Sx = O(n)
    public int[][] merge(int[][] intervals) {
        List<int[]> mergedIntervals = new ArrayList<>();
        Arrays.sort(intervals, Comparator.comparingInt(interval -> interval[0])); // sort by start time
        mergedIntervals.add(intervals[0]);

        for(int index=1; index<intervals.length; index++) {
            int size = mergedIntervals.size();
            if(intervals[index][0] <= mergedIntervals.get(size-1)[1]) {
                mergedIntervals.get(size-1)[1] = Math.max(mergedIntervals.get(size-1)[1], intervals[index][1]);
            } else {
                mergedIntervals.add(intervals[index]);
            }
        }

        return mergedIntervals.toArray(new int[mergedIntervals.size()][]);
    }
}
