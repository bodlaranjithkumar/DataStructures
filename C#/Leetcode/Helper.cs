using System;

namespace LeetcodeSolutions
{
    public class Helper
    {
        public static void Print(int[] result)
        {
            foreach (var val in result)
            {
                Console.Write($"{val}\t");
            }
        }
    }
}
