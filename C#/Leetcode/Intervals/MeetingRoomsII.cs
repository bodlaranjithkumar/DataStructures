using LeetcodeSolutions.DataStructures;

namespace LeetcodeSolutions.Intervals
{
    // Leetcode 253
    // Submission Detail: https://leetcode.com/submissions/detail/181966142/

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
