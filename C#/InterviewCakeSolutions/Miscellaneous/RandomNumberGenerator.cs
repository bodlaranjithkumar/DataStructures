using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.Miscellaneous
{
    public class RandomNumberGenerator
    {
        Random random = null;

        public RandomNumberGenerator()
        {
            random = new Random();
        }

        public int GenerateRandomNumber(int floor, int ceiling)
        {
            return random.Next(floor, ceiling);
        }
    }

    public class Rand7
    {
        RandomNumberGenerator rand = new RandomNumberGenerator();

        public int GenerateRandomNumber7()
        {
            return rand.GenerateRandomNumber(1, 7);
        }
    }

    public class Rand5
    {
        RandomNumberGenerator rand = new RandomNumberGenerator();

        public int GenerateRandomNumber5()
        {
            return rand.GenerateRandomNumber(1, 5);
        }
    }
}
