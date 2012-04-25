using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_of_life
{
  public class GameOfLife
  {
    List<Cell[]> gameState;
    private readonly uint dimension;

    public GameOfLife(uint dimension)
    {
      if (dimension < 2)
        throw new Exception("Små game of life er ikke tilladt");

      this.dimension = dimension;
      gameState = new List<Cell[]>();
      for (int i = 0; i < dimension; i++)
      {
        gameState.Add(new Cell[dimension]);
      }
    }

    public void PopulateRow(int ydimension, int[] row)
    {
      gameState[ydimension - 1] = CellFactory.CreateCells(row);
    }

    public void EvaluateLife()
    {
      var newGameState = new List<Cell[]>();
      for (int i = 0; i < dimension; i++) //iterer op ad y aksen
      {
        if (i == 0)
          newGameState.Add(EvaluateBottomLine());
      
        else if (i == dimension - 1)
          newGameState.Add(EvaluateTopLine());
      
        else
          newGameState.Add(EvaluateMiddelLines(i));
      }

      gameState = newGameState;
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();

      string seperator = MakeSeperator();
      sb.AppendLine(seperator);
      for (int i = gameState.Count - 1; i >= 0; i--)
      {
        var line = gameState[i];
        sb.AppendLine(line.Select(j => j.ToString()).Aggregate((s, t) => string.Format("{0}{1}", s, t)));
      }

      sb.AppendLine(seperator);

      return sb.ToString();
    }

    internal Cell[] GetHorizontalLine(uint ycoordinate)
    {
      if (ycoordinate > dimension)
        throw new Exception();
      return gameState[(int)ycoordinate - 1];
    }

    #region evaluate lines

    private Cell[] EvaluateTopLine()
    {
      Cell[] newline = new Cell[dimension];

      Cell[] currentLine = gameState[((int)dimension) - 1];
      Cell[] secondFromTopLine = gameState[((int)dimension) - 2];
      for (int j = 0; j < dimension; j++) //iterer ud af x aksen
      {
        Cell origValue = currentLine[j];
        //første element i nederste række evalueres
        if (j == 0)
        {
          newline[j] = origValue.Evaluate(new Cell[]{secondFromTopLine[0], secondFromTopLine[1], currentLine[1]});
        }

        //sidste element i nederste række evalueres
        else if (j == dimension - 1)
        {
          newline[j] = origValue.Evaluate(new Cell[]{ currentLine[dimension - 2], secondFromTopLine[dimension - 2], secondFromTopLine[dimension - 1]});
        }

        //evaluere resten
        else
        {
          newline[j] = origValue.Evaluate(new Cell[]{currentLine[j - 1], currentLine[j + 1], secondFromTopLine[j - 1], secondFromTopLine[j], secondFromTopLine[j + 1]});
        }
      }
      return newline;
    }

    private Cell[] EvaluateMiddelLines(int rowIndex)
    {
      Cell[] newline = new Cell[dimension];
      Cell[] currentLine = gameState[rowIndex];
      Cell[] lineBelow = gameState[rowIndex - 1];
      Cell[] lineAbove = gameState[rowIndex + 1];
      for (int j = 0; j < dimension; j++) //iterer ud af x aksen
      {
        Cell origValue = currentLine[j];

        //første element i rækken evalueres
        if (j == 0)
        {
          newline[0] = origValue.Evaluate(new Cell[]{lineBelow[0], lineBelow[1], currentLine[1], lineAbove[1], lineAbove[0]});
        }

        //sidste element i rækken evalueres
        else if (j == dimension - 1)
        {
          newline[dimension - 1] = origValue.Evaluate(new Cell[]{lineBelow[j], lineBelow[j - 1], currentLine[j - 1], lineAbove[j - 1], lineAbove[j]});
        }

        //evaluere resten
        else
        {
          newline[j] = origValue.Evaluate(new Cell[]{lineBelow[j - 1], lineBelow[j], lineBelow[j + 1], currentLine[j + 1], lineAbove[j + 1], lineAbove[j], lineAbove[j - 1], currentLine[j - 1]});
        }
      }
      return newline;
    }

    private Cell[] EvaluateBottomLine()
    {
      Cell[] newline = new Cell[dimension];
      Cell[] currentLine = gameState[0];
      Cell[] secondLine = gameState[1];

      for (int j = 0; j < dimension; j++) //iterer ud af x aksen
      {
        Cell origValue = currentLine[j];

        //første element i nederste række evalueres
        if (j == 0)
        {
          newline[j] = origValue.Evaluate(new Cell[]{currentLine[0], secondLine[1], currentLine[1]});
        }

        //sidste element i nederste række evalueres
        else if (j == dimension - 1)
        {
          newline[j] = origValue.Evaluate(new Cell[]{secondLine[dimension - 1], secondLine[dimension - 2], currentLine[dimension - 2]});
        }

        //evaluere resten
        else
        {
          newline[j] = origValue.Evaluate(new Cell[]{currentLine[j - 1], currentLine[j + 1], secondLine[j - 1], secondLine[j], secondLine[j + 1]});
        }
      }
      return newline;
    }

    #endregion

    private string MakeSeperator()
    {
      string seperator = "";
      for (int i = 0; i < dimension * 2; i++)
      {
        seperator += "-";
      }
      return seperator;
    }
  }
}