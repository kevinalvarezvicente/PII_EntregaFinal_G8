﻿using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Ship
    {
        List<int[,]> coordList = new List<int[,]>();

        public Ship(int length)
        {
            int[] ship1 = new int[length];
            for (int i = 0; i < ship1.GetLength(0); i++)
            {
                    ship1[i] = 'o';     
            }
            
        }

        //se tiene que ver como agregar el barco
        public void PlaceShip(int x, int y, int direction){
            
            
            
        }

        

        public int ships(int x){
            //un for que reccorra el barco y se fije si todas las posiciones estan con una x
            int[] ship1 = new int[5] { 'x', 'x', 'x', 'x','x'};
            // si el barco(array )esta con todas sus posiciones en x haces un funcionamiento que imprima hundiste el barco(array ship1)

        
        }
    }
}


