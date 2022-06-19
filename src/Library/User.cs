using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Class User saves and work with the user information
    /// </summary>
    public class User
    {
        private List<Game> gameHistory;
        private bool wantToPlay;

        public int UserId { get; private set; }
        public string Name { get; private set; }

        public User(int userId, string name)
        {
            this.UserId = userId;
            this.Name = name;
            this.gameHistory = new List<Game>();
        }

        public void WantToPlay()
        {
            Administrator administrator = new Administrator();
            administrator.AddUserToList(this);
        }

        public void AddGameToGameHistory(Game game)
        {
            this.gameHistory.Add(game);
        }

        public List<Game> GetUserGameHistory()
        {
            return this.gameHistory;
        }

    }
}