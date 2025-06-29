﻿using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.Patterns.Intervals
{
    // Leetcode 253 - https://leetcode.com/problems/meeting-rooms-ii/description/
    // Submission Detail - https://leetcode.com/submissions/detail/181966142/
    // Explanation - http://www.cnblogs.com/grandyang/p/5244720.html
    // find the minimum number of conference rooms required

    // Input: [[15,20],[0,30],[35,40]] -> 2
    // Input: [[15,40],[15,20],[0,30]] -> 3
    public class MeetingRoomsII
    {
        // Tx = O(nlogn)
        // Sx = O(n)
        public int MinMeetingRooms(Interval[] intervals)
        {
            int length = intervals.Length;

            int[] startTimes = new int[length];
            int[] endTimes = new int[length];

            for (int i = 0; i < length; i++)
            {
                startTimes[i] = intervals[i].start;
                endTimes[i] = intervals[i].end;
            }

            System.Array.Sort(startTimes);
            System.Array.Sort(endTimes);

            int startIndex = 0, endIndex = 0, minMeetingRooms = 0;

            while (startIndex < length)
            {
                if (startTimes[startIndex] >= endTimes[endIndex])
                {
                    minMeetingRooms--;  // Use one of the meeting rooms ended.
                    endIndex++;
                }

                minMeetingRooms++;
                startIndex++;
            }

            return minMeetingRooms;
        }
    }
}
