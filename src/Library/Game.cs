﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Aca se encuentran todos los métodos relacionados con el juego en general.
    /// La clase Game cumple con Expert siendo ésta  la clase que tiene toda la información para iniciar una partida
    /// la información necesaria para poder cumplir con la lógica del programa. 
    /// - Hacer los tiros en los tableros de ambos jugadores
    /// - Ubicar barcos
    /// - Indicar si finalizó la partida
    /// Cumple Creator ya que tiene responsabilidad de crear instancias de:
    /// - Player
    /// - Ship (Cualquier tipo)
    /// </summary>
    public class Game: IJsonConvertible
    {
        
        /// <summary>
        ///El campo estático currentID almacena el ID de usuario de la última persona que ha sido creado.
        /// </summary>
        private static int currentGameID;
        /// <summary>
        /// Es el ID del juago y es unico
        /// </summary>
        /// <value>Cada usuario tiene el suyo</value>
        public int GameId { get; private set; }
        /// <summary>
        /// Cada partida se guarda con la fecha de comienzo
        /// </summary>
        public DateTime Date { get; private set; }
        /// <summary>
        /// El Active_Player es el jugador con el turno, comienza él siempre
        /// Es el que está primero en la lista de Lobby de espera, o sea el primero que llego
        /// </summary>
        private Player active_Player = null;
        private Player inactive_Player = null;
        public Player Active_Player
        {
            get
            {
                return this.active_Player;
            }
            set
            {
                this.active_Player = value;
            }
        }
        /// <summary>
        /// El Inactive_Player es el jugador que espera a que sea su turno
        /// </summary>
        public Player Inactive_Player
        {
            get
            {
                return this.inactive_Player;
            }
            set
            {
                this.inactive_Player = value;
            }
        }


        /// <summary>
        /// Para guardar la partida se guardará una lista con los usuarios que la jugaron.
        /// Usuarios que jugarán la partida. Tiene solo get porque no va a cambiar en ningun momento. 
        /// </summary>
        private List<Player> playersList = new List<Player>();
        public List<Player> PlayersList
        {
            get
            {
                return this.playersList;
            }

        }
        /// <summary>
        /// Este atributo dice si el juego finalizó o no
        /// </summary>
        /// <value>Es un valor booleano</value>
        public bool GameStatus { get; set; }
        /// <summary>
        /// Se inicia el juego con el constructor de la clase
        /// Recibe como argumento todos los datos necesarios para crear instancia de Player transformando a un usuario en player
        /// </summary>
        /// <param name="player1">Será el jugador que inicia todo</param>
        /// <param name="player2"></param>
        public Game(Player player1, Player player2)
        {
            GetNextGameID();
            this.GameStatus = default;
            this.GameId = currentGameID;
            this.Date = DateTime.Now;
            this.active_Player = player1;
            this.Inactive_Player = player2;
            this.playersList.Add(player1);
        }

        /// <summary>
        /// Constructor estático para inicializar el miembro estático, currentID. 
        /// Este se llama al constructor una vez, automáticamente, antes de cualquier instancia User se crea, o se hace referencia a currentID.
        /// </summary>
        static Game() => currentGameID = 0;

        /// <summary>
        /// currentID es un campo estático. 
        /// </summary>
        /// <returns>Se incrementa cada vez que una nueva se crea una instancia de Person.</returns>

        protected int GetNextGameID() => ++currentGameID;

        /// <summary>
        /// Este método permite al jugador hacer el tiro y al jugador opuesto recibirlo tal que lo que ve cada jugador será distinto en cuanto a los barcos.
        /// No se debe modificar un tablero, sino que se modificará el tablero respectivo a cada jugador
        /// </summary>
        /// <param name="coord">coordenada string que luego se transformará en (x,y)</param>
        public void ShotMade(string coord)
        {
            Console.WriteLine($"{Active_Player.PlayerName} hace el disparo a {Inactive_Player.PlayerName}");
            try
            {
                Active_Player.MakeShot(coord);
                Inactive_Player.ReceiveShot(coord);
            }
            catch
            {
                throw new CoordException("Las coordenadas estan fuera de rango.");
            }

            Console.WriteLine($"Ahora es el turno de {Active_Player.PlayerName} de realizar el tiro");

        }

        /// <summary>
        /// Este método agrega el barco en el Tablero de barcos
        /// Si el barco que se desea agregar no cumple con el rango habilitado por el tablero tira una excepción
        /// </summary>
        /// <param name="shipOption">Es la opción prederminada del barco a elegir</param>
        /// <param name="coord">Es un string de dos cifras que se divide en dos numeros enteros</param>
        /// <param name="direction">Las opciones son vertical u horizontal</param>
        public void PlaceShip(int shipOption, string coord, string direction)
        {
            int x;
            int y;
            (x, y) = Utils.SplitCoordIntoRowAndColumn(coord);

            ChooseShipOption(shipOption, coord, direction);
            Console.WriteLine($"Se ubican los barcos de {this.Active_Player.PlayerName} y se imprime tablero");

        }
        /// <summary>
        /// Es un método que al recibir la posicion del barco la pone en el board.
        /// Recibe como argumento todos los datos necesarios para crear instancia de los subtipos de Ship
        /// </summary>
        /// <param name="option">Es un entero, hay solo 3 opciones de barco </param>
        /// <param name="coord">Es una cadena que indica la coordenada inicial del barco</param>
        /// <param name="direction">Es una cadena que recive v o h</param>
        public void ChooseShipOption(int option, string coord, string direction)
        {
            switch (option)
            {
                case 1:
                    Ship shipFrigate = new Frigate(coord, direction);
                    this.Active_Player.PlaceShipOnBoard(shipFrigate);
                    this.Active_Player.AddShipToPlayerShipList(shipFrigate);
                    break;

                case 2:
                    Ship shipLightCruiser = new LightCruiser(coord, direction);
                    this.Active_Player.PlaceShipOnBoard(shipLightCruiser);
                    this.Active_Player.AddShipToPlayerShipList(shipLightCruiser);
                    break;

                case 3:
                    Ship shipSubmarine = new LightCruiser(coord, direction);
                    this.Active_Player.PlaceShipOnBoard(shipSubmarine);
                    this.Active_Player.AddShipToPlayerShipList(shipSubmarine);
                    break;

                default:
                    throw new OptionException("Solo tiene 3 opciones de nave.");

            }
        }

        /// <summary>
        /// Este método permite saber si un jugador tiene todos sus barcos hundidos.
        /// Retorna true si todos los valores son true
        /// </summary>
        /// <returns>Devuelve un booleano según si todos los barcos del jugador eestán hundidos o no</returns>

        public bool AreAllShipsSinked(Player player)
        {
            foreach (Ship ship in player.ShipsList)
            {
                foreach (Spot spot in ship.CoordsList)
                {
                    if (spot.wasHit == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Método que chequea que todos los barcos de alguno de los jugadores estén hundidos
        /// </summary>
        /// <returns>Retorna true o false para finalizar el juego</returns>
        public bool GameFinished()
        {

            if (AreAllShipsSinked(this.Inactive_Player) || AreAllShipsSinked(this.Active_Player))
            {
                this.GameStatus = true;
                return this.GameStatus;
            }
            return this.GameStatus;
        }


        public List<string> TransformGameToList()
        {
            List<string> gameInfo= new List<string>();
            gameInfo.Add(this.GameStatus.ToString());
            gameInfo.Add(this.GameId.ToString());
            gameInfo.Add(this.Date.ToString());
            gameInfo.Add(this.active_Player.ToString());
            gameInfo.Add(this.active_Player.PlayerBoardsList.ToString());
            gameInfo.Add(this.Inactive_Player.PlayerBoardsList.ToString());
            gameInfo.Add(this.Inactive_Player.ToString());
            gameInfo.Add(this.playersList.ToString());
            return gameInfo;            
        }

        public Game(string json)
        {
            this.LoadFromJson(json);
        }

        public string ConvertToJson()
        {

            return JsonSerializer.Serialize(this.TransformGameToList());
        }

        public void LoadFromJson(string json)
        {
            Game deserialized = JsonSerializer.Deserialize<Game>(json);
            this.GameStatus = deserialized.GameStatus;
            this.GameId= deserialized.GameId;
            this.Date = deserialized.Date;
            this.active_Player = deserialized.active_Player;
            this.active_Player.PlayerBoardsList=deserialized.Inactive_Player.PlayerBoardsList;
            this.Inactive_Player.PlayerBoardsList=deserialized.Inactive_Player.PlayerBoardsList;
            this.Inactive_Player = deserialized.Inactive_Player;
            this.playersList=deserialized.playersList;

        }
        

    }
}