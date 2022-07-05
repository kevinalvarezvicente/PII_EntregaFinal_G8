using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase estatica para no tener que instanciar en cada momento
    /// Es Expert porque conoce toda la informacion de los juegos cumpliendo su tarea de agregar, eliminar o mostrar la informacion
    /// </summary>
    public static class GamesContainer
    {
        /// <summary>
        /// Una lista de juegos en general 
        /// </summary>    
        private static List<Game> gamescontainer = new List<Game>();

        /// <summary>
        /// Se añade el juego
        /// </summary>
        /// <param name="game">Es un parámetro de tipo Game</param>
        public static void AddGame(Game game)
        {
            if (!gamescontainer.Contains(game))
            {
                gamescontainer.Add(game);
            }
            else
            {
                throw new ContainerException($"El elemento ya está en la lista");
            }


        }
        /// <summary>
        /// Es el operador para tener acceso a la lista de juegos
        /// </summary>
        /// <value></value>
        public static List<Game> gamesContainer
        {
            get
            {
                return gamescontainer;
            }
        }
        /// <summary>
        /// Saca el juego de la lista
        /// </summary>
        /// <param name="game">Tipo Game es el parámetro</param>
        public static void RemoveGame(Game game)
        {

            if (gamescontainer.Contains(game))
            {
                gamescontainer.Remove(game);
            }
            else
            {
                throw new ContainerException($"El elemento ya está en la lista");
            }
        }

        /// <summary>
        /// Verifica el Usuario en el juego
        /// </summary>
        /// <param name="ID">Es el Identificador del usuario</param>
        /// <returns>Devuelve el ID si es que el usuario esta en el juego</returns>

        public static Game VerifyUserOnGame(long ID)
        {
            for (int i = 0; i < GamesContainer.gamesContainer.Count; i++)
            {
                for (int x = 0; x <= GamesContainer.gamesContainer[i].PlayersList.Count; x++)
                {
                    if (GamesContainer.gamesContainer[i].PlayersList[x].UserId == ID)
                    {
                        return GamesContainer.gamesContainer[i];
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Método para obtener el iD del oponente
        /// </summary>
        /// <param name="ID">Es el identificador del oponente</param>
        /// <returns>retorna un long porque es el id de telegram</returns>
        public static long ObtainEnemyId(long ID)
        {
            for (int i = 0; i < GamesContainer.gamesContainer.Count; i++)
            {
                List<Player> UsersPlaying = GamesContainer.gamesContainer[i].PlayersList;
                foreach (Player player in UsersPlaying)
                {
                    if (player.UserId != ID)
                    {
                        return player.UserId;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Método para obtener el juego según el ID del jugador
        /// </summary>
        /// <param name="ID">Es el ID del jugador obtenido de telegram</param>
        /// <returns>Retorna el juego</returns>

        public static Player ObtainPlayer(long ID)
        {
            for (int i = 0; i < GamesContainer.gamesContainer.Count; i++)
            {
                List<Player> UsersPlaying = GamesContainer.gamesContainer[i].PlayersList;
                foreach (Player player in UsersPlaying)

                {
                    if (player.UserId == ID)
                    {
                        return player;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Método para obtener la partida segun el ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        public static Game ObtainGame(long ID)
        {
            foreach (Game game in gamescontainer)
            {
                if (game.GameId == ID)
                {
                    return game;
                }
            }
            return null;
        }
    }
}