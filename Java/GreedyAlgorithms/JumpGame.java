package GreedyAlgorithms;

public class JumpGame {
  // Leetcode 55: https://leetcode.com/problems/jump-game/description/
  // Submission Detail: https://leetcode.com/problems/jump-game/submissions/1652402305

  //  Input: nums = [2,3,1,1,4]
  //  Output: true
  //  Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

  //  Input: nums = [3,2,1,0,4]
  //  Output: false
  //  Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.

  // Tx = O(n)
  // Sx = O(1)
  public boolean canJump(int[] nums) {
    int maxReachableIndex = 0;

    for(int i = 0; i < nums.length; i++) {
      if(i > maxReachableIndex)
        return false;
      maxReachableIndex = Math.max(maxReachableIndex, i + nums[i]);
    }

    return true;
  }
}
