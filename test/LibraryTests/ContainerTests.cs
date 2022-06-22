using System.Linq;
using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Se testean los métodos de Lobby y Administrator. Se hacen juntos ya que son clases Singleton
    /// IMPORTANTE: Para correr cada uno se debe descomentar, pues dado que es un singleton, al agregar usuarios a la lista se mentienen alli
    /// </summary>
    public class ContainerTests
    {

        [SetUp]
        public void SetUp()
        {
        }
        /// <summary>
        /// Se realiza Test1
        /// </summary>
        [Test]
        public void TestAddUserToLobby()
        {
            User player1 = new User("Carol","Glass");
            User player2 = new User("Tony","Pereira");
            LobbyContainer.AddUser(player1);
            LobbyContainer.AddUser(player2);
            Assert.AreEqual(2,LobbyContainer.lobbyContainer.Count);
        }
        /// <summary>
        /// Test2
        /// </summary>
        [Test]
        public void TestRemoveUserFromLobby()
        {   
            User player1 = new User("Carol","Glass");
            User player2 = new User("Tony","Pereira");
            LobbyContainer.AddUser(player1);
            LobbyContainer.AddUser(player2);
            LobbyContainer.RemoveUser(player1);
            Assert.AreEqual(1,LobbyContainer.lobbyContainer.Count);
        }
        /// <summary>
        /// Test para ver que no es posible iniciar una partida solo con un jugador
        /// </summary>
        /*[Test]
        public void TestAreNOTUsersToStartGame()
        {
            LobbyContainer lobby = new LobbyContainer();
            bool expected = false;
            Assert.AreEqual(expected,lobby.AreUsersToStartGame());
        }
        /// <summary>
        /// Test para chequear que queda un usuario registrado
        /// </summary>
        [Test]
        public void TestRegisterUser()
        {
            Singleton<Administrator>.Instance.RegisterUser("Carol","Glass");
            Singleton<Administrator>.Instance.RegisterUser("Matias","Olave");
            int expected = 2;
            Assert.AreEqual(expected,Singleton<UserContainer>.Instance.ContainerList.Count);
        }
        /*[Test]
        public void TestUserWantToPlayer()
        {
            User carol = new User("Carol","Glass");
            carol.WantToPlay();
            Assert.AreEqual(1,Singleton<LobbyContainer>.Instance.ContainerList.Count);
        }*/

        /*[Test]
        public void TestStartGame()
        {
            User juan = new User("Juan","Gomez");
            juan.WantToPlay();
            Singleton<Administrator>.Instance.StartGame();
            Assert.AreEqual(0,Singleton<LobbyContainer>.Instance.ContainerList.Count);
        }*/
        
        
    }
}   
        
        