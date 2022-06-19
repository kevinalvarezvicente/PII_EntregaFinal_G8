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
        
        [Test]
        [TestCase("11")]
        public void userloby(string data)
        {   
            Lobby lobby = new Lobby();
            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            Game game1   = new Game(player1, player2, 10);
            lobby.AddUserToList(player1);
            lobby.AddUserToList(player2);
            lobby.CountUsersSearchingForGame();
            Assert.AreEqual(2, lobby.CountUsersSearchingForGame());
        }
        /*
        [Test]
        [TestCase("11")]
        public void placeship(string data)
        {
            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            Player carol = new Player(player1, 10);
            Player Tony  = new Player(player2, 10);
            Game game1   = new Game(player1, player2, 10);
            game1.PlaceShip(3, "11", "V");
            (int x, int y) = Utils.SplitCoordIntoRowAndColumn(data);
             Assert.AreEqual("o", carol.GetPlayerShipBoard().GameBoard[x, y]);
        }
          */
        /*
        [Test]
        [TestCase("56")]
        public void ShotOcean(string data)
        {
            player.ReceiveShot(data);
            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            Game game1 = new Game(player1, player2, 10);
            game1.PlaceShip(3, "11", "H");
            Board shotBoard = player.GetPlayerShotBoard();
            (int x, int y) = Utils.SplitCoordIntoRowAndColumn(data);
            Assert.AreEqual("O", shotBoard.GameBoard[x, y]);
        }
        */

        //si se ubico el barco
        //si hace un tiro al oceano
        //si hace un tiro en una posicion ya tocada
        //si hace un tiro en una posicion no tocada
        //si hace un tiro en una posicion fuera del tablero
    }
}
