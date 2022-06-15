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
        private List<Board> Player1Boards;
        private List<Board> Player2Boards;

        //Se crea el constructor para cuando se inicia un juego

        public Game(User player1, User player2, int boardLength)
        {
            this.Date=DateTime.Now;
            this.Active_Player= new Player(player1, boardLength);
            this.Inactive_Player=new Player(player2, boardLength);
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

        public void ShotMade(string coord)
        {
            Console.WriteLine($"{Active_Player.GetPlayerName()} hace el disparo a {Inactive_Player.GetPlayerName()}");
            Active_Player.MakeShot(coord);
            Inactive_Player.ReceiveShot(coord);
            
            Active_Player.PrintPlayerShotBoard();
            Inactive_Player.PrintPlayerShipBoard();
            Swap.Swaping(ref Active_Player, ref Inactive_Player);
            Console.WriteLine($"Ahora es el turno de {Active_Player.GetPlayerName()} de realizar el tiro");
        }

        /// <summary>
        /// Este método agrega el barco en el Tablero de barcos
        /// Si el barco que se desea agregar no cumple con el rango habilitado por el tablero tira una excepción
        /// </summary>
        /// <param name="length"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public void PlaceShip(int length, string coord, string direction)
        {
            int x;
            int y;
            (x, y)=Utils.SplitCoordIntoRowAndColumn(coord);
            int boardX = x-1;
            int boardY = y-1;
            Ship ship = new Ship(length);
            
            try
            {

                if (direction.ToUpper()=="H")
                {
                    for (int i=boardX; i<boardX+length; i++)
                    {
                        this.Active_Player.GetPlayerShipBoard().GameBoard[boardY,i]=ship.GetShip()[0];
                        //this.Active_Player.GetPlayerShipBoard().GameBoard[i,boardY]=ship.GetShip()[0];
                    }

                }
                else if (direction.ToUpper()=="V")
                {
                    for (int i=boardY; i<boardY+length; i++)
                    {
                        this.Active_Player.GetPlayerShipBoard().GameBoard[i,boardX]=ship.GetShip()[0];
                    }                
                }
            }
            catch
            {
                throw new LibraryException("Las coordenadas elegidas estan fuera de rango");
            }
            Console.WriteLine($"Se ubican los barcos de {this.Active_Player.GetPlayerName()} y se imprime tablero");
            this.Active_Player.PrintPlayerShipBoard();

        }

        public void AskPlayerToPlaceShips()
        {
            int maxShipsQuantity = Active_Player.GetPlayerShipBoard().MaxShipsQuantity;
            int shipsLeft = maxShipsQuantity;
            Console.WriteLine($"{Active_Player.GetPlayerName()} puede agregar hasta {maxShipsQuantity} barcos según el tamaño de su tablero");
            while (shipsLeft>0)
            {
                Console.WriteLine($"{Active_Player.GetPlayerName()} indique el tamaño del barco: ");
                int shipLength = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"{Active_Player.GetPlayerName()} indique la coordenada en donde desea ubicarlo: ");
                string coord = Console.ReadLine();
                Console.WriteLine($"{Active_Player.GetPlayerName()} indique la dirección para ubicarlo ubicarlo v/h: ");
                string direction = Console.ReadLine();
                PlaceShip(shipLength,coord,direction);
                shipsLeft--;
                Console.WriteLine($"Le quedan {shipsLeft} barcos por agregar.");
            }
            Console.WriteLine($"Se ubicaron todos los barcos de {Active_Player.GetPlayerName()}");
            Swap.Swaping(ref Active_Player, ref Inactive_Player);
        }

        
        /*public void PrintActivePlayerShotBoard()
        {
            Console.WriteLine($"Se imprime el tablero de tiros de {Active_Player.GetPlayerName()}");
            for (int i = 0; i < Active_Player.GetPlayerShotBoard().GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < Active_Player.GetPlayerShotBoard().GameBoard.GetLength(1); j++)
                {
                Console.Write(Active_Player.GetPlayerShotBoard().GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }
        }

        public void PrintInactivePlayerShotBoard()
        {
            Console.WriteLine($"Se imprime el tablero de tiros de {Inactive_Player.GetPlayerName()}");
            for (int i = 0; i < Inactive_Player.GetPlayerShotBoard().GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < Inactive_Player.GetPlayerShotBoard().GameBoard.GetLength(1); j++)
                {
                Console.Write(Inactive_Player.GetPlayerShotBoard().GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }
        }

        public void PrintInactivePlayerShipBoard()
        {
            Console.WriteLine($"Se imprime el tablero de tiros de {Inactive_Player.GetPlayerName()}");
            for (int i = 0; i < Inactive_Player.GetPlayerShipBoard().GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < Inactive_Player.GetPlayerShipBoard().GameBoard.GetLength(1); j++)
                {
                Console.Write(Inactive_Player.GetPlayerShipBoard().GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }
        }

        public void PrintActivePlayerShipBoard()
        {
            Console.WriteLine($"Se imprime el tablero de tiros de {Active_Player.GetPlayerName()}");
            for (int i = 0; i < Active_Player.GetPlayerShipBoard().GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < Active_Player.GetPlayerShipBoard().GameBoard.GetLength(1); j++)
                {
                Console.Write(Active_Player.GetPlayerShipBoard().GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }
        }*/

        /*private DateTime date;
        Player Active_Player = new Player(this);
        Player Inactive_Player = new Player(this);

        public Game(User player1, User player2)
        {
            this.DateTime = DateTime.Now;
        }


        public DateTime DateTime
        {
            get
            {
                return this.date;
            }

            private set
            {
                this.date = value;
            }
        }
        public List<User> PlayersList
        {
            get
            {
                return this.playersList;
            }

        }
        public List<Board> Player1Board
        {
            get
            {
                return this.player1Board;
            }
            private set
            {
                Board value1 = value;
                this.player1Board.Add(value1);
            }

        }
        public List<Board> Player1Board
        {
            get
            {
                return this.player2Board;
            }
            private set
            {
                Board value1 = value;
                this.player2Board.Add(value1);
            }
        }

        public void ShotMade(int x, int y)
        {
            Active_Player.MakeShot(x, y);
            Inactive_Player.ReceiveShot(x, y);
            Swap.Swaping(ref Active_Player, ref Inactive_Player);
        }*/
    }
}
