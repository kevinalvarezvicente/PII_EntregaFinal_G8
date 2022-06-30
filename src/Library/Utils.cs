using System;
using System.Linq;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase permite usar ciertas propiedades sin instanciar la clase
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Convierte un numero a letra patra cuando salta mensaje del bot
        /// </summary>
        /// <param name="number">Recibe por parámetro el numero que es el tamaño del tablero</param>
        /// <returns>Retorna la letra para el mensaje del boto</returns>
        public static string NumberToletter(int number)
        {
            string[] abc = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            return abc[number];
        }

        /// <summary>
        /// Este método devuelve la fila y la columna en numeros enteros.
        /// Cumple SRP ya que su única responsabilidad es brindar propiedades para facilitar la interaccion con el usuario
        /// </summary>
        /// <param name="coord">Es la coordenada de la matriz del tablero</param>
        /// <returns></returns>
        public static (int row, int column) SplitCoordIntoRowAndColumn(string coord)
        {
            if (coord.Length != 2)
            {
                throw new CoordException($"{coord} es una coordenada inválida");
            }
            char[] coordArray = coord.ToArray();
            int row = (int)Char.GetNumericValue(coordArray[0]);
            int column = (int)Char.GetNumericValue(coordArray[1]);
            return (row, column);


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