using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Class User guarda y trabaja con la información del usuario
    /// </summary>
    public class User
    {
        /// <summary>
        /// Es una lista donde se guardarán los juegos del jugador
        /// </summary>
        private List<Game> gameHistory;
        /// <summary>
        /// Es el ID de usuario
        /// </summary>
        /// <value>Cada usuario tiene el suyo</value>
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
            this.UserId = userId;
            this.Name = name;
            this.gameHistory = new List<Game>();
        }
        /// <summary>
        /// El método dice si el usuario quiere jugar llama al administrador para que lo agregue a la lista
        /// </summary>
        public void WantToPlay()
        {
            Lobby.Instance.AddUserToSearchingGameList(this);
        }
        /// <summary>
        /// Añade el juego al historial de juegos del usuario
        /// </summary>
        /// <param name="game">Es un parámetro de tipo Game</param>
        public void AddGameToGameHistory(Game game)
        {
            this.gameHistory.Add(game);
        }
        /// <summary>
        /// Se obtiene el historial de partidas del usuario con la propiedad GameHistory
        /// </summary>
        /// <returns>Devuelve una lista de Game que son partidos jugados por el usuario</returns>
        public List<Game> GameHistory
        {
            get
            {
                return this.gameHistory;
            }
            
        }

    }
}