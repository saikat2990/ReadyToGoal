using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class FindWords
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        public static IList<string> FullJustify(string[] words, int maxWidth)
        {
            IList<string> answerLines = new List<string>();
            int i = 0;

            while (i < words.Length)
            {
                int lineLength = 0;
                var j = i;
                while (j < words.Length && (lineLength + words[j].Length) <= maxWidth)
                {
                    lineLength += words[j].Length + 1;
                    j++;
                }

                var wordsInLine = j - i;
                if (wordsInLine == 1 || words.Length == j)
                {
                    var lastLine = words[i++] + " ";
                    while (j > i)
                    {
                        lastLine += words[i++] + " ";
                    }

                    var s = maxWidth - lastLine.Length;
                    for (int k = 0; k < s; k++)
                    {
                        lastLine += " ";
                    }

                    answerLines.Add(lastLine);
                    continue;
                }
                lineLength--;
                var totalRemainSpaces = maxWidth - lineLength;
                var spacesPerWords = totalRemainSpaces / (wordsInLine - 1);
                var remainspaces = totalRemainSpaces % (wordsInLine - 1);
                var line = words[i++];
                while (j > i && line.Length <= maxWidth)
                {

                    for (int k = 0; k < spacesPerWords + 1; k++)
                    {
                        line += " ";
                    }
                    if (remainspaces >= 0)
                    {
                        line += " ";
                        remainspaces--;
                    }
                    line += words[i++];
                }
                answerLines.Add(line);
            }

            return answerLines;
        }

        static IDictionary<int, IList<string>> dp;

        //public static IList<string> FindWordss(char[][] board, string[] words)
        //{
        //    int m = board.Length;
        //    int n = board[0].Length;
        //    List<string> res = new();

        //    //build trie
        //    Node root = new();
        //    foreach (var word in words)
        //    {
        //        Node node = root;
        //        foreach (var c in word)
        //        {
        //            if (node.Next[c] == null) node.Next[c] = new Node();
        //            node = node.Next[c];
        //        }

        //        node.Word = word;
        //    }

        //    //do dfs
        //    for (int i = 0; i < m; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            Dfs(i, j, root);
        //        }
        //    }

        //    return res;

        //    void Dfs(int i, int j, Node node)
        //    {


        //        if (i < 0 || j < 0 || i == m || j == n) return;
        //        char c = board[i][j];
        //        if (c == '/' || node.Next[c] is null) return;
        //        node = node.Next[c];

        //        if (node.Word is not null)
        //        {
        //            res.Add(node.Word);
        //            node.Word = null;
        //        }

        //        board[i][j] = '/';
        //        Dfs(i - 1, j, node);
        //        Dfs(i, j - 1, node);
        //        Dfs(i + 1, j, node);
        //        Dfs(i, j + 1, node);
        //        board[i][j] = c;
        //    }
        //}
        public static void Mains(string[] args)
        {
            var words = new string[] { "oath", "pea", "eat", "rain" };
            //FullJustify(words, 16);
            //WordBreak("catsanddog", new List<string>() { "cat", "cats", "and", "sand", "dog" });
            var data = new char[][] { new char[] { 'o', 'a', 'a', 'n' }, new char[] { 'e', 't', 'a', 'e' }, new char[] { 'i', 'h', 'k', 'r' }, new char[] { 'i', 'f', 'l', 'v' } };
            //var words = new string[]{}
            //FindWordss(data, words);
            //FindWordss(data, words);
        }

    }
}
