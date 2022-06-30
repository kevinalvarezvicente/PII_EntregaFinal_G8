using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    public class ContainerTests
    {
        /// <summary>
        /// Se testean los métodos de Lobby y Administrator. Se hacen juntos ya que son clases Singleton
        /// </summary>

        [Test]
        public void TestAddPlayerToLobby()
        {
            User carol = new User(10,"Carol","Glass");
            Player player1= new Player(carol);
            User tony = new User(11,"Tony","Pereira");
            Player player2 = new Player(tony);
            LobbyContainer.AddPlayer(player1);
            LobbyContainer.AddPlayer(player2);
            Assert.AreEqual(2,LobbyContainer.lobbyContainer.Count);
        }

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
/*
        [Test]
        public void RemoveUser(){
            User carol = new User(10,"Carol","Glass");
            Player player1 = new Player(carol);
            Assert.AreEqual("player1",LobbyContainer.GetPlayerByID(10));
        }
*/

        
    }
}