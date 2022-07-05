using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Tests de los métodos de la clase Player
    /// </summary>
    public class PlayerTests
    {
        /// <summary>
        /// Testea que cuando se agregan barcos a la lista de barcos del jugador
        /// </summary>
        [Test]
        public void TestPlayerShipsList()
        {
            User matias = new User(1202755835,"Matias","Olave");
            Player player = new Player(matias); 
            LightCruiser cruiser = new LightCruiser("00","h");
            Submarine submarine = new Submarine("40","v");
            Frigate frigate = new Frigate("20","h");
            player.AddShipToPlayerShipList(cruiser);
            player.AddShipToPlayerShipList(submarine);
            player.AddShipToPlayerShipList(frigate);
            Assert.AreEqual(3,player.ShipsList.Count);
        }


        /// <summary>
        /// Testea que busca la coordenada en la lista de barcos de cada jugador. Si esta la coordenada en la lista de barcos es porque el jugador tiene un barco ubicado ahi.
        /// Se hace Assert.AreEqual para una coordenada que si esta
        /// </summary>
        [Test]
        public void TestSearchForCoordInShipsListOK()
        {
            User matias = new User(3,"Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(10));
            player.AddPlayerShotBoard(new ShotBoard(10));
            LobbyContainer.AddPlayer(player);
            LightCruiser cruiser = new LightCruiser("03","h"); 
            player.PlaceShipOnBoard(cruiser);
            Assert.AreEqual(true, player.SearchForCoordInShipsList("04"));
              
        }
        /// <summary>
        /// Testea que busca la coordenada en la lista de barcos de cada jugador. Si esta la coordenada en la lista de barcos es porque el jugador tiene un barco ubicado ahi.
        /// Se hace Assert.AreEqual para una coordenada que no esta
        /// </summary>
        [Test]
        public void TestSearchForCoordInShipsListNotOK()
        {
            User matias = new User(3,"Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(10));
            player.AddPlayerShotBoard(new ShotBoard(10));
            LobbyContainer.AddPlayer(player);
            LightCruiser cruiser = new LightCruiser("03","h"); 
            player.PlaceShipOnBoard(cruiser);
            Assert.AreEqual(false, player.SearchForCoordInShipsList("00"));   
        }
        /// <summary>
        /// Testea cuando se añade el tablero a un jugador, se añade a su lista de tableros
        /// </summary>
        [Test]
        public void TestAddBoardsToPlayer()
        {
            User maria = new User(3,"Maria", "Parapar");
            Player player = new Player(maria);
            player.AddPlayerShipBoard(new ShipBoard(10));
            player.AddPlayerShotBoard(new ShotBoard(10));
            Assert.AreEqual(2,player.PlayerBoardsList.Count);
        }
        /// <summary>
        /// Testea el método de conocer el tablero que selecciono el jugador
        /// </summary>
        [Test]
        public void TestGetPlayerBoardSize()
        {
            User maria = new User(3,"Maria", "Parapar");
            Player player = new Player(maria);
            player.AddPlayerShipBoard(new ShipBoard(10));
            player.AddPlayerShotBoard(new ShotBoard(10));
            Assert.AreEqual(10,player.GetPlayerBoardSize());
        }
        
        /// <summary>
        /// Se testea el disparo dos veces a la misma coordenada. Se testea excepcion
        /// </summary>
        [Test]
        public void TestReceiveShotException()
        {
            User matias = new User(3,"Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(10));
            player.AddPlayerShotBoard(new ShotBoard(10));
            LobbyContainer.AddPlayer(player);
            Ship frigate = new Frigate("11","v");
            player.PlaceShipOnBoard(frigate);
            //player.MakeShot("11");
            player.ReceiveShot("11");  
            Assert.Throws<ReceiveShotException>(() =>player.ReceiveShot("11"));
        }

        /// <summary>
        /// Testea que no se pueda ubicar ningun tipo de barco si una coordenada queda fuera del tablero lanzando una excepcion
        /// </summary>
        [Test]
        public void TestPlaceShipOutOfBoard()
        {
            User matias = new User(3,"Olave", "Matias");
            Player player = new Player(matias);
            player.AddPlayerShipBoard(new ShipBoard(10));
            player.AddPlayerShotBoard(new ShotBoard(10));
            LobbyContainer.AddPlayer(player);
            LightCruiser cruiser = new LightCruiser("99","h");  
            Submarine submarine = new Submarine("98","h");
            Assert.AreEqual(false,player.PlaceShipOnBoard(cruiser));
            Assert.AreEqual(false,player.PlaceShipOnBoard(submarine));


        }

    }
}