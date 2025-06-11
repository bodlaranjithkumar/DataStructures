package DFS.Tree;

import DataStructures.TreeNode;

public class PathSum {
  // Leetcode 112: https://leetcode.com/problems/path-sum/description/
  // Submission Detail: https://leetcode.com/problems/path-sum/submissions/1648623536

  // Tx = O(n)
  // Sx = O(n)
  public boolean hasPathSum(TreeNode node, int targetSum) {
    // Base Case: Empty Node doesn't have target sum.
    if(node == null)
      return false;

    // Base Case: Leaf Node
    if(node.left == null && node.right == null)
      return node.val == targetSum;

    boolean left = hasPathSum(node.left, targetSum-node.val);
    boolean right = hasPathSum(node.right, targetSum-node.val);

    return left || right;
  }
}
