package DFS.Tree;

import DataStructures.TreeNode;

public class BinaryTreeTilt {
  // Leetcode 563 : https://leetcode.com/problems/binary-tree-tilt/description/
  // Submission Detail: https://leetcode.com/problems/binary-tree-tilt/submissions/1650307944

  // Tx = O(n)
  // Sx = O(n)
  int totalTilt = 0;
  public int findTilt(TreeNode root) {
    dfs(root);

    return totalTilt;
  }

  private int dfs(TreeNode root) {
    // Base Case: Empty has tilt of 0
    if(root == null)
      return 0;

    // Base Case: Leaf node has a tilt of current node's value.
    if(root.left == null && root.right == null)
      return root.val;

    int left = dfs(root.left);
    int right = dfs(root.right);
    totalTilt += Math.abs(left - right);

    return left + right + root.val;
  }
}
