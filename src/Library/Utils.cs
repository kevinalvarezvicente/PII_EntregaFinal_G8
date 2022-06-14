using System.Linq;
using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Utils
    {
        /// <summary>
        /// Este método devuelve la fila y la columna en numeros enteros
        /// </summary>
        /// <param name="row"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static (int row, int column) SplitCoordIntoRowAndColumn(string coord)
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //string row = "";
            int row = 0;
            int column = 0;
            

            if (coord.Length != 2)
            {
                throw new LibraryException($"{coord} es una coordenada inválida ");
            }

            char[] coordArray = coord.ToArray();

            //row = coordArray[0].ToString();
            row = int.Parse(coordArray[0].ToString());
            column = int.Parse(coordArray[1].ToString());

            //nt rowNum = letters.IndexOf(row)+1;

            return (row, column);
        }
    }
}