using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_of_life
{
  internal static class CellFactory
  {
    public static Cell[] CreateCells(int[] cellstates)
    {
      List<Cell> cells = new List<Cell>();
      foreach (var cell in cellstates)
      {
        if (cell == 0)
        {
          cells.Add(Cell.DeadCell);
          continue;
        }
        if (cell == 1)
        {
          cells.Add(Cell.AliveCell);
          continue;
        }

        throw new ArgumentOutOfRangeException();
      }

      return cells.ToArray();
    }
  }
}
