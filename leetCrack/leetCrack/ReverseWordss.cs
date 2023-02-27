using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class ReverseWordss
    {
        public static string ReverseWords(string s)
        {
            var str = string.Join(" ", s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            List<string> data = str.Trim().Split(" ").Reverse().ToList();
            var result = string.Join(" ", data);
            return result;
        }
    }
}
