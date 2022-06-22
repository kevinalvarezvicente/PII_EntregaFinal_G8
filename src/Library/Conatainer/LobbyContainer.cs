using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase estatica para no tener que instanciar en cada momento
    /// SRP unico motivo de cambio es si en vez de querer guardar Users tengo que guardar Players solo cambia los parámetros a pasar
    /// </summary>
    public static class LobbyContainer
    {
        /// <summary>
        /// Se instancia una lista para usuarios que quieren esperar para jugar
        /// </summary>
        /// <returns></returns>
        private static List<User> lobbycontainer = new List<User>();
        /// <summary>
        /// Método para agregar usuario al contenedor
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(User user)
        {
            if(!lobbycontainer.Contains(user))
            {
                lobbycontainer.Add(user);
            }
            else
            {
                throw new ContainerException($"El elemento ya está en la lista");
            }

            
        }
        /// <summary>
        /// Para tener acceso al container de espera
        /// </summary>
        /// <value></value>
        public static List<User> lobbyContainer
        {
            get
            {
                return lobbycontainer;
            }
        }
        /// <summary>
        /// Quita al usuario, sirve para cuando un usuario comienza a jugar ya no es necesario que este en el lobby
        /// </summary>
        /// <param name="user"></param>
        public static void RemoveUser(User user)
        {
            
            if(lobbycontainer.Contains(user))
            {
                lobbycontainer.Remove(user);
            }
            else
            {
                throw new ContainerException($"El elemento no está en la lista");
            }
        }
        /// <summary>
        /// Retorna un booleanos si hay suficientes usuarios para comenzar un juwgo
        /// </summary>
        /// <returns></returns>
        public static bool AreUsersToStartGame() 
        {
            if (lobbycontainer.Count>=2)
            {
                return true;
            }
            else
            {
                return false;
                
            }
        } 
        
    }
}