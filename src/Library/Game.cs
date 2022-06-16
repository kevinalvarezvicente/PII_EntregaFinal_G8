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

        public void ShotMade(string coord)
        {
            bool trySuperated = false;
            Console.WriteLine($"{Active_Player.GetPlayerName()} hace el disparo a {Inactive_Player.GetPlayerName()}");
            try
            {
                Active_Player.MakeShot(coord);
                Inactive_Player.ReceiveShot(coord);
                trySuperated=true;
            }
            catch
            {
                throw new LibraryException("Las coordenadas estan fuera de rango.");
            }
            finally
            {
                if (!trySuperated)
                {
                    Console.WriteLine("Indique nuevamente las coordenadas a disparar");
                    string newCoord = Console.Read().ToString();
                    AskForShotAgain(newCoord);  
                }
                else
                {
                    Active_Player.PrintPlayerShotBoard();
                    Inactive_Player.PrintPlayerShipBoard();
                    Utils.Swap(ref Active_Player, ref Inactive_Player);
                    Console.WriteLine($"Ahora es el turno de {Active_Player.GetPlayerName()} de realizar el tiro");
                }
            }
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
        public void PlaceShip(int length, string coord, string direction)
        {
            bool trySuperated = false;
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
                        
                    }

                }
                else if (direction.ToUpper()=="V")
                {
                    for (int i=boardY; i<boardY+length; i++)
                    {
                        this.Active_Player.GetPlayerShipBoard().GameBoard[i,boardX]=ship.GetShip()[0];
                    }                
                }
                trySuperated=true;
            }
            catch
            {
                throw new LibraryException("Las coordenadas elegidas estan fuera de rango");
            }

            finally
            {
                if (!trySuperated)
                {
                    AskPlayerForShipCoord();
                }
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
                //string coord = AskPlayerForShipCoord();
                Console.WriteLine($"{Active_Player.GetPlayerName()} indique la dirección para ubicarlo ubicarlo v/h: ");
                string direction = Console.ReadLine();
                PlaceShip(shipLength,coord,direction);
                shipsLeft--;
                Console.WriteLine($"Le quedan {shipsLeft} barcos por agregar.");
            }
            Console.WriteLine($"Se ubicaron todos los barcos de {Active_Player.GetPlayerName()}");
            Utils.Swap(ref Active_Player, ref Inactive_Player);
        }

        public string AskPlayerForShipCoord()
        {
            Console.WriteLine("Indique la coordenada en donde desea ubicarlo: ");
            string coord = Console.Read().ToString();
            return coord;
        }

        public List<User> UsersPlayingList
        {
            get
            {
                return this.usersList;
            }

        }



    }
}
