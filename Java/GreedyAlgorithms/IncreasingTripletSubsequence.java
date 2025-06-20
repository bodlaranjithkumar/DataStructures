package GreedyAlgorithms;

public class IncreasingTripletSubsequence {
    // Leetcode 334: https://leetcode.com/problems/increasing-triplet-subsequence/description/
    // Submission Detail: https://leetcode.com/problems/increasing-triplet-subsequence/submissions/1670817315

    //Input: nums = [1,2,3,4,5]
    //Output: true
    //Explanation: Any triplet where i < j < k is valid.

    //Input: nums = [5,4,3,2,1]
    //Output: false
    //Explanation: No triplet exists.

    //Input: nums = [2,1,5,0,4,6]
    //Output: true
    //Explanation: The triplet (3, 4, 5) is valid because nums[3] == 0 < nums[4] == 4 < nums[5] == 6.

    // Tx = O(n)
    // Sx = O(1)
    public boolean increasingTriplet(int[] nums) {
        int firstHighest = Integer.MAX_VALUE, secondHighest = Integer.MAX_VALUE;
        
        for(int num:nums) {
            if(num <= firstHighest)
                firstHighest = num;
            else if(num <= secondHighest)
                secondHighest = num;
            else 
                return true; // Found 3 increasing numbers because current num is greater than firstHighest, secondHighest
        }

        return false;
    }    
}
