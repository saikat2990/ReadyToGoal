using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class Permutations
    {
        public void permutations(IList<IList<int>> answer, List<int> current, int[] nums)
        {


            if (current.Count == nums.Length)
            {
                int[] array = new int[nums.Length];
                current.CopyTo(array, 0);
                answer.Add(array.ToList());

                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (current.Contains(nums[i])) continue;
                current.Add(nums[i]);
                permutations(answer, current, nums);
                current.RemoveAt(current.Count - 1);

            }
        }

        public IList<IList<int>> permute(int[] nums)
        {
            IList<IList<int>> answer = new List<IList<int>>();

            List<int> current = new List<int>();
            permutations(answer, current, nums);


            return answer;
        }
    }

    
}
