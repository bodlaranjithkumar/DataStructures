using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;

namespace LeetcodeSolutions.BinaryTree
{
    class BinaryTreeNodeWithParent
    {
        public BinaryTreeNode Node { get; set; }
        public BinaryTreeNodeWithParent Parent { get; set; }
    }

    //      _______3______
    //     /              \
    //  ___5__          ___1__
    // /      \        /      \
    // 6      _2       0       8
    //       /  \
    //       7   4

    // Tx = O(h)
    // Sx = O(h) for visited ancestor nodes of p.
    // Assumption: Nodes p, q exists in the tree.
    class LowestCommontAncestorOfBinaryTreeWithParentPointer
    {
        // Method1: Using hashset
        public BinaryTreeNodeWithParent LowestCommonAncestor(BinaryTreeNodeWithParent root,
                BinaryTreeNodeWithParent p, BinaryTreeNodeWithParent q)
        {
            HashSet<BinaryTreeNodeWithParent> visitedNodes = new HashSet<BinaryTreeNodeWithParent>();

            while (p != null)
            {
                visitedNodes.Add(p);
                p = p.Parent;
            }

            while (q != null)
            {
                if (visitedNodes.Contains(q))
                    return q;

                q = q.Parent;
            }

            return null;
        }

        // Method2: Calculate depth
        // Tx = O(h)
        // Sx = O(1)        
        public BinaryTreeNodeWithParent LowestCommonAncestorUsingDepth(BinaryTreeNodeWithParent root,
                BinaryTreeNodeWithParent p, BinaryTreeNodeWithParent q)
        {
            int p_depth = Depth(p);
            int q_depth = Depth(q);

            int diff_depth = p_depth - q_depth;

            // q is located lower in the tree than p;
            if(diff_depth < 0)
            {
                while(diff_depth < 0)
                {
                    q = q.Parent;
                    diff_depth++;
                }
            }
            else
            {
                while (diff_depth > 0)
                {
                    p = p.Parent;
                    diff_depth--;
                }
            }

            while(p != null && q != null)
            {
                if (p == q)
                    return p;

                p = p.Parent;
                q = q.Parent;
            }

            return null;
        }

        private int Depth(BinaryTreeNodeWithParent node)
        {
            int depth = 0;

            while (node != null)
            {
                depth++;
                node = node.Parent;
            }

            return depth;
        }
    }
}
