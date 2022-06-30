using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    public class PlayerTests
    {
        /// <summary>
        /// Se testea cuando un jugador recibe un shot 
        /// Se testea que el barco que se agregó se agrega a la lista de barcos del jugador
        /// Se testea que al recibir el shot cambie el valor de la coordenada del barco
        /// </summary>
        [Test]
        public void PlayerReceivesShotTest()
        {
            User matias = new User(1202755835,"Matias","Olave");
            Player player = new Player(matias);
            Submarine submarine = new Submarine("11","v");
            player.PlaceShipOnBoard(submarine);
            player.ReceiveShot("11");
            //ool isTrue= player.SearchForCoordInShipsList("11");
            Assert.AreEqual("x", player.GetPlayerShipBoard().GameBoard[1, 1]);
            Assert.AreEqual(1,player.ShipsList.Count);
            //Assert.AreEqual(true,isTrue);   Método aún sin funcionar
            
        }

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
        /// El test prueba el método MakeShot del jugador, este método hace que el jugador realiza el disparo y ubica una "x" en su tablero de tiros
        /// </summary>
        [Test]
        public void TestMakeShot()
        {
                User player1 = new User(1202755835,"Kevin","Alvarez");
                Player kevin = new Player(player1);
                kevin.MakeShot("12");
                Assert.AreEqual("X",kevin.GetPlayerShotBoard().GameBoard[1,2]);  
        }

    }
}