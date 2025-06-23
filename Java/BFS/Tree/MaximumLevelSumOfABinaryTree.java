package BFS.Tree;

import DataStructures.TreeNode;

import java.util.LinkedList;
import java.util.Queue;

public class MaximumLevelSumOfABinaryTree {
    // Leetcode 1161: https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/description/
    // Submission Detail: https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/submissions/1673348678

    //Input: root = [1,7,0,7,-8,null,null]
    //Output: 2
    //Explanation:
    //Level 1 sum = 1.
    //Level 2 sum = 7 + 0 = 7.
    //Level 3 sum = 7 + -8 = -1.
    //So we return the level with the maximum sum which is level 2.

    //Input: root = [989,null,10250,98693,-89388,null,null,null,-32127]
    //Output: 2

    public int maxLevelSum(TreeNode root) {
        Queue<TreeNode> nodes = new LinkedList<>();
        nodes.offer(root);

        int maxSum = Integer.MIN_VALUE, maxSumLevel = 0, currentLevel = 1;

        while(!nodes.isEmpty()) {
            int currentLevelSize = nodes.size();
            int currentSum = 0;

            while(currentLevelSize > 0) {
                TreeNode node = nodes.poll();
                currentSum += node.val;

                if(currentLevelSize == 1) {
                    if(currentSum > maxSum) {
                        maxSum = currentSum;
                        maxSumLevel =  currentLevel;
                    }
                }

                if(node.left != null)
                    nodes.offer(node.left);
                if(node.right != null)
                    nodes.offer(node.right);

                currentLevelSize--;
            }

            currentLevel++;
        }

        return maxSumLevel;
    }
}
