using System;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 482 - https://leetcode.com/problems/license-key-formatting/
    // Submission Detail - https://leetcode.com/submissions/detail/139760389/
    // Similar to sliding window technique.

    public class LicenseKeyFormatting
    {
        //public static void Main(string[] args)
        //{
        //    LicenseKeyFormatting lk = new LicenseKeyFormatting();
        //    string output1 = lk.FormatLicenseKey("5F3Z-2e-9-w", 4);   // 5F3Z-2e9w
        //    string output2 = lk.FormatLicenseKey("2-5g-3-J", 2);      // 2-5g-3J
        //    string output3 = lk.FormatLicenseKey("5", 2);             // 5

        //    Console.ReadKey();
        //}

        // Tx = O(n) 
        // Sx = O(n) // Actually 2n.
        public string FormatLicenseKey(string S, int K)
        {
            string[] splits = S.Split('-');
            string AlphaNumerics = System.String.Join("", splits).ToUpper();  // TODO: Can this additional space be avoided

            int count = S.Length - splits.Length + 1;
            int start = 0, end = count % K == 0 ? K : count % K;

            StringBuilder output = new StringBuilder();

            while (end <= AlphaNumerics.Length)
            {
                output.Append(AlphaNumerics.Substring(start, end - start));
                
                if (end < AlphaNumerics.Length)
                    output.Append('-');

                start = end;
                end += K;
            }

            return output.ToString();
        }
    }
}
