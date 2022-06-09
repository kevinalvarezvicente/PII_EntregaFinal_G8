using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Board
    {
        
            private int[,] matriz;

            public Board(int x, int y){
                
                this.Matriz = new int[x,y];
                
            }

        public int[,] Matriz
        {
            get
            {
                return this.matriz;
            }
            private set
            {
                this.matriz = value;
            }
        }


           public void ArregloInicial(){
                 //declaro la matriz
                //for anidado para llenar la matriz de un valor
                for (int i = 0; i < this.matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < this.matriz.GetLength(0); j++)
                    {
                        this.matriz[i, j] = 1;
                    }
                }
           }
               


                //for anidado para imprimir la matriz
            public void imprimirTablero(Board board1)
                {
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                         Console.Write(i + " [");
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            Console.Write(matriz[i, j] + " ");
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
