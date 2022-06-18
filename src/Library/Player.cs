using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Player : LibraryException
    {
        private Board playerShipBoard;
        private Board playerShotBoard;
        private string playerName;
        private List<Dictionary<(int, int), bool>> shipsList;

        public Player(User user, int BoardLength)
        {
            this.playerName = user.Name;
            this.playerShipBoard = new ShipBoard(BoardLength);
            this.playerShotBoard = new ShotBoard(BoardLength);
            this.shipsList = new List<Dictionary<(int, int), bool>>();

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
            this.playerName = NewName;
        }

        public List<Dictionary<(int, int), bool>> ShipsList
        {
            get
            {
                return this.shipsList;
            }

        }

        public void MakeShot(string coord)
        {
            int x;
            int y;
            (x, y) = Utils.SplitCoordIntoRowAndColumn(coord);
            playerShotBoard.GameBoard[x, y] = "X";
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
            (x, y) = Utils.SplitCoordIntoRowAndColumn(coord);

            if (GetPlayerShipBoard().GameBoard[x, y].Equals("o"))
            {
                GetPlayerShipBoard().GameBoard[x, y] = "x";
                Console.WriteLine("Barco disparado");
            }
            else if (GetPlayerShipBoard().GameBoard[x, y].Equals("-"))
            {
                Console.WriteLine("Oceano");
                GetPlayerShipBoard().GameBoard[x, y] = "|";
            }else if (GetPlayerShipBoard().GameBoard[x, y].Equals("x"))
            {
                Console.WriteLine("Ya fue disparado");
                //algun comando handler 
            }


        }

    }
}
