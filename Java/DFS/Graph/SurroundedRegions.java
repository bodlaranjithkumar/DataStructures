package DFS.Graph;

public class SurroundedRegions {
    // Leetcode 130: https://leetcode.com/problems/surrounded-regions/description/
    // Submission Detail: https://leetcode.com/problems/surrounded-regions/submissions/1703961883

    //Example 1:
    //Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
    //Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]

    //Example 2:
    //Input: board = [["X"]]
    //Output: [["X"]]

    // Tx = O(m*n)
    // Sx = O(m*n) for call stack
    public void solve(char[][] board) {
        // Step 1: Start from the borders to mark all the 'O's with 'S's that shouldn't be changed to "X's

        // Columns
        for(int row=0; row<board.length; row++) {
            if(board[row][0] == 'O')    // column 0
                dfs(board, row, 0);
            if(board[row][board[0].length-1] == 'O') // last column
                dfs(board, row, board[0].length-1);
        }

        // Rows
        for(int col = 0; col < board[0].length; col++) {
            if(board[0][col] == 'O') // row 0
                dfs(board, 0, col);
            if(board[board.length-1][col] == 'O') // last row
                dfs(board, board.length-1, col);
        }

        // Step 2: Replace with 'X's if the current grid value is 'O' and switch back to 'O' if it is 'S'
        for(int row=0; row<board.length; row++) {
            for(int col=0; col<board[0].length; col++) {
                if(board[row][col] == 'O')
                    board[row][col] = 'X';
                else if(board[row][col] == 'S')
                    board[row][col] = 'O';
            }
        }
    }

    private void dfs(char[][] board, int row, int col) {
        if(row < 0 || row >= board.length || col < 0 || col >= board[0].length || board[row][col] != 'O')
            return;

        board[row][col] = 'S';
        dfs(board, row+1, col); // go down
        dfs(board, row-1, col); // go up
        dfs(board, row, col+1); // go right
        dfs(board, row, col-1); // go left
    }
}
