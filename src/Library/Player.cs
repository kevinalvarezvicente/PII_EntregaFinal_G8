using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    ///  ...
    /// </summary>
    public class Player : LibraryException
    {
        Board playerShipBoard = new ShipBoard(5);
        Board playerShotBoard = new ShotBoard(5);
        /// <summary>
        ///  ...
        /// </summary>
        public void MakeShot(int x, int y)
        {
            playerShotBoard.GameBoard[x, y] = "1";
        }
        /// <summary>
        ///  ...
        /// </summary>
        public void ReceiveShot(int x, int y)
        {
            try
            {

                if (playerShipBoard.GameBoard[x, y].Equals("o"))
                {
                    playerShipBoard.GameBoard[x, y] = "x";
                }
                else if (playerShipBoard.GameBoard[x, y].Equals("-"))
                {
                    Console.WriteLine("Oceano");
                }
            }
            catch
            {
                throw new LibraryException("Las coordenadas elegidas estan fuera de rango");
            }


        }
        //se tiene que ver como agregar el barco
        /// <summary>
        ///  ...
        /// </summary>
        public void PlaceShip(int length, int x, int y, string direction)
        {
            int boardX = x-1;
            int boardY = y-1;
            Ship ship = new Ship(length);
            playerShipBoard.GameBoard[x,y]=ship.ToString();

            if (direction.ToUpper()=="V")
            {
                for (int i=boardX; i<boardX+length; i++)
                {
                    playerShipBoard.GameBoard[i,boardY]=length.ToString();
                }

            }
            else if (direction.ToUpper()=="H")
            {
                for (int i=boardY; i<boardY+length; i++)
                {
                    playerShipBoard.GameBoard[boardX,i]=length.ToString();
                }                
            }

        }
        
    }
}
