namespace LeetcodeSolutions.DynamicProgramming
{
    // Dynamic programming

    public class SubsetSum
    {
        // Ref: https://www.youtube.com/watch?v=s6FhG--P7z0

        public static void Main(string[] args)
        {
            SubsetSum subsetSum = new SubsetSum();

            int[] arr1 = { 2, 3, 7, 8 };
            bool result1 = subsetSum.IsSubsetWithGivenSumExists(arr1, 9);     // true;
            bool result2 = subsetSum.IsSubsetWithGivenSumExists(arr1, 17);     // true;
            bool result3 = subsetSum.IsSubsetWithGivenSumExists(arr1, 12);     // true;
            bool result4 = subsetSum.IsSubsetWithGivenSumExists(arr1, 6);     // false;
        }

        // Bottom-Up
        public bool IsSubsetWithGivenSumExists(int[] nums, int targetSum)
        {
            int rows = nums.Length;

            // targetSum+1 columns because of the column sum = 0.
            bool[,] dp = new bool[rows, targetSum + 1];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j <= targetSum; j++)
                    if (j == 0 || (i == 0 && nums[i] == j))
                        dp[i, j] = true;
                    else if (i > 0)
                    {
                        dp[i, j] = dp[i - 1, j];

                        if (j >= nums[i])
                            dp[i, j] = dp[i,j] || dp[i - 1, j - nums[i]];
                    }


            return dp[rows - 1, targetSum];
        }
    }
}
