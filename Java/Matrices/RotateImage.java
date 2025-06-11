package Matrices;

public class RotateImage {
  // Leetcode 48: https://leetcode.com/problems/rotate-image/submissions/1659303066/
  // Submission Detail: https://leetcode.com/problems/rotate-image/submissions/1659303066

  // Tx = O(n*n)
  // Sx = O(1)
  public void rotate(int[][] matrix) {
    int n = matrix.length;
    for(int i=0; i<n; i++) {
      for(int j=i; j<n-1-i; j++) {
        int temp = matrix[i][j];
        matrix[i][j] = matrix[n-1-j][i];
        matrix[n-1-j][i] = matrix[n-1-i][n-1-j];
        matrix[n-1-i][n-1-j] = matrix[j][n-1-i];
        matrix[j][n-1-i] = temp;
      }
    }
  }
}
