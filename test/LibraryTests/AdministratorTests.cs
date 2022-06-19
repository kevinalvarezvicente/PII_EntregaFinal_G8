using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    public class AdministratorTests
    {
        private User player1;
        private User player2;
        private Game game1;
        [SetUp]
        public void Setup()
        {
            this.player1 = new User(1, "Carol");
            this.player2 = new User(2, "Tony");
            this.game1 = new Game(player1, player2, 10);

        }

        [Test]
        public void TestLobby()
        {
            Administrator.Instance.AddUserToList(player1);
            Administrator.Instance.AddUserToList(player2);
            Assert.AreEqual(2, Lobby.Instance.CountUsersSearchingForGame());
        }
        [Test]
        public void TestJoinPlayers()
        {
            
        }
    }
}
