using LeetcodeSolutions.DataStructures;
using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 252
    // Problem Explanation : http://www.cnblogs.com/grandyang/p/5240774.html
    public class MeetingRooms
    {        
        //public static void Main(string[] args)
        //{
        //    MeetingRooms meetings = new MeetingRooms();

        //    Interval[] meetings1 = new Interval[] {
        //        new Interval(0,30),
        //        new Interval(5,10),
        //        new Interval(15,20)
        //    };

        //    bool canAttendMeetings1 = meetings.CanAttendMeetings(meetings1);

        //    Console.ReadLine();
        //}

        // Clean code
        // Tx = O(nlogn)
        // Sx = O(1)
        public bool CanAttendMeetings(Interval[] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return false;

            System.Array.Sort(intervals);

            for (int i = 0; i < intervals.Length - 1; i++)
            {
                if (intervals[i].end > intervals[i + 1].start)
                    return false;
            }

            return true;
        }


        //public bool CanAttendMeetings(Interval[] intervals)
        //{
        //    if (intervals == null || intervals.Length == 0)
        //        return false;

        //    System.Array.Sort(intervals);

        //    Interval lastInterval = intervals[0];

        //    foreach (Interval currentInterval in intervals)
        //    {
        //        if (lastInterval.start < currentInterval.start && lastInterval.end > currentInterval.end)
        //            return false;
        //        else if (lastInterval.end <= currentInterval.start)
        //            lastInterval.end = System.Math.Max(lastInterval.end, currentInterval.end);
        //    }

        //    return true;
        //}
    }
}
