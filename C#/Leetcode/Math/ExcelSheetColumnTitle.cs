using System.Text;

namespace LeetcodeSolutions.Math
{
    // Leetcode 168 - https://leetcode.com/problems/excel-sheet-column-title/
    // Submission Detail - https://leetcode.com/submissions/detail/143480793/

    public class ExcelSheetColumnTitle
    {
        // 28 -> AB
        // 53 -> BA
        // 100 -> CV
        // Tx = O(1)
        // Sx = O(1)
        public string ConvertToTitle(int n)
        {
            StringBuilder s = new StringBuilder();

            while (n > 0)
            {
                n--;
                s.Insert(0, (char)('A' + n % 26));
                n /= 26;
            }

            return s.ToString();
        }
    }
}
