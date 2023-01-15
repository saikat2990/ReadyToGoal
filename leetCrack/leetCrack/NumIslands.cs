using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    internal class NumIslands
    {
        public static void DFS(char[][] grid, int rowIndex, int colIndex, int totalRow, int totalCol, int count)
        {
            if (grid[rowIndex][colIndex] != '1')
                return;

            grid[rowIndex][colIndex] = 'X';
            if (colIndex + 1 < totalCol)
                DFS(grid, rowIndex, colIndex + 1, totalRow, totalCol, count);
            if (rowIndex + 1 < totalRow)
                DFS(grid, rowIndex + 1, colIndex, totalRow, totalCol, count);
            if (colIndex > 0)
                DFS(grid, rowIndex, colIndex - 1, totalRow, totalCol, count);
            if (rowIndex > 0)
                DFS(grid, rowIndex - 1, colIndex, totalRow, totalCol, count);

        }

        public static int NumIslandss(char[][] grid)
        {
            int row = grid.GetLength(0);
            int col = grid[0].Length;
            int count = 0;
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    if (grid[i][j] == '1')
                        DFS(grid, i, j, row, col, count++);
                }
            }


            return count;
        }
    }
}
