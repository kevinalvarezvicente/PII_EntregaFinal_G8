using System;
namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase que hereda de Exception, es clase derivada que se utilizará si la opcion seleccionada no existe
    /// Cumple SRP cuya única responsabilidad es lanzar la excepción
    /// único motivo de cambio es si se desea agrgarle otro parámetro 
    /// </summary>
    public class OptionException:Exception 
    {
            /// <summary>
        /// Constructor que recibe el mensaje
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public OptionException(string message):base(message)
        {
            
        }
    }
}