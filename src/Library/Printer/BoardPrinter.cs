using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase que implementa la interfaz IPrinter. 
    /// El único método que necesita también debe poder ser utilizado para imprimir un tablero de disparos.
    /// Tiene la responsabilidad de imprimir el tablero del jugador con barcos
    /// Se podría decir que cumple con SRP.
    /// Es expert, es quien tiene toda la informacion para imprimir tablero
    /// Tiene un único motivo de cambio, pues solo imprime el tablero de tiros.
    /// Es polimórfica pasandole por parámetro un argumento de tipo Board si el dia de mañana se creara otro tipo de tablero se imprimira sin problema. 
    /// Cumple DIP pues a través de la clase abstracta AbstractBoard de la que Board depende y que BoardPrinter depende también de esa abstracción por la interfaz de la cual hereda.
    /// </summary>
    public class BoardPrinter: IPrinter
    {
        /// <summary>
      /// Permite imprimir el tablero de tiros del jugador pasado por parámetro.
      /// Es una operación polimórfica se debe pasar por parámetro un objeto de tipo Board y allí imprime por pantalla sin problema si se le manda ShotBoard o ShipBoard o si el día de mañana se agrega otro subtipo de Board.
      /// </summary>
      /// <param name="board">Jugador dueño del tablero que se desea imprimir por pantalla</param>
        public void PrintPlayerBoard(AbstractBoard board)
        {
            
            for (int i = 0; i < board.GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j <  board.GameBoard.GetLength(1); j++)
                {
                Console.Write( board.GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }
        }

        
    }
}








