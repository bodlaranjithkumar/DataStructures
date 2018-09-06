using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeSolutions
{
    public class InterestingPoints
    {
        public static void Main(string[] args)
        {
            InterestingPoints ip = new InterestingPoints();

            Console.WriteLine($"{ip.CountInterestingPoints("01:21:21", "22:21:23")}");

            Console.ReadKey();
        }

        public int CountInterestingPoints(string s, string t)
        {
            // Split the start time to hours, minutes, seconds using : as the delimiter
            string[] stringStart = s.Split(new[] { ':' });

            // Convert the string array to integer array.
            int[] start = stringStart.Select(int.Parse).ToArray();

            string[] stringEnd = t.Split(new[] { ':' });
            int[] end = stringEnd.Select(int.Parse).ToArray();

            int TotalInterestingPoints = 0;

            // Iterate through hours between the hour in the input s, t - start[0], end[0]
            for (int h = start[0]; h <= end[0]; h++)
            {
                // minutes (m) starts from the mm componet in the input s. 
                int m = start[1];

                // If the hour has incremented from above we need to start it from 0 done below.
                if (h != start[0])  // start m with 0 if h is start hour
                    m = 0;

                //error 1: for (; m <= end[1] && m < 59; m++)
                //if h has reached end then mm needs to end at the mm component of the input string t.
                //else m needs to run till the end - 59 since the range is 0-59
                for (; (h == end[0] && m <= end[1]) || (h != end[0] && m <= 59) ; m++)
                {
                    // seconds (ss) starts from the ss componet in the input s. 
                    int ss = start[2];

                    // If the minute has incremented from above we need to start it from 0 done below.
                    if (m != start[1])   // start ss with 0 if m is start minute
                        ss = 0;

                    //error 2: for (; ss <= end[2] && ss < 59; ss++)
                    //if m has reached end then ss needs to end at the ss component of the input string t.
                    //else ss needs to run till the end - 59 since the range is 0-59
                    for (; (m == end[1] && ss <= end[2]) || (m != end[1] && ss <= 59); ss++)
                    {
                        StringBuilder time = new StringBuilder();

                        // Use custom append to convert number 9 to 09
                        CustomAppend(time, h);
                        CustomAppend(time, m);
                        CustomAppend(time, ss);

                        // Check if the current combination of HH:MM:SS is an interesting point.
                        if (IsInterestingPoint(time.ToString()))
                            TotalInterestingPoints++;
                    }
                }
            }

            return TotalInterestingPoints;
        }

        // if the input "t" is a single digit like 1,2,3 then it needs to be coverted to 01,02,03 respectively.
        private static void CustomAppend(StringBuilder time, int t)
        {
            //error 3: if (t >= 0 && t < 9)
            if (t >= 0 && t <= 9)
                time.Append(0);

            time.Append(t);
        }

        // Reads each digit represented as a character and add it to hashset. 
        // If at any point we find more than 2 unique digits then return false.

        // Improvement: Instead of creating a hashset each time this function is called, 
        // we can just create once and clear it's contents by calling the built-in clear() method.
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
