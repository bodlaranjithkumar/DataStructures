using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 402:  https://leetcode.com/problems/remove-k-digits/description/
    // Submission Detail: https://leetcode.com/submissions/detail/183529286/

    //"1412569",3   => 1125
    //"1432219",3   => 1219
    //"654321",10   => 0
    //"112", 1      => 11

    public class RemoveKDigits
    {
        //public static void Main(string[] args)
        //{
        //    RemoveKDigits obj = new RemoveKDigits();

        //    obj.Removekdigits("0000", 1);
        //}

        // Algorithm: Iterate through the string. If the current number is 
        //   less than the previous number inserted into the char array, 
        //   then decrement the top pointer until a lower number in
        //   the array is found. Decrement k at the same time which basically
        //   means the numbers are being removed. In the end, leading zeros 
        //   needs to be removed. So, find the index until the first non zero
        //   index is found.

        public string RemoveKdigits(string num, int k)
        {
            char[] nums = new char[num.Length];
            int top = 0, totalDigitsInTheResult = num.Length - k;

            for (int i = 0; i < num.Length; i++, top++)
            {
                while (top > 0 && num[i] < nums[top - 1] && k > 0)
                {
                    top--;
                    k--;
                }
                nums[top] = num[i];
            }

            int firstNonZeroIndex = 0;
            while (firstNonZeroIndex < totalDigitsInTheResult && nums[firstNonZeroIndex] == '0')
                firstNonZeroIndex++;

            return firstNonZeroIndex == totalDigitsInTheResult || totalDigitsInTheResult < 0
                    ? "0"
                    : new string(nums, firstNonZeroIndex, totalDigitsInTheResult - firstNonZeroIndex);
        }




        //"1234567890",9 => 1   Failed for this case
        // Method 2
        public string Removekdigits(string num, int k)
        {
            if (num.Length <= k)
                return "0";

            HashSet<int> indexOfDigitsToRemove = new HashSet<int>();

            for (int i = 0; i < num.Length - 1 && indexOfDigitsToRemove.Count < k; i++)
            {
                if (num[i] != 0 && num[i] > num[i + 1])
                    indexOfDigitsToRemove.Add(i);
            }

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < num.Length; i++)
            {
                if (!indexOfDigitsToRemove.Contains(i))
                    str.Append(num[i]);
            }

            int count = indexOfDigitsToRemove.Count;

            if (count < k)
                str.Remove(num.Length - k, k - count);

            int firstNonZeroIndex = 0;
            while (firstNonZeroIndex < str.Length - 1 && str[firstNonZeroIndex] == '0')
            {
                firstNonZeroIndex++;
            }

            return str.Remove(0, firstNonZeroIndex).ToString();
        }
    }
}
