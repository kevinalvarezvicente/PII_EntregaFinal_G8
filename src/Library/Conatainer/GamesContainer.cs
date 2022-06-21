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
        /// <typeparam name="Game"> La lista es de elementos de tipo Game</typeparam>
        /// <returns></returns>
        private static List<Game> gamescontainer = new List<Game>();
        /// <summary>
        /// Se añade el juego
        /// </summary>
        /// <param name="game">Es un parámetro de tipo Game</param>
        public static void AddGame(Game game)
        {
            if(!gamescontainer.Contains(game))
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
        public static void RemoveUser(Game game)
        {
            
            if(gamescontainer.Contains(game))
            {
               gamescontainer.Remove(game);
            }
            else
            {
                throw new ContainerException($"El elemento ya está en la lista");
            }
        }

        /*public static List<string> SearchGameByID(int ID)
        {
            for (int i = 0; i<gamescontainer.Count; i++)
            {
                if (ID==gamescontainer[i].GameId)
                {
                    List<T> list = new List<T>()
                                                {
                                                    gamescontainer[i].Date,
                                                    gamescontainer[i].,
                                                };
                    return list;
                }
                else
                {
                    throw new ContainerException("No se ha encontrado el usuario");
                }
            }
        }*/
        
    }
}