using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Test de los containers
    /// </summary>
    public class ContainerTests
    {
        /// <summary>
        /// Test para ver que es posible iniciar una partida porque hay mas jugadores
        /// </summary>
        [Test]
        public void TestAreNotUserInListException()
        {
            User carol = new User(10,"Carol","Glass");
            Player player1= new Player(carol);
            User tony = new User(11,"Tony","Pereira");
            Player player2 = new Player(tony);
            Assert.Throws<ContainerException>(() =>LobbyContainer.RemoveUser(player1));
            Assert.Throws<ContainerException>(() =>LobbyContainer.RemoveUser(player2));
        }
        /// <summary>
        /// Se testea la union de dos jugadores que escogen el mismo tamaño de tablero
        /// Se testea método de añadir jugadores a lobby
        /// </summary>

        [Test]
        public void JoinPlayersWithSameBoardSizeTest()
        {
            User carol = new User(10,"Carol","Glass");
            Player player1= new Player(carol);
            player1.AddPlayerShipBoard(new Board(10));
            LobbyContainer.AddPlayer(player1);
            User tony = new User(11,"Tony","Pereira");
            Player player2 = new Player(tony);
            player2.AddPlayerShipBoard(new Board(10));
            LobbyContainer.AddPlayer(player2);
            Assert.AreEqual(player2,LobbyContainer.JoinPlayersWithSameBoardSize(player1));
            Assert.AreEqual(2,LobbyContainer.lobbyContainer.Count);
        }
        /// <summary>
        /// Testea el método añadir una partida al container de partidas
        /// </summary>

        [Test]
        public void AddGameToGameContainer()
        {
            User carol = new User(10,"Carol","Glass");
            Player player1= new Player(carol);
            User tony = new User(11,"Tony","Pereira");
            Player player2 = new Player(tony);
            Game game = new Game(player1, player2);
            GamesContainer.AddGame(game);
            Assert.AreEqual(1,GamesContainer.gamesContainer.Count);
        }
        
        /// <summary>
        /// Testea añadir un Uusario al contenedor de usuarios
        /// </summary>

        [Test]
        public void AddUserToUsersContainer()
        {
            User carol = new User(10,"Carol","Glass");
            UsersContainer.usersContainer.Add(carol);
            Assert.AreEqual(1, UsersContainer.usersContainer.Count);
        }
        /// <summary>
        /// Se testea que no hya otro jugador para unir con 
        /// </summary>

        [Test]
        public void JoinPlayersWithSameBoardSizeNull()
        {
            User tony = new User(11,"Tony","Pereira");
            Player player2 = new Player(tony);
            player2.AddPlayerShipBoard(new Board(15));
            Assert.AreEqual(null,LobbyContainer.JoinPlayersWithSameBoardSize(player2));
        }


        
    }
}