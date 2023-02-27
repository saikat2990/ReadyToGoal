using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class OrangesRotting
    {
        private static int OrangesRottings(int[][] grid)
        {
            Queue<int[]> contains2 = new Queue<int[]>();
            int freshItem = 0;
            var row = grid.Length;
            var col = grid[0].Length;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == 2) contains2.Enqueue(new int[] { i, j });
                    else if (grid[i][j] == 1) freshItem++;
                }
            }

            int rottingNum = 0;
            while (contains2.Any())
            {
                var count = contains2.Count;
                while (count > 0)
                {
                    var enqueData = contains2.Dequeue();
                    var findRowNum = enqueData[0];
                    var findColNum = enqueData[1];

                    if (findRowNum + 1 < row && grid[findRowNum + 1][findColNum] == 1)
                    {
                        freshItem--;
                        contains2.Enqueue(new int[] { findRowNum + 1, findColNum });
                        grid[findRowNum + 1][findColNum] = 2;

                    }
                    if (findRowNum - 1 >= 0 && grid[findRowNum - 1][findColNum] == 1)
                    {
                        freshItem--;
                        contains2.Enqueue(new int[] { findRowNum - 1, findColNum });
                        grid[findRowNum - 1][findColNum] = 2;

                    }
                    if (findColNum + 1 < col && grid[findRowNum][findColNum + 1] == 1)
                    {
                        freshItem--;
                        contains2.Enqueue(new int[] { findRowNum, findColNum + 1 });
                        grid[findRowNum][findColNum + 1] = 2;

                    }
                    if (findColNum - 1 >= 0 && grid[findRowNum][findColNum - 1] == 1)
                    {
                        freshItem--;
                        contains2.Enqueue(new int[] { findRowNum, findColNum - 1 });
                        grid[findRowNum][findColNum - 1] = 2;

                    }

                    count--;
                }

                rottingNum++;

            }

            if (freshItem > 0) return -1;
            return rottingNum;
        }

    }
}
