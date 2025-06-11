package Matrices;

public class SetMatrixZeroes {
  // Leetcode 73: https://leetcode.com/problems/set-matrix-zeroes/description/
  // Submission Detail: https://leetcode.com/problems/set-matrix-zeroes/submissions/1659443321

  //  Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
  //  Output: [[1,0,1],[0,0,0],[1,0,1]]

  //  Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
  //  Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]

  public void setZeroes(int[][] matrix) {
    boolean firstRow = false, firstColumn = false;

    // Step 1: First Pass - iterate and track what cols, rows needs to be set to 0.
    for(int row=0; row<matrix.length; row++) {
      for(int col=0; col<matrix[0].length; col++) {
        if(matrix[row][col] == 0) {
          if (row == 0)
            firstRow = true;

          if(col == 0)
            firstColumn = true;

          if(row != 0 && col != 0) {
            matrix[0][col] = 0;
            matrix[row][0] = 0;
          }
        }
      }
    }

    // Step 2: Use the tracked values to set the cell value to 0
    for(int row=0; row< matrix.length; row++) {
      for(int col = 0; col < matrix[0].length; col++) {
        if(row != 0 && col != 0 && (matrix[row][0] == 0 || matrix[0][col] == 0))
          matrix[row][col] = 0;
      }
    }

    // Step 3: Use the tracked values to set the firstCol value to 0
    if(firstColumn) {
      for(int row=0; row< matrix.length; row++)
        matrix[row][0] = 0;
    }

    // Step 4: Use the tracked values to set the firstRow value to 0
    if(firstRow){
      for(int col = 0; col < matrix[0].length; col++)
        matrix[0][col] = 0;
    }
  }
}
