namespace LeetcodeSolutions.Math
{
    // Leetcode 136
    // Submission Detail: https://leetcode.com/submissions/detail/142272930/
    // XOR
    public class SingleNumber
    {
        // Input: [-1,5,3,-1,5] -> 3
        // Input: [1]   -> 1
        // Tx = O(n)
        // Sx = O(1)
        public int FindSingleNumber(int[] nums)
        {
            int result = 0;

            // XOR. 0,1->1 && 1,0->1
            foreach (int num in nums)
                result ^= num;

            return result;
        }
    }
}
