using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace ClassLibrary
{
    /// <summary>
    /// La clase que guardará la cadena de los datos de los handlers. 
    /// Es un singleton pues permite controlar que solo se instancie una vez
    /// </summary>
    public class ChainData
    {
        /// <summary>
        /// Constructor privado, es el unico que sabe que esta instanciado
        /// </summary>
        private static ChainData _instance;
        /// <summary>
        /// Es un diccionario que guardará la posicion del handler en el que se encuentra el jugador
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Collection<string>> userPostionHandler = new Dictionary<string, Collection<string>>();
        /// <summary>
        /// Al acceder por primera vez a la propiedad de clase Instance 
        /// se crea la única instancia y se guarda en la variable de clase privada instance
        ///Luego cada vez que se accede a la propiedad de clase Instance se retorna esa única instancia.
        /// </summary>
        /// <value></value>
        public static ChainData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ChainData();
                }
                return _instance;
            }
        }
    }
}