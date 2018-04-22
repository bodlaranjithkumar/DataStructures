namespace LeetcodeSolutions.Math
{
    // Leetcode 171
    // Submission Detail: https://leetcode.com/submissions/detail/151036845/
    public class ExcelSheetColumnNumber
    {
        // Tx = O(n)
        // Sx = O(1)
        // Traverse from right to left
        public int TitleToNumber(string s)
        {
            int ColNumber = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                int charValue = s[i] - 'A' + 1;
                ColNumber += charValue * (int)System.Math.Pow(26, s.Length - i - 1);
            }

            return ColNumber;
        }
    }
}
