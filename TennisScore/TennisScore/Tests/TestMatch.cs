using System;
using NUnit.Framework;

namespace TennisScore
{
    [TestFixture]
    public class TestMatch
    {
        [Test]
        public void TestCleanSweep()
        {
            Match match = new Match();

            for (int i = 0; i < 72; i++)
            {
                match.PlayerOneWinsPoint();
            }
            Assert.AreEqual("6 - 0, 6 - 0, 6 - 0", match.Score());
        }

        [Test]
        public void TestCleanSweepP2()
        {
            Match match = new Match();

            for (int i = 0; i < 72; i++)
            {
                match.PlayerTwoWinsPoint();
            }
            Assert.AreEqual("0 - 6, 0 - 6, 0 - 6", match.Score());
        }

        [Test]
        public void TestMatchNotDone()
        {
            Match match = new Match();

            for (int i = 0; i < 50; i++)
            {
                match.PlayerTwoWinsPoint();
            }
            Assert.AreEqual("0 - 6, 0 - 6, 0 - 0, love - 30", match.Score());
        }


        [Test]
        [ExpectedException(typeof(Exception))]
        public void TestmatchAlreadyEndedP2()
        {
            Match match = new Match();

            for (int i = 0; i < 73; i++)
            {
                match.PlayerTwoWinsPoint();
            }
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void TestmatchAlreadyEndedP1()
        {
            Match match = new Match();

            for (int i = 0; i < 73; i++)
            {
                match.PlayerOneWinsPoint();
            }
        }
    }
}
