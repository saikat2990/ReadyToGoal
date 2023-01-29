using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCrack
{
    public class MaxAreaOfIslands
    {
        public static int exploreIsland(int[][] grid, int row, int col, int tolRow, int tolCol, int found)
        {
            if (grid[row][col] == 0)
            {
                return found - 1;
            }
            grid[row][col] = 0;

            if (row + 1 < tolRow)
                found = exploreIsland(grid, row + 1, col, tolRow, tolCol, found + 1);
            if (col + 1 < tolCol)
                found = exploreIsland(grid, row, col + 1, tolRow, tolCol, found + 1);
            if (row - 1 >= 0)
                found = exploreIsland(grid, row - 1, col, tolRow, tolCol, found + 1);
            if (col - 1 >= 0)
                found = exploreIsland(grid, row, col - 1, tolRow, tolCol, found + 1);
            return found;
        }

        public static int MaxAreaOfIsland(int[][] grid)
        {
            var row = grid.Length;
            if (row == 0) return 0;
            var col = grid[0].Length;
            var foundList = new List<int>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        foundList.Add(exploreIsland(grid, i, j, row, col, 1));
                    }
                }
            }
            foundList.Sort();
            if (foundList.Count > 0)
                return foundList[foundList.Count - 1];
            else return 0;
        }

    }
}
