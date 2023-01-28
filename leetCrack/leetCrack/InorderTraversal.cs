using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace leetCrack
{
    public class Programs
    {


        public static void TraverseData(TreeNode node, List<int> answer)
        {
            if (node.left != null)
            {
                TraverseData(node.left, answer);
                answer.Add(node.val);
            }
            else
            {
                answer.Add(node.val);
            }

            if (node.right != null)
            {
                TraverseData(node.right, answer);
            }

        }

        public static IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
                return new List<int>() { };
            var answer = new List<int>();
            TraverseData(root, answer);
            return answer;
        }

        public static void Main1(string[] args)
        {
            var root = new TreeNode('A');
            var n1 = new TreeNode('B');
            var n2 = new TreeNode('C');
            var n3 = new TreeNode('D');
            var n4 = new TreeNode('E');

            // setup children
            root.left = n1;
            root.right = n2;
            n1.left = n3;
            n1.right = n4;

            var data = InorderTraversal(root);
            Console.WriteLine(data);
        }
    }
}