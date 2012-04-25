using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Game_of_life
{
  [TestFixture]
  public class TestCell
  {
    static readonly Cell[] sum1 = new[] { Cell.AliveCell, Cell.DeadCell, Cell.DeadCell, Cell.DeadCell, Cell.DeadCell };
    static readonly Cell[] sum2 = new[] { Cell.AliveCell, Cell.AliveCell, Cell.DeadCell, Cell.DeadCell, Cell.DeadCell };
    static readonly Cell[] sum3 = new[] { Cell.AliveCell, Cell.AliveCell, Cell.AliveCell, Cell.DeadCell, Cell.DeadCell };
    static readonly Cell[] sum4 = new[] { Cell.AliveCell, Cell.AliveCell, Cell.AliveCell, Cell.AliveCell, Cell.DeadCell };

    [Test]
    public void TestEvaluattionOfAliveCell()
    {
      var c = Cell.AliveCell;
      var newcell = c.Evaluate(sum1);
      Assert.IsFalse(newcell.Alive);

      var newcell1 = c.Evaluate(sum2);
      Assert.IsTrue(newcell1.Alive);

      var newcell2 = c.Evaluate(sum3);
      Assert.IsTrue(newcell2.Alive);

      var newcell3 = c.Evaluate(sum4);
      Assert.IsFalse(newcell3.Alive);
    }

    [Test]
    public void TestEvaluattionOfDeadCell()
    {
      var c = Cell.DeadCell;
      var newcell = c.Evaluate(sum1);
      Assert.IsFalse(newcell.Alive);

      var newcell1 = c.Evaluate(sum2);
      Assert.IsFalse(newcell1.Alive);

      var newcell2 = c.Evaluate(sum3);
      Assert.IsTrue(newcell2.Alive);

      var newcell3 = c.Evaluate(sum4);
      Assert.IsFalse(newcell3.Alive);
    }

    [Test]
    public void TestCreation()
    {
      var c = Cell.AliveCell;
      var d = Cell.DeadCell;
    }
 
    [Test]
    public void TestToString()
    {
      var c = Cell.AliveCell;
      Assert.AreEqual("*", c.ToString());
      var d = Cell.DeadCell;
      Assert.AreEqual(" ", d.ToString());
    }
  }
}
