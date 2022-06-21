using System;
using System.Collections.Generic;

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
    /// - Ship (Cualquier subtipo)
    /// </summary>
    public class Game
    {

        private DateTime Date;
        private Player Active_Player;
        private Player Inactive_Player;
        private List<Board> player1Boards;
        private List<Board> player2Boards;
        private List<User> usersList;
        /// <summary>
        /// Se inicia el juego con el constructor de la clase
        /// Recibe como argumento todos los datos necesarios para crear instancia de Player transformando a un usuario en player
        /// </summary>
        /// <param name="player1">Será el jugador que inicia todo</param>
        /// <param name="player2"></param>
        /// <param name="boardLength">Ambos jugadores tendrán el mismo tamaño de tablero</param>

        //Se crea el constructor para cuando se inicia un juego

        public Game(User player1, User player2, int boardLength)
        {
            this.Date=DateTime.Now;
            this.Active_Player= new Player(player1, boardLength);
            this.Inactive_Player=new Player(player2, boardLength);
            this.usersList= new List<User>();
            this.usersList.Add(player1);
            this.usersList.Add(player2);
            Console.WriteLine($"Comenzará {Active_Player.GetPlayerName()} \nSu tablero se ve asi");
            Active_Player.PrintPlayerShipBoard();
        }
        public DateTime DateTime
        {
            get
            {
                return this.Date;
            }

            private set
            {
                this.Date = value;
            }
        }
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
                    Ship shipFrigate= new Frigate(coord,direction);
                    this.Active_Player.PlaceShipOnBoard(shipFrigate);
                    this.Active_Player.AddShipToPlayerShipList(shipFrigate);
                break;

                case 2:
                    Ship shipLightCruiser= new LightCruiser(coord,direction);
                    this.Active_Player.PlaceShipOnBoard(shipLightCruiser);
                    this.Active_Player.AddShipToPlayerShipList(shipLightCruiser);
                break;

                case 3:
                    Ship shipSubmarine= new LightCruiser(coord,direction);
                    this.Active_Player.PlaceShipOnBoard(shipSubmarine);
                    this.Active_Player.AddShipToPlayerShipList(shipSubmarine);
                break;

                default:                        
                        throw new OptionException("Solo tiene 3 opciones de nave.");

                }
        }

        /// <summary>
        /// Usuarios que jugarán la partida. Tiene solo get porque no va a cambiar en ningun momento. 
        /// </summary>
        /// <value>Es una lista de tipo User</value>
        public List<User> UsersPlayingList
        {
            get
            {
                return this.usersList;
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
        /// Método que chequea que todos los barcos de alguno de los jugadores estén hundidos
        /// </summary>
        /// <returns>Retorna true o false para finalizar el juego</returns>
        public bool GameFinished()
        {
            if (AreAllShipsSinked(this.Inactive_Player) || AreAllShipsSinked(this.Active_Player))
            {
                return true;
            }
            return false;
        }

    }
}
