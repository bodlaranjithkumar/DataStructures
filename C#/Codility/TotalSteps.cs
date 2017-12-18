using System;

namespace InterviewCakeSolutions
{
    class TotalSteps
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("computedvalue: {0}", ComputeValue("11100"));
        //    Console.WriteLine("Totalsteps: {0}", CaculateTotalSteps(ComputeValue("11100")));

        //    Console.ReadKey();
        //}

        //public int solution(string S)
        //{
        //    // write your code in C# 6.0 with .NET 4.5 (Mono)
        //    Console.WriteLine("computedvalue: {0}", ComputeValue("0100"));
        //    return 0;
        //}

        private static int CaculateTotalSteps(ulong value)
        {
            int totalSteps = 0;
            while (value > 0)
            {
                if (value % 2 == 0)
                    value /= 2;
                else
                    value--;

                totalSteps++;
            }

            return totalSteps;
        }

        // 4 = 0100
        private static ulong ComputeValue(string S)
        {
            ulong value = 0;
            int count = 0;

            int index = S.Length - 1;
            while (index > 0)
            {
                value += S[index] - '0' == 0 ? 0 : (ulong)Math.Pow(2, count);
                count++;
                index--;
            }

            return value;
        }
    }
}
