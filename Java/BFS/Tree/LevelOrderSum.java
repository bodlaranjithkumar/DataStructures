package BFS.Tree;

import DataStructures.TreeNode;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;

public class LevelOrderSum {

  // Tx = O(n)
  // Sx = O(n)
  public List<Integer> levelOrder(TreeNode root) {
    List<Integer> result = new ArrayList<>();
    Queue<TreeNode> bfs = new LinkedList<>();
    bfs.add(root);

    while(!bfs.isEmpty()) {
      int size = bfs.size();
      int sum = 0;

      while(size > 0) {
        TreeNode currentNode = bfs.poll();
        sum+= currentNode.val;

        if(currentNode.left != null)
          bfs.add(currentNode.left);
        if(currentNode.right != null)
          bfs.add(currentNode.right);

        size--;
      }

      result.add(sum);
    }

    return result;
  }
}
