using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Board
    {
        
        private int[,] gameBoard;

        public int[,] GameBoard
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
               gameBoard = new int [x,x];

                for (int i = 0; i < this.gameBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < this.gameBoard.GetLength(1); j++)
                    {
                        this.gameBoard[i, j] = 0;
                    }
                }
           }

           
               


                //for anidado para imprimir la matriz
            public void imprimirTablero(Board board1)
                {
                    for (int i = 0; i < gameBoard.GetLength(0); i++)
                    {
                         Console.Write(i + " [");
                        for (int j = 0; j < gameBoard.GetLength(1); j++)
                        {
                            Console.Write(gameBoard[i, j] + " ");
                        }
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
                    return  arreglo;
                }


    }
}
