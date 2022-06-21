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
        /// <summary>
        /// Cada partida se guarda con la fecha de comienzo
        /// </summary>
        private DateTime Date;
        /// <summary>
        /// El Active_Player es el jugador con el turno, comienza él siempre
        /// Es el que está primero en la lista de Lobby de espera, o sea el primero que llego
        /// </summary>
        private Player Active_Player;
        /// <summary>
        /// El Inactive_Player es el jugador que espera a que sea su turno
        /// </summary>
        private Player Inactive_Player;
        /// <summary>
        /// Se crea una lista con ambos tableros del jugador
        /// </summary>
        private List<Board> player1Boards;
        /// <summary>
        /// Se crea una lista con ambos tableros del jugador
        /// </summary>
        private List<Board> player2Boards;
        /// <summary>
        /// Para guardar la partida se guardará una lista con los usuarios que la jugaron
        /// </summary>
        private List<User> usersList;
        /// <summary>
        /// Se inicia el juego con el constructor de la clase
        /// Recibe como argumento todos los datos necesarios para crear instancia de Player transformando a un usuario en player
        /// </summary>
        /// <param name="player1">Será el jugador que inicia todo</param>
        /// <param name="player2"></param>
        /// <param name="boardLength">Ambos jugadores tendrán el mismo tamaño de tablero</param>
        public Game(User player1, User player2, int boardLength)
        {
            this.Date = DateTime.Now;
            this.Active_Player = new Player(player1, boardLength);
            this.Inactive_Player = new Player(player2, boardLength);
            this.usersList = new List<User>();
            this.usersList.Add(player1);
            this.usersList.Add(player2);
        }
        /// <summary>
        /// Todas las partidas tienen su fecha de inicio
        /// </summary>
        /// <value>Son los getters y setters de la fecha de la partida</value>
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
        
        //El siguiente método es solo una referencia a futuro
            // Este metodo le pide al jugador que agregue los barcos según el tamaño del tablero
            // Sirve al comienzo para chequear que el tablero se imprima bien sin realizar test


            /*public void AskPlayerToPlaceShips(int shipLength,string coord, string direction)
            {
                int maxShipsQuantity = Active_Player.GetPlayerShipBoard().MaxShipsQuantity;
                int shipsLeft = maxShipsQuantity;
                Console.WriteLine($"{Active_Player.GetPlayerName()} puede agregar hasta {maxShipsQuantity} barcos según el tamaño de su tablero");
                while (shipsLeft>0)
                {
                    /*Console.WriteLine($"{Active_Player.GetPlayerName()} Indique el tipo del barco: ");
                    Console.WriteLine($"Opciones a elegir:\n1) 2 Coordenadas \n2) 3 Coordenadas \n3) 4 coordendas");
                    int shipLength = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"{Active_Player.GetPlayerName()} indique la coordenada en donde desea ubicarlo: ");
                    string coord = Console.ReadLine();
                    Console.WriteLine($"{Active_Player.GetPlayerName()} indique la dirección para ubicarlo ubicarlo v/h: ");
                    string direction = Console.ReadLine();*/
                /*switch (shipLength)
                {
                case 1:
                        AddShipToPlayerShipList(Active_Player,PlaceShip(2, coord,direction));
                        shipsLeft--;
                break;

                case 2:
                        AddShipToPlayerShipList(Active_Player,PlaceShip(3, coord,direction));
                        shipsLeft--;
                break;

                case 3:
                        AddShipToPlayerShipList(Active_Player,PlaceShip(4, coord,direction));
                        PlaceShip(4, coord,direction);
                        shipsLeft--;
                break;

                default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El barco no puede tener un tamaño mayor a 5");
                break;
                }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Le quedan {shipsLeft} barcos por agregar.");

        }
        Console.WriteLine($"Se ubicaron todos los barcos de {Active_Player.GetPlayerName()}");
        Console.WriteLine("---------------------------");
        Utils.Swap(ref Active_Player, ref Inactive_Player);
        }*/

    }
}
