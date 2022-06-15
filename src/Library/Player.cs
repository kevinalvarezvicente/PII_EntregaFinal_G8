using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Player: LibraryException 
    {
        private Board playerShipBoard;
        private Board playerShotBoard;
        private string playerName;

        public object column { get; private set; }

        public Player(User user, int BoardLength)
        {
            this.playerName = user.Name;
            this.playerShipBoard = new ShipBoard(BoardLength);
            this.playerShotBoard = new ShotBoard(BoardLength);
        }
        public Board GetPlayerShipBoard()
        {
            return this.playerShipBoard;
        }

        public Board GetPlayerShotBoard()
        {
            return this.playerShotBoard;
        }

        public string GetPlayerName()
        {
            return this.playerName;
        }

        private void SetPlayerName(string NewName)
        {
            this.playerName=NewName;
        }

        public void MakeShot(string coord)
        {
            int x;
            int y;
            (x, y)=Utils.SplitCoordIntoRowAndColumn(coord);
            playerShotBoard.GameBoard[x, y] = "|";
        }

        /// <summary>
        /// Este método hace que el jugador reciba el disparo ubicandolo en el tablero de disparos
        /// Si hay un pipe "|" entonces significa que hubo disparo ahi pero no habia barco
        /// Si hay "x" es porque habia un barco y se disparo
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ReceiveShot(string coord)
        {
           
            int x;
            int y;
            (x, y)=Utils.SplitCoordIntoRowAndColumn(coord);

                if (GetPlayerShipBoard().GameBoard[x-1, y-1].Equals("o"))
                {
                    GetPlayerShipBoard().GameBoard[x-1, y-1] = "x";
                    Console.WriteLine("Barco disparado");

                }
                else if (GetPlayerShipBoard().GameBoard[x-1, y-1].Equals("-"))
                {
                    Console.WriteLine("Oceano");
                    GetPlayerShipBoard().GameBoard[x-1, y-1] = "|";
                }



        }
        /*public void ReceiveShot(string coord)
        {
            bool trySuperated = false;
            int x;
            int y;
            (x, y)=Utils.SplitCoordIntoRowAndColumn(coord);
            try
            {
                if (GetPlayerShipBoard().GameBoard[x-1, y-1].Equals("o"))
                {
                    GetPlayerShipBoard().GameBoard[x-1, y-1] = "x";
                    Console.WriteLine("Barco disparado");

                }
                else if (GetPlayerShipBoard().GameBoard[x-1, y-1].Equals("-"))
                {
                    Console.WriteLine("Oceano");
                    GetPlayerShipBoard().GameBoard[x-1, y-1] = "|";
                }
                trySuperated = true;
            }
            catch
            {
                throw new LibraryException("Las coordenadas elegidas estan fuera de rango");
            }
            finally
            {
                if (!trySuperated)
                {
                    Console.WriteLine("Indique nuevamente las coordenadas a disparar");
                    string newCoord = Console.Read().ToString();
                    ReceiveShot(newCoord);               
                }
            }


        }*/

        public void PrintPlayerShotBoard()
        {

            Console.WriteLine($"Se imprime el tablero de tiros de {this.GetPlayerName()}");
            
            for (int i = 0; i < this.GetPlayerShotBoard().GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.GetPlayerShotBoard().GameBoard.GetLength(1); j++)
                    {
                    Console.Write(this.GetPlayerShotBoard().GameBoard[i,j]+" ");
                    }
                Console.WriteLine();
            }
        }

        public void PrintPlayerShipBoard()
        {
            Console.WriteLine($"Se imprime el tablero de barcos de {this.GetPlayerName()}");
            for (int i = 0; i < this.GetPlayerShipBoard().GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < this.GetPlayerShipBoard().GameBoard.GetLength(1); j++)
                {
                Console.Write(this.GetPlayerShipBoard().GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }
        }

        
    }
}
