using NUnit.Framework;

namespace TennisScore
{
    [TestFixture]
    public class TestSet
    {
        [Test]
        public void TestCleanSweep()
        {
            Set set = new Set();
            for (int i = 0; i < 24; i++)
            {
                set.PlayerOneWinsPoint();
            }
            Assert.AreEqual("6 - 0", set.Score());
        }

        [Test]
        public void TestTripleSetPoint()
        {
            Set set = new Set();
            for (int i = 0; i < 23; i++)
            {
                set.PlayerOneWinsPoint();
            }
            Assert.AreEqual("5 - 0, 40 - love", set.Score());
        }


        [Test]
        public void TestTiebreak()
        {
            Set set = new Set();

            for (int i = 0; i < 6; i++)
            {
                TestUtilities.WinOrdinaryGame(set.PlayerOneWinsPoint);
                TestUtilities.WinOrdinaryGame(set.PlayerTwoWinsPoint);
            }
            set.PlayerOneWinsPoint();
            Assert.AreEqual("6 - 6, 1 - 0", set.Score());

            for (int i = 0; i < 7; i++)
            {
                set.PlayerTwoWinsPoint();
            }

            Assert.AreEqual("6 - 7", set.Score());
        }
    }
}
