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
            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            int expected = 2;
            LobbyContainer lobby = new LobbyContainer();
            lobby.AddItem(player1);
            lobby.AddItem(player2);
            Assert.AreEqual(expected,lobby.ContainerList.Count);
        }
        /// <summary>
        /// Test2
        /// </summary>
        [Test]
        public void TestRemoveUserFromLobby()
        {   
            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            int expected = 1;
            LobbyContainer lobby = new LobbyContainer();
            lobby.AddItem(player1);
            lobby.AddItem(player2);
            lobby.RemoveItem(player1);
            Assert.AreEqual(expected,lobby.ContainerList.Count);
        }
        /// <summary>
        /// Test para ver que no es posible iniciar una partida solo con un jugador
        /// </summary>
        [Test]
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
            Singleton<Administrator>.Instance.RegisterUser(1,"Carol");
            int expected = 1;
            Assert.AreEqual(expected,Singleton<UserContainer>.Instance.ContainerList.Count);
        }
        
        
    }
}   
        
        