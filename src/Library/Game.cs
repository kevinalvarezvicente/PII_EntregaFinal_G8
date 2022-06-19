using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Aca se encuentran todos los métodos relacionados con el juego en general
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
            Console.WriteLine($"Comenzará {Active_Player.GetPlayerName()} \nSu tablero se ve asi");
            BoardPrinter.PrintPlayerShipBoard(Active_Player);
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
            Console.WriteLine($"{Active_Player.GetPlayerName()} hace el disparo a {Inactive_Player.GetPlayerName()}");
            try
            {
                Active_Player.MakeShot(coord);
                Inactive_Player.ReceiveShot(coord);
            }
            catch
            {
                throw new LibraryException("Las coordenadas estan fuera de rango.");
            }
            BoardPrinter.PrintPlayerShotBoard(Active_Player);
            BoardPrinter.PrintPlayerShipBoard(Inactive_Player);
            Console.WriteLine($"Ahora es el turno de {Active_Player.GetPlayerName()} de realizar el tiro");

        }
        /// <summary>
        /// Este método se utilizó para probar unas excepciones
        /// </summary>
        /// <param name="newCoord">Es la nueva coordenada</param>
        public void AskForShotAgain(string newCoord)
        {
            Active_Player.MakeShot(newCoord);
            Inactive_Player.ReceiveShot(newCoord);
        }
        /// <summary>
        /// Este método agrega el barco en el Tablero de barcos
        /// Si el barco que se desea agregar no cumple con el rango habilitado por el tablero tira una excepción
        /// </summary>
        /// <param name="shipOption">Es la opción prederminada del barco a elegir</param>
        /// <param name="x">Luego de dividir la coordenada en fila y columna, la fila se guarda en x</param>
        /// <param name="y">Luego de dividir la coordenada en fila y columna, la columna se guarda en y</param>
        /// <param name="coord">Es un string de dos cifras que se divide en dos numeros enteros</param>
        /// <param name="direction">Las opciones son vertical u horizontal</param>
        public void PlaceShip(int shipOption, string coord, string direction)
        {
            int length;
            int x;
            int y;
            (x, y) = Utils.SplitCoordIntoRowAndColumn(coord);
            int boardX = x - 1;
            int boardY = y - 1;
            try
            {
            
                if (shipOption==1)
                {
                    Frigate ship= new Frigate(coord,direction);
                    length=ship.GetLength();
                    foreach ((int i,int j) in  ship.CoordsDict.Keys)
                    {
                        this.Active_Player.GetPlayerShipBoard().GameBoard[i,j] = "o";
                    }
                    AddShipToPlayerShipList(Active_Player, ship);
                   
                }
                
                else if (shipOption==2)
                {   
                    LightCruiser ship= new LightCruiser(coord,direction);
                    length= ship.GetLength();
                    foreach ((int i,int j) in  ship.CoordsDict.Keys)
                    {
                        this.Active_Player.GetPlayerShipBoard().GameBoard[i,j] = "o";
                    }
                    AddShipToPlayerShipList(Active_Player, ship);
                }
                else if (shipOption==3)
                {
                    Submarine ship= new Submarine(coord,direction);
                    length=ship.GetLength();
                    foreach ((int i,int j) in  ship.CoordsDict.Keys)
                    {
                        this.Active_Player.GetPlayerShipBoard().GameBoard[i,j] = "o";
                    }
                    AddShipToPlayerShipList(Active_Player, ship);
                }
            }
                catch
            {
                throw new LibraryException("Las coordenadas elegidas estan fuera de rango");
            }

            Console.WriteLine($"Se ubican los barcos de {this.Active_Player.GetPlayerName()} y se imprime tablero");
            BoardPrinter.PrintPlayerShipBoard(Active_Player);
            
            }

        /// <summary>
        /// Usuarios que jugarán la partida
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
        /// Este método agrega el barco creado en la posición a una lista de barcos del jugador
        /// </summary>
        /// <param name="player">El dueño de la lista de barcos</param>
        /// <param name="ship">El barco a agregar a la lista de barcos del jugador</param>
        public void AddShipToPlayerShipList(Player player, AbstractShip ship)
        {
            player.ShipsList.Add(ship.CoordsDict);
        }

        /// <summary>
        /// Este método permite saber si un jugador tiene todos sus barcos hundidos.
        /// Retorna true si todos los valores son true
        /// </summary>
        /// <returns>Devuelve un booleano según si todos los barcos del jugador eestán hundidos o no</returns>

        public bool AreAllShipsSinked(Player player)
        {
           foreach (Dictionary<(int, int), bool> dict in player.ShipsList)
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
