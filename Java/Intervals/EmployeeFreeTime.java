package Intervals;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

public class EmployeeFreeTime {
    // Input: schedule = [[[2,4],[7,10]],[[1,5]],[[6,9]]] => [[1,5], [2,4], [6,9], [7,10]]
    // Output: [(5,6)]

    public int[][] FreeTime(int[][] schedule) {
        List<int[]> freeTime = new ArrayList<>();
        Arrays.sort(schedule, Comparator.comparingInt(s -> s[0]));

        // Step1: Merge the intervals;
        List<int[]> mergedIntervals = new ArrayList<>();
        mergedIntervals.add(schedule[0]);

        for(int index=1; index<schedule.length; index++) {
            int size = mergedIntervals.size()-1;
            if(schedule[index][0] <= mergedIntervals.get(size)[1]) {
                mergedIntervals.get(size)[1] = Math.max(mergedIntervals.get(size)[1], schedule[index][1]);
            } else {
                mergedIntervals.add(schedule[index]);
            }
        }

        // Step 2: Find the gap between each merged intervals which is the free time.
        for(int index = 1; index<mergedIntervals.size(); index++) {
            int start = mergedIntervals.get(index-1)[1];
            int end = mergedIntervals.get(index)[0];
            freeTime.add(new int[]{start, end});
        }

        return freeTime.toArray(new int[freeTime.size()][]);
    }
}
