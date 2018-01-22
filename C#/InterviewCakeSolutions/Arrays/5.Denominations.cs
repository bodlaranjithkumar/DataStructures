using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.Arrays
{
    public class Denominations
    {
        public static void Main(string[] args)
        {
            Denominations den = new Denominations();
            int count1 = den.TotalDenominations(new int[] { 1, 2, 3 }, 4);  //4
            int count2 = den.TotalDenominations(new int[] { 2, 3 }, 1);  //0
        }

        public int TotalDenominations(int[] coins, int sum)
        {
            return TotalDenominations(coins, sum, 0, 0);
        }

        //Assumption: Coins array is sorted.
        private int TotalDenominations(int[] coins, int sum, int startIndex, int count)
        {
            for (int i = startIndex; i < coins.Length; i++)
            {
                int balance = sum - coins[i];

                if (balance == 0)
                {
                    count++;
                    break;
                }
                else if (balance < 0)
                {
                    break;
                }

                TotalDenominations(coins, balance, i, count);
            }

            return count;
        }
    }
}
