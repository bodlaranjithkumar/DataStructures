namespace LeetcodeSolutions.DynamicProgramming
{
    // Leetcode 509: https://leetcode.com/problems/fibonacci-number/description/
    // Submission Detail: https://leetcode.com/submissions/detail/202480047/

    public class FibonacciNumbers
    {
        // Bottom-up Dynamic Programming
        // Tx = O(N)
        // Sx = O(1)
        public int Fib(int N)
        {
            if (N < 2) return N;

            int prevprev = 0, prev = 1, nthfib = 0;

            for (int i = 1; i < N; i++)
            {
                nthfib = prevprev + prev;
                prevprev = prev;
                prev = nthfib;
            }

            return nthfib;
        }
    }
}
