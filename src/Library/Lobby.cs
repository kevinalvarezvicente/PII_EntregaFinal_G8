using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// La clase Lobby es donde se guardarán los datos de los usuarios que quieren jugar
    /// </summary>
    public class Lobby : Singleton<Lobby>
    {
        /// <summary>
        /// La lista de usuarios esperando para jugar
        /// Es estatica para poder acceder a ella desde todos lados
        /// </summary>
        private List<User> usersSearchingGame;
        /// <summary>
        /// Este método chequea que hayan suficiente cantidad de usuarios esperando para jugar
        /// </summary>
        /// <returns> Retorna un booleano tal que si hay mas de 2 usuarios retornará true </returns>
        public bool AreUsersToStartGame() 
        {
            if (usersSearchingGame.Count>=2)
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
        public List<User> UsersSearchingForGameList
        {
            get 
            {
                return this.usersSearchingGame;
            }
            
        }

        public int CountUsersSearchingForGame()
        {
            return this.usersSearchingGame.Count;
        }

    }
}