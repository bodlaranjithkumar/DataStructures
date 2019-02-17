using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Intervals
{
    // Leetcode 452 - https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/description/
    // Submission Detail - https://leetcode.com/submissions/detail/208408087/
    // Similar to leetcode 986 interval intersections problem.

    public class MinArrowsToBurstBalloons
    {
        // Tx = O(nlogn)
        // Sx = O(1)

        //public int findMinArrowShots(int[][] points)
        //{
        //    if (points == null || points.length == 0 || points[0].length == 0)
        //        return 0;

        //    Arrays.sort(points, new Comparator<int[]>()
        //    {
        //        public int compare(int[] a, int[] b)
        //        {
        //            if (a[0] == b[0])
        //                return a[1] - b[1];
        //            else
        //                return a[0] - b[0];
        //        }
        //    });
        
        //    int lastPoint = points[0][1], count = 1;
        
        //    for(int i=1; i<points.length; i++) {
        //        int[] point = points[i];
            
        //        if(point[0] > lastPoint) {
        //            lastPoint = point[1];
                
        //            count++;
        //        }
        //        else if(point[0] <= lastPoint) {
        //            lastPoint = Math.min(lastPoint, point[1]);
        //        }
        //    }
        
        //    return count;
        //}
    }
}
