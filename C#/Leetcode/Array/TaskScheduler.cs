using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 621
    // Explanation : http://www.cnblogs.com/grandyang/p/7098764.html
    // Solution: https://leetcode.com/problems/task-scheduler/discuss/104496/concise-Java-Solution-O(N)-time-O(26)-space
    // Submission: https://leetcode.com/submissions/detail/140296542/
    // Frequencies
    public class TaskScheduler
    {
        //public static void Main(string[] args)
        //{
        //    TaskScheduler s = new TaskScheduler();

        //    char[] c1 = { 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'E', 'E', 'F', 'F', 'G', 'G' };
        //    Console.WriteLine(s.LeastInterval(c1, 3));  //13

        //    char[] c2 = { 'A', 'C', 'C', 'C', 'E', 'E', 'E' };
        //    Console.WriteLine(s.LeastInterval(c2, 2));  //8

        //    char[] c3 = {};
        //    Console.WriteLine(s.LeastInterval(c3, 2));  //23

        //    Console.ReadKey();
        //}

        // Tx = O(1) although it is Math.Max(O(26log26),O(10000)) as input array length is in the range [1...10000]
        // Sx = O(1)
        public int LeastInterval(char[] tasks, int n)
        {
            int[] frequencies = new int[26];
            foreach (char c in tasks)
                frequencies[c - 'A']++;

            System.Array.Sort(frequencies);

            int i = 25;
            while (i >= 0 && frequencies[i] == frequencies[25]) i--;

            return System.Math.Max(tasks.Length, (frequencies[25] - 1) * (n + 1) + 25 - i);
        }
    }
}
