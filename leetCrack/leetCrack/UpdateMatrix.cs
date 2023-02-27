using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class UpdateMatrix
    {
        public static int[][] UpdateMatrixs(int[][] mat)
        {
            int ROW = mat.Length;
            int COL = mat[0].Length;
            var answer = new int[ROW][];
            Queue<(int, int, int)> q = new Queue<(int, int, int)>();

            for (int i = 0; i < ROW; i++)
            {
                answer[i] = new int[COL];
                for (int j = 0; j < COL; j++)
                {
                    if (mat[i][j] == 0) q.Enqueue((i, j, 0));
                    else answer[i][j] = int.MaxValue;
                }

            }

            (int, int)[] around = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            while (q.Count > 0)
            {
                var data = q.Dequeue();
                var distance = data.Item3;
                distance++;
                foreach ((var rowX, var colY) in around)
                {
                    var newRowX = rowX + data.Item1;
                    var newColY = colY + data.Item2;
                    if (newRowX >= 0 && newRowX < ROW && newColY >= 0 && newColY < COL &&
                        distance < answer[newRowX][newColY])
                    {
                        answer[newRowX][newColY] = distance;
                        q.Enqueue((newRowX, newColY, distance));
                    }

                }
            }
            return answer;
        }

    }
}
