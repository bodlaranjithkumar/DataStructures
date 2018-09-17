namespace LeetcodeSolutions.String
{
    // Leetcode 389 - https://leetcode.com/problems/find-the-difference/
    // Submission - https://leetcode.com/submissions/detail/141070720/

    public class FindTheDifference
    {
        // Calculate the ASCII value difference.
        // Tx = O(n)
        // Sx = O(1)
        public char FindTheAdditionalCharacter(string s, string t)
        {
            // Initialize with t's last character ASCII value because 
            // the for loop runs for length of s.
            int difference = t[t.Length-1];

            for(int i = 0; i < s.Length; i++)
                difference = difference - s[i] + t[i];

            return (char)difference;
        }
    }
}
