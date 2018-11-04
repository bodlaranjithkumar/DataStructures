namespace LeetcodeSolutions.DynamicProgramming
{
    // Leetcode 10 - https://leetcode.com/problems/regular-expression-matching/description/
    // Submission Detail - https://leetcode.com/submissions/detail/184926273/

    // Ref: https://www.youtube.com/watch?v=l3hda49XcDE
    //      https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/RegexMatching.java

    public class RegularExpressionMatching
    {
        // Tx = O(m*n)
        // Sx = O(m*n)

        public bool IsMatch(string text, string pattern)
        {
            int length1 = text.Length, length2 = pattern.Length;

            bool[,] dp = new bool[length1 + 1, length2 + 1];

            dp[0, 0] = true;

            //Deals with patterns like a* or a*b* or a*b*c*
            for (int i = 1; i <= length2; i++)
                if (pattern[i - 1] == '*')
                    dp[0, i] = dp[0, i - 2];

            for (int i = 1; i <= length1; i++)
            {
                for (int j = 1; j <= length2; j++)
                {
                    if (pattern[j - 1] == '.' || text[i - 1] == pattern[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (pattern[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 2];   // This could be T or F

                        if (pattern[j - 2] == '.' || text[i - 1] == pattern[j - 2])
                            dp[i, j] = dp[i, j] | dp[i - 1, j]; // boolean logical OR
                    }
                }
            }

            return dp[length1, length2];
        }
    }
}
