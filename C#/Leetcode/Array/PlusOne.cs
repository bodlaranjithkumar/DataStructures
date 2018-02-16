namespace LeetcodeSolutions.Array
{
    // Leetcode 66
    // Submission: https://leetcode.com/submissions/detail/140742448/
    public class PlusOne
    {
        // 8,9,9,9 -> 9,0,0,0
        // 9,9,9,9 -> 1,0,0,0,0
        // 9,9,9,8 -> 9,9,9,9

        // Tx = O(n)
        // Sx = O(n)    // worst case
        public int[] AddPlusOne(int[] digits)
        {
            int length = digits.Length - 1;

            for (int i = length; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            int[] result = new int[length + 2];
            result[0] = 1;

            return result;
        }
    }
}
