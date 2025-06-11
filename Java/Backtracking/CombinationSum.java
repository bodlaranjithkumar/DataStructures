package Backtracking;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class CombinationSum {
    // Leetcode 39: https://leetcode.com/problems/combination-sum/description/
    // Submission Detail:

    //Input: candidates = [2,3,6,7], target = 7
    //Output: [[2,2,3],[7]]
    //Explanation:
    //        2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
    //7 is a candidate, and 7 = 7.
    //These are the only two combinations.

    //Input: candidates = [2,3,5], target = 8
    //Output: [[2,2,2,2],[2,3,3],[3,5]]

    //Input: candidates = [2], target = 1
    //Output: []

    List<List<Integer>> result;
    public List<List<Integer>> combinationSum(int[] candidates, int target) {
        result = new ArrayList<>();
        Arrays.sort(candidates);

        backtrack(candidates, 0, target, new ArrayList<>());

        return result;
    }

    private void backtrack(int[] candidates, int index, int currentTarget, List<Integer> list) {
        // Base Case: When the target is 0, the numbers in the list are a pair
        if(currentTarget == 0) {
            result.add(new ArrayList<>(list));
            return;
        }

        for(int i=index; i<candidates.length; i++) {
            int candidate = candidates[i];

            if(candidate > currentTarget)
                return;

            list.add(candidate);
            backtrack(candidates, i, currentTarget-candidate, list);
            list.remove(list.size()-1);
        }
    }
}
