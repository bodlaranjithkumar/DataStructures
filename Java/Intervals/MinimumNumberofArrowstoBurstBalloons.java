package Intervals;

import java.util.Arrays;

public class MinimumNumberofArrowstoBurstBalloons {
    // Leetcode 452: https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/submissions/1681993888/
    // Submission Detail: https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/submissions/1681993888

    //Input: points = [[10,16],[2,8],[1,6],[7,12]]
    //Output: 2
    //Explanation: The balloons can be burst by 2 arrows:
    //        - Shoot an arrow at x = 6, bursting the balloons [2,8] and [1,6].
    //        - Shoot an arrow at x = 11, bursting the balloons [10,16] and [7,12].

    //Input: points = [[1,2],[3,4],[5,6],[7,8]]
    //Output: 4
    //Explanation: One arrow needs to be shot for each balloon for a total of 4 arrows.

    //Input: points = [[1,2],[2,3],[3,4],[4,5]]
    //Output: 2
    //Explanation: The balloons can be burst by 2 arrows:
    //        - Shoot an arrow at x = 2, bursting the balloons [1,2] and [2,3].
    //        - Shoot an arrow at x = 4, bursting the balloons [3,4] and [4,5].

    public int findMinArrowShots(int[][] points) {
        Arrays.sort(points, (a, b) -> Integer.compare(a[0],b[0]));
        int end = points[0][1], minArrowShots = 1;

        for(int index=1; index<points.length; index++) {
            int[] point = points[index];

            if(point[0] > end) {
                end = point[1];
                minArrowShots++;
            } else {
                end = Math.min(end, point[1]);
            }
        }

        return minArrowShots;
    }
}
