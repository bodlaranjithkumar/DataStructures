using System;

public class Solution {

    // Leetcode 455: https://leetcode.com/problems/assign-cookies/description/
    // Submission Detail: https://leetcode.com/problems/assign-cookies/submissions/1565587232
    // Explanation: https://www.hellointerview.com/learn/code/greedy/overview
    
    // Tx = O(mlogm + nlogn)
    // Sx = O(1)
    public int FindContentChildren(int[] g, int[] s) {
        Array.Sort(g);
        Array.Sort(s);

        int result = 0;
        int i = 0, j = 0;

        while(j < s.Length && i < g.Length) {
            if(s[j] >= g[i]) {
                result++;
                i++;
            }
            j++;
        }

        return result;
    }
}