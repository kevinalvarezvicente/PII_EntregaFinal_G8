using System;
namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Subclase de exception, esta axcepcion será utilizada para cuando ocurra algo inesperado al utilizar algún método de Container
    /// Cumple SRP cuya única responsabilidad es lanzar la excepción
    /// </summary>
    public class ContainerException:Exception 
    {
        /// <summary>
        /// Constructor que recibe el mensaje
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public ContainerException(string message):base(message)
        {
        }
    }
}