package BFS.Tree;

import DataStructures.TreeNode;

import java.util.LinkedList;
import java.util.Queue;

public class MaximumWidthOfBinaryTree {
  // Leetcode 662: https://leetcode.com/problems/maximum-width-of-binary-tree/description/
  // Submission Detail: https://leetcode.com/problems/maximum-width-of-binary-tree/submissions/1651336467
  // Explanation: https://leetcode.com/problems/maximum-width-of-binary-tree/solutions/3436593/image-explanation-why-long-to-int-c-java-python

  // Tx = O(n)
  // Sx = O(n)
  public int widthOfBinaryTree(TreeNode root) {
    Queue<BinaryTreeNodePosition> bfs = new LinkedList<>();
    if(root != null)
      bfs.add(new BinaryTreeNodePosition(root, 0));

    int maxWidth = 0;

    while(!bfs.isEmpty()) {
      int firstNodePosition = bfs.peek().position;
      int size = bfs.size();
      int index = 0;

      for(int i = 0; i < size; i++) {
        BinaryTreeNodePosition currentNode = bfs.poll();
        index = currentNode.position;

        if(currentNode.node.left != null)
          bfs.add(new BinaryTreeNodePosition(currentNode.node.left, 2*index));

        if(currentNode.node.right != null)
          bfs.add(new BinaryTreeNodePosition(currentNode.node.right, 2*index+1));
      }

      maxWidth = Math.max(maxWidth, index-firstNodePosition+1);
    }

    return maxWidth;
  }

  private class BinaryTreeNodePosition {
    TreeNode node;
    int position;

    BinaryTreeNodePosition(TreeNode node, int position) {
      this.node = node;
      this.position = position;
    }
  }
}
