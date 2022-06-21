using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// CLASE SIN FUNCIONAR AUN
    /// Subclase de Container donde se almacenarán todas las partidas
    /// Cumple SRP (Single Responsibility Principle) cuya única responsabilidad es almacenar todas las partidas jugadas
    /// </summary>
    /*public class GamesContainer
    {
        List<Game> GamesContainerList =Singleton<List<Game>>.Instance;
        public void AddGame(Game game)
        {
            try
            {
                GamesContainerList.Add(game);
            }
            catch
            {
                throw new ContainerException("Error al añadir la partida");
            }
        }
        public Game SearchGameByID(int ID)
        {
            for (int i = 0; i<GamesContainerList.Count;i++)
            {
                if (ID==GamesContainerList[i].GameId)
                {
                    return GamesContainerList[i];
                }
                else
                {
                    throw new ContainerException("No se ha encontrado a la partida");
                }
            }

        }
        public Game SearchGameByDate(DateTime date)
        {
            for (int i = 0; i<GamesContainerList.Count; i++)
            {
                if (date.Equals(GamesContainerList[i].Date))
                {
                    return GamesContainerList[i];
                }
                else
                {
                    throw new ContainerException("No se ha encontrado a la partida");
                }
            }
        }            
        
    }*/
}