using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 415
    // Submission : https://leetcode.com/submissions/detail/141064879/
    // Use carry
    // Similar to Leetcode 67: Add Binary
    public class AddStrings
    {
        // Tx = O(n)
        // Sx = O(n)    // for resultant string
        public string AddTwoStrings(string num1, string num2)
        {
            int i = num1.Length - 1, j = num2.Length - 1;

            StringBuilder sb = new StringBuilder(System.Math.Max(i, j) + 1);
            int carry = 0;

            // Run the while loop any digit in either num1, num2 is left over or carry == 1
            while (i >= 0 || j >= 0 || carry == 1)
            {
                int digit1 = i >= 0 ? num1[i--] - '0' : 0;
                int digit2 = j >= 0 ? num2[j--] - '0' : 0;
                sb.Insert(0,((digit1 + digit2 + carry) % 10));  // Insert the remainder at the 0th index
                carry = (digit1 + digit2 + carry) / 10;
            }

            return sb.ToString();
        }
    }
}
