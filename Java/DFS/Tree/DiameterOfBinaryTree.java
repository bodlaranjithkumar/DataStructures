package DFS.Tree;

import DataStructures.TreeNode;

public class DiameterOfBinaryTree {
  // Leetcode 543 : https://leetcode.com/problems/diameter-of-binary-tree/description/
  // Submission Detail: https://leetcode.com/problems/diameter-of-binary-tree/submissions/1650329335

  // Tx = O(n)
  // Sx = O(n)
  int diameter = 0;
  public int diameterOfBinaryTree(TreeNode root) {
    dfs(root);

    return diameter;
  }

  private int dfs (TreeNode node) {
    if(node == null)
      return 0;

    int left = dfs(node.left);
    int right = dfs(node.right);
    diameter = Math.max(diameter, left+right);

    return 1 + Math.max(left, right);
  }
}
