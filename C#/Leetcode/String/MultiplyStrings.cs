using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 43 - https://leetcode.com/problems/multiply-strings/description/
    // Submission Detail - https://leetcode.com/submissions/detail/205447947/

    public class MultiplyStrings
    {
        // Tx = O(m*n)
        // Sx = O(m+n)
        public string Multiply(string num1, string num2)
        {
            int m = num1.Length, n = num2.Length;
            int[] arr = new int[m + n];

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    int product = (num1[i] - '0') * (num2[j] - '0');
                    int index1 = i + j, index2 = i + j + 1;
                    int sum = product + arr[index2];

                    arr[index2] = sum % 10;
                    arr[index1] += sum / 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (int c in arr)
            {
                if (!(sb.Length == 0 && c == 0))
                    sb.Append(c);
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }
    }
}
