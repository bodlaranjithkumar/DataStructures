package DFS.Tree;

import DataStructures.TreeNode;

public class LowestCommonAncestorOfABinaryTree {
    // Leetcode 236: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
    // Submission Detail: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/submissions/1673183795

    //Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
    //Output: 3
    //Explanation: The LCA of nodes 5 and 1 is 3.

    //Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
    //Output: 5
    //Explanation: The LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.

    //Input: root = [1,2], p = 1, q = 2
    //Output: 1

    // Tx = O(n)
    // Sx = O(n) for the call stack
    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // Base Condition: Null Node. Return Null.
        if(root == null)
            return null;

        // Base Condition: If either of the nodes p OR q is found, return that node.
        if(root == p || root == q)
            return root;

        TreeNode left = lowestCommonAncestor(root.left, p, q);
        TreeNode right = lowestCommonAncestor(root.right, p, q);

        // Could be a leaf node or subtree that doesn't have p or q as child.
        if(left == null && right == null)
            return null;

        if(left != null && right != null)
            return root; // Found the LCA

        return left == null ? right : left; // LCA is either of left OR right. This is the case when LCA is not the root node.
    }
}
