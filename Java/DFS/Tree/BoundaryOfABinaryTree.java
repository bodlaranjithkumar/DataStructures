package DFS.Tree;

import DataStructures.TreeNode;

import java.util.ArrayList;
import java.util.List;

public class BoundaryOfABinaryTree {
    // Leetcode 545:
    // Ref: https://www.geeksforgeeks.org/problems/boundary-traversal-of-binary-tree/1


    // Input: root[] = [1, 2, 3, 4, 5, 6, 7, N, N, 8, 9, N, N, N, N]
    // Output: [1, 2, 4, 8, 9, 6, 7, 3]

    // Input: root[] = [1, 2, N, 4, 9, 6, 5, N, 3, N, N, N, N 7, 8]
    // Output: [1, 2, 4, 6, 5, 7, 8]

    // Input: root[] = [1, N, 2, N, 3, N, 4, N, N]
    // Output: [1, 4, 3, 2]

    private List<Integer> output = new ArrayList<>();
    public List<Integer> boundaryTraversal(TreeNode node) {
        output.add(node.val);

        // Step 1: Traverse left sub-tree
        leftTreeTraversal(node.left);

        // Step 2: Traverse all leaf nodes within the left & right subtree to root
        leafNodesTraversal(node.left);
        leafNodesTraversal(node.right);

        // Step 3: Traverse right sub-tree
        rightTreeTraversal(node.right);

        return output;
    }

    private void leftTreeTraversal(TreeNode node) {
        // Base Case: Ignore null node or leaf node
        if(node == null || (node.left == null && node.right == null)) {
            return;
        }

        output.add(node.val);

        if(node.left != null) {
            leftTreeTraversal(node.left);
        } else if(node.right != null) {
            leftTreeTraversal(node.right);
        }
    }

    private void rightTreeTraversal(TreeNode node) {
        // Base Case: Ignore null node or leaf node
        if(node == null || (node.left == null && node.right == null)) {
            return;
        }

        if(node.right != null) {
            rightTreeTraversal(node.right);
        } else if(node.left != null) {
            rightTreeTraversal(node.left);
        }

        output.add(node.val);
    }

    private void leafNodesTraversal(TreeNode node) {
        if(node == null) {
            return;
        } else if(node.left == null && node.right == null) {
            output.add(node.val);
        }

        leafNodesTraversal(node.left);
        leafNodesTraversal(node.right);
    }
}
