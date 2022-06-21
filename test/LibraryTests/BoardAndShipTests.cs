using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Se hace test para el método que divide la coordenada
    /// </summary>
    public class BoardAndShipTests
    {
        /// <summary>
        /// Se testea el disparo dos veces a la misma coordenada. Se testea excepcion
        /// </summary>
        [Test]
        public void TestReceiveShotException()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Ship frigate = new Frigate("11","v");
            player.PlaceShipOnBoard(frigate);
            player.ReceiveShot("11");  
            Assert.Throws<ReceiveShotException>(() =>player.ReceiveShot("11"));
        }
        /// <summary>
        /// Se testea la maxima cantidad de barcos 
        /// </summary>

        [Test]
        public void TestMaxShipQuantity()
        {
            Board board = new Board(10);
            int max = board.MaxShipsQuantity;
            Assert.AreEqual(5, max);
        }
        /// <summary>
        /// Se testea agregar un LightCruiser en vertical
        /// </summary>
        [Test]
        public void AddFrigateToBoardVertical()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Ship frigate = new Frigate("11","v");
            player.PlaceShipOnBoard(frigate);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 1]);
        }
        /// <summary>
        /// Se testea agregar un Frigate en horizontal
        /// </summary>
        [Test]
        public void AddFrigateToBoardHorizontal()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Ship frigate = new Frigate("11","H");
            player.PlaceShipOnBoard(frigate);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 2]);
        }
        /// <summary>
        /// Testea que se agreguen 2 posiciones de Frigate
        /// </summary>
        [Test]
        public void AddAllPositionsOfFrigate()
        {
            int count=0;
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Ship frigate = new Frigate("11","v");
            player.PlaceShipOnBoard(frigate);
            foreach (Spot spot in frigate.CoordsList)
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }
        /// <summary>
        /// Se testea agregar un LightCruiser en vertical
        /// </summary>
        [Test]
        public void AddLightCruiserToBoardVertical()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Ship lightCruiser= new LightCruiser("13","V");
            player.PlaceShipOnBoard(lightCruiser);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 3]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 3]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[3, 3]);
        }
        /// <summary>
        /// Se testea agregar un LightCruiser en horizontal
        /// </summary>
        [Test]
        public void AddLightCruiserToBoardHorizontal()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Ship lightCruiser= new LightCruiser("22","h");
            player.PlaceShipOnBoard(lightCruiser);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 2]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 3]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 4]);
        }
        /// <summary>
        /// Se testea que se agreguen las 3 posiciones de LightCruiser
        /// </summary>
        [Test]
        public void AddAllPositionsOfLightCruiser()
        {
            int count=0;
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Ship lightCruiser= new LightCruiser("22","V");
            player.PlaceShipOnBoard(lightCruiser);
            foreach (Spot spot in lightCruiser.CoordsList)
            {
                count++;
            }
            Assert.AreEqual(3, count);
        }
        /// <summary>
        /// Se testea agregar un Submarino en vertical
        /// </summary>
        [Test]
        public void AddSubmarineToBoardVertical()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Ship submarine = new Submarine("11","v");
            player.PlaceShipOnBoard(submarine);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[1, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[3, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[4, 1]);
        }
        /// <summary>
        /// Se testea agregar un Submarino en horizontal
        /// </summary>
        [Test]
        public void AddSubmarineToBoardHorizontal()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Ship submarine = new Submarine("21","H");
            player.PlaceShipOnBoard(submarine);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 1]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 2]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 3]);
            Assert.AreEqual("o", player.PlayerShipBoard.GameBoard[2, 4]);
        }
        /// <summary>
        /// Se testea que se agreguen las 4 posiciones del submarino
        /// </summary>
        [Test]
        public void AddAllPositionsOfSubmarine()
        {
            int count=0;
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
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
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
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
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Submarine submarine = new Submarine("11","v");
            player.PlaceShipOnBoard(submarine);
            //Se agrega el submarino en las coordenadas 
            player.ReceiveShot("11");
            player.ReceiveShot("21");
            player.ReceiveShot("31");
            player.ReceiveShot("41");
            bool expected = true;
            Assert.AreEqual(expected,submarine.IsShipSinked()); 
        }
        /// <summary>
        /// Testea que si se dispara a la coordenada vulnerable de cualquier barco se hunde.
        /// Testea que al jugador se le hundieron todos sus barcos
        /// </summary>  
        [Test]
        public void TestVulnerableCoord()
        {
            User user = new User("player","player");
            Player player = new Player(user,11);   
            LightCruiser cruiser = new LightCruiser("00","h");
            Submarine submarine = new Submarine("40","v");
            Frigate frigate = new Frigate("20","h");
            player.AddShipToPlayerShipList(cruiser);
            player.AddShipToPlayerShipList(submarine);
            player.AddShipToPlayerShipList(frigate);
            cruiser.ShotInVulnerableCoord("00");
            submarine.ShotInVulnerableCoord("40");
            frigate.ShotInVulnerableCoord("20");
            Assert.AreEqual(true, cruiser.IsShipSinked());
            Assert.AreEqual(true, submarine.IsShipSinked());
            Assert.AreEqual(true,frigate.IsShipSinked());
            Assert.AreEqual(true, player.AreAllShipsSinked());
        }
        /// <summary>
        /// Testea que cuando se agregan barcos a la lista de barcos del jugador
        /// </summary>
        [Test]
        public void TestPlayerShipsList()
        {
            User user = new User("player","player");
            Player player = new Player(user,11);   
            LightCruiser cruiser = new LightCruiser("00","h");
            Submarine submarine = new Submarine("40","v");
            Frigate frigate = new Frigate("20","h");
            player.AddShipToPlayerShipList(cruiser);
            player.AddShipToPlayerShipList(submarine);
            player.AddShipToPlayerShipList(frigate);
            Assert.AreEqual(3,player.ShipsList.Count);
        }
        /// <summary>
        /// Testea que cuando se agregan barcos al tablero del jugador con el metodo PlaceShipOnBoard
        /// </summary>
        [Test]
        public void TestPlayerAddingManyShipsList()
        {
            User user = new User("player","player");
            Player player = new Player(user,11);   
            LightCruiser cruiser = new LightCruiser("00","h");
            Submarine submarine = new Submarine("40","v");
            Frigate frigate = new Frigate("20","h");
            player.PlaceShipOnBoard(cruiser);
            player.PlaceShipOnBoard(submarine);
            player.PlaceShipOnBoard(frigate);
            Assert.AreEqual(3,player.ShipsList.Count);
        }
        
        /// <summary>
        /// El test prueba el método MakeShot del jugador, este método hace que el jugador realiza el disparo y ubica una "x" en su tablero de tiros
        /// </summary>
        [Test]
        public void TestMakeShot()
        {
                User player1 = new User("Carol","Glass");
                Player carol = new Player(player1,10);
                carol.MakeShot("12");
                Assert.AreEqual("X",carol.PlayerShotBoard.GameBoard[1,2]);  
        }
        /// <summary>
        /// Testea excepcion del tamaño del tablero
        /// </summary>
        [Test]
        public void TestBigBoardException()
        {
            Assert.Throws<BoardException>(() =>new Board(15));
        }
        /// <summary>
        /// Testea excepcion de que el tamaño del tablero se elige 0
        /// </summary>
        [Test]
        public void TestSmallBoardException()
        {
            Assert.Throws<BoardException>(() =>new Board(0));
        }
        /// <summary>
        /// Testea si la coordenada elegida para ubicar el fragata ya tiene un barco ubicado
        /// </summary>
        [Test]
        public void TestPlaceSubmarineInTakenPosition()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Submarine submarine = new Submarine("00","h");
            //Ubica el submarino en (0,0), (0,1), (0,2) y (0,3)
            player.PlaceShipOnBoard(submarine);
            Frigate frigate = new Frigate("01","h");
            Assert.Throws<CoordException>(() =>player.PlaceShipOnBoard(frigate));
        }
        /// <summary>
        /// Testea si la coordenada elegida para ubicar el submarino ya tiene un barco ubicado
        /// </summary>
        [Test]
        public void TestPlaceFrigateInTakenPosition()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Frigate frigate = new Frigate("01","h");
            Submarine submarine = new Submarine("00","h");
            player.PlaceShipOnBoard(frigate);     
            Assert.Throws<CoordException>(() =>player.PlaceShipOnBoard(submarine));
        }
        /// <summary>
        /// Testea si la coordenada elegida para ubicar el crucero ya tiene un barco ubicado
        /// </summary>
        [Test]
        public void TestPlaceCruiserInTakenPosition()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 10);
            Frigate frigate = new Frigate("01","h");
            LightCruiser cruiser = new LightCruiser("00","h");
            player.PlaceShipOnBoard(frigate);     
            Assert.Throws<CoordException>(() =>player.PlaceShipOnBoard(cruiser));
        }
        /// <summary>
        /// Testea que no se pueda ubicar ningun tipo de barco si una coordenada queda fuera del tablero lanzando una excepcion
        /// </summary>
        [Test]
        public void TestPlaceShipOutOfBoard()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 5);
            LightCruiser cruiser = new LightCruiser("04","h");  
            Frigate frigate = new Frigate("55","h"); 
            Submarine submarine = new Submarine("44","v");
            Assert.Throws<CoordException>(() =>player.PlaceShipOnBoard(cruiser));
            Assert.Throws<CoordException>(() =>player.PlaceShipOnBoard(frigate));
            Assert.Throws<CoordException>(() =>player.PlaceShipOnBoard(submarine));

        }
        /// <summary>
        /// Testea que busca la coordenada en la lista de barcos de cada jugador. Si esta la coordenada en la lista de barcos es porque el jugador tiene un barco ubicado ahi.
        /// Se hace Assert.AreEqual para una coordenada que si esta
        /// </summary>
        [Test]
        public void TestSearchForCoordInShipsListOK()
        {
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 8);
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
            User matias = new User("Matias","Olave");
            Player player = new Player(matias, 8);
            LightCruiser cruiser = new LightCruiser("03","h"); 
            player.PlaceShipOnBoard(cruiser);
            Assert.AreEqual(false, player.SearchForCoordInShipsList("00"));   
        }
    }
}