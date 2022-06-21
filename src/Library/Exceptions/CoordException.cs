using System;
namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase derivada de Exception que se utilizará para cuando hay algún error al agregar una coordenada
    /// Cumple SRP cuya única responsabilidad es lanzar la excepción
    /// único motivo de cambio es si se desea agrgarle otro parámetro 
    /// </summary>
    public class CoordException:Exception 
    {
        /// <summary>
        /// Constructor que recibe el mensaje
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public CoordException(string message):base(message)
        {
        }
    }
}