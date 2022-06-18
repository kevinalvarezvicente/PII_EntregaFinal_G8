using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    public class PlayerTests
    {
        static User Juan = new User("0", "Juan");
        static Player player = new Player(Juan, 5);
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("1C", true)]
        public void MakeShotTest(string data, bool pass)
        {
            player.MakeShot(data);
            Board shotBoard = player.GetPlayerShotBoard();
            (int x, int y) = Utils.SplitCoordIntoRowAndColumn(data);
            shotBoard.GameBoard[x, y] = "|";
        }
    }
}
