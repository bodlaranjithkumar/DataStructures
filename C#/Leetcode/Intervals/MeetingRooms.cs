using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.Intervals
{
    // Leetcode 252 - https://leetcode.com/problems/meeting-rooms/description/
    // Submission Detail - https://leetcode.com/submissions/detail/185728670/
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
        // Tx = O(nlogn) for sorting
        // Sx = O(1)
        public bool CanAttendMeetings(Interval[] intervals)
        {
            System.Array.Sort(intervals, (i1, i2) =>
            {
                return i1.start.CompareTo(i2.start);
            });

            for (int i = 1; i < intervals.Length; i++)
                if (intervals[i - 1].end > intervals[i].start)
                    return false;

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
