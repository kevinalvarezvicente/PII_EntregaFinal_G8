using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Class User guarda y trabaja con la información del usuario
    /// Es expert por contener toda la información del usuario
    /// Cumple (LCHC) Low Coupling and High Cohesion
    /// Hace lo mínimo necesario como almacenar la información del usuario y delega todo lo demás 
    /// Es altamente cohesiva porque lo poco que hace está sumamente relacionado, pero tiene muchas relaciones con otras clases, con lo cual va a estar muy acoplada.
    /// </summary>
    public class User 
    {

        public static List<User> usersList = new List<User>();

        /// <summary>
        ///El campo estático currentID almacena el ID de usuario de la última persona que ha sido creado. 
        /// </summary>
        private static int currentID;

        /// <summary>
        /// Es el ID de usuario
        /// </summary>
        /// <value>Cada usuario tiene el suyo</value>
        public long UserId { get; private set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        /// <value></value>
        public string Name { get; private set; }
        /// <summary>
        /// Apellido del usuario
        /// </summary>
        /// <value></value>
        public string Surename { get; private set; }
        /// <summary>
        /// Es la lista de juegos del usuario propio
        /// </summary>
        /// <value></value>
        //public List<Game> UserGamesList { get; private set; }
        /// <summary>
        /// El constructor de Usuario crea una Lista de juegos del usuario
        /// </summary>
        /// <param name="name">Es de tipo int</param>
        /// <param name="surename">Es de tipo string</param>
        public User(long userId, string name, string surename)
        {
            this.UserId = userId;
            this.Name = name;
            this.Surename = surename;
        }





    }
}