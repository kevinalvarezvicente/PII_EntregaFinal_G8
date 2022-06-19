using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    public class PlayerTests
    {
        static User Juan = new User(0, "Juan");
        static Player player = new Player(Juan, 5);
        [SetUp]
        public void Setup()
        {



        }

        [Test]
        [TestCase("11")]
        public void MakeShotTest(string data)
        {
            player.MakeShot(data);
            Board shotBoard = player.GetPlayerShotBoard();
            (int x, int y) = Utils.SplitCoordIntoRowAndColumn(data);
            Assert.AreEqual("|", shotBoard.GameBoard[x, y]);
        }    
    
        [Test]
        [TestCase("11")]
        public void CorrectPositionShot(string data)
        {
            player.MakeShot(data);
            Board shotBoard = player.GetPlayerShotBoard();
            (int x, int y) = Utils.SplitCoordIntoRowAndColumn(data);
             Assert.AreEqual(shotBoard.GameBoard[1, 1], shotBoard.GameBoard[x, y]);
        }    
        
        /*[Test]
        public void userloby()
        {   
            Administrator admin = new Administrator();
            Lobby lobby = new Lobby();
            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            Game game1   = new Game(player1, player2, 10);
            admin.AddUserToList(player1);
            admin.AddUserToList(player2);
            lobby.CountUsersSearchingForGame();
            Assert.AreEqual(2, lobby.CountUsersSearchingForGame());
        }*/

        [Test]
        public void MaxShipsQuantity()
        {   
            Board board1 = new Board(10);
            int maximo = board1.MaxShipsQuantity;
            Assert.AreEqual(5, maximo);
        }
        
        
        [Test]
        public void placeship()
        {
            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            Player carol = new Player(player1, 10);
            Player Tony  = new Player(player2, 10);
            Board board1 = new Board(10);
            Game game1   = new Game(player1, player2, 10);
            game1.PlaceShip(1, "11", "V");
            carol.GetPlayerShipBoard();
            Assert.AreEqual("o", carol.GetPlayerShipBoard().GameBoard[1, 1]);
        }
          
        
        [Test]
        public void ShotOcean()
        {
            player.ReceiveShot("21");
            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            Game game1 = new Game(player1, player2, 10);
            game1.PlaceShip(2, "11", "H");
            Board shotBoard = player.GetPlayerShotBoard();
            Assert.AreEqual("-", shotBoard.GameBoard[0, 0]);
        }
        

        //si se ubico el barco
        //si hace un tiro al oceano
        //si hace un tiro en una posicion ya tocada
        //si hace un tiro en una posicion no tocada
        //si hace un tiro en una posicion fuera del tablero
    }
}
