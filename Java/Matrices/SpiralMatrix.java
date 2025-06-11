package Matrices;

import java.util.ArrayList;
import java.util.List;

public class SpiralMatrix {
  // Leetcode 54: https://leetcode.com/problems/spiral-matrix/description/
  // Submission Detail: https://leetcode.com/problems/spiral-matrix/submissions/1659290036

  //  Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
  //  Output: [1,2,3,6,9,8,7,4,5]

  //  Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
  //  Output: [1,2,3,4,8,12,11,10,9,5,6,7]

  // Tx = O(m*n)
  // Sx = O(m*n)
  public List<Integer> spiralOrder(int[][] matrix) {
    int top = 0, bottom = matrix.length-1, left = 0, right = matrix[0].length-1, dir = 0;
    List<Integer> result = new ArrayList<>();

    while(top <= bottom && left <= right) {
      if(dir == 0) {
        for(int i = left; i<=right; i++)
          result.add(matrix[top][i]);

        top++;
        dir++;
      } else if(dir == 1) {
        for(int i=top; i<=bottom; i++)
          result.add(matrix[i][right]);

        right--;
        dir++;
      } else if(dir ==2) {
        for(int i=right; i>= left; i--)
          result.add(matrix[bottom][i]);

        bottom--;
        dir++;
      } else if(dir == 3) {
        for(int i=bottom; i>=top; i--)
          result.add(matrix[i][left]);

        left++;
        dir = 0;
      }
    }

    return result;
  }
}
