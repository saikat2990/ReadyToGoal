using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class AttemptedCompress
    {
        public static char[] Compress(char[] chars)
        {
            Dictionary<char, int> occur = new Dictionary<char, int>();
            Dictionary<char, int> serials = new Dictionary<char, int>();
            int serialData = 1;
            foreach (char c in chars)
            {
                if (occur.TryGetValue(c, out int v))
                {
                    occur[c] = v + 1;
                }
                else
                {
                    occur.Add(c, 1);
                }

                if (!serials.TryGetValue(c, out int vv))
                {
                    serials.Add(c, serialData);
                    serialData++;
                }
            }

            var finalData = new List<characterData>();
            var totalString = "";
            foreach (var V in occur.Keys)
            {

                var data = new characterData()
                {
                    ch = V,
                    serial = serialData,
                    totalOccur = occur[V]
                };
                finalData.Add(data);
                if (occur[V] == 1)
                {
                    totalString += V;
                }
                else
                {
                    totalString += (V + occur[V].ToString());
                }

            }

            totalString = "";
            var sortedData = finalData.OrderBy(x => x.serial);
            foreach (var sortD in sortedData)
            {

                if (sortD.totalOccur == 1) totalString += sortD.ch;
                else totalString += (sortD.ch + sortD.totalOccur.ToString());

            }

            var result = totalString.ToCharArray();
            foreach (var sortD in result)
            {
                Console.WriteLine(sortD);
            }
            return result;
        }

    }
}
