package Backtracking;

import java.util.ArrayList;
import java.util.List;

public class CombinationSumIII {
    // Leetcode 216: https://leetcode.com/problems/combination-sum-iii/description/
    // Submission Detail: https://leetcode.com/problems/combination-sum-iii/submissions/1680868170

    //Input: k = 3, n = 7
    //Output: [[1,2,4]]
    //Explanation:
    //        1 + 2 + 4 = 7
    //There are no other valid combinations.

    //Input: k = 3, n = 9
    //Output: [[1,2,6],[1,3,5],[2,3,4]]
    //Explanation:
    //        1 + 2 + 6 = 9
    //        1 + 3 + 5 = 9
    //        2 + 3 + 4 = 9
    //There are no other valid combinations.

    //Input: k = 4, n = 1
    //Output: []
    //Explanation: There are no valid combinations.
    //        Using 4 different numbers in the range [1,9], the smallest sum we can get is 1+2+3+4 = 10 and since 10 > 1, there are no valid combination.

    private List<List<Integer>> result = new ArrayList<>();
    public List<List<Integer>> combinationSum3(int k, int n) {
        backtrack(k, n, 1, 0, new ArrayList<>());

        return result;
    }

    private void backtrack(int k, int targetSum, int num, int sumSoFar, List<Integer> currentNums) {
        // Base Case: When the currentNums length is eq to k. Found the combination
        if(currentNums.size() == k && sumSoFar == targetSum) {
            result.add(new ArrayList<>(currentNums));
            return;
        }

        for(; num<=9; num++) {
            sumSoFar += num;
            if(sumSoFar <= targetSum) {
                currentNums.add(num);
                backtrack(k, targetSum, num+1, sumSoFar, currentNums);
                currentNums.remove(currentNums.size()-1);
            } else {
                return;
            }

            sumSoFar -= num;
        }
    }
}
