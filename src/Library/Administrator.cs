using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase cumple el rol de administrador.
    /// Es Expert.
    /// Es un singleton ya que solo existirá un administrador y se lo puede llamar desde distintas clases.
    /// Cumple Creator ya que tiene responsabilidad de crear instancias de:
    /// - Game: cuando une a dos jugadores que quieren jugar.
    /// - User: Para registrar el usuario y agregalo al UserContainer
    /// Cumple (LCHC) Low Coupling and High Cohesion
    /// Hace lo mínimo necesario como para realizar tareas de administrador
    /// Es altamente cohesiva porque lo poco que hace está sumamente relacionado, pero tiene muchas relaciones con otras clases, con lo cual va a estar muy acoplada.
    /// </summary>
    public static class Administrator
    {


        /// <summary>
        /// Finaliza la partida si es indicado
        /// Hace que la clase use Game
        /// </summary>
        /// <param name="game">Recibe como parámetro la partida</param>

        public static void EndGame(Game game)
        {
            if (game.GameFinished())
            {
                Console.Write("La partida ha finalizado");
            }
            else
            {
                throw new GameNotFinishedException("El juego aún no finaliza");
            }
        }




    }
}
