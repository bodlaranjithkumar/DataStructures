package TwoPointers;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class ThreeSum {
    // Leetcode 15: https://leetcode.com/problems/3sum/submissions/1622488020/
    // Submission Detail: https://leetcode.com/problems/3sum/submissions/1622488020

    //Input: nums = [-1,0,1,2,-1,-4]
    //Output: [[-1,-1,2],[-1,0,1]]

    // Tx = O(n2)
    // Sx = O(n2)
    public List<List<Integer>> threeSum(int[] nums) {
        List<List<Integer>> result = new ArrayList<>();
        Arrays.sort(nums);

        for(int index = 0; index < nums.length-2; index++) {
            if(index > 0 && nums[index] == nums[index-1])
                continue;

            int left = index+1, right = nums.length-1;
            while(left < right) {
                int sum = nums[index] + nums[left] + nums[right];

                if(sum < 0) {
                    left ++;
                } else if (sum > 0) {
                    right--;
                } else {
                    result.add(Arrays.asList(nums[index], nums[left], nums[right]));
                    while(left < right && nums[left] == nums[left+1])
                        left++;

                    while(left < right && nums[right] == nums[right-1])
                        right--;

                    // we covered the values at these indexes previously.
                    left++;
                    right--;
                }
            }
        }

        return result;
    }
}
