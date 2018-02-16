using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 345
    // Submission: https://leetcode.com/submissions/detail/140495752/
    // 2 pointers
    public class ReverseVowelsOfAString
    {
        //"hello", return "holle"
        //"leetcode", return "leotcede"
        //"google", return "geoglo"
        //"letcode", return "letcode"
        private static HashSet<char> vowels = new HashSet<char>() {
            'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        // Tx = O(n)
        // Sx = O(n)    // for the new reversed string
        public string ReverseVowels(string s)
        {
            if (s == null || s.Length == 0)
                return s;

            int low = 0, high = s.Length - 1;
            StringBuilder sb = new StringBuilder(s);

            while (low < high)
            {
                // Keep going right until low < high and char at index low is a valid vowel.
                while (low < high && !vowels.Contains(sb[low]))
                    low++;

                // Keep going left until low < high and char at index high is a valid vowel.
                while (low < high && !vowels.Contains(sb[high]))
                    high--;

                // case sensitive character comparision
                if (!sb[low].Equals(sb[high]))
                {
                    char temp = sb[low];
                    sb[low] = sb[high];
                    sb[high] = temp;
                }

                low++; high--;
            }

            return sb.ToString();
        }
    }
}
