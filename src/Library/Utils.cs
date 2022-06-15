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
            string column = "";
            int row = 0;
            

            if (coord.Length != 2)
            {
                throw new LibraryException($"{coord} es una coordenada inválida ");
            }

            char[] coordArray = coord.ToArray();

            column = coordArray[1].ToString().ToUpper();
            row = int.Parse(coordArray[0].ToString());

            int columnNum = letters.IndexOf(column)+1;

            return (columnNum+1, row+1);
        }
    }
}