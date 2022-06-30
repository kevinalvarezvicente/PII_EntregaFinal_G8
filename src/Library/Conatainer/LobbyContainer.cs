using System.Collections.Generic;


namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase estatica para no tener que instanciar en cada momento
    /// SRP unico motivo de cambio es si en vez de querer guardar Players tengo que guardar Users solo cambia los parámetros a pasar
    /// </summary>
    public static class LobbyContainer
    {
        /// <summary>
        /// Se instancia una lista para usuarios que quieren esperar para jugar
        /// </summary>
        /// <returns></returns>
        private static List<Player> lobbycontainer = new List<Player>();
        /// <summary>
        /// Método para agregar usuario al contenedor
        /// </summary>
        /// <param name="player">Recibe por parámetro un jugador para agrgar a lobby</param>
        public static void AddPlayer(Player player)
        {
            foreach (Player playerToCompare in lobbycontainer)
            {
                if (playerToCompare.Equals(player))
                {
                    throw new ContainerException($"El jugador ya está en la lista");
                }
            }
            lobbycontainer.Add(player);



        }
        /// <summary>
        /// Para tener acceso al container de espera
        /// </summary>
        /// <value></value>
        public static List<Player> lobbyContainer
        {
            get
            {
                return lobbycontainer;
            }
        }
        /// <summary>
        /// Quita al jugador, sirve para cuando un jugador comienza a jugar ya no es necesario que este en el lobby
        /// </summary>
        /// <param name="player"></param>
        public static void RemoveUser(Player player)
        {

            if (lobbycontainer.Contains(player))
            {
                lobbycontainer.Remove(player);
            }
            else
            {
                throw new ContainerException($"El jugador no está en la lista");
            }
        }
        /// <summary>
        /// Retorna un booleanos si hay suficientes usuarios para comenzar un juwgo
        /// </summary>
        /// <returns></returns>
        public static bool AreUsersToStartGame()
        {
            if (lobbycontainer.Count >= 2)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        /// <summary>
        /// Une a los jugadores con el mismo tamaño de tablero elegido
        /// </summary>
        /// <param name="player">Recibe por parámetro un jugador</param>
        /// <returns>Retorna el jugador cuyo tablero coincide con el del jugador pasado por parámetro</returns>
        public static Player JoinPlayersWithSameBoardSize(Player player)
        {
            for (int i = 0; i < lobbycontainer.Count; i++)
            {
                if (lobbycontainer[i].GetPlayerBoardSize() == player.GetPlayerBoardSize() && lobbycontainer[i].UserId != player.UserId)
                {
                    return lobbycontainer[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Metodo que busca al jugador en el lobby por su ID
        /// </summary>
        /// <param name="ID">Identificador del jugador</param>
        /// <returns>Retorna el jugador que coincide con el ID o larga Excepcion</returns>

        public static Player GetPlayerByID(long ID)
        {
            for (int i = 0; i < lobbycontainer.Count; i++)
            {

                if (ID == lobbycontainer[i].UserId)
                {

                    return lobbycontainer[i];
                }
            }
            throw new ContainerException("No se encontro player id");
        }

    }
}