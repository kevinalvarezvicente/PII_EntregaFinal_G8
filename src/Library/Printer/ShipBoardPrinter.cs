using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase que implementa la interfaz IPrinter. 
    /// El único método que necesita también debe poder ser utilizado para imprimir un tablero de disparos.
    /// Tiene la responsabilidad de imprimir el tablero del jugador con barcos
    /// Se podría decir que cumple con SRP
    /// Tiene un único motivo de cambio, pues solo imprime el tablero de tiros.
    /// Se esta trabajando para que haga lo mismo pero pasandole por parámetro si va a ser tablero de tiros o de barcos
    /// </summary>
    public class ShipBoardPrinter
    //: IPrinter
    {
        /// <summary>
        /// CLASE SIN FUNCIONAR AUN
      /// Permite imprimir el tablero de tiros del jugador pasado por parámetro.
      /// Para que sea una operación polimórfica se debe pasar por parámetro un objeto de tipo Board y allí imprime por pantalla sin problema si se le manda ShotBoard o ShipBoard.
      /// </summary>
      /// <param name="player">Jugador dueño del tablero que se desea imprimir por pantalla</param>
        public void PrintPlayerShipBoard(Player player)
        {
            Console.WriteLine($"Se imprime el tablero de barcos de {player.PlayerName}");
            for (int i = 0; i < player.PlayerShipBoard.GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < player.PlayerShipBoard.GameBoard.GetLength(1); j++)
                {
                Console.Write(player.PlayerShipBoard.GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }
        }
    }
}








