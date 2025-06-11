package Backtracking;

public class WordSearch {
    // Leetcode 79: https://leetcode.com/problems/word-search/description/
    // Submission Detail: https://leetcode.com/problems/word-search/submissions/1660283728

    //Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
    //Output: true

    //Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
    //Output: false

    int[][] visited;

    // Tx = O(m * n * 4L) {L: length of the word}
    // Sx = O(L)
    public boolean exist(char[][] board, String word) {
        visited = new int[board.length][board[0].length];

        for(int row=0; row<board.length; row++) {
            for(int col=0; col<board[0].length; col++) {
                if(board[row][col] == word.charAt(0) && backtrack(board, row, col, word, 0))
                    return true;
            }
        }

        return false;
    }

    private boolean backtrack(char[][] board, int row, int col, String word, int wordIndex) {
        // Base Case: We parsed all the characters in the word on the board.
        if(wordIndex == word.length())
            return true;

        // Base Case: Index out of bounds of the baord
        if(row < 0 || col < 0 || row >= board.length || col >= board[0].length || word.charAt(wordIndex) != board[row][col] || visited[row][col] == 1)
            return false;

        visited[row][col] = 1;

        wordIndex++;
        if(backtrack(board, row+1, col, word, wordIndex) // Go Down
            || backtrack(board, row, col+1, word, wordIndex) // Go Right
            || backtrack(board, row-1, col, word, wordIndex) // Go Up
            || backtrack(board, row, col-1, word, wordIndex)) // Go Left
            return true;

        visited[row][col] = 0;

        return false;
    }
}
