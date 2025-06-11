package BFS.Tree;

import DataStructures.TreeNode;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;

public class BinaryTreeRightSideView {
  // Leetcode 199: https://leetcode.com/problems/binary-tree-right-side-view/description/
  // Submission Detail: https://leetcode.com/problems/binary-tree-right-side-view/submissions/1651210084

  public List<Integer> rightSideView(TreeNode root) {
    List<Integer> result = new ArrayList<>();
    Queue<TreeNode> bfs = new LinkedList<>();
    if(root != null)
      bfs.add(root);

    while(!bfs.isEmpty()) {
      int size = bfs.size();

      while(size > 0) {
        TreeNode currentNode = bfs.poll();

        if(size == 1)
          result.add(currentNode.val);

        if(currentNode.left != null)
          bfs.add(currentNode.left);
        if(currentNode.right != null)
          bfs.add(currentNode.right);

        size--;
      }
    }

    return result;
  }
}
