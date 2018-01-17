namespace LeetcodeSolutions.Array
{
    // Leetcode 167
    public class TwoSum_InputArrayIsSorted
    {
        // Runtime:498 ms
        // Tx = O(n)
        // Sx = O(1)
        public int[] TwoSum(int[] numbers, int target)
        {
            int[] indices = new int[2];

            int low = 0, high = numbers.Length - 1;

            while (low < high)
            {
                int sum = numbers[low] + numbers[high];
                if (sum > target)
                    high--;
                else if (sum < target)
                    low++;
                else
                {
                    indices[0] = low + 1;
                    indices[1] = high + 1;
                    break;
                }
            }

            return indices;
        }
    }
}
