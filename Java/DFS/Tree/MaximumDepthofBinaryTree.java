package DFS.Tree;

import DataStructures.TreeNode;

public class MaximumDepthofBinaryTree {
  // Leetcode 104: https://leetcode.com/problems/maximum-depth-of-binary-tree/
  // Submission Detail: https://leetcode.com/problems/maximum-depth-of-binary-tree/submissions/1648617921

  // Tx = O(n)
  // Sx = O(n)
  public int maxDepth(TreeNode node) {
    // Base Case: Empty Node has a height of 0
    if(node == null)
      return 0;

    // Base Case: Leaf Node has a height of 1
    if(node.left == null && node.right == null)
      return 1;

    int left = maxDepth(node.left);
    int right = maxDepth(node.right);

    return 1 + Math.max(left, right);
  }
}
