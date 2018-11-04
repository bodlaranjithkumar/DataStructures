using sys = System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 169 - https://leetcode.com/problems/majority-element/description/
    // Submission Detail - https://leetcode.com/submissions/detail/185909551/
    // Boyer - Moore Voting Algorithm

    //Input : [1,2 | 1,1,4,3] -> 1
    //        [7, 7, 5, 7, 5, 1 | 5, 7 | 5, 5, 7, 7 | 7, 7, 7, 7] -> 7
    public class MajorityElement
    {
        // Tx = O(n)
        // Sx = O(1)
        public int FindMajorityElement(int[] nums)
        {
            int major = 0, count = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    major = num;
                    count = 1;
                }
                else if (major == num)
                    count++;
                else
                    count--;
            }

            return major;
        }


        // Tx = O(nlogn)
        // Sx = O(1)
        //public int FindMajorityElement(int[] nums)
        //{
        //    int minLength = (int)sys.Math.Floor((double)nums.Length / 2);

        //    sys.Array.Sort(nums); // O(nlogn)

        //    int currentNumber = nums[0];
        //    int previousNumber = currentNumber;
        //    int maxElement = currentNumber;
        //    int maxLength = 1;
        //    int currentLength = maxLength;

        //    // O(n)
        //    for (int index = 1; index < nums.Length; index++)
        //    {
        //        currentNumber = nums[index];

        //        if (currentNumber != previousNumber)
        //        {// || index == nums.Length-1){
        //            if (currentLength >= minLength && currentLength > maxLength)
        //            {
        //                maxLength = currentLength;
        //                maxElement = previousNumber;
        //            }

        //            previousNumber = currentNumber;
        //            currentLength = 0;
        //        }

        //        currentLength++;
        //    }

        //    return currentLength > maxLength ? currentNumber : maxElement;
        //}
    }
}
