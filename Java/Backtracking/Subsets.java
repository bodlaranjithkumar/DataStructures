package Backtracking;

import java.util.ArrayList;
import java.util.List;

public class Subsets {
    // Leetcode 78: https://leetcode.com/problems/subsets/
    // Submission Detail: https://leetcode.com/problems/subsets/submissions/1660479551
    // Explanation: https://www.hellointerview.com/learn/code/backtracking/subsets
    // Background explanation: https://www.hellointerview.com/learn/code/backtracking/solution-space-trees
    // Observation is to make a decision of including and excluding before calling the backtrack function recursively.

    //Input: nums = [1,2,3]
    //Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

    //Input: nums = [0]
    //Output: [[],[0]]

    List<List<Integer>> result;
    public List<List<Integer>> subsets(int[] nums) {
        result = new ArrayList<>();

        backtrack(nums, 0, new ArrayList<>());

        return result;
    }

    private void backtrack(int[] nums, int index, List<Integer> list) {
        // base case
        if(index == nums.length) {
            result.add(new ArrayList<>(list));
            return;
        }

        // decision to include the number at index in the list
        list.add(nums[index]);
        backtrack(nums, index+1, list);

        // decision to exclude the number at index in the list
        list.remove(list.size()-1);
        backtrack(nums, index+1, list);
    }
}
