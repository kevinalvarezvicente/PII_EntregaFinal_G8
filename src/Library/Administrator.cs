using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase cumple el rol de administrador.
    /// Es un singleton ya que solo existirá un administrador y se lo puede llamar desde distintas clases
    /// </summary>
    public class Administrator: Singleton<Administrator>
    {
        /// <summary>
        /// Crea un diccionario cuya clave es el id y el valor es el nombre
        /// </summary>
        
        private Dictionary<int,string> allUsers = new Dictionary<int, string>();
        /*private static Administrator _instance; 
        public static Administrator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Administrator();
                }
                return _instance;
            }
        }*/
        /// <summary>
        /// Se crea una instancia de clase
        /// </summary>
        //public Administrator _administrator;
        /// <summary>
        /// Se crea Lobby donde los usuarios aguardan para comenzar a jugar, el cual será Singleton
        /// </summary>
        /// <returns></returns>
        //Lobby lobby = new Lobby();

        /// <summary>
        /// El método JoinUsersToPlay permite unir a dos Usuarios que esten esperando para jugar e inicia una partida Game
        /// Como ya ambos usuarios comenzaron a jugar y se transformaron en jugadores los quita del lobby de espera
        /// </summary>
        /// <param name="user1">Usuario que comenzará el juego</param>
        /// <param name="user2">Uusario contrario</param>
        public void JoinUsersToPlay(User user1, User user2)
        {
            Console.WriteLine($"Jugarán {user1.Name} contra {user2.Name}");
            Console.WriteLine($"{user1.Name} indique el tamaño del tablero");
            int boardLength = Console.Read();
            Game game = new Game(user1, user2, boardLength);
            RemoveUserFromList(user1);
            RemoveUserFromList(user2);
        }
        /// <summary>
        /// Este método une a los usuarios usando JoinUsersToPlay
        /// toma los dos primeros usuarios en el lobby una vez que se comprueba que hay mas de un usuario esperando por una partida
        /// </summary>
        public void StartGame()
        {
            if (Singleton<Lobby>.Instance.AreUsersToStartGame())
            {
                JoinUsersToPlay(Singleton<Lobby>.Instance.GetUsersSearchingGame()[0], Lobby.Instance.GetUsersSearchingGame()[1]);
            }
        }

        /// <summary>
        /// Se agrega el usuario a la lista de usuarios esperando para jugar
        /// </summary>
        /// <param name="user">El parámetro es de tipo user</param>
        /*public void AddUserToList(User user)
        {
            Lobby.Instance.AddUserToSearchingGameList(user);

        }*/

        /// <summary>
        /// Se quita el usuario de la lista una vez que se arma una partida
        /// </summary>
        /// <param name="user">El parámetro es de tipo user</param>
        public void RemoveUserFromList(User user)
        {
            Lobby.Instance.RemoveUserFromSearchingGameList(user);
        }

        public void EndGame(Game game)
        {
            if (game.GameFinished())
            {
                Console.Write("La partida ha finalizado");
            }
        }

        public void RegisterUser(int id, string name)
        {
            foreach (int identificator in allUsers.Keys)
            {
                if (identificator!=id)
                {
                    User user= new User(id,name);
                    this.allUsers.Add(user.UserId,user.Name);
                }

            }
        }


    }
}