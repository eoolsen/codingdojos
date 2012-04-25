using NUnit.Framework;

namespace TennisScore
{
    [TestFixture]
    public class TestTiebreak
    {
        [Test]
        public void Test57()
        {
            Tiebreak tiebreak = new Tiebreak();
            for (int i = 0; i < 5; i++)
            {
                tiebreak.PlayerOneWinsPoint();
            }
            for (int i = 0; i < 7; i++)
            {
                tiebreak.PlayerTwoWinsPoint();
            }
            Assert.AreEqual("5 - 7", tiebreak.Score());
            Assert.IsTrue(tiebreak.GameOver);
        }

        [Test]
        public void Test108()
        {
            Tiebreak tiebreak = new Tiebreak();
            for (int i = 0; i < 8; i++)
            {
                tiebreak.PlayerOneWinsPoint();
                tiebreak.PlayerTwoWinsPoint();
            }
            tiebreak.PlayerOneWinsPoint();
            tiebreak.PlayerOneWinsPoint();

            Assert.AreEqual("10 - 8", tiebreak.Score());
            Assert.IsTrue(tiebreak.GameOver);
        }

        [Test]
        public void Test98()
        {
            Tiebreak tiebreak = new Tiebreak();
            for (int i = 0; i < 8; i++)
            {
                tiebreak.PlayerOneWinsPoint();
                tiebreak.PlayerTwoWinsPoint();
            }
            tiebreak.PlayerOneWinsPoint();

            Assert.AreEqual("9 - 8", tiebreak.Score());
            Assert.IsFalse(tiebreak.GameOver);
        }
    }
}
