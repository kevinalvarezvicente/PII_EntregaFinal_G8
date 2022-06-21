using System;
namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase que hereda de Exception, es clase derivada que se utilizará si la coordenada al hacer el shot no existe 
    /// Cumple SRP cuya única responsabilidad es lanzar la excepción
    /// </summary>
    public class ReceiveShotException:Exception 
    {
        /// <summary>
        /// Constructor que recibe el mensaje
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public ReceiveShotException(string message):base(message)
        {
        }
    }
}