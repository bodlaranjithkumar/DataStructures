package DFS.Tree;

import DataStructures.TreeNode;

public class LongestZigZagPathinaBinaryTree {
    // Leetcode 1372: https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree/description/
    // Submission Detail: https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree/submissions/1673135175

    //Input: root = [1,null,1,1,1,null,null,1,1,null,1,null,null,null,1]
    //Output: 3
    //Explanation: Longest ZigZag path in blue nodes (right -> left -> right).

    //Input: root = [1,1,1,null,1,null,null,1,1,null,1]
    //Output: 4
    //Explanation: Longest ZigZag path in blue nodes (left -> right -> left -> right).

    //Input: root = [1]
    //Output: 0

    int maxLength = 0;
    public int longestZigZag(TreeNode root) {
        dfs(root, true, 0);
        dfs(root, false, 0);

        return maxLength;
    }

    private void dfs(TreeNode node, boolean isNodeRightToParent, int lengthSoFar) {
        // Base Case: Null Node. Do nothing
        if(node == null)
            return;

        maxLength = Math.max(maxLength, lengthSoFar);
        if(isNodeRightToParent) {
            dfs(node.left, false, lengthSoFar+1);
            dfs(node.right, true, 1);   // reset the length
        } else {
            dfs(node.right, true, lengthSoFar+1);
            dfs(node.left, false, 1);
        }
    }
}
