package PrefixSum;

public class FindPivotIndex {
    // Leetcode 724: https://leetcode.com/problems/find-pivot-index/description/
    // Submission Detail: https://leetcode.com/problems/find-pivot-index/submissions/1670995369

    //Input: nums = [1,7,3,6,5,6]
    //Output: 3
    //Explanation:
    //The pivot index is 3.
    //Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
    //Right sum = nums[4] + nums[5] = 5 + 6 = 11

    //Input: nums = [1,2,3]
    //Output: -1
    //Explanation:
    //There is no index that satisfies the conditions in the problem statement.

    //Input: nums = [2,1,-1]
    //Output: 0
    //Explanation:
    //The pivot index is 0.
    //Left sum = 0 (no elements to the left of index 0)
    //Right sum = nums[1] + nums[2] = 1 + -1 = 0

    //Input: nums = [-1,1,2]
    //Output: 2
    //Explanation:
    //The pivot index is 2.
    //Left sum = 0 (no elements to the right of index 2)
    //Right sum = nums[0] + nums[1] = -1 + 1 = 0

    public int pivotIndex(int[] nums) {
        int sumSoFar=0, length=nums.length;
        int[] leftToRightSum = new int[length];
        int[] rightToLeftSum = new int[length];

        // Step 1: Calculate the left to right sum till index
        for(int index=0; index<length; index++) {
            sumSoFar += nums[index];
            leftToRightSum[index] = sumSoFar;
        }

        sumSoFar = 0;   // reset sum
        // Step 2: Calculate the right to left sum till index
        for(int index=length-1; index>=0; index--) {
            sumSoFar += nums[index];
            rightToLeftSum[index] = sumSoFar;
        }

        // Step 3: if the sum at any index is equal in both the sum arrays, that's the pivot index
        for(int index=0; index<length; index++) {
            if(leftToRightSum[index] == rightToLeftSum[index])
                return index;
        }

        return -1;
    }
}
