using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_of_life;
using System.Threading;

namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      //en glider
      var firstrow =  new[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
      var secondrow = new[] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 };
      var thirdrow =  new[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
      var nullrow =   new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

      
      GameOfLife game = new GameOfLife(10);
      game.PopulateRow(10, firstrow);
      game.PopulateRow(9, secondrow);
      game.PopulateRow(8, thirdrow);
      game.PopulateRow(7, nullrow);
      game.PopulateRow(6, nullrow);
      game.PopulateRow(5, nullrow);
      game.PopulateRow(4, nullrow);
      game.PopulateRow(3, nullrow);
      game.PopulateRow(2, nullrow);
      game.PopulateRow(1, nullrow);

      Console.WriteLine(game.ToString());

      while (true)
      {
        Thread.Sleep(1000);
        game.EvaluateLife();

        Console.WriteLine(game.ToString());
      }
    }
  }
}
