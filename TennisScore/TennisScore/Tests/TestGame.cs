using NUnit.Framework;

namespace TennisScore
{
    [TestFixture]
    public class Testgame
    {
        [Test]
        public void Test1515()
        {
            Game game = new Game();
            game.PlayerOneWinsPoint();
            game.PlayerTwoWinsPoint();
            Assert.AreEqual("15 all", game.Score());
        }

        [Test]
        public void Test1540()
        {
            Game game = new Game();
            game.PlayerTwoWinsPoint();
            game.PlayerOneWinsPoint();
            game.PlayerTwoWinsPoint();
            game.PlayerTwoWinsPoint();
            Assert.AreEqual("15 - 40", game.Score());
        }

        [Test]
        public void TestGameOver()
        {
            Game game = new Game();
            game.PlayerTwoWinsPoint();
            game.PlayerOneWinsPoint();
            game.PlayerTwoWinsPoint();
            game.PlayerTwoWinsPoint();
            game.PlayerTwoWinsPoint();
            Assert.AreEqual(true, game.GameOver);
        }

        [Test]
        public void TestTripleGamePoint()
        {
            Game game = new Game();
            for (int i = 0; i < 3; i++)
            {
                game.PlayerOneWinsPoint();
            }
            Assert.AreEqual("40 - love", game.Score());
        }

        [Test]
        public void TestAdvP1()
        {
            Game game = new Game();
            for (int i = 0; i < 3; i++)
            {
                game.PlayerOneWinsPoint();
                game.PlayerTwoWinsPoint();
            }
            game.PlayerOneWinsPoint();
            
            Assert.AreEqual("advantage player one", game.Score());
        }

        [Test]
        public void TestAdvP2()
        {
            Game game = new Game();
            for (int i = 0; i < 3; i++)
            {
                game.PlayerOneWinsPoint();
                game.PlayerTwoWinsPoint();
            }
            game.PlayerTwoWinsPoint();

            Assert.AreEqual("advantage player two", game.Score());
        }

        [Test]
        public void TestP2Wins()
        {
            Game game = new Game();
            for (int i = 0; i < 3; i++)
            {
                game.PlayerOneWinsPoint();
                game.PlayerTwoWinsPoint();
            }
            game.PlayerTwoWinsPoint();
            game.PlayerTwoWinsPoint();

            Assert.AreEqual("player two wins", game.Score());
        }

        [Test]
        public void TestP1Wins()
        {
            Game game = new Game();
            for (int i = 0; i < 3; i++)
            {
                game.PlayerOneWinsPoint();
                game.PlayerTwoWinsPoint();
            }
            game.PlayerOneWinsPoint();
            game.PlayerOneWinsPoint();

            Assert.AreEqual("player one wins", game.Score());
        }

        [Test]
        public void TestDeuce()
        {
            Game game = new Game();
            for (int i = 0; i < 5; i++)
            {
                game.PlayerOneWinsPoint();
                game.PlayerTwoWinsPoint();
            }

            Assert.AreEqual("deuce", game.Score());
        }

        [Test]
        public void Test3030()
        {
            Game game = new Game();
            for (int i = 0; i < 2; i++)
            {
                game.PlayerOneWinsPoint();
                game.PlayerTwoWinsPoint();
            }

            Assert.AreEqual("30 all", game.Score());
        }

        [Test]
        public void TestLoveAll()
        {
            Game game = new Game();
            Assert.AreEqual("love all", game.Score());
        }
    }
}
