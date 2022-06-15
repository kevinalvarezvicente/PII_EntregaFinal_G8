using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Class User saves and work with the user information
    /// </summary>
    public class User
    {
        private int userId;
        private string name;
        private List<Game> gameSavedList;
        private bool wantToPlay;

        public int UserId { get; private set; }
        public string Name { get; private set; }
        public List<Game> GameSavedList { get; private set; }

        public User(int userId, string name)
        {
            this.UserId = userId;
            this.Name = name;
        }

        public void WantToPlay()
        {
            this.wantToPlay=true;
        }

    }
}