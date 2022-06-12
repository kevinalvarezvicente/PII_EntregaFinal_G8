using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    ///  
    /// </summary>
    public class Lobby : Singleton<Lobby>
    {
        private List<User> usersSearchingGame;
        /// <summary>
        ///  
        /// </summary>
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
        /// <summary>
        ///  
        /// </summary>
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



    }
}