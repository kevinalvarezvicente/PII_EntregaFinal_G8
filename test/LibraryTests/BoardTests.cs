using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Se hace test para el método que divide la coordenada
    /// </summary>
    public class BoardTests
    {
        private User player1;
        private User player2;
        private Player carol;
        private Player tony;

        [SetUp]
        public void SetUp()
        {
            /*User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            Player carol = new Player(player1, 10);
            Player tony  = new Player(player2, 10);*/
        }

        /// <summary>
        /// Se testea el disparo dos veces a la misma coordenada
        /// </summary>
        [Test]
        public void TestReceiveShot()
        {
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship frigate = new Frigate("11","v");
            player.PlaceShipOnBoard(frigate);
            player.ReceiveShot("11");  
            Assert.Throws<ReceiveShotException>(() =>player.ReceiveShot("11"));
        }
        

        [Test]
        public void TestMaxShipQuantity()
        {
            Board board = new Board(10);
            int max = board.MaxShipsQuantity;
            Assert.AreEqual(5, max);
        }
        [Test]
        public void AddFrigateToBoard()
        {
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship frigate = new Frigate("11","v");
            player.PlaceShipOnBoard(frigate);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 2]);
        }
        [Test]
        public void AddAllPositionsOfFrigate()
        {
            int count=0;
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship frigate = new Frigate("11","v");
            player.PlaceShipOnBoard(frigate);
            foreach (Spot spot in frigate.CoordsList)
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }
        

        /*[Test]
        public void AddLightCruiserToBoard()
        {
            int counter = 0;
            Game game1   = new Game(player1, player2, 10);
            game1.PlaceShip(2, "11", "V");
            Assert.AreEqual("o", carol.PlayerShipBoard.GameBoard[2, 1]);
        }
        [Test]
        public void AddSubmarineToBoard()
        {
            int counter = 0;
            Game game1   = new Game(player1, player2, 10);
            game1.PlaceShip(3, "11", "V");
            Assert.AreEqual("o", carol.PlayerShipBoard.GameBoard[2, 1]);
        }*/
    }
}