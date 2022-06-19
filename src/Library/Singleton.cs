namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Se hace para poder utilizar singleton con diferentes clases
    /// Al generar la clase se instancia T de manera unica
    /// Clase que permite controlar que solo se instancie una vez
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : new()
    {
        /// <summary>
        /// Constructor privado, es el unico que sabe que esta instanciado
        /// </summary>
        private static T instance;
        /// <summary>
        /// Al acceder por primera vez a la propiedad de clase Instance 
        /// se crea la única instancia y se guarda en la variable de clase privada instance
        ///Luego cada vez que se accede a la propiedad de clase Instance se retorna esa única instancia.*/
        /// </summary>
        /// <value></value>      
        public static T Instance        
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;

            }
        }
    }
}
