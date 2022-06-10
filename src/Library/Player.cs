using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Player : LibraryException
    {
        Board playerShipBoard = new ShipBoard(4);
        Board playerShotBoard = new ShotBoard(5);

        public void MakeShot(int x, int y)
        {
            playerShotBoard.GameBoard[x, y] = "1";
        }
        public void ReceiveShot(int x, int y)
        {
            playerShipBoard.VerifyShot();
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
    }
}
