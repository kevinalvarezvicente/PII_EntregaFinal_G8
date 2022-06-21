using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Se crea una clase Abstracta para el tablero. 
    /// Cumple con OCP (Open/Close Principle) pues es abierta a la extension pero cerrada a la modificacion.
    /// La clase Board heredará de esta e implementará el método initializeBoard en su constructor.
    /// </summary>
    public abstract class AbstractBoard
    {
        /// <summary>
        /// Se crea atributo privado de la matriz.
        /// </summary>
        protected string[,] gameBoard;
        /// <summary>
        /// Atributo que permite tener una cantidad maxima de barcos segun el tamaño del tablero.
        /// </summary>
        protected int maxShipsQuantity;
        /// <summary>
        /// Es una matriz de strings "-".
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
        /// Metodo que inicializa el tablero .
        /// </summary>
        /// <param name="x">Largo del lado del tablero</param>
        protected void InitializeBoard(int x)
        {
            if (x>12 || x<1)
            {
                throw new BoardException("El lado del tablero no puede superar el tamaño 12");
            }
            gameBoard = new string[x, x];

            for (int i = 0; i < this.gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.gameBoard.GetLength(1); j++)
                {
                    //this.gameBoard[i, j] = i + "," + j;
                    this.gameBoard[i, j] = "-";
                }
            }
        }


    }
}

