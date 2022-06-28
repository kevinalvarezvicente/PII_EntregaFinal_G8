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
        private static List<Player> lobbycontainerMaldivas = new List<Player>();
        private static List<Player> lobbycontainerDonbas = new List<Player>();
        private static List<Player> lobbycontainerLaos = new List<Player>();

        /// <summary>
        /// Método para agregar usuario al contenedor
        /// </summary>
        /// <param name="user"></param>
        public static void AddPlayer(Player player, int lobbyType)
        {
            foreach (Player userToCompare in lobbycontainerMaldivas)
            {
                if (userToCompare.Equals(player))
                {
                    throw new ContainerException($"El elemento ya está en la lista");
                }
            }
            foreach (Player userToCompare in lobbycontainerDonbas)
            {
                if (userToCompare.Equals(player))
                {
                    throw new ContainerException($"El elemento ya está en la lista");
                }
            }
            foreach (Player userToCompare in lobbycontainerLaos)
            {
                if (userToCompare.Equals(player))
                {
                    throw new ContainerException($"El elemento ya está en la lista");
                }
            }
            if (lobbyType == 1)
            {
                lobbycontainerMaldivas.Add(player);
            }
            else if (lobbyType == 2)
            {
                lobbycontainerDonbas.Add(player);
            }
            else if (lobbyType == 3)
            {
                lobbycontainerLaos.Add(player);
            }

            /*if(!lobbycontainer.Contains(user))
            {
                lobbycontainer.Add(user);
            }
            else
            {
                throw new ContainerException($"El elemento ya está en la lista");
            }*/
        }
        /// <summary>
        /// Para tener acceso al container de espera
        /// </summary>
        /// <value></value>
        public static List<Player> lobbyMaldivas
        {
            get
            {
                return lobbycontainerMaldivas;
            }
        }
        public static List<Player> lobbyDonbas
        {
            get
            {
                return lobbycontainerDonbas;
            }
        }
        public static List<Player> lobbyLaos
        {
            get
            {
                return lobbycontainerLaos;
            }
        }
        /// <summary>
        /// Quita al usuario, sirve para cuando un usuario comienza a jugar ya no es necesario que este en el lobby
        /// </summary>
        /// <param name="user"></param>
        public static void RemovePlayer(Player player)
        {

            if (lobbycontainerMaldivas.Contains(player))
            {
                lobbycontainerMaldivas.Remove(player);
            }
            else if ((lobbycontainerDonbas.Contains(player)) {
                lobbycontainerDonbas.Remove(player);
            }
            else if ((lobbycontainerLaos.Contains(player)) {
                lobbycontainerLaos.Remove(player);
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
        public static bool ArePlayerToStartGame()
        {
            if (lobbycontainerMaldivas.Count >= 2 || lobbycontainerDonbas.Count >= 2 || lobbycontainerLaos.Count >= 2)
            {
                return true;
            }
            return false;
        }
    }