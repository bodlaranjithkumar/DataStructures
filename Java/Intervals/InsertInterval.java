package Intervals;

import java.util.ArrayList;
import java.util.List;

public class InsertInterval {
    // Leetcode 57: https://leetcode.com/problems/insert-interval/
    // Submission Detail: https://leetcode.com/problems/insert-interval/submissions/1626686888

    //Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
    //Output: [[1,5],[6,9]]

    //Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
    //Output: [[1,2],[3,10],[12,16]]

    // Tx = O(nlogn)
    // Sx = O(n)
    public int[][] insert(int[][] intervals, int[] newInterval) {
        List<int[]> mergedIntervals = new ArrayList<>();
        int index = 0, length = intervals.length;

        // Step 1: Merge all intervals before newInterval to the result
        while(index < length && intervals[index][1] < newInterval[0]) {
            mergedIntervals.add(intervals[index]);
            index++;
        }

        // Step 2: merge overlapping intervals
        while(index < length && intervals[index][0] <= newInterval[1] ) {
            newInterval[0] = Math.min(newInterval[0], intervals[index][0]);
            newInterval[1] = Math.max(newInterval[1], intervals[index][1]);
            index++;
        }
        mergedIntervals.add(newInterval);

        // Step 3: merge remaining non-overlapping intervals
        while(index < length) {
            mergedIntervals.add(intervals[index]);
            index++;
        }

        return mergedIntervals.toArray(new int[mergedIntervals.size()][]);
    }

//    public int[][] insert(int[][] intervals, int[] newInterval) {
//        List<int[]> result = new ArrayList<>();
//        int index=0;
//        for(; index<intervals.length; index++) {
//            result.add(intervals[index]);
//            if(newInterval[0] <= intervals[index][1]) { //overlapping interval
//                result.get(index)[1] = Math.max(intervals[index][1], newInterval[1]);
//                break;
//            }
//        }
//
//        for(int nextIndex=index+1; nextIndex<intervals.length; nextIndex++) {
//            if(intervals[nextIndex][0] <= intervals[index][1]) {
//                result.get(result.size()-1)[1] = Math.max(intervals[index][1], intervals[nextIndex][1]);
//            } else {
//                result.add(intervals[nextIndex]);
//                index++;
//            }
//        }
//
//        return result.toArray(new int[result.size()][]);
//    }
}
