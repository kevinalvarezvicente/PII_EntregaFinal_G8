using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    ///  ...
    /// </summary>
    public class Board
    {

        private string[,] gameBoard;
        /// <summary>
        ///  ...
        /// </summary>
        public Board(int x)
        {
            this.InitializeBoard(x);
        }
        /// <summary>
        ///  ...
        /// </summary>
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
        ///  ...
        /// </summary>
        public void InitializeBoard(int x)
        {
            gameBoard = new string[x, x];
        
            for (int i = 0; i < this.gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.gameBoard.GetLength(1); j++)
                {
                    this.gameBoard[i, j] = "-";
                }
            }
        }
        public void PlaceShip(int length, int x, int y, string direction)
        {
            int boardX = x-1;
            int boardY = y-1;
            Ship ship = new Ship(length);

            if(boardX < 0 || boardX >= this.gameBoard.GetLength(0) || boardY < 0 || boardY >= this.gameBoard.GetLength(1))
            {
                throw new LibraryException("La coordenada no es valida");
            }        
            if(boardY + length > this.gameBoard.GetLength(1))
                {
                    throw new LibraryException("El barco no puede estar fuera del tablero");
                }
            if (direction.ToUpper()=="H")
            {
                for (int i = 0; i < length; i++)
                {
                    this.gameBoard[boardX, boardY] = length.ToString();
                    boardX++;
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    this.gameBoard[boardX, boardY] = length.ToString();
                    boardY++;
                }
            }
        }
        /// <summary>
        ///  ...
        /// </summary>
          public void ReceiveShot(int x, int y)
        {
            try
            {
                if (GameBoard[x, y].Equals("1") || GameBoard[x, y].Equals("2") || GameBoard[x, y].Equals("3"))
                {
                    GameBoard[x, y] = "x";
                }
                else if (GameBoard[x, y].Equals("-"))
                {
                    Console.WriteLine("Oceano");
                }
            }
            catch
            {
                throw new LibraryException("Las coordenadas elegidas estan fuera de rango");
            }
        }
        


        /// <summary>
        ///  
        /// </summary>
        //for anidado para imprimir la matriz
        public void imprimirTablero(Board board1)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    Console.Write(gameBoard[i, j] + " ");
                }
                //saltodelinea
                Console.WriteLine();
            }
        }


        //leer el arreglo
        static int[,] LeerArregloBidimensionalPantalla(int[,] arreglo)
        {
            for (int i = 0; i < arreglo.GetLength(0); i++)
            {
                for (int j = 0; j < arreglo.GetLength(1); j++)
                {
                    Console.Write("Ingrese el valor de la posicion [" + i + "," + j + "]: ");
                    arreglo[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return arreglo;
        }


    }
}
