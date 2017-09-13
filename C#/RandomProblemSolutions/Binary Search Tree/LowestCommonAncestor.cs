using System;
using System.Collections.Generic;
using System.Text;

namespace RandomProblemSolutions
{
    //Example:
    //                  50
    //                 /  \
    //               25    75  
    //              / \    / \
    //            10  45 75   90
    //                   /    / \
    //                  65  80   100

    //      node1       node2       LCA
    //      50          80          50
    //      75(1st)     100         75(1st)
    //      75(2nd)     100         75(1st)
    //      75(2nd)     65          75(2nd)
    //      5           100         50

    class LowestCommonAncestor<T>
    {
        public BinaryTreeNode<T> FindLowestCommonAncestor(BinaryTreeNode<T> root, BinaryTreeNode<T> node1,
                                                    BinaryTreeNode<T> node2)
        {
            if (root == null || (root.Left == null && root.Right == null))
                throw new ArgumentException("Minimum 3 nodes are required to find LCA.");

            while (true)
            {
                if (root != node1 && root != node2)
                {
                    if ((root.Value >= node1.Value && root.Value < node2.Value)
                            || (root.Value < node1.Value && root.Value >= node2.Value))
                    {
                        return root;
                    }
                    else if (root.Value >= Math.Max(node1.Value, node2.Value))
                        root = root.Left;
                    else
                        root = root.Right;
                }

                else if (root == node1)
                {
                    return node1;
                }
                else if (root == node2)
                {
                    return node2;
                }
            }
        }
    }
}
