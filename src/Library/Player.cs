﻿using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase es la que crea al jugador. 
    /// Cumple patron expert ya que es la que contiene la información de:
    /// Los tableros
    /// Usuario
    /// Barcos y sus posiciones
    /// Hace tiro
    /// recibe tiro como jugador inactivo
    /// Ubica los barcos
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
        /// Cada jugador tiene una lista de listas. Cada lista interna representa las posiciones del barco.
        /// Polimórfica, puede contener Submarine, LightCruiser, Frigate
        /// </summary>
        private List<Ship> shipsList = new List<Ship>();
        /// <summary>
        /// Constructor de player. 
        /// Se utiliza patrón creator para crear instancia del tablero de tiros y de barcos del jugador
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
        /// Es la lista de barcos formada por diccionarios.
        /// En tiempo de ejecución, los objetos de una clase derivada (como Submarine, LightCruiser o Frigate) pueden ser
        /// tratados como objetos de la clase base Ship
        /// </summary>
        public List<Ship> ShipsList
        {
            get
            {
                return this.shipsList;
            }

        }
        /// <summary>
        /// Busca la coordenada en la lista de barcos cambiarla a true pues se realizó un disparo
        /// Devuelve true una vez que cambio el valor del Spot
        /// No funciona este método aún falta arreglarlo
        /// </summary>
        /// <param name="coord">Es una cadena que luego se transforma en (x,y)</param>
        public bool SearchForCoordInShipsList(string coord)
        {
            (int x, int y)=Utils.SplitCoordIntoRowAndColumn(coord);
            Spot spot = new Spot(x,y);
            foreach (Ship ship in ShipsList)
            {
                if (ship.CoordsList.Contains(spot))
                {
                    int index = ship.CoordsList.IndexOf(spot);
                    ship.CoordsList[index].wasHit=true;
                    return true;
                }
            }
            return false;
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
           foreach (Ship ship in ShipsList)
            {
                foreach(Spot spot in ship.CoordsList)
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
        /// En tiempo de ejecución, los objetos de una clase derivada (como Submarine, LightCruiser o Frigate) pueden ser
        /// tratados como objetos de la clase base Ship
        /// </summary>
        /// <param name="ship">Es de tipo Ship pero se pasa por parametro cualquier subtipo de Ship</param>
        public void PlaceShipOnBoard(Ship ship)
        {
                foreach (Spot spot in  ship.CoordsList)
                {
                    this.PlayerShipBoard.GameBoard[spot.X,spot.Y] = "o";
                    
                }
                ShipsList.Add(ship);
        }

        /// <summary>
        /// Este método agrega el barco creado en la posición a una lista de barcos del jugador
        /// Operación polimórfica 
        /// En tiempo de ejecución, los objetos de una clase derivada (como Submarine, LightCruiser o Frigate) pueden ser
        /// tratados como objetos de la clase base Ship
        /// </summary>
        /// <param name="ship">El barco a agregar a la lista de barcos del jugador</param>
        public void AddShipToPlayerShipList(Ship ship)
        {
            ShipsList.Add(ship);
        }
    }
}
