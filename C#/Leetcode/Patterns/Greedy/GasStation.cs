public class Solution {
    // Leetcode 134 - https://leetcode.com/problems/gas-station/
    // Submission Detail - https://leetcode.com/problems/gas-station/submissions/1565625293
    // Explanation - https://www.hellointerview.com/learn/code/greedy/gas-station

    // Tx = O(n)
    // Sx = O(1)
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        // No path exists if total gas is less than total cost
        if(CalculateSum(gas) < CalculateSum(cost))
            return -1;

        int start = 0, fuelRemaining = 0;

        for(int i=0; i<gas.Length; i++) {
            if(fuelRemaining + gas[i] - cost[i] >= 0) {
                fuelRemaining += gas[i] - cost[i];
            } else {
                // if the cost of starting at previous gas stations outweighs fueled gas, then starting 
                // at next index gives us the optimal outcome. Because our condition at the top indirectly implies this.
                start = i+1;
                fuelRemaining = 0;
            }
        }

        return start;
    }

    private long CalculateSum(int[] nums) {
        long sum = 0;

        foreach(int num in nums)
            sum+= num;
        
        return sum;
    }
}