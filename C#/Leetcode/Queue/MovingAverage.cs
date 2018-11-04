using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Queue
{
    // Leetcode 346 - https://leetcode.com/problems/moving-average-from-data-stream/description/
    // Submission Detail - https://leetcode.com/submissions/detail/186286478/

    public class MovingAverage
    {
        //private static void Main(string[] args)
        //{
        //    MovingAverage avg = new MovingAverage(3);

        //    Console.WriteLine(avg.Next(1));
        //    Console.WriteLine(avg.Next(10));
        //    Console.WriteLine(avg.Next(3));
        //    Console.WriteLine(avg.Next(5));

        //    Console.ReadKey();
        //}

        private readonly Queue<int> Numbers;
        private readonly int Size;
        private double Sum;

        public MovingAverage(int size)
        {
            Numbers = new Queue<int>(size);
            Size = size;
        }

        public double Next(int val)
        {
            if(Numbers.Count == Size)
                Sum -= Numbers.Dequeue();
            
            Numbers.Enqueue(val);
            Sum += val;

            return Sum / Numbers.Count;
        }
    }
}
