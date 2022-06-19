using System;
using System.Runtime.Serialization;

[Serializable]
public class LibraryException : Exception
//Esta clase se va a re modificar pero aún no hemos tenido tiempo. La idea es crear clases según las posibles excepciones
//Se define la clase de la nueva excepcion a levantar. 
//No es absolutamente necesario definir nuevas clases de excepcion si las que ya existen son adecuadas.
//Todas las excepciones son instancias de una clase sucesora de la clase base Exception
//Debe implementar constructores sin parámetros, con el mensaje como parámetro, con un mensaje y una excepción encadenada y decorada con el atributo [Serializable]
{
    public LibraryException()
    //Constructor sin parámetros
    {
    }

    public LibraryException(string message)
    : base(message)
    //Constructor con el mensaje como parámetro
    {
    }

    public LibraryException(string message, Exception innerException)
    : base(message, innerException)
    //Constructor con un mensaje y una excepcion encadenada
    {
    }

    protected LibraryException(SerializationInfo info, StreamingContext context)
    : base(info, context)
    //debe ser decorada con el atributo [Serializable]
    //Preguntar porque protected
    {
    }


}
