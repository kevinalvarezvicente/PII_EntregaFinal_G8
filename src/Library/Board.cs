using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase donde comienza el tablero
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Se crea atributo privado de la matriz
        /// </summary>
        private string[,] gameBoard;
        /// <summary>
        /// Atributo que permite tener una cantidad maxima de barcos segun el tamaño del tablero
        /// </summary>
        private int maxShipsQuantity;
        /// <summary>
        /// Constructor del tablero
        /// Como funcionalidad extra del equipo se pone un maximo de barcos a agregar segun el tamaño del tablero
        /// La cantidad de barcos será la mitad del tamaño del lado del tablero
        /// </summary>
        /// <param name="x">Es un entero que representa el largo del lado del tablero</param>

        public Board(int x)
        {
            this.InitializeBoard(x);
            this.maxShipsQuantity = x / 2;
        }
        /// <summary>
        /// Es una matriz de strings
        /// </summary>
        /// <value>Matriz del tablero general</value>
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
        /// <summary>
        /// Permite acceder a la cantidad maxima de barcos
        /// </summary>
        /// <value>Es de tipo entero</value>
        public int MaxShipsQuantity
        {
            get
            {
                return this.maxShipsQuantity;
            }
        }
        /// <summary>
        /// Metodo que inicializa el tablero 
        /// </summary>
        /// <param name="x">Largo del lado del tablero</param>
        public void InitializeBoard(int x)
        {
            gameBoard = new string[x, x];

            for (int i = 0; i < this.gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.gameBoard.GetLength(1); j++)
                {
                    this.gameBoard[i, j] = i + "," + j;
                }
            }
        }
            /*int counter = 1;
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
            }*/

    }
}

