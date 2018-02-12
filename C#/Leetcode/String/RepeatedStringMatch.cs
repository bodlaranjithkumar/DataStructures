using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 686
    // Submission : https://leetcode.com/submissions/detail/140491920/
    public class RepeatedStringMatch
    {
        // aa,a
        // abcabcabcabc,abac
        // abababaaba, aabaaba
        // abcd, cdabcdab
        public int IsRepeatedStringMatch(string A, string B)
        {
            int count = 1;
            StringBuilder sb = new StringBuilder(A);
            while (sb.Length < B.Length)    //Key: Run until A's length is less that B's length
            {
                sb.Append(A);
                count++;
            }

            if (sb.ToString().Contains(B)) return count;
            else if (sb.Append(A).ToString().Contains(B)) return count + 1;
            else return -1;
        }
    }
}
