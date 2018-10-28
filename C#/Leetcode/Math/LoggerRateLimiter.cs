using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Math
{
    // Leetcode 359 - https://leetcode.com/problems/logger-rate-limiter/
    // Submission Detail - https://leetcode.com/submissions/detail/185721417/

    //    Design a logger system that receive stream of messages along with 
    //      its timestamps, each message should be printed if and only if it 
    //      is not printed in the last 10 seconds.

    //Given a message and a timestamp(in seconds granularity), return true if 
    //the message should be printed in the given timestamp, otherwise returns false.

    //It is possible that several messages arrive roughly at the same time.
    public class LoggerRateLimiter
    {
        //public static void Main(string[] args)
        //{
        //    LoggerRateLimiter logger = new LoggerRateLimiter();

        //    // logging string "foo" at timestamp 1
        //    Console.WriteLine(logger.ShouldPrintMessage(1, "foo")); //true;

        //    // logging string "bar" at timestamp 2
        //    Console.WriteLine(logger.ShouldPrintMessage(2, "bar")); //true;

        //    // logging string "foo" at timestamp 3
        //    Console.WriteLine(logger.ShouldPrintMessage(3, "foo")); //false;

        //    // logging string "bar" at timestamp 8
        //    Console.WriteLine(logger.ShouldPrintMessage(8, "bar")); //false;

        //    // logging string "foo" at timestamp 10
        //    Console.WriteLine(logger.ShouldPrintMessage(10, "foo")); //false;

        //    // logging string "foo" at timestamp 11
        //    Console.WriteLine(logger.ShouldPrintMessage(11, "foo")); //true;

        //    Console.ReadLine();
        //}

        private Dictionary<string, int> timeStamps;

        public LoggerRateLimiter()
        {
            timeStamps = new Dictionary<string, int>();
        }

        public bool ShouldPrintMessage(int timeStamp, string message)
        {
            if (!timeStamps.ContainsKey(message))
            {
                timeStamps.Add(message, timeStamp);
            }
            else
            {
                if (timeStamp - timeStamps[message] < 10)
                    return false;

                timeStamps[message] = timeStamp;
            }

            return true;
        }
    }
}
