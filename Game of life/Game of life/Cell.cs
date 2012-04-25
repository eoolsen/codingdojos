using System.Linq;

namespace Game_of_life
{
  internal class Cell
  {
    private readonly CellState cellstate;

    private Cell(CellState cellstate)
    {
      this.cellstate = cellstate;
    }

    public static Cell AliveCell { get { return new Cell(CellState.Alive); } }
    public static Cell DeadCell { get { return new Cell(CellState.Dead); } }

    public Cell Evaluate(Cell[] neighbors)
    {
      int sumOfNeighbors = neighbors.Sum(c => c.Value);
      switch (cellstate)
      {
        case CellState.Alive:
          if (sumOfNeighbors < 2)
            return DeadCell;

          if (sumOfNeighbors < 4)
            return AliveCell;
          
          return DeadCell;

        case CellState.Dead:
          return sumOfNeighbors == 3 ? AliveCell : DeadCell; 
      }

      return null;
    }

    public int Value { get { return Alive ? 1 : 0; } }
    public bool Alive { get { return cellstate == CellState.Alive; } }

    public override string ToString()
    {
      return Alive ? "*" : " ";
    }
    public override bool Equals (object obj)
    {
      if (obj == null || GetType() != obj.GetType())
      {
        return false;
      }

      return this.cellstate == ((Cell)obj).cellstate;  
    }
    public override int GetHashCode()
    {
      return this.cellstate.GetHashCode();
    }
  }
}
