
using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase donde comienza el tablero.
    /// Es una clase base de los tableros de tiros y de barcos.
    /// Cumple con SRP (Single Responsibility Principle)
    /// Tiene la única responsabilidad de inicializar el tablero y única razón de cambio es si el dia de mañana se quiere permitir que se elija un tablero de tamaño mayor que 12 o que la cantidad de barcos a agregar sea mayor.
    /// Romperá LSP (Liskov Substitution Principle) ya que hay operaciones en el programa en general donde se requiere un objeto de tipo Board e importa si es de ShipBoard o ShotBoard ya que el juego está hecho para que cada jugador vea el ShotBoard y el ShipBoard por separado.
    /// Cumple OCP (Open-Close Principle) pues si el dia de mañana se agrega otro tipo de Board puede extender de esta sin problema y es cerrada a la modificación en el sentido de que  no es necesario realizar cambios en el código de esa clase
    /// </summary>
    public class Board : AbstractBoard
    {
        /// <summary>
        /// Atributo que dice que tablero es, si de barcos o de disparos
        /// </summary>
        protected string what;
        /// <summary>
        /// Se crea atributo privado de la matriz.
        /// </summary>
        private string[,] gameBoard;
        /// <summary>
        /// Atributo que permite tener una cantidad maxima de barcos segun el tamaño del tablero.
        /// </summary>
        private int maxShipsQuantity;
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
        /// Constructor del tablero
        /// Como funcionalidad extra del equipo se pone un maximo de barcos a agregar segun el tamaño del tablero.
        /// La cantidad de barcos será la mitad del tamaño del lado del tablero.
        /// </summary>
        /// <param name="x">Es un entero que representa el largo del lado del tablero</param>
        public Board(int x)
        {
            this.InitializeBoard(x);
            this.maxShipsQuantity = x / 2;
            this.what = "";
        }
        /// <summary>
        /// Método de acceso a la cantidad maxima habilitada de barcos a ubicar
        /// </summary>
        /// <value>Retorna un entero segun el tamaño del tablero</value>
        public int MaxShipsQuantity
        {
            get
            {
                return this.maxShipsQuantity;
            }
        }
        /// <summary>
        /// Propiedad de acceso al atributo what
        /// </summary>
        /// <value></value>
        public string What
        {
            get
            {
                return this.what;
            }
        }
        /// <summary>
        /// Método implementado que inicializa el tablero
        /// </summary>
        /// <param name="x">Es el largo del tablero</param>
        public override void InitializeBoard(int x)
        {
            if (x > 20 || x < 1)
            {
                throw new BoardException("El lado del tablero no puede superar el tamaño 20");
            }
            this.gameBoard = new string[x, x];

            for (int i = 0; i < this.gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.gameBoard.GetLength(1); j++)
                {

                    this.gameBoard[i, j] = "-";
                }
            }
        }

    }
}

