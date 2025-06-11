package DFS.Tree;

import DataStructures.TreeNode;

public class ValidateBST {
  // Leetcode 98: https://leetcode.com/problems/validate-binary-search-tree/description/

  // Tx = O(n)
  // Sx = O(n)
  public boolean isValidBST(TreeNode root) {
    return isValidBST(root, Integer.MIN_VALUE, Integer.MAX_VALUE);
  }

  private boolean isValidBST(TreeNode node, int min, int max) {
    if(node == null)
      return true;

    if(node.val <= min || node.val >= max)
      return false;

    boolean left = isValidBST(node.left, min, node.val);
    boolean right = isValidBST(node.right, node.val, max);

    return left && right;
  }
}
