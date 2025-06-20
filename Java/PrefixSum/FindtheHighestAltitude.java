package PrefixSum;

public class FindtheHighestAltitude {
    // Leetcode 1732: https://leetcode.com/problems/find-the-highest-altitude/description/
    // Submission Detail: https://leetcode.com/problems/find-the-highest-altitude/submissions/1670989259

    //Input: gain = [-5,1,5,0,-7]
    //Output: 1
    //Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.

    //Input: gain = [-4,-3,-2,-1,4,3,2]
    //Output: 0
    //Explanation: The altitudes are [0,-4,-7,-9,-10,-6,-3,-1]. The highest is 0.

    public int largestAltitude(int[] gains) {
        int currentAltitude=0, maxLatitude=0;

        for(int gain:gains) {
            currentAltitude += gain;
            maxLatitude = Math.max(maxLatitude, currentAltitude);
        }

        return maxLatitude;
    }
}
