namespace LeetcodeSolutions.Array
{
    // Leetcode 179
    // Submission Detail: https://leetcode.com/submissions/detail/151099674/
    public class LargestNumber
    {
        // Tx = O(nlogn)
        // Sx = O(n)
        // Sort
        public string FormLargestNumber(int[] nums)
        {
            string[] numbers = new string[nums.Length];

            for (int i = 0; i < nums.Length; i++)
                numbers[i] = nums[i] + "";
            
            System.Array.Sort(numbers, (str1, str2) =>
            {
                var s1 = str1 + str2;
                var s2 = str2 + str1;

                return s2.CompareTo(s1);
            });

            // To cover the case of [0,0] -> "0"
            if (numbers[0] == "0") return "0";

            string largestNumber = string.Join("", numbers);

            return largestNumber;
        }
    }
}
