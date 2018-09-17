namespace LeetcodeSolutions.String
{
    // Leetcode 680 - https://leetcode.com/problems/valid-palindrome-ii/

    public class ValidPalindromeII
    {
        // Tx = O(n)
        // Sx = O(1)
        // Failed for the input "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga"
        // Actual: false, expected: true
        public bool ValidPalindrome(string s)
        {
            int count = 0, low = 0, high = s.Length - 1;

            while (low < high)
            {
                if (s[low] != s[high])
                {
                    if (count == 1)
                        return false;

                    count++;

                    if (low + 1 < high && s[low + 1] == s[high])
                        low++;
                    else //if(low < high-1 && s[low] == s[high-1])
                        high--;
                }
                else
                {
                    low++;
                    high--;
                }
            }

            return true;
        }
    }
}
