package DFS.Tree;

import DataStructures.TreeNode;

public class SearchInABinarySearchTree {
    // Leetcode 700: https://leetcode.com/problems/search-in-a-binary-search-tree/
    // Submission Detail: https://leetcode.com/problems/search-in-a-binary-search-tree/submissions/1673378316

    //Input: root = [4,2,7,1,3], val = 2
    //Output: [2,1,3]

    //Input: root = [4,2,7,1,3], val = 5
    //Output: []

    public TreeNode searchBST(TreeNode root, int val) {
        // Base Cases: Null Node OR  found the node
        if(root == null || root.val == val)
            return root;

        if(val < root.val) {
            return searchBST(root.left, val);
        } else {
            return searchBST(root.right, val);
        }
    }
}
