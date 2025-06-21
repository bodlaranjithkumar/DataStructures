package Matrices;

import java.util.HashMap;
import java.util.Map;

public class EqualRowandColumnPairs {
    // Leetcode 2352: https://leetcode.com/problems/equal-row-and-column-pairs/description/
    // Submission Detail: https://leetcode.com/problems/equal-row-and-column-pairs/submissions/1671950580

    //Input: grid = [[3,2,1],[1,7,6],[2,7,7]]
    //Output: 1
    //Explanation: There is 1 equal row and column pair:
    //        - (Row 2, Column 1): [2,7,7]

    //Input: grid = [[3,1,2,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]
    //Output: 3
    //Explanation: There are 3 equal row and column pairs:
    //        - (Row 0, Column 0): [3,1,2,2]
    //        - (Row 2, Column 2): [2,4,2,2]
    //        - (Row 3, Column 2): [2,4,2,2]

    public int equalPairs(int[][] grid) {
        Map<String, Integer> rowFreqCount = new HashMap<>();
        Map<String, Integer> colFreqCount = new HashMap<>();

        // Step1: Count the unique row frequency count
        for(int row=0; row<grid.length; row++) {
            StringBuilder sb = new StringBuilder();
            for(int col=0; col<grid[0].length; col++) {
                sb.append(grid[row][col]).append(",");
            }

            int count = rowFreqCount.getOrDefault(sb.toString(), 0);
            rowFreqCount.put(sb.toString(), count+1);
        }

        // Step2: Count the unique col frequency count
        for(int col=0; col<grid[0].length; col++) {
            StringBuilder sb = new StringBuilder();
            for(int row=0; row<grid.length; row++) {
                sb.append(grid[row][col]).append(",");
            }

            int count = colFreqCount.getOrDefault(sb.toString(), 0);
            colFreqCount.put(sb.toString(), count+1);
        }

        // Step3: Iterate through either of the row/col freq count and check if the key exists in the other.
        // If it does, then multiply freq of both row & col
        int result = 0;
        for(String key:rowFreqCount.keySet()) {
            if(colFreqCount.containsKey(key)) {
                result += rowFreqCount.get(key) * colFreqCount.get(key);
            }
        }

        return result;
    }
}
