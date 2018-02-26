using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 253
    // Explanation: http://www.cnblogs.com/grandyang/p/5244720.html
    // Input: [[15,20],[0,30],[35,40]] -> 2
    // Input: [[15,40],[15,20],[0,30]] -> 3
    public class MeetingRoomsII
    {
        // TODO: Optimal solution
        // Tx = O(nlogn)
        // Sx = O(n)
        public int MinMeetingRooms(Interval[] intervals)
        {
            int length = intervals.Length;
            int[] start = new int[length];
            int[] end = new int[length];

            for (int i = 0; i < length; i++)
            {
                start[i] = intervals[i].start;
                end[i] = intervals[i].end;
            }

            System.Array.Sort(start);
            System.Array.Sort(end);

            int minMeetings = 0, endPos = 0;
            for (int i = 0; i < start.Length; i++)
            {
                if (start[i] < end[endPos]) minMeetings++;
                else endPos++;
            }

            return minMeetings;
        }
    }
}
