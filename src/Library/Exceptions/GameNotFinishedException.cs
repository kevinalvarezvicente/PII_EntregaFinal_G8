using System;
namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase derivada de Exception que se utilizará para cuando la partida aún ni finaliza
    /// Cumple SRP cuya única responsabilidad es lanzar la expeción
    /// único motivo de cambio es si se desea agrgarle otro parámetro 
    /// </summary>
    public class GameNotFinishedException:Exception 
    {
        /// <summary>
        /// Constructor que recibe el mensaje
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public GameNotFinishedException(string message):base(message)
        {
        }
    }
}