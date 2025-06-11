package DFS.Tree;

import DataStructures.TreeNode;

public class SumofNodes {
  public int sumOfNodes(TreeNode node) {
    // Base case of empty node
    if(node == null)
      return 0;

    // Base case for leaf node
    if(node.left == null && node.right == null)
      return node.val;

    int left = sumOfNodes(node.left);
    int right = sumOfNodes(node.right);

    return node.val + left + right;
  }
}
