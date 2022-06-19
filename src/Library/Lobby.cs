using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// La clase Lobby es donde se guardarán los datos de los usuarios que quieren jugar
    /// </summary>
    public class Lobby 
    //: Singleton<Lobby>
    {
        private static Lobby _instance;
        private List<User> UsersSearchingGame;
        public static Lobby Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Lobby();
                }
                return _instance;
            }
        }
        private Lobby()
        {
        }
        /// <summary>
        /// La lista de usuarios esperando para jugar
        /// </summary>

        /*public Lobby()
        {
        }*/
        /// <summary>
        /// Este método chequea que hayan suficiente cantidad de usuarios esperando para jugar
        /// </summary>
        /// <returns> Retorna un booleano tal que si hay mas de 2 usuarios retornará true </returns>
        public bool AreUsersToStartGame() 
        {
            if (UsersSearchingGame.Count>=2)
            {
                return true;
            }
            else
            {
                return false;
                
            }
        }
        /// <summary>
        /// Va a permitir que el acceso a la lista de usuarios esperando por otor jugador
        /// </summary>
        /// <returns>Devuelve la lista</returns>
        /*public List<User> UsersSearchingGame{get; set;}
        public List<User> UsersSearchingGameList
        {
            get
            {
            return this.UsersSearchingGame;
            }
        }*/

        public void AddUserToSearchingGameList(User user)
        {
            UsersSearchingGame.Add(user);
        }
        public void RemoveUserFromSearchingGameList(User user)
        {
            UsersSearchingGame.Remove(user);
        }
        public List<User> GetUsersSearchingGame()
        {
            return UsersSearchingGame;
        }
        public int CountUsersSearchingForGame()
        {
            return UsersSearchingGame.Count;
        }

    }
}