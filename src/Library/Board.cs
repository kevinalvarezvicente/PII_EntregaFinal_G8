using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Board
    {

        private string[,] gameBoard;

        public Board(int x)
        {
            this.InitializeBoard(x);
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


        public bool VerifyShot(int x, int y)
        {
            try
            {
                if (this.GameBoard[x, y].Equals("o")) //si hay un barco
                {
                    this.GameBoard[x, y] = "x"; //si le pega lo pone como x 
                    return true;
                }
                return false;
            }
            catch
            {
                throw new LibraryException("Las coordenadas elegidas estan fuera de rango");
            }
        }


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
