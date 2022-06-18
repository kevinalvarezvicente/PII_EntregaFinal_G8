using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Game
    {
        /*
        Agregado por Carol 
        */

        private DateTime Date;
        private Player Active_Player;
        private Player Inactive_Player;
        private List<Board> player1Boards;
        private List<Board> player2Boards;
        private List<User> usersList;

        //Se crea el constructor para cuando se inicia un juego

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="boardLength"></param>
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
            Utils.Swap(ref Active_Player, ref Inactive_Player);
            Console.WriteLine($"Ahora es el turno de {Active_Player.GetPlayerName()} de realizar el tiro");

        }

        public void AskForShotAgain(string newCoord)
        {
            Active_Player.MakeShot(newCoord);
            Inactive_Player.ReceiveShot(newCoord);
        }
        /// <summary>
        /// Este método agrega el barco en el Tablero de barcos
        /// Si el barco que se desea agregar no cumple con el rango habilitado por el tablero tira una excepción
        /// </summary>
        /// <param name="length"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public Ship PlaceShip(int length, string coord, string direction)
        {

            int x;
            int y;
            (x, y) = Utils.SplitCoordIntoRowAndColumn(coord);
            int boardX = x - 1;
            int boardY = y - 1;
            Ship ship = new Ship(length, coord, direction);

            try
            {

                if (direction.ToUpper() == "H")
                {
                    for (int i = boardX; i < boardX + length; i++)
                    {
                        this.Active_Player.GetPlayerShipBoard().GameBoard[boardY, i] = "o";
                        ship.CoordsDict.Add((boardY, i), false);

                    }

                }
                else if (direction.ToUpper() == "V")
                {
                    for (int i = boardY; i < boardY + length; i++)
                    {
                        this.Active_Player.GetPlayerShipBoard().GameBoard[i, boardX] = "o";
                        ship.CoordsDict.Add((i, boardX), false);

                    }
                }
            }
            catch
            {
                throw new LibraryException("Las coordenadas elegidas estan fuera de rango");
            }

            Console.WriteLine($"Se ubican los barcos de {this.Active_Player.GetPlayerName()} y se imprime tablero");
            BoardPrinter.PrintPlayerShipBoard(Active_Player);
            return ship;
        }

        /// <summary>
        /// Este metodo le pide al jugador que agregue los barcos según el tamaño del tablero
        /// </summary>

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

        public List<User> UsersPlayingList
        {
            get
            {
                return this.usersList;
            }

        }

        public void AddShipToPlayerShipList(Player player, Ship ship)
        {
            player.ShipsList.Add(ship.CoordsDict);
        }
    }
}
