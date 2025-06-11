package DFS.Tree;

import DataStructures.TreeNode;

public class LongestUnivaluePath {
  // Leetcode 687: https://leetcode.com/problems/longest-univalue-path/description/
  // Submission Detail: https://leetcode.com/problems/longest-univalue-path/submissions/1650348537

  // Tx = O(n)
  // Sx = O(n)
  int result = 0;
  public int longestUnivaluePath(TreeNode root) {
    if(root == null)
      return 0;

    dfs(root, root.val);

    return result;
  }

  private int dfs(TreeNode node, int parentVal) {
    if(node == null)
      return 0;

    int left = dfs(node.left, node.val);
    int right = dfs(node.right, node.val);
    result = Math.max(result, left + right);

    if(node.val == parentVal)
      return 1 + Math.max(left, right);
    else
      return 0;
  }
}
