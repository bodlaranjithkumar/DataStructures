package Arrays;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class UniqueNumberofOccurrences {
    // Leetcode 1207: https://leetcode.com/problems/unique-number-of-occurrences/description/
    // Submission Detail: https://leetcode.com/problems/unique-number-of-occurrences/submissions/1671004744

    //Input: arr = [1,2,2,1,1,3]
    //Output: true
    //Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.

    //Input: arr = [1,2]
    //Output: false

    //Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
    //Output: true

    public boolean uniqueOccurrences(int[] nums) {
        Map<Integer, Integer> numCount = new HashMap();
        Set<Integer> distinctNumCount = new HashSet<>();

        for(int num:nums) {
            int count = numCount.getOrDefault(num, 0);
            numCount.put(num, count+1);
        }

        for(Integer freq:numCount.values()) {
            if(!distinctNumCount.contains(freq))
                distinctNumCount.add(freq);
        }

        return distinctNumCount.size() == numCount.size();
    }
}
