package GreedyAlgorithms;

import java.util.Arrays;

public class AssignCookies {
  // Leetcode 455 : https://leetcode.com/problems/assign-cookies/
  // Submission Detail: https://leetcode.com/problems/assign-cookies/submissions/1652345120

  //  Input: g = [1,2,3], s = [1,1]
  //  Output: 1

  //  Input: g = [1,2], s = [1,2,3]
  //  Output: 2

  // Greedy Algorithm
  // Tx = O(nlogn + klogk)
  // Sx = O(1)
  public int findContentChildren(int[] g, int[] s) {
    Arrays.sort(g);
    Arrays.sort(s);

    int count = 0, i = 0, j = 0;
    while(i < g.length && j < s.length) {
      if(s[j] >= g[i]) {
        count++;
        i++;
      }

      j++;
    }

    return count;
  }
}
