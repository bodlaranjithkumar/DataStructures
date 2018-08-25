namespace LeetcodeSolutions.Math
{
    // Leetcode 70 - https://leetcode.com/problems/climbing-stairs
    // Submission Detail - https://leetcode.com/submissions/detail/128782293/
    // Bottom-Up Dynami Programming

    public class ClimbingStairs
    {
        // 1 - 1
        // 2 - 2
        // 3 - 3 (1 + 2)
        // 4 - 5 (2 + 3)
        // 5 - 8 (3 + 5) .......
        // Runtime = 150ms
        // Tx = O(n) {n = input}
        // Sx = O(1)
        public int ClimbStairs(int n)
        {
            if (n == 0 || n == 1 || n == 2)
            {
                return n;
            }

            int prev = 2;
            int prevPrev = 1;
            int numberOfWays = 0;

            for (int i = 2; i < n; i++)
            {
                numberOfWays = prev + prevPrev;
                prevPrev = prev;
                prev = numberOfWays;
            }

            return numberOfWays;
        }
    }
}
