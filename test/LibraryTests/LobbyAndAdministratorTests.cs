using System.Linq;
using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Se testean los métodos de Lobby y Administrator. Se hacen juntos ya que son clases Singleton
    /// IMPORTANTE: Para correr cada uno se debe descomentar, pues dado que es un singleton, al agregar usuarios a la lista se mentienen alli
    /// </summary>
    public class LobbyAndAdministratorTests
    {
        private User player1;
        private User player2;

        [SetUp]
        public void SetUp()
        {
            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
        }
        [Test]
        public void TestLobby()
        {   
            int expected = 2;
            Singleton<Administrator>.Instance.AddUserToList(player1);
            Singleton<Administrator>.Instance.AddUserToList(player2);
            Assert.AreEqual(expected, Singleton<Lobby>.Instance.GetUsersSearchingGame().Count());
        }

        /*[Test]
        public void TestAreNOTUsersToStartGame()
        {
            bool expected = false;
            Singleton<Administrator>.Instance.AddUserToList(player1);
            Assert.AreEqual(expected,Singleton<Lobby>.Instance.AreUsersToStartGame());
        }*/
        
    }
}   
        
        