using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 163
    // Input: [0, 1, 3, 50, 75] -> [“2”, “4->49”, “51->74”, “76->99”]
    public class MissingRanges
    {
        //public static void Main(string[] args)
        //{
        //    MissingRanges ranges = new MissingRanges();
        //    Helper.PrintListElements(ranges.FindMissingRanges(new int[] { 0, 1, 3, 50, 75 }, 0, 99));
        //    Helper.PrintListElements(ranges.FindMissingRanges(new int[] { 1, 2, 3, 50, 75 }, 0, 99));
        //    Helper.PrintListElements(ranges.FindMissingRanges(new int[] { 2, 10 , 50, 75 }, 0, 99));
        //    Helper.PrintListElements(ranges.FindMissingRanges(new int[] { 0, 1, 3, 50, 99 }, 0, 99));

        //    Console.ReadLine();
        //}

        // key is to start with the start-1 and end with end+1 to cover first and last numbers in the range
        // Tx = O(n)
        // Sx = O(n)
        public List<string> FindMissingRanges(int[] vals, int start, int end)
        {
            List<string> missingRanges = new List<string>();
            int prev = start - 1;
            for (int i = 0; i <= vals.Length; i++)
            {
                int curr = (i == vals.Length) ? end + 1 : vals[i];
                if (curr - prev >= 2)
                    missingRanges.Add(GetRange(prev + 1, curr - 1));

                prev = curr;
            }

            return missingRanges;
        }

        private string GetRange(int from, int to)
        {
            return from.ToString() + ((from == to) ?  "" : "->" + to.ToString());
        }
    }
}
