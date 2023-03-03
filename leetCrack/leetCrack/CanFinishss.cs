using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class CanFinishss
    {
        public class GraphCLass
        {
            public int existance { get; set; }

            public List<GraphCLass> connectedList { get; set; }

            public GraphCLass()
            {
                connectedList = new List<GraphCLass>();
                existance = 0;
            }
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, GraphCLass> dict = new Dictionary<int, GraphCLass>();
            for (var i = 0; i < numCourses; i++)
            {
                dict.Add(i, new GraphCLass());
            }

            foreach (var relation in prerequisites)
            {
                GraphCLass g1 = dict[relation[1]];
                GraphCLass g0 = dict[relation[0]];
                g0.existance++;
                g1.connectedList.Add(g0);
            }

            Queue<GraphCLass> qu = new Queue<GraphCLass>();
            for (int i = 0; i < numCourses; i++)
            {
                if (dict[i].existance == 0)
                    qu.Enqueue(dict[i]);
            }

            var count = 0;
            while (qu.Count > 0)
            {
                var gh = qu.Dequeue();
                count++;
                foreach (var ch in gh.connectedList)
                {
                    ch.existance--;
                    if (ch.existance == 0)
                        qu.Enqueue(ch);
                }
            }

            if (count == numCourses) return true;
            return false;
        }
    }
}
