using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Se crea una clase Abstracta para el tablero AbstractBoard de la que hereda Board.
    /// La clase AbstractBoard tiene la responsabilidad de inicializar un tablero 
    /// Cumple con OCP (Open/Close Principle) pues es abierta a la extension pero cerrada a la modificacion.
    /// Si el día de mañana, se quiere que agregar un tablero que sea con letras se puede perfectamente agregando otra clase que herede de esta y modificando el método utilizado de inicializar tablero con override
    /// </summary>
    public abstract class AbstractBoard
    {
        
        /// <summary>
        /// Metodo que inicializa el tablero .
        /// </summary>
        /// <param name="x">Largo del lado del tablero</param>
        public abstract void InitializeBoard(int x);



    }
}

