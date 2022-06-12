using System;
using System.Runtime.Serialization;


/// <summary>
///  
/// </summary>
[Serializable]
public class LibraryException : Exception
//Se define la clase de la nueva excepcion a levantar. 
//No es absolutamente necesario definir nuevas clases de excepcion si las que ya existen son adecuadas.
//Todas las excepciones son instancias de una clase sucesora de la clase base Exception
//Debe implementar constructores sin parámetros, con el mensaje como parámetro, con un mensaje y una excepción encadenada y decorada con el atributo [Serializable]
{
    /// <summary>
    ///  
    /// </summary>
    public LibraryException()
    //Constructor sin parámetros
    {
    }
    /// <summary>
    ///  
    /// </summary>
    public LibraryException(string message)
    : base(message)
    //Constructor con el mensaje como parámetro
    {
    }
    /// <summary>
    ///  
    /// </summary>
    public LibraryException(string message, Exception innerException)
    : base(message, innerException)
    //Constructor con un mensaje y una excepcion encadenada
    {
    }
    /// <summary>
    ///  
    /// </summary>
    protected LibraryException(SerializationInfo info, StreamingContext context)
    : base(info, context)
    //debe ser decorada con el atributo [Serializable]
    //Preguntar porque protected
    {
    }


}
