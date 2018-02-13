namespace LeetcodeSolutions.Array
{
    // Leetcode 66
    // Submission: https://leetcode.com/submissions/detail/140742448/
    public class PlusOne
    {
        public int[] AddPlusOne(int[] digits)
        {
            if (digits == null)
                return digits;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            int[] result = new int[digits.Length + 1];
            result[0] = 1;

            return result;
        }
    }
}
