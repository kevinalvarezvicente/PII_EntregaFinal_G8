using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Class User guarda y trabaja con la información del usuario
    /// Es experta en la información del usuario
    /// Cumple (LCHC) Low Coupling and High Cohesion
    /// Hace lo mínimo necesario como almacenar la información del usuario y delega todo lo demás 
    /// Es altamente cohesiva porque lo poco que hace está sumamente relacionado, pero tiene muchas relaciones con otras clases, con lo cual va a estar muy acoplada.
    /// </summary>
    public class User
    {
        private int userId;
        private string name;
        private List<Game> gameHistory;
        private bool wantToPlay;

        public int UserId { get; private set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        /// <value></value>
        public string Name { get; private set; }
        /// <summary>
        /// El constructor de Usuario crea una Lista de juegos del usuario
        /// </summary>
        /// <param name="userId">Es de tipo int</param>
        /// <param name="name">Es de tipo int</param>
        public User(int userId, string name)
        {
            this.userId = userId;
            this.name = name;
            this.gameHistory = new List<Game>();
        }
        /// <summary>
        /// El método dice si el usuario quiere jugar llama al lobby para que lo agregue a la lista
        /// </summary>
        public void WantToPlay()
        {
            Lobby lobby = new Lobby();
            lobby.AddUserToList(this);
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