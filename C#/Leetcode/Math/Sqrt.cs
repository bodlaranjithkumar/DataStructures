namespace LeetcodeSolutions.Math
{
    // Leetcode 69 - https://leetcode.com/problems/sqrtx/
    // Submission Detail - https://leetcode.com/submissions/detail/140386303/
    // Modified Binary Search

    public class Sqrt
    {
        // Tx = O(lgn)
        // Sx = O(1)
        // Note: x may not be a perfect square.

        public int MySqrt(int x)
        {
            if (x == 0 || x == 1)
                return x;

            int low = 1, high = x / 2, result = 0;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                // Use division instead of mid * mid to avoid overflow resulting in incorrect output.
                // if x is not perfect square take the floor value as the sqrt.
                if (mid <= x / mid) 
                { 
                    result = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return result;
        }
    }
}
