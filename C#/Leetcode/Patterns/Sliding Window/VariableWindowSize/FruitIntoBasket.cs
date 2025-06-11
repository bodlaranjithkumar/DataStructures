public class Solution {
    // Leetcode 904 - https://leetcode.com/problems/fruit-into-baskets/
    // Submission Detail: https://leetcode.com/problems/fruit-into-baskets/submissions/1541123727
    // Variable Sliding Window

    // Tx = O(n)
    // Sx = O(n)
    public int TotalFruit(int[] fruits) {
        int start = 0;
        int end = 0;
        int length = fruits.Length;
        IDictionary<int, int> fruitCount = new Dictionary<int, int>(length);
        int maxDistinctFruits = 0;

        while(end < length) {
            int endFruit = fruits[end];
            if(!fruitCount.ContainsKey(endFruit)) {
                fruitCount.Add(endFruit, 0);
            }
            fruitCount[endFruit]++;
            
            while(fruitCount.Keys.Count > 2) {
                 // remove the fruits at the start to bring fruitcount down to 2
                int startFruit = fruits[start];
                fruitCount[startFruit]--;
                if(fruitCount[startFruit] == 0) {
                    fruitCount.Remove(startFruit);
                }
                start++;
            }
                
            maxDistinctFruits = Math.Max(maxDistinctFruits, end-start+1);
            end++;
        }

        return maxDistinctFruits;
    }
}