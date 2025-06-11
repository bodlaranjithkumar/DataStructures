namespace LeetcodeSolutions.Patterns.Two_Pointers
{
    // Leetcode 75
    // Submission Detail: https://leetcode.com/submissions/detail/151359598/
    public class SortColors
    {
        // [2,0,2,1,1,0]    =>  [0,0,1,1,2,2]
        // [1,1,0,2,1,0,2]  =>  [0,0,1,1,1,2,2]
        // [2,0,1]          =>  [0,1,2]
        // Tx = O(n)
        // Sx = O(1)    In-place
        // Two Pointers
        // Bruteforce: Counting sort.
        // Idea: Use 3 pointers - i,j,k. 
        //          i is the iterative index.
        //          j points to the first occurrence of 1.
        //          k points to the index before the last occurrence of 2.

        public void SortNumbers(int[] nums)
        {
            if (nums == null) return;

            int i = 0, j = 0, k = nums.Length - 1;

            while (i <= k)
            {
                int num = nums[i];
                if (num == 0)
                {
                    Swap(nums, i, j);
                    i++;
                    j++;
                }
                else if (num == 1)
                {
                    i++;
                }
                else if (num == 2)
                {
                    Swap(nums, i, k);
                    k--;
                }
            }
        }

        private static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
