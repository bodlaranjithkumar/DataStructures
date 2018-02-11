﻿namespace LeetcodeSolutions.Math
{
    //Leetcode 69
    public class Sqrt
    {
        // Tx = O(lgn)
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
