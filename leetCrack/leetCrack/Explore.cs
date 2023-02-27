using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    internal class Explores
    {
        public void Explore(FindWords.Node node, FindWords.Node rightNode)
        {
            if (node == null)
            {
                return;
            }
            node.next = rightNode;
            if (node.right != null)
            {
                Explore(node.left, node.right);
            }
            else
            {
                Explore(node.left, null);
            }
            if (node.next != null)
            {
                Explore(node.right, node.next.left);
            }
            else
            {
                Explore(node.right, null);
            }
        }

        public FindWords.Node Connect(FindWords.Node root)
        {
            if (root == null) return root;
            Explore(root.left, root.right);
            Explore(root.right, null);
            return root;

        }
    }
}
