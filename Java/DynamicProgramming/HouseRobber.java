package DynamicProgramming;

import java.util.HashMap;
import java.util.Map;

public class HouseRobber {
    // Leetcode 198: https://leetcode.com/problems/house-robber/description/

    //Input: treasure = : [3, 1, 4, 1, 5]
    //Output: 12
    //Explanation: Collect from houses 0, 2, and 4 for a total of 3 + 4 + 5 = 12.

    //Input: nums = [1,2,3,1]
    //Output: 4
    //Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
    //Total amount you can rob = 1 + 3 = 4.

    //Input: nums = [2,7,9,3,1]
    //Output: 12
    //Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
    //Total amount you can rob = 2 + 9 + 1 = 12.

    // Bottom Up
    // Submission Detail: https://leetcode.com/problems/house-robber/submissions/1661501320
    // Tx = O(n)
    // Sx = O(1)
    public int robBottomUpSpaceOptimized(int[] nums) {
        int prev = 0, curr = nums[0];

        for(int i=1; i<nums.length; i++) {
            int max = Math.max(curr, prev + nums[i]);
            prev = curr;
            curr = max;
        }

        return curr;
    }

    // Submission Detail: https://leetcode.com/problems/house-robber/submissions/1661498114
    // Bottom Up
    // Tx = O(n)
    // Sx = O(n)
    public int robBottomUp(int[] nums) {
        int[] dp = new int[nums.length+1];
        dp[0] = 0;
        dp[1] = nums[0];

        for(int i=2; i<dp.length; i++) {
            int skip = dp[i-1];
            int take = dp[i-2]+nums[i-1];
            dp[i] = Math.max(skip, take);
        }

        return dp[nums.length];
    }

    // Top Down with Memoization
    // Submission Detail: https://leetcode.com/problems/house-robber/submissions/1661485281
    public int rob(int[] nums) {
        Map<Integer, Integer> dp = new HashMap<>(nums.length+1);
        int result = robTopDown(nums, nums.length, dp);

        return result;
    }

    public int robTopDown(int[] nums, int houseIndex, Map<Integer, Integer> dp) {
        // Base Case
        if(houseIndex == 0)  // House 0 has no amount to rob
            return 0;
        if(houseIndex == 1)
            return nums[0];

        if(dp.containsKey(houseIndex))
            return dp.get(houseIndex);

        int skip = robTopDown(nums, houseIndex-1, dp);
        int take = robTopDown(nums, houseIndex-2, dp) + nums[houseIndex-1];
        int result = Math.max(skip, take);

        if(!dp.containsKey(houseIndex))
            dp.put(houseIndex, result);

        return result;
    }
}
