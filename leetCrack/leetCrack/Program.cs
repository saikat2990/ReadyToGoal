using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace leetCrack
{
    public class Program
    {
       

        public static List<int> getAllValues(TreeNode node,List<int> allValues)
        {
            allValues.Add(node.val);
            if (node.left != null)
                allValues = getAllValues(node.left, allValues);
            if (node.right != null)
                allValues = getAllValues(node.right, allValues);
            return allValues;
        }

        public static void isItaddableOrNot(TreeNode node,int val,bool isBigCheck, List<int> changeList)
        {
            List<int> allVals = new List<int>();
            
            
            if (isBigCheck )
            {
                if (node.right != null)
                {
                    allVals = getAllValues(node.right, allVals);
                    foreach (var childVal in allVals)
                    {
                        if (childVal <= val) changeList.Add(childVal);
                    }
                }

               
            }
            else{
                if(node.left != null)
                {
                    allVals = getAllValues(node.left, allVals);
                    foreach (var childVal in allVals)
                    {
                        if (childVal > val) changeList.Add(childVal);
                    }
                }
              
            }
           
        }

        public static (int,int) TraverseData(TreeNode node, List<int> changeList)
        {
            
            if (node.left != null)
            {
                isItaddableOrNot(node, node.val, false, changeList);
                TraverseData(node.left, changeList);
            }
           
            if (node.right != null)
            {
                isItaddableOrNot(node, node.val, true, changeList);
                TraverseData(node.right, changeList);

            }
            if (changeList.Count > 0)
                return changeList.Count > 1 ? (changeList[0], changeList[1]) : (node.val, changeList[0]);
            return (-1, -1);
        }

        private static void interChangeValue(TreeNode node,int parent,int child)
        {
            Console.WriteLine(parent+" "+child+" "+node?.val);
            if (node.val == parent)
            {
                node.val = child;
            }
            else if (node.val == child)
            {
                node.val = parent;
            }
            if(node.left!=null)interChangeValue(node.left,parent,child);
            if(node.right!=null)interChangeValue(node.right,parent,child);
        }

        public static void IsValidBstData(TreeNode root)
        {

            List<int> changeList = new List<int>();
            var data = TraverseData(root, changeList);
          if (data.Item1 != -1 || data.Item2 != -1)
              interChangeValue(root, data.Item1, data.Item2);
        }

        public static void Main(string[] args)
        {
            var root = new TreeNode(2);
            var n1 = new TreeNode(3);
            var n2 = new TreeNode(1);
            //var n3 = new TreeNode(2);
           // var n4 = new TreeNode(6);

            // setup children
            root.left = n1;
            root.right = n2;
            //n2.left = n3;
            //n2.right = n4;

            IsValidBstData(root);

            IsValidBSTCHeck.IsValidBST2(root);
            Console.WriteLine();
        }
    }
}