using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class CloneGraphs
    {
        public Node Dfs(Node node, Dictionary<int, Node> dict)
        {

            if (dict.TryGetValue(node.val, out var clone))
                return clone;
            clone = new Node(node.val);
            dict.Add(node.val, clone);
            foreach (var chNode in node.neighbors)
            {
                clone.neighbors.Add(Dfs(chNode, dict));
            }
            return clone;
        }

        public Node CloneGraph(Node node)
        {
            if (node == null) return null;
            if (node.neighbors == null || node.neighbors.Count == 0)
                return new Node(node.val);
            return Dfs(node, new Dictionary<int, Node>());
        }
    }
}
