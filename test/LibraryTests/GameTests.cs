using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Test de los métodos de la clase Game 
    /// </summary>
    public class GameTests
    {
        /// <summary>
        /// Testea partida finalizada una vez que se disparo a todos los barcos de los usuarios de la partida
        /// </summary>
        [Test]
        public void GameFinishedTest()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(20));
            player.AddPlayerShotBoard(new ShotBoard(20));
            Submarine submarineMatias = new Submarine("11", "v");
            player.PlaceShipOnBoard(submarineMatias);
            User maria = new User(4, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            LobbyContainer.AddPlayer(player);
            Ship submarineMaria = new Submarine("21", "H");
            player2.PlaceShipOnBoard(submarineMaria);
            Game game = new Game(player, player2);

            player.ReceiveShot("11");
            player.ReceiveShot("21");
            player.ReceiveShot("31");
            player.ReceiveShot("41");

            player2.ReceiveShot("21");
            player2.ReceiveShot("22");
            player2.ReceiveShot("23");
            player2.ReceiveShot("24");
            Assert.AreEqual(true, game.GameFinished());
        }

        /// <summary>
        /// Testea partida finalizada una vez que se disparo a todos los barcos de un usuario de la partida
        /// </summary>
        [Test]
        public void GameFinishedBecauseOfOnePlayerTest()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(20));
            player.AddPlayerShotBoard(new ShotBoard(20));
            Submarine submarineMatias = new Submarine("11", "v");
            player.PlaceShipOnBoard(submarineMatias);
            User maria = new User(4, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            LobbyContainer.AddPlayer(player);
            Ship submarineMaria = new Submarine("21", "H");
            player2.PlaceShipOnBoard(submarineMaria);
            Game game = new Game(player, player2);

            player.ReceiveShot("11");
            player.ReceiveShot("21");
            player.ReceiveShot("31");
            player.ReceiveShot("41");

            player2.ReceiveShot("21");
            player2.ReceiveShot("22");

            Assert.AreEqual(true, game.GameFinished());
        }

        /// <summary>
        /// Testea partida no finalizada pues aun los barcos no estan hundidos
        /// </summary>
        [Test]
        public void GameNotFinishedTest()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(20));
            player.AddPlayerShotBoard(new ShotBoard(20));
            Submarine submarineMatias = new Submarine("11", "v");
            player.PlaceShipOnBoard(submarineMatias);
            User maria = new User(4, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            LobbyContainer.AddPlayer(player);
            Ship submarineMaria = new Submarine("21", "H");
            player2.PlaceShipOnBoard(submarineMaria);
            Game game = new Game(player, player2);

            player.ReceiveShot("11");
            player.ReceiveShot("21");
            player.ReceiveShot("31");

            player2.ReceiveShot("21");
            player2.ReceiveShot("22");
            player2.ReceiveShot("23");
            Assert.AreEqual(false, game.GameFinished());
        }

        /// <summary>
        /// Testea partida finalizada una vez que se disparo a todos los barcos de un usuario de la partida con el método ShotMade
        /// </summary>
        [Test]
        public void GameFinishedTestWithShotMadeMethod()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(20));
            player.AddPlayerShotBoard(new ShotBoard(20));
            Ship frigateMatias = new Frigate("11", "v");
            player.PlaceShipOnBoard(frigateMatias);
            User maria = new User(4, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            LobbyContainer.AddPlayer(player);
            Ship frigateMaria = new Frigate("11", "H");
            player2.PlaceShipOnBoard(frigateMaria);
            Game game = new Game(player, player2);
            game.ShotMade("11");
            game.ShotMade("11");
            game.ShotMade("12");
            Assert.AreEqual(true, game.GameFinished());
        }

        /// <summary>
        /// Testea todos los barcos de un usuario hundidos de la partida con el método ShotMade
        /// </summary>
        [Test]
        public void AreAllShipsSinkedTestWithShotMadeMethod()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(20));
            player.AddPlayerShotBoard(new ShotBoard(20));
            Ship frigateMatias = new Frigate("11", "v");
            player.PlaceShipOnBoard(frigateMatias);
            User maria = new User(4, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            LobbyContainer.AddPlayer(player);
            Ship frigateMaria = new Frigate("11", "H");
            player2.PlaceShipOnBoard(frigateMaria);
            Game game = new Game(player, player2);
            game.ShotMade("11");
            game.ShotMade("11");
            game.ShotMade("12");
            game.ShotMade("21");
            Assert.AreEqual(true, player.AreAllShipsSinked());
            Assert.AreEqual(true, player2.AreAllShipsSinked());
        }

        /// <summary>
        /// Test De si todos los barcos fueron hundidos 
        /// </summary>    
        [Test]
        public void PlayerShipSinkedTest()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(20));
            player.AddPlayerShotBoard(new ShotBoard(20));
            LobbyContainer.AddPlayer(player);

            Submarine submarine = new Submarine("11", "v");
            player.PlaceShipOnBoard(submarine);
            //Se agrega el submarino en las coordenadas 
            player.ReceiveShot("11");
            player.ReceiveShot("21");
            player.ReceiveShot("31");
            player.ReceiveShot("41");
            bool expected = true;
            Assert.AreEqual(expected, submarine.IsShipSinked());
        }

        /// <summary>
        /// Se testea cuando un jugador recibe un shot 
        /// Se testea que el barco que se agregó se agrega a la lista de barcos del jugador
        /// Se testea que al recibir el shot cambie el valor de la coordenada del barco
        /// </summary>
        [Test]
        public void PlayerReceivesShotTest()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(10));
            player.AddPlayerShotBoard(new ShotBoard(10));
            LobbyContainer.AddPlayer(player);
            Frigate frigate = new Frigate("11", "h");
            player.PlaceShipOnBoard(frigate);
            player.ReceiveShot("11");
            Assert.AreEqual("🟢", player.GetPlayerShipBoard().GameBoard[1, 1]);
            Assert.AreEqual(1, player.ShipsList.Count);

        }

        /// <summary>
        /// El test prueba el método MakeShot del jugador, este método hace que el jugador realiza el disparo y ubica una "x" en su tablero de tiros
        /// </summary>
        [Test]
        public void TestMakeShot()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(10));
            player.AddPlayerShotBoard(new ShotBoard(10));
            LobbyContainer.AddPlayer(player);
            player.MakeShot("12");
            Assert.AreEqual("X", player.GetPlayerShotBoard().GameBoard[1, 2]);
        }
        /// <summary>
        /// Se testea el método de ShotMade sin barcos, el cual afecta a los tableros de ambos jugadores
        /// </summary>
        [Test]
        public void TestShotMadeWithoutShips()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player1 = new Player(matias);
            player1.AddPlayerShipBoard(new ShipBoard(20));
            player1.AddPlayerShotBoard(new ShotBoard(20));
            User maria = new User(2, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            Game game = new Game(player1, player2);
            //Player1 es active_player
            //Player2 es inactive_player
            game.ShotMade("55");
            Assert.AreEqual("X", player1.GetPlayerShotBoard().GameBoard[5, 5]);
            Assert.AreEqual("🔵", player2.GetPlayerShipBoard().GameBoard[5, 5]);
        }
        /// <summary>
        /// Testea método ShotMade con los barcos y la lista de barcos
        /// </summary>
        [Test]
        public void TestShotMadeWithShips()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player1 = new Player(matias);
            player1.AddPlayerShipBoard(new ShipBoard(20));
            player1.AddPlayerShotBoard(new ShotBoard(20));
            User maria = new User(2, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            player2.PlaceShipOnBoard(new Submarine("55", "v"));
            Game game = new Game(player1, player2);
            //Player1 es active_player
            //Player2 es inactive_player
            game.ShotMade("55");
            Assert.AreEqual("X", player1.GetPlayerShotBoard().GameBoard[5, 5]);
            Assert.AreEqual("X", player2.GetPlayerShipBoard().GameBoard[5, 5]);
        }
    }
}