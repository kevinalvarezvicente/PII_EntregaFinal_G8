using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Lobby : Singleton<Lobby>
    {
        /// <summary>
        ///  bshjh 
        /// </summary>
        private List<User> usersSearchingGame;
        public void AddUserToList(User user)
        {
            try
            {
                this.usersSearchingGame.Add(user);
            }
            catch
            {
                throw new LibraryException("Error al añadir el usuario a Lobby de espera");
            }

        }

        public void RemoveUserFromList(User user)
        {
            try
            {
                this.usersSearchingGame.Remove(user);
            }
            catch
            {
                throw new LibraryException("Error al remover el usuario de Lobby de espera");
            }
        }

        public bool AreUsersToStartGame()
        {
            if (this.usersSearchingGame.Count>=2)
            {
                return true;
            }
            else
            {
                return false;
                Console.WriteLine("No hay aún otro usuario esperando para jugar");
            }
        }

        public List<User> GetUsersSearchingForGameList()
        {
            return this.usersSearchingGame;
        }


    }
}