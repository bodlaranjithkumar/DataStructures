using System;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 681
    // Reference: http://zxi.mytechroad.com/blog/simulation/leetcode-681-next-closest-time/
    // Input: "19:34" -> "19:39"
    // Input: "23:59" -> "22:22"
    public class NextClosestTime
    {
        //public static void Main(string[] args)
        //{
        //    NextClosestTime nextClosest = new NextClosestTime();
        //    Console.WriteLine(nextClosest.FindNextClosestTime("19:34"));
        //    Console.WriteLine(nextClosest.FindNextClosestTime("23:59"));

        //    Console.ReadLine();
        //}

        // Tx = O(1) // O(6*9^3)
        // Sx = O(1)
        public string FindNextClosestTime(string time)
        {
            int hour = Convert.ToInt32(time.Substring(0, 2));
            int min = Convert.ToInt32(time.Substring(3, 2));

            StringBuilder nextClosest = new StringBuilder(time.Length);

            while (true)
            {
                // min : 00 to 59
                // hr: 00 to 23
                if (++min == 60)
                {
                    min = 0;
                    hour++;
                    hour %= 24;
                }
                nextClosest.Clear();
                nextClosest.Append(System.String.Format("{0}:{1}", NumberFormatter(hour), NumberFormatter(min)));

                if (IsNextClosest(time, nextClosest.ToString()))
                    break;
            }

            return nextClosest.ToString();
        }

        // Verify if the curr is the next closest to time with one or more same digits in time.
        private static bool IsNextClosest(string time, string curr)
        {
            for (int i = 0; i < curr.Length; i++)
            {
                if (time.IndexOf(curr[i]) < 0)
                    return false;
            }

            return true;
        }

        private static string NumberFormatter(int num)
        {
            return (num < 10 ? "0" : "") + num;
        }
    }
}
