using System;
using System.Text;
using NUnit.Framework;

namespace Game_of_life
{
  [TestFixture]
  public class TestGameOfLife
  {
    [Test]
    public void TestCreation()
    {
      new GameOfLife(4);
    }

    [Test]
    [ExpectedException(typeof(Exception))]
    public void TestHorizontalLine()
    {
      var g = new GameOfLife(4);
      g.GetHorizontalLine(7);
    }

    [Test]
    [ExpectedException(typeof(Exception))]
    public void TestIllegalCreation()
    {
      new GameOfLife(0);
    }

    [Test]
    public void TestPopulation()
    {
      GameOfLife g = new GameOfLife(3);
      g.PopulateRow(1, new[] { 0, 1, 1 });
      g.PopulateRow(2, new[] { 0, 0, 1 });
      g.PopulateRow(3, new[] { 0, 1, 1 });

      Assert.AreEqual(CellFactory.CreateCells(new[] { 0, 1, 1 }), g.GetHorizontalLine(3));
    }

    [Test]
    public void TestTostring()
    {
      GameOfLife g = new GameOfLife(3);
      g.PopulateRow(1, new[] { 0, 1, 1 });
      g.PopulateRow(2, new[] { 0, 0, 1 });
      g.PopulateRow(3, new[] { 0, 1, 1 });

      StringBuilder result = new StringBuilder();
      result.AppendLine("------");
      result.AppendLine(" **");
      result.AppendLine("  *");
      result.AppendLine(" **");
      result.AppendLine("------");
      
      Assert.AreEqual(result.ToString(), g.ToString());
    }

    [Test]
    public void TestTostringLength()
    {
      GameOfLife g = new GameOfLife(2);
      g.PopulateRow(2, new[] { 0, 0 });
      g.PopulateRow(1, new[] { 0, 1 });

      StringBuilder expectedResult = new StringBuilder();
      expectedResult.AppendLine("----");
      expectedResult.AppendLine("  ");
      expectedResult.AppendLine(" *");
      expectedResult.AppendLine("----");
      Assert.AreEqual(expectedResult.ToString(), g.ToString());

    }

    [Test]
    public void TestEvaluation1()
    {
      GameOfLife g = new GameOfLife(7);

      g.PopulateRow(7, new[] { 0, 1, 1, 1, 1, 1, 1 });
      g.PopulateRow(6, new[] { 0, 0, 1, 0, 1, 0, 1 });
      g.PopulateRow(5, new[] { 0, 1, 1, 1, 1, 0, 0 });
      g.PopulateRow(4, new[] { 0, 1, 1, 0, 0, 1, 1 });
      g.PopulateRow(3, new[] { 0, 0, 1, 1, 1, 0, 0 });
      g.PopulateRow(2, new[] { 0, 1, 1, 0, 0, 1, 1 });
      g.PopulateRow(1, new[] { 0, 1, 1, 1, 1, 1, 0 });

      g.EvaluateLife();
      Assert.AreEqual(CellFactory.CreateCells(new[] { 0, 1, 1, 0, 1, 0, 1 }), g.GetHorizontalLine(7), "row 7");//ok
      Assert.AreEqual(CellFactory.CreateCells(new[] { 0, 0, 0, 0, 0, 0, 1 }), g.GetHorizontalLine(6), "row 6"); //ok
      Assert.AreEqual(CellFactory.CreateCells(new[] { 0, 0, 0, 0, 1, 0, 1 }), g.GetHorizontalLine(5), "row 5");//ok
      Assert.AreEqual(CellFactory.CreateCells(new[] { 0, 0, 0, 0, 0, 1, 0 }), g.GetHorizontalLine(4), "row 4");//ok
      Assert.AreEqual(CellFactory.CreateCells(new[] { 0, 0, 0, 0, 1, 0, 0 }), g.GetHorizontalLine(3), "row 3");//ok
      Assert.AreEqual(CellFactory.CreateCells(new[] { 0, 0, 0, 0, 0, 0, 1 }), g.GetHorizontalLine(2), "row 2"); //ok
      Assert.AreEqual(CellFactory.CreateCells(new[] { 0, 1, 0, 1, 1, 1, 1 }), g.GetHorizontalLine(1), "row 1"); //ok
    }

    [Test]
    public void TestEvaluation()
    {
      GameOfLife g = new GameOfLife(3);
      g.PopulateRow(1, new[] {0, 1, 1});
      g.PopulateRow(2, new[] {0, 0, 1});
      g.PopulateRow(3, new[] {0, 1, 1});

      g.EvaluateLife();
      Assert.AreEqual(CellFactory.CreateCells(new[] {0, 1, 1}), g.GetHorizontalLine(3));
      Assert.AreEqual(CellFactory.CreateCells(new[] {0, 0, 0}), g.GetHorizontalLine(2));
      Assert.AreEqual(CellFactory.CreateCells(new[] {0, 1, 1}), g.GetHorizontalLine(1));
    }
  }
}