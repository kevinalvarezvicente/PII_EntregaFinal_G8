using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase es la que crea al jugador
    /// </summary>
    public class Player : LibraryException
    {
        /// <summary>
        /// Cada jugador tiene un tablero donde insertará sus barcos
        /// </summary>
        private Board playerShipBoard;
        /// <summary>
        /// Cada jugador tiene un tablero donde irán los tiros
        /// </summary>
        private Board playerShotBoard;
        /// <summary>
        /// El jugador se pone un nombre
        /// </summary>
        private string playerName;
        /// <summary>
        /// Cada jugador tiene una lista de diccionarios
        /// cada diccionario es un barco
        /// </summary>
        private List<Dictionary<(int, int), bool>> shipsList;
        /// <summary>
        /// Constructor de player
        /// </summary>
        /// <param name="user">Recibe como parámetro el usuario ya que en este momento el usuario pasa a ser jugador</param>
        /// <param name="BoardLength">Elige el tamaño del tablero</param>
        public Player(User user, int BoardLength)
        {
            this.playerName = user.Name;
            this.playerShipBoard = new ShipBoard(BoardLength);
            this.playerShotBoard = new ShotBoard(BoardLength);
            this.shipsList = new List<Dictionary<(int, int), bool>>();
        }
        /// <summary>
        /// Permite obtener el tablero de barcos
        /// </summary>
        /// <returns>Retorna una matriz con los barcos agregados</returns>
        public Board GetPlayerShipBoard()
        {
            return this.playerShipBoard;
        }
        /// <summary>
        /// Permite obtener el tablero de tiros
        /// </summary>
        /// <returns>Retorna una matriz con los tiros realizados </returns>
        public Board GetPlayerShotBoard()
        {
            return this.playerShotBoard;
        }
        /// <summary>
        /// Para obtener el nombre del usuario
        /// </summary>
        /// <returns>Retorna el nombre del usuario</returns>
        public string GetPlayerName()
        {
            return this.playerName;
        }
        /// <summary>
        /// Permite al jugador cambiar su nombre
        /// </summary>
        /// <param name="NewName">Recibe un nuevo nombre para el jugador</param>
        private void SetPlayerName(string NewName)
        {
            this.playerName = NewName;
        }
        /// <summary>
        /// Es la lista de barcos formada por diccionarios
        /// </summary>
        public List<Dictionary<(int, int), bool>> ShipsList
        {
            get
            {
                return this.shipsList;
            }

        }
        /// <summary>
        /// Busca la coordenada en la lista de barcos cambiarla a true pues se realizó un disparo
        /// </summary>
        /// <param name="coord">Es una cadena que luego se transforma en (x,y)</param>
        public void SearchForCoordInShipsList(string coord)
        {
            (int x, int y)=Utils.SplitCoordIntoRowAndColumn(coord);
            foreach (Dictionary<(int, int), bool> dict in ShipsList)
            {
                if (dict.ContainsKey((x,y)))
                {
                    dict[(x,y)]=true;
                }
                break;
            }
        }
        /// <summary>
        /// Realiza el shot
        /// </summary>
        /// <param name="coord">Es una cadena que luego se transforma en (x,y)</param>
        public void MakeShot(string coord)
        {
            int x;
            int y;
            (x, y) = Utils.SplitCoordIntoRowAndColumn(coord);
            playerShotBoard.GameBoard[x, y] = "|";
        }

        /// <summary>
        /// Este método hace que el jugador reciba el disparo ubicandolo en el tablero de disparos
        /// Si hay un pipe "|" entonces significa que hubo disparo ahi pero no habia barco
        /// Si hay "x" es porque habia un barco y se disparo
        /// </summary>
        /// <param name="x"> X Es la coordenada x de la posición del disparo en el tablero</param>
        /// <param name="y"> Y Es la coordenada y de la posición del disparo en el tablero</param>
        /// <param name="coord">Es la coordenada que se pasa por parámetro</param>
        public void ReceiveShot(string coord)
        {
            int x;
            int y;
            (x, y) = Utils.SplitCoordIntoRowAndColumn(coord);
            SearchForCoordInShipsList(coord);

            if (GetPlayerShipBoard().GameBoard[x, y].Equals("o"))
            {
                GetPlayerShipBoard().GameBoard[x, y] = "x";
                Console.WriteLine("Barco disparado");
            }
            else if (GetPlayerShipBoard().GameBoard[x, y].Equals("-"))
            {
                Console.WriteLine("Oceano");
                GetPlayerShipBoard().GameBoard[x, y] = "|";
            }
            else if (GetPlayerShipBoard().GameBoard[x, y].Equals("x"))
            {
                Console.WriteLine("Ya fue disparado");
                //algun comando handler 
            }

        }
        /// <summary>
        /// Este método permite saber si un jugador tiene todos sus barcos hundidos.
        /// Retorna true si todos los valores son true
        /// </summary>
        /// <returns>Devuelve un booleano según si todos los barcos del jugador eestán hundidos o no</returns>

        public bool AreAllShipsSinked()
        {
           foreach (Dictionary<(int, int), bool> dict in ShipsList)
            {
                foreach(bool value in dict.Values)
                {
                    if (!value)
                    {
                        return false;
                    }
                }
            }
            return true; 
        }
    }
}
