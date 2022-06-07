using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    
    public class Singleton<T> where T: new()            
    //Se hace para poder utilizar singleton con diferentes clases
    //Al generar la clase se instancia T de manera unica
    //Clase que permite controlar que solo se instancie una vez

    {
            
        private static T instance;      //Constructor siempre privado, es el unico que sabe que esta instanciado
        
        public static T Instance        //Metodo, si no se instancia lo instancia. Siempre devuelve la misma instancia

        /*Al acceder por primera vez a la propiedad de clase Instance 
        se crea la única instancia y se guarda en la variable de clase privada instance
        Luego cada vez que se accede a la propiedad de clase Instance se retorna esa única instancia.*/

        //Se usa cuando se tiene multiples hilos, un hilo instancia, le deja a otro, se lo da a otro. Cuando un hilo toma la instancia no se quiere que el otro tambien instancie. Por eso es unico.        

        {
            get
            {
                if (instance == null)
                {
                    instance = new T ();
                }

                return instance;

            }
        }
    } 
}
