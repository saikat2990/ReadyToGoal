using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class FindOrders
    {
        public class GraphCLass
        {
            public int existance { get; set; }
            public int val { get; set; }
            public List<GraphCLass> connectedList { get; set; }

            public GraphCLass(int val)
            {
                connectedList = new List<GraphCLass>();
                existance = 0;
                this.val = val;
            }
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var data = new List<int>();
            Dictionary<int, GraphCLass> dict = new Dictionary<int, GraphCLass>();
            for (var i = 0; i < numCourses; i++)
            {
                dict.Add(i, new GraphCLass(i));
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
                {
                    qu.Enqueue(dict[i]);
                    data.Add(i);
                }


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
                    {
                        qu.Enqueue(ch);
                        data.Add(ch.val);
                    }


                }
            }

            if (count == numCourses)
            {
                return data.ToArray();
            }
            var final = new List<int>() { };

            return final.ToArray();

        }

    }
}
