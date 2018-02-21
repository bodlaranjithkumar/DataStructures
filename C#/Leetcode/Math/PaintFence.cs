using System;

namespace LeetcodeSolutions.Math
{
    // Leetcode 276
    // Reference: https://www.geeksforgeeks.org/painting-fence-algorithm/
    public class PaintFence
    {
        //public static void Main(string[] args)
        //{
        //    PaintFence f = new PaintFence();

        //    Console.WriteLine($"n=3, k=2, Ways={f.NumWays(3, 2)}");//6

        //    Console.ReadKey();
        //}

        //Tx = O(n)
        //Sx = O(1)
        public int NumWays(int n, int k)
        {
            // Total for n = 1;
            int total = k;

            int same = 0, diff = k;

            for (int i = 2; i <= n; i++)
            {
                same = diff;
                diff = total * (k - 1);
                total = same + diff;
            }

            return total;
        }
    }
}
