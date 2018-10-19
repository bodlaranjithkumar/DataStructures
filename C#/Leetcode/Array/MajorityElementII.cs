using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 229 - https://leetcode.com/problems/majority-element-ii/description/
    // Submission Detail - https://leetcode.com/submissions/detail/183877813/

    public class MajorityElementII
    {
        // This is an extension to Majority Element problem. Solving that problem makes this easy to understand.
        // On observing the problem carefully, there could be only 2 numbers with frequency > floor(n/3). Hence, use 2 num1, num2 variables.
        public IList<int> MajorityElement(int[] nums)
        {
            IList<int> majorityElements = new List<int>();

            if (nums == null || nums.Length == 0)
                return majorityElements;

            int num1 = nums[0], num2 = nums[0], count1 = 0, count2 = 0, n = nums.Length;

            foreach (int num in nums)
            {
                if (num1 == num)
                {
                    count1++;
                }
                else if (num2 == num)
                {
                    count2++;
                }
                else if (count1 == 0)
                {
                    num1 = num;
                    count1 = 1;
                }
                else if (count2 == 0)
                {
                    num2 = num;
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            // we found the 2 major numbers. Now check their frequencies.
            count1 = 0;
            count2 = 0;

            foreach (int num in nums)
            {
                if (num == num1)
                    count1++;
                else if (num == num2)
                    count2++;
            }

            if (count1 > n / 3)
                majorityElements.Add(num1);

            if (count2 > n / 3)
                majorityElements.Add(num2);

            return majorityElements;
        }
    }
}
