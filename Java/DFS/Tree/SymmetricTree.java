package DFS.Tree;

import DataStructures.TreeNode;

public class SymmetricTree {
    // Leetcode 101: https://leetcode.com/problems/symmetric-tree/description/
    // Submission Detail: https://leetcode.com/problems/symmetric-tree/submissions/1675598328

    //Input: root = [1,2,2,3,4,4,3]
    //Output: true

    //Input: root = [1,2,2,null,3,null,3]
    //Output: false

    public boolean isSymmetric(TreeNode root) {
        return isSymmetric(root.left, root.right);
    }

    private boolean isSymmetric(TreeNode node1, TreeNode node2) {
        // Base Case: Could be leaf node
        if(node1 == null && node2 == null)
            return true;

        // Base Case: nodes are not symmetric
        if(node1 == null || node2 == null || node1.val != node2.val)
            return false;

        return isSymmetric(node1.left, node2.right) && isSymmetric(node1.right, node2.left);
    }
}
