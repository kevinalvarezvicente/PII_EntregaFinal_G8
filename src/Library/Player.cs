﻿using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase es la que crea al jugador. 
    /// </summary>
    public class Player 
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
        private List<List<Spot>> shipsList = new List<List<Spot>>();
        /// <summary>
        /// Constructor de player. Se utiliza patrón creator para crear instancia del tablero de tiros y de barcos del jugador
        /// Cada jugador tiene su propio tablero.
        /// </summary>
        /// <param name="user">Recibe como parámetro el usuario ya que en este momento el usuario pasa a ser jugador</param>
        /// <param name="BoardLength">Elige el tamaño del tablero</param>
        public Player(User user, int BoardLength)
        {
            this.playerName = user.Name;
            this.playerShipBoard = new ShipBoard(BoardLength);
            this.playerShotBoard = new ShotBoard(BoardLength);

        }
        /// <summary>
        /// Se obtiene el tablero de barcos a través de la propiedad PlayerShipBoard 
        /// </summary>
        /// <returns>Retorna una matriz con los barcos agregados</returns>
        public Board PlayerShipBoard
        {
            get
            {
                return this.playerShipBoard;
            }
            
        }
        /// <summary>
        /// Se obtiene el tablero de tiros a través de la propiedad PlayerShotBoard
        /// </summary>
        /// <returns>Retorna una matriz con los tiros realizados </returns>
        public Board PlayerShotBoard
        {
            get
            {
                return this.playerShotBoard;
            }
            
        }
        /// <summary>
        /// Se obtiene el nombre del jugador a través de la propiedad PlayerName
        /// </summary>
        /// <returns>Retorna el nombre del usuario</returns>
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            
        }
        /// <summary>
        /// Permite al jugador cambiar su nombre
        /// </summary>
        /// <param name="NewName">Recibe un nuevo nombre para el jugador</param>
        private void ChangePlayerName(string NewName)
        {
            this.playerName = NewName;
        }
        /// <summary>
        /// Es la lista de barcos formada por diccionarios
        /// </summary>
        public List<List<Spot>> ShipsList
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
            Spot spot = new Spot(x,y);
            foreach (List<Spot> list in ShipsList)
            {
                if (list.Contains(spot))
                {
                    spot.wasHit=true;
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
            playerShotBoard.GameBoard[x, y] = "X";
        }

        /// <summary>
        /// Este método hace que el jugador reciba el disparo ubicandolo en el tablero de disparos
        /// Si hay un pipe "|" entonces significa que hubo disparo ahi pero no habia barco
        /// Si hay "x" es porque habia un barco y se disparo
        /// </summary>
        /// <param name="coord">Es la coordenada que se pasa por parámetro</param>
        public void ReceiveShot(string coord)
        {
            int x;
            int y;
            (x, y) = Utils.SplitCoordIntoRowAndColumn(coord);
            SearchForCoordInShipsList(coord);

            if (this.playerShipBoard.GameBoard[x, y].Equals("o"))
            {
                this.playerShipBoard.GameBoard[x, y] = "x";
                Console.WriteLine("Tocado");
            }
            else if (this.playerShipBoard.GameBoard[x, y].Equals("-"))
            {
                Console.WriteLine("Agua");
                this.playerShipBoard.GameBoard[x, y] = "|";
            }
            else if (this.playerShipBoard.GameBoard[x, y].Equals("x"))
            {
                throw new ReceiveShotException("Ya disparo a esta coordenada");
            }

        }
        /// <summary>
        /// Este método permite saber si un jugador tiene todos sus barcos hundidos.
        /// Retorna true si todos los valores son true
        /// </summary>
        /// <returns>Devuelve un booleano según si todos los barcos del jugador eestán hundidos o no</returns>
        public bool AreAllShipsSinked()
        {
           foreach (List<Spot> list in ShipsList)
            {
                foreach(Spot spot in list)
                {
                    if (spot.wasHit==false)
                    {
                        return false;
                    }
                }
            }
            return true; 
        }
        /// <summary>
        /// Operación polimórifca que ubica el barco en el tablero.
        /// </summary>
        /// <param name="ship">Es de tipo Ship pero se pasa por parpametro cualquier subtipo de Ship</param>
        public void PlaceShipOnBoard(Ship ship)
        {
                foreach (Spot spot in  ship.CoordsList)
                {
                    this.PlayerShipBoard.GameBoard[spot.X,spot.Y] = "o";
                    
                }
        }

        /// <summary>
        /// Este método agrega el barco creado en la posición a una lista de barcos del jugador
        /// </summary>
        /// <param name="player">El dueño de la lista de barcos</param>
        /// <param name="ship">El barco a agregar a la lista de barcos del jugador</param>
        public void AddShipToPlayerShipList(Ship ship)
        {
            ShipsList.Add(ship.CoordsList);
        }
    }
}
