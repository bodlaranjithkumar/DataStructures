package SlidingWindow.VariableWindow;

import java.util.HashMap;
import java.util.Map;

public class FruitIntoBaskets {
    // Leetcode 904: https://leetcode.com/problems/fruit-into-baskets/description/
    // Submission Detail: https://leetcode.com/problems/fruit-into-baskets/submissions/1624555460

    // Input: fruits = [3, 3, 2, 1, 2, 1, 0]
    // Output: 4
    // Explanation: We can pick up 4 fruit from the subarray [2, 1, 2, 1]
    public int totalFruit(int[] fruits) {
        int start = 0, maxWindowSize = 0;
        Map<Integer, Integer> fruitCount = new HashMap<>();

        for(int end = 0; end < fruits.length; end++) {
            int count = fruitCount.getOrDefault(fruits[end], 0);
            fruitCount.put(fruits[end], count+1);

            while(fruitCount.keySet().size() > 2) {
                int currentFruitCount = fruitCount.get(fruits[start]);
                if(currentFruitCount == 1) {
                    fruitCount.remove(fruits[start]);
                } else {
                    fruitCount.put(fruits[start], currentFruitCount-1);
                }

                start++;
            }

            maxWindowSize = Math.max(maxWindowSize, end-start);
        }

        return maxWindowSize;
    }
}
