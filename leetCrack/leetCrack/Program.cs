﻿using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace leetCrack
{
    public class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static List<int> getAllValues(TreeNode node,List<int> allValues)
        {
            allValues.Add(node.val);
            if (node.left != null)
                allValues = getAllValues(node.left, allValues);
            if (node.right != null)
                allValues = getAllValues(node.right, allValues);
            return allValues;
        }

        public static bool isItaddableOrNot(TreeNode node,int val,bool isBigCheck)
        {
            List<int> allVals = new List<int>();
            
            
            if (isBigCheck )
            {
                if (node.right != null)
                {
                    allVals = getAllValues(node.right, allVals);
                    foreach (var childVal in allVals)
                    {
                        if (childVal < val) return false;
                    }
                }

               
            }
            else{
                if(node.left != null)
                {
                    allVals = getAllValues(node.left, allVals);
                    foreach (var childVal in allVals)
                    {
                        if (childVal > val) return false;
                    }
                }
              
            }
            return true;
        }

        public static bool TraverseData(TreeNode node)
        {

            if (node.left != null)
            {
                if (!isItaddableOrNot(node,node.val,false)) return false;
                var tag = TraverseData(node.left);
                if (!tag)
                    return false;
            }
           
            if (node.right != null)
            {
                if (!isItaddableOrNot(node, node.val, true)) return false;
                var tag =  TraverseData(node.right);
                if (!tag)
                    return false;
            }
            return true;
        }

        public static bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return false;
            
            return TraverseData(root);
        }

        public static void Main(string[] args)
        {
            var root = new TreeNode(5);
            var n1 = new TreeNode(1);
            var n2 = new TreeNode(4);
            var n3 = new TreeNode(3);
            var n4 = new TreeNode(6);

            // setup children
            root.left = n1;
            root.right = n2;
            n2.left = n3;
            n2.right = n4;

            var data = IsValidBST(root);
            Console.WriteLine(data);
        }
    }
}