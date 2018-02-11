using System;

namespace LeetcodeSolutions.DataStructures
{
    public class Interval : IComparable<Interval>
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }

        public int CompareTo(Interval interval)
        {
            return start.CompareTo(interval.start);
        }
    }
}
