using sys = System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 15
    // Input:  [-1, 0, 1, 2, -1, -4]
    // Output: [[-1, 0, 1],[-1, -1, 2]]
    public class ThreeSum
    {
        // Runtime : 576 ms
        // Tx = O(n^2) {n : size of integer array}
        // Sx = O(n) {for the resultant list}
        public static IList<IList<int>> SumOfThree(int[] nums)
        {
            int length = nums.Length;
            IList<IList<int>> result = new List<IList<int>>();

            sys.Array.Sort(nums);

            for (int currentIndex = 0; currentIndex < length - 2; currentIndex++)
            {
                int low = currentIndex + 1;
                int high = length - 1;
                if (currentIndex == 0 || (currentIndex > 0 && nums[currentIndex] != nums[currentIndex - 1]))
                {
                    while (low < high)
                    {
                        if (nums[currentIndex] + nums[low] + nums[high] == 0)
                        {
                            result.Add(new List<int>
                                    {   nums[currentIndex],
                                        nums[low],
                                        nums[high]
                                    });
                            // Check if the next numbers are the same as current for both low, high;
                            while (low < high && nums[low] == nums[low + 1]) low++;
                            while (low < high && nums[high] == nums[high - 1]) high--;
                            low++;
                            //high--;
                        }
                        else if (nums[currentIndex] + nums[low] + nums[high] < 0) low++;
                        else high--;
                    }
                }
            }

            return result;
        }
    }
}
