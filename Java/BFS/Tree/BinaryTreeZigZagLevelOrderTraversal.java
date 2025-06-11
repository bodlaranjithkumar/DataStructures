package BFS.Tree;

import DataStructures.TreeNode;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;

public class BinaryTreeZigZagLevelOrderTraversal {
  // Leetcode 103 : https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
  // Submission Detail: https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/submissions/1651308426

  // Tx = O(n)
  // Sx = O(n)
  public List<List<Integer>> zigzagLevelOrder(TreeNode root) {
    List<List<Integer>> result = new ArrayList<>();
    boolean leftToRight = true;  // denotes the direction to add node values at current level

    Queue<TreeNode> bfs = new LinkedList<>();
    if(root != null)
      bfs.add(root);

    while(!bfs.isEmpty()) {
      int size = bfs.size();
      List<Integer> level = new ArrayList<>();

      while(size > 0) {
        TreeNode node = bfs.poll();

        if(!leftToRight) {
          level.addFirst(node.val);
        } else {
          level.addLast(node.val);
        }

        if(node.left != null)
          bfs.add(node.left);
        if(node.right != null)
          bfs.add(node.right);

        size--;
      }

      leftToRight = !leftToRight;
      result.add(level);
    }

    return result;
  }
}
