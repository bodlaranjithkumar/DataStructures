package Arrays;

import java.util.*;

public class FindtheDifferenceofTwoArrays {
    // Leetcode 2215: https://leetcode.com/problems/find-the-difference-of-two-arrays/description/
    // Submission Detail: https://leetcode.com/problems/find-the-difference-of-two-arrays/submissions/1671002067

    //Input: nums1 = [1,2,3], nums2 = [2,4,6]
    //Output: [[1,3],[4,6]]
    //Explanation:
    //For nums1, nums1[1] = 2 is present at index 0 of nums2, whereas nums1[0] = 1 and nums1[2] = 3 are not present in nums2. Therefore, answer[0] = [1,3].
    //For nums2, nums2[0] = 2 is present at index 1 of nums1, whereas nums2[1] = 4 and nums2[2] = 6 are not present in nums1. Therefore, answer[1] = [4,6].

    //Input: nums1 = [1,2,3,3], nums2 = [1,1,2,2]
    //Output: [[3],[]]
    //Explanation:
    //For nums1, nums1[2] and nums1[3] are not present in nums2. Since nums1[2] == nums1[3], their value is only included once and answer[0] = [3].
    //Every integer in nums2 is present in nums1. Therefore, answer[1] = [].

    public List<List<Integer>> findDifference(int[] nums1, int[] nums2) {
        List<List<Integer>> result = new ArrayList<>(2);
        Map<Integer, Integer> distinctNums1 = new HashMap<>();
        Map<Integer, Integer> distinctNums2 = new HashMap<>();

        // Step 1: Gather all unique nums count from nums1
        for(int num: nums1) {
            int count = distinctNums1.getOrDefault(num, 0);
            distinctNums1.put(num, count+1);
        }

        // Step 2: Gather all unique nums count from nums2
        for(int num: nums2) {
            int count = distinctNums2.getOrDefault(num, 0);
            distinctNums2.put(num, count+1);
        }

        // Step 3: Filter out the distinct num present in nums2
        List<Integer> result0 = new ArrayList<>();
        for(Integer key:distinctNums1.keySet()) {
            if(!distinctNums2.containsKey(key))
                result0.add(key);
        }

        // Step 4: Filter out the nums from nums2 present in nums1
        List<Integer> result1 = new ArrayList<>();
        for(Integer key:distinctNums2.keySet()) {
            if(!distinctNums1.containsKey(key))
                result1.add(key);
        }

        result.add(result0);
        result.add(result1);

        return result;
    }
}
