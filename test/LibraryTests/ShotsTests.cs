using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Test de los métodos de la clase ShotCounter y sus subclases 
    /// </summary>
    public class ShotTests
    {
        
        /// <summary>
        /// Test con disparos al agua
        /// </summary>
        [Test]
        public void WaterShotsTest()
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
            game.ShotMade("55");
            game.ShotMade("22");
            Assert.AreEqual(2, game.GetWaterShotCounter());

        }

        /// <summary>
        /// Test de ambos jugadores con disparos a barcos 
        /// </summary>

        [Test]
        public void ShipShotsTest()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player1 = new Player(matias);
            player1.AddPlayerShipBoard(new ShipBoard(20));
            player1.AddPlayerShotBoard(new ShotBoard(20));
            player1.PlaceShipOnBoard(new Submarine("00", "v"));
            User maria = new User(2, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            player2.PlaceShipOnBoard(new Submarine("55", "v"));
            Game game = new Game(player1, player2);
            game.ShotMade("55");
            game.ShotMade("00");
            game.ShotMade("65");
            Assert.AreEqual(3, game.GetShipShotCounter());
        }

        /// <summary>
        /// Test que simula una partida entre dos jugadores
        /// </summary>

        [Test]
        public void BothShotTest()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player1 = new Player(matias);
            player1.AddPlayerShipBoard(new ShipBoard(20));
            player1.AddPlayerShotBoard(new ShotBoard(20));
            player1.PlaceShipOnBoard(new Submarine("00", "v"));
            User maria = new User(2, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            player2.PlaceShipOnBoard(new Submarine("55", "v"));
            Game game = new Game(player1, player2);
            //Player 1 hace el primer shot y le dispara a player2 en un barco
            game.ShotMade("55");
            //Player 2 hace el segundo shot y no le dispara a nada
            game.ShotMade("88");
            //Player 1 hace el tercer shot y le dispara a player2 en un barco
            game.ShotMade("65");
            //Player 2 hace el cuarto shot y le dispara a un barco
            game.ShotMade("00");
            //Player 1 hace el quinto shot y no le dispara a nada
            game.ShotMade("00");
            Assert.AreEqual(3, game.GetShipShotCounter());
            Assert.AreEqual(2, game.GetWaterShotCounter());
        }
        /// <summary>
        /// Test de que se realiza un tiro al agua y el contador de tiros a barcos es 0
        /// </summary>

        [Test]
        public void ShipShotDoesNotChangeTest()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player1 = new Player(matias);
            player1.AddPlayerShipBoard(new ShipBoard(20));
            player1.AddPlayerShotBoard(new ShotBoard(20));
            player1.PlaceShipOnBoard(new Submarine("00", "v"));
            User maria = new User(2, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            player2.PlaceShipOnBoard(new Submarine("55", "v"));
            Game game = new Game(player1, player2);
            game.ShotMade("00");
            Assert.AreEqual(0, game.GetShipShotCounter());
        }

        /// <summary>
        /// Test de que se crea la partida y hasta que no hay un tiro no aumenta el contador
        /// </summary>
        [Test]
        public void NoShotTest()
        {
            User matias = new User(3, "Olave", "Matias");
            Player player1 = new Player(matias);
            player1.AddPlayerShipBoard(new ShipBoard(20));
            player1.AddPlayerShotBoard(new ShotBoard(20));
            player1.PlaceShipOnBoard(new Submarine("00", "v"));
            User maria = new User(2, "Maria", "Parapar");
            Player player2 = new Player(maria);
            player2.AddPlayerShipBoard(new ShipBoard(20));
            player2.AddPlayerShotBoard(new ShotBoard(20));
            player2.PlaceShipOnBoard(new Submarine("55", "v"));
            Game game = new Game(player1, player2);
            Assert.AreEqual(0, game.GetShipShotCounter());
            Assert.AreEqual(0, game.GetWaterShotCounter());
        }




    }
}