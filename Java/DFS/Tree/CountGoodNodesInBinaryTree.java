package DFS.Tree;

import DataStructures.TreeNode;

public class CountGoodNodesInBinaryTree {
  // Leetcode 1448: https://leetcode.com/problems/count-good-nodes-in-binary-tree/description/
  // Submission Detail: https://leetcode.com/problems/count-good-nodes-in-binary-tree/submissions/1648637875

  // Tx = O(n)
  // Sx = O(n)
  public int goodNodes(TreeNode root) {
    return 1 + goodNodes(root.left, root.val) + goodNodes(root.right, root.val);
  }

  private int goodNodes(TreeNode node, int maxAncestorVal) {
    // Base Case: Return on empty val
    if(node == null)
      return 0;

    int left = goodNodes(node.left, Math.max(maxAncestorVal, node.val));
    int right = goodNodes(node.right, Math.max(maxAncestorVal, node.val));

    return left + right + (node.val >= maxAncestorVal ? 1 : 0);
  }
}
