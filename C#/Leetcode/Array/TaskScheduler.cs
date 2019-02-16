using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 621 - https://leetcode.com/problems/task-scheduler/
   
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

        // Ref: https://leetcode.com/problems/task-scheduler/discuss/104500/Java-O(n)-time-O(1)-space-1-pass-no-sorting-solution-with-detailed-explanation
        // Submission Detail: https://leetcode.com/submissions/detail/208333877/

        // Tx = O(n)
        // Sx = O(1)

        public int LeastIntervalUnderstandable(char[] tasks, int n)
        {
            int[] taskFreq = new int[26];
            int maxFreq = 0, maxFreqCount = 0;

            foreach (char task in tasks)
            {
                int index = task - 'A';

                taskFreq[index]++;

                if (maxFreq == taskFreq[index])
                {
                    maxFreqCount++;
                }
                else if (maxFreq < taskFreq[index])
                {   // Found a new max task frequency
                    maxFreq = taskFreq[index];
                    maxFreqCount = 1;
                }
            }

            int totalMaxFreq = maxFreq - 1; // last task may not need additional idle n slots
            int remainingTasksCount = n - (maxFreqCount - 1);
            int emptySlots = totalMaxFreq * remainingTasksCount;
            int availableSlots = tasks.Length - maxFreq * maxFreqCount;

            int idleSlots = System.Math.Max(0, emptySlots - availableSlots);

            return tasks.Length + idleSlots;
        }

        // Solution 2 : 
        // Tx = O(1) although it is Math.Max(O(26log26),O(10000)) as input array length is in the range [1...10000]
        // Sx = O(1)
        // Explanation - http://www.cnblogs.com/grandyang/p/7098764.html
        // Solution - https://leetcode.com/problems/task-scheduler/discuss/104496/concise-Java-Solution-O(N)-time-O(26)-space
        // Submission - https://leetcode.com/submissions/detail/140296542/

        public int LeastInterval(char[] tasks, int n)
        {
            int[] frequencies = new int[26];
            foreach (char c in tasks)
                frequencies[c - 'A']++;

            System.Array.Sort(frequencies);

            int i = 25;
            while (i >= 0 && frequencies[i] == frequencies[25])
                i--;

            return System.Math.Max(tasks.Length, (frequencies[25] - 1) * (n + 1) + 25 - i);
        }
    }
}
