using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeSolutions
{
    public class InterestingPoints
    {
        //public static void Main(string[] args)
        //{
        //    //Console.WriteLine($"{IsInterestingPoint("222221")}");
        //    //Console.WriteLine($"{IsInterestingPoint("222123")}");
        //    string s = "01:21:21";
        //    string[] stringStart = s.Split(new[] { ':' });
        //    int[] start = stringStart.Select(int.Parse).ToArray();

        //    string T = "22:21:23";
        //    string[] stringEnd = T.Split(new[] { ':' });
        //    int[] end = stringEnd.Select(int.Parse).ToArray();

        //    int TotalInterestingPoints = 0;

        //    for (int h = start[0]; h <= end[0]; h++)
        //    {
        //        int m = start[1];
        //        if (h != start[0])  // start m with 0 if h is start hour
        //            m = 0;

        //        for (; m <= end[1] && m < 59; m++)
        //        {
        //            int ss = start[2];
        //            if (m != start[1])   // start ss with 0 if m is start minute
        //                ss = 0;

        //            for (; ss <= end[2] && ss < 59; ss++)
        //            {
        //                StringBuilder time = new StringBuilder();

        //                CustomAppend(time, h);
        //                CustomAppend(time, m);
        //                CustomAppend(time, ss);

        //                if (IsInterestingPoint(time.ToString()))
        //                    TotalInterestingPoints++;
        //            }
        //        }
        //    }

        //    Console.WriteLine($"{TotalInterestingPoints}");

        //    Console.ReadKey();
        //}

        private static void CustomAppend(StringBuilder time, int t)
        {
            if (t >= 0 && t < 9)
                time.Append(0);

            time.Append(t);
        }

        private static bool IsInterestingPoint(string time)
        {
            HashSet<int> visited = new HashSet<int>();

            foreach (char c in time)
            {
                int number = c - '0';
                if (!visited.Contains(number))
                {
                    if (visited.Count == 2)
                        return false;
                    else
                        visited.Add(number);
                }
            }

            return true;
        }
    }
}
