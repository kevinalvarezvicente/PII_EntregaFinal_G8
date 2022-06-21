using System.Linq;
using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase permite usar ciertas propiedades sin instanciar la clase
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Este método devuelve la fila y la columna en numeros enteros.
        /// Cumple SRP ya que su única responsabilidad es brindar propiedades para facilitar la interaccion con el usuario
        /// </summary>
        /// <param name="coord">Es la coordenada de la matriz del tablero</param>
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

        /// <summary>
        /// El método Swap permite ir variando el turno del jugador
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <typeparam name="T">Es el tipo, tal que sea genérico</typeparam>
        public static void Swap<T>(ref T param1, ref T param2)
        {
            T temporal;
            temporal = param1;
            param1 = param2;
            param2 = temporal;
        }
    }
}