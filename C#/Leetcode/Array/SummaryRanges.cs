using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 228
    // Submission Detail: https://leetcode.com/submissions/detail/141987551/
    public class SummaryRanges
    {
        //Input: [0,1,2,4,5,7]
        //Output: ["0->2","4->5","7"]

        //Input: [0,2,3,4,6,8,9]
        //Output: ["0","2->4","6","8->9"]

        // Tx = O(n)
        // Sx = O(n) for output list of strings
        public IList<string> FindSummaryRanges(int[] nums)
        {
            IList<string> ranges = new List<string>();

            // Key: Run the j loop until it is out of index to cover the last element.
            for (int i = 0, j = 0; j <= nums.Length; j++)
            {
                // Check if the array is not empty.
                //      a. 2nd pointer is within the range and is not an increment of the previous number.
                //      b. 2nd pointer is equal to length of the array.
                if (nums.Length > 0
                    && ((j > 0 && j < nums.Length && nums[j] != nums[j - 1] + 1)
                        || j == nums.Length))
                {
                    StringBuilder str = new StringBuilder(nums[i].ToString());

                    if (i != j - 1)
                        str.Append("->").Append(nums[j - 1].ToString());

                    ranges.Add(str.ToString());
                    i = j;
                }
            }

            return ranges;
        }
    }
}
