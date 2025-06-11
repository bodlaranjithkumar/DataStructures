package DFS.Tree;

import DataStructures.TreeNode;

import java.util.ArrayList;
import java.util.List;

public class PathSumII {
  // Leetcode 113:
  // Submission Detail: https://leetcode.com/problems/path-sum-ii/submissions/1651190904

  List<List<Integer>> result;
  public PathSumII() {
    result = new ArrayList<>();
  }

  // Tx = O(n)
  // Sx = O(n + k log n) {k: number of paths}
  public List<List<Integer>> pathSum(TreeNode root, int targetSum) {
    dfs(root, new ArrayList<>(), targetSum);

    return result;
  }

  private void dfs(TreeNode node, List<Integer> pathNodes, int remainingTargetSum) {
    // Base case: Do nothing for an empty node.
    if(node == null)
      return;

    pathNodes.add(node.val);

    // Base Case: Left node. Check if the path equals targetsum and add the resultant array to the list.
    if(node.left == null && node.right == null) {
      if(node.val == remainingTargetSum) {
        // Create a new arraylist copy so that we don't modify it after adding.
        result.add(new ArrayList<>(pathNodes));
        pathNodes.remove(pathNodes.size()-1);

        return;
      }
    }

    dfs(node.left, pathNodes, remainingTargetSum-node.val);
    dfs(node.right, pathNodes, remainingTargetSum-node.val);

    pathNodes.remove(pathNodes.size()-1);
  }
}
