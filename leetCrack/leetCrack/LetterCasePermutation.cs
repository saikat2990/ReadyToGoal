using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class LetterCasePermutation
    {
        public static void recursivelyCheck(string strs, List<string> answer)
        {

            var charData = strs.ToCharArray();
            for (int i = 0; i < charData.Length; i++)
            {

                if ((int)charData[i] >= 97)
                {
                    charData[i] = strs[i].ToString().ToUpper().ToCharArray()[0];
                    strs = new string(charData);
                    if (answer.Contains(strs))
                        continue;
                    answer.Add(strs);
                }
                else if ((int)charData[i] < 97 && (int)charData[i] >= 65)
                {
                    charData[i] = strs[i].ToString().ToLower().ToCharArray()[0];
                    strs = new string(charData);
                    if (answer.Contains(strs))
                        continue;
                    answer.Add(strs);
                }
                else continue;
                recursivelyCheck(strs, answer);

            }
        }

        public static IList<string> LetterCasePermutations(string s)
        {
            var answer = new List<string>();
            recursivelyCheck(s, answer);
            Console.WriteLine(answer.Count);
            foreach (var VARIABLE in answer)
            {
                Console.WriteLine(VARIABLE);
            }

            if (answer.Count == 0)
            {
                var data = new List<string>();
                data.Add(s);
                return data;
            }

            return answer;
        }
    }
}
