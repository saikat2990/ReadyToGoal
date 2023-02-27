using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class Combine
    {
        public static void combination(List<int> current, IList<IList<int>> answer, int n, int k, HashSet<List<int>> check, int initial)
        {

            if (current.Count == k)
            {
                answer.Add(new List<int>(current));
            }
            else
            {
                for (int i = initial; i <= n; i++)
                {
                    current.Add(i);
                    combination(current, answer, n, k, check, i + 1);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
    }
}
