package Intervals;

import java.util.Arrays;
import java.util.Comparator;

public class CanAttendMeetings {

    // Input: intervals = [(1,5),(3,9),(6,8)]
    // Output: false

    // Input: intervals = [(10,12),(6,9),(13,15)]
    // Output: true

    // Tx = O(n*logn) for sorting
    // Sx = O(1)
    public boolean canAttendAllMeetings(int[][] meetings) {
        // Sort in ascending order of start time
        // Arrays.sort(meetings, (m1, m2) -> Integer.compare(m1[0], m2[0]));
        Arrays.sort(meetings, Comparator.comparingInt(m -> m[0])); // java 17
        for(int index = 1; index < meetings.length; index++) {
            if(meetings[index][0] < meetings[index-1][1])
                return false;
        }

        return true;
    }
}
