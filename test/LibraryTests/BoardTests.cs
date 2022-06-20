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
        /// Test4
        /// Se testea el disparo dos veces a la misma coordenada
        /// </summary>
        [Test]
        public void TestReceiveShotException()
        {
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship frigate = new Frigate("11","v");
            player.PlaceShipOnBoard(frigate);
            player.ReceiveShot("11");  
            Assert.Throws<ReceiveShotException>(() =>player.ReceiveShot("11"));
        }
        /// <summary>
        /// Test5
        /// </summary>

        [Test]
        public void TestMaxShipQuantity()
        {
            Board board = new Board(10);
            int max = board.MaxShipsQuantity;
            Assert.AreEqual(5, max);
        }
        /// <summary>
        /// Test 6
        /// </summary>
        [Test]
        public void AddFrigateToBoardVertical()
        {
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship frigate = new Frigate("11","v");
            player.PlaceShipOnBoard(frigate);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 1]);
        }
        /// <summary>
        /// Test6
        /// </summary>
        [Test]
        public void AddFrigateToBoardHorizontal()
        {
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship frigate = new Frigate("11","H");
            player.PlaceShipOnBoard(frigate);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 2]);
        }
        /// <summary>
        /// Test7
        /// </summary>
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
        /// <summary>
        /// Test8
        /// </summary>
        public void AddLightCruiserToBoardVertical()
        {
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship lightCruiser= new LightCruiser("13","V");
            player.PlaceShipOnBoard(lightCruiser);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 3]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 3]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[3, 3]);
        }
        /// <summary>
        /// Test9
        /// </summary>
        public void AddLightCruiserToBoardHorizontal()
        {
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship lightCruiser= new LightCruiser("22","h");
            player.PlaceShipOnBoard(lightCruiser);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 2]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 3]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 4]);
        }
        /// <summary>
        /// Test10
        /// </summary>
        [Test]
        public void AddAllPositionsOfLightCruiser()
        {
            int count=0;
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship lightCruiser= new LightCruiser("22","V");
            player.PlaceShipOnBoard(lightCruiser);
            foreach (Spot spot in lightCruiser.CoordsList)
            {
                count++;
            }
            Assert.AreEqual(3, count);
        }
        /// <summary>
        /// Test11
        /// </summary>
        public void AddSubmarineToBoardVertical()
        {
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship submarine = new Submarine("11","v");
            player.PlaceShipOnBoard(submarine);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[3, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[4, 1]);
        }
        /// <summary>
        /// Test12
        /// </summary>
        public void AddSubmarineToBoardHorizontal()
        {
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship submarine = new Submarine("21","H");
            player.PlaceShipOnBoard(submarine);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 2]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 3]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 4]);
        }
        /// <summary>
        /// Test 13
        /// </summary>
        [Test]
        public void AddAllPositionsOfSubmarine()
        {
            int count=0;
            User player1 = new User(1, "Carol");
            Player player = new Player(player1, 10);
            Ship submarine = new Submarine("11","v");
            player.PlaceShipOnBoard(submarine);
            foreach (Spot spot in submarine.CoordsList)
            {
                count++;
            }
            Assert.AreEqual(4, count);
        }
        /// <summary>
        /// Se testea cuando un jugador recibe un shot 
        /// Se testea que el barco que se agregó se agrega a la lista de barcos del jugador
        /// Se testea que al recibir el shot cambie el valor de la coordenada del barco
        /// </summary>
        [Test]
        public void PlayerReceivesShotTest()
        {
            User juan = new User(1,"Juan");
            Player player = new Player(juan,10);
            Submarine submarine = new Submarine("11","v");
            player.PlaceShipOnBoard(submarine);
            player.ReceiveShot("11");
            //ool isTrue= player.SearchForCoordInShipsList("11");
            Assert.AreEqual("x", player.PlayerShipBoard.GameBoard[1, 1]);
            Assert.AreEqual(1,player.ShipsList.Count);
            //Assert.AreEqual(true,isTrue);   Método aún sin funcionar
            
        }
        /// <summary>
        /// Test sin funcionar aún 
        /// </summary>    
        [Test]
        public void PlayerShipSinkedTest()
        {
            User juan = new User(1,"Juan");
            Player player = new Player(juan,10);
            Submarine submarine = new Submarine("11","v");
            player.PlaceShipOnBoard(submarine);
            //Se agrega el submarino en las coordenadas 
            player.ReceiveShot("11");
            player.ReceiveShot("21");
            player.ReceiveShot("31");
            player.ReceiveShot("41");
            bool expected = true;
            Assert.AreEqual(expected,submarine.IsSinked);
            
            
        }  

    }
}