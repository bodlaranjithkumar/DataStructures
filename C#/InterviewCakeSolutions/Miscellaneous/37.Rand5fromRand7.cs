using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.Miscellaneous
{
    class Random5Generator
    {
        Rand7 rand7 = new Rand7();

        //public static void Main(string[] args)
        //{
        //    Random5Generator random5 = new Random5Generator();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine($"Generated Random Number: {random5.GenerateRandom5()}");
        //    }

        //    Console.ReadKey();
        //}

        public int GenerateRandom5()
        {
            int randomNumber7 = rand7.GenerateRandomNumber7();
            
            while (randomNumber7 >= 1 && randomNumber7 <= 7 && (randomNumber7 == 6  || randomNumber7 == 7))
            {
                randomNumber7 = rand7.GenerateRandomNumber7();
            }

            // This can be avoided if the rand7 function generates a number between the range 1 to 7 and above loop can be re-written.
            if (randomNumber7 < 1 || randomNumber7 > 7)
            {
                throw new Exception("Rand7 function returned number out of the range 1...7");
            }

            return randomNumber7;
        }
    }
}
