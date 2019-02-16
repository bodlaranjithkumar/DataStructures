namespace LeetcodeSolutions.Array
{
    // Leetcode 55 - https://leetcode.com/problems/jump-game/description/
    // Submission Detail - https://leetcode.com/submissions/detail/205838562/
    // Reference -  https://leetcode.com/problems/jump-game/solution/

    // Input: A = [2,3,1,1,4] -> true.
    // Input: A = [3,2,1,0,4] -> false.
    public class JumpGame
    {
        // Greedy
        // Tx = O(n)
        // Sx = O(1)
        public bool CanJumpGreedy(int[] nums)
        {
            int lastPos = nums.Length - 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (i + nums[i] >= lastPos)
                    lastPos = i;
            }
            return lastPos == 0;
        }

        // TODO: Problem can be solved using DP

        // Exceeds timelimit for lengthy array.
        // Inefficient and there is repetition.
        // Tx = ?
        // Sx = O(n) for call stack.
        public bool CanJumpBackTracking(int[] nums)
        {
            return CanJumpBackTracking(nums, 0);
        }

        public bool CanJumpBackTracking(int[] nums, int pos)
        {
            if (pos == nums.Length - 1) return true;

            //Determine the maxPos to avoid index out of range.
            int maxPos = System.Math.Min(pos + nums[pos], nums.Length - 1);
            for (int nextPos = pos + 1; nextPos <= maxPos; nextPos++)
            {
                if (CanJumpBackTracking(nums, nextPos))
                    return true;
            }

            return false;
        }
    }
}
