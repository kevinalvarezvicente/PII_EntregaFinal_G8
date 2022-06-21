using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase donde comienza el tablero.
    /// Es una clase base de los tableros de tiros y de barcos.
    /// Cumple con SRP (Single Responsibility Principle)
    /// Tiene la única responsabilidad de inicializar el barco.
    /// Rompe LSP (Liskov Substitution Principle) ya que hay operaciones donde se requiere un objeto de tipo Board e importa si es ShipBoard o ShotBoard dependiendo de eso que verá cada jugador
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Se crea atributo privado de la matriz.
        /// </summary>
        private string[,] gameBoard;
        /// <summary>
        /// Atributo que permite tener una cantidad maxima de barcos segun el tamaño del tablero.
        /// </summary>
        private int maxShipsQuantity;
        /// <summary>
        /// Constructor del tablero
        /// Como funcionalidad extra del equipo se pone un maximo de barcos a agregar segun el tamaño del tablero.
        /// La cantidad de barcos será la mitad del tamaño del lado del tablero.
        /// </summary>
        /// <param name="x">Es un entero que representa el largo del lado del tablero</param>
        /// 
        public Board(int x)
        {
            this.InitializeBoard(x);
            this.maxShipsQuantity = x/2;
        }

        /// <summary>
        /// Es una matriz de strings "-"-
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

        public int MaxShipsQuantity
        {
            get 
            {
                return this.maxShipsQuantity;
            }
        }

        /// <summary>
        /// Metodo que inicializa el tablero .
        /// </summary>
        /// <param name="x">Largo del lado del tablero</param>
        protected void InitializeBoard(int x)
        {
            if (x>12)
            {
                throw new SizeException("El lado del tablero no puede superar el tamaño 12");
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
