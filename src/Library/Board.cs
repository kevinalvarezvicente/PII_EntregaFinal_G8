using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Board
    {

        private string[,] gameBoard;
        private int maxShipsQuantity;
        /// <summary>
        /// Metodo que crea el tablero
        /// Como funcionalidad extra del equipo se pone un maximo de barcos a agregar segun el tamaño del tablero
        /// La cantidad de barcos será la mitad del tamaño del lado del tablero
        /// </summary>
        /// <param name="x"></param>

        public Board(int x)
        {
            this.InitializeBoard(x);
            this.maxShipsQuantity = x / 2;
        }

        public string[,] GameBoard
        {
            get
            {
                return this.gameBoard;
            }
            private set
            {
                this.gameBoard = value;
            }
        }

        public int MaxShipsQuantity
        {
            get
            {
                return this.maxShipsQuantity;
            }
        }

        public void InitializeBoard(int x)
        {
            int counter = 1;
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] lettersArray = letters.ToCharArray();
            gameBoard = new string[x, x];

            for (int i = 0; i < (Math.Sqrt(gameBoard.Length)); i++)
            {
                for (int j = 0; j < (Math.Sqrt(gameBoard.Length)); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        gameBoard[0, 0] = " ";
                    }
                    else if (i == 0 && j != 0)
                    {
                        gameBoard[0, j] = lettersArray[j - 1].ToString();
                    }
                    else if (j == 0 && i != 0)
                    {
                        gameBoard[i, 0] = counter.ToString();
                        counter++;
                    }
                    else
                    {
                        gameBoard[i, j] = "-";
                    }
                }
            }

        }
    }
}
