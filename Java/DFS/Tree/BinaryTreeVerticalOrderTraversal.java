package DFS.Tree;

import DataStructures.TreeNode;

import java.util.ArrayList;
import java.util.List;

public class BinaryTreeVerticalOrderTraversal {
    // leetcode 314

    //    _3_
    //   /   \
    //  9    20     ->      [[4], [9], [3,5,2], [20], [7]]
    // / \   / \
    //4   5 2   7

    //  3
    // / \
    //9  20         ->      [[9],[3,15],[20],[7]]
    //  /  \
    // 15   7

    // Tx = O(n)
    // Sx = O(n)
    int minLevel = 0, maxLevel = 0;
    List<List<Integer>> output = new ArrayList<>();
    public List<List<Integer>> levelOrder(TreeNode root) {
        CalculateLevelMinMax(root, 0);

        for(int index=0; index<maxLevel-minLevel+1; index++) {
            output.add(new ArrayList<>());
        }

        levelOrder(root, 0-minLevel);

        return output;
    }

    private void levelOrder(TreeNode node, int level) {
        if(node == null) {
            return;
        }

        output.get(level).add(node.val);

        levelOrder(node.left, level-1);
        levelOrder(node.right, level+1);
    }

    private void CalculateLevelMinMax(TreeNode node, int level) {
        if(node == null) {
            return;
        }

        minLevel = Math.min(minLevel, level);
        maxLevel = Math.max(maxLevel, level);

        CalculateLevelMinMax(node.left, level-1);
        CalculateLevelMinMax(node.right, level+1);
    }
}
