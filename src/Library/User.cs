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
        /// <summary>
        ///El campo estático currentID almacena el ID de usuario de la última persona que ha sido creado. 
        /// </summary>
        private static int currentID;
        /// <summary>
        ///  Se registra con la instancia de UserGamesContainer en el constructor,
        /// </summary>
        private UserGamesContainer container;
        /// <summary>
        /// Solo get ya que se quiere acceder de afuera al contenedor 
        /// </summary>
        /// <value>En el caso de que se quiera agregar o remover una partida el método es de la clase UserGamesContainer</value>
        
        public UserGamesContainer Container
        {
            get 
            {
                return this.container;
            }
        }
        /// <summary>
        /// Es el ID de usuario
        /// </summary>
        /// <value>Cada usuario tiene el suyo</value>
        public int UserId { get; private set; }
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
        /// El constructor de Usuario crea una Lista de juegos del usuario
        /// </summary>
        /// <param name="name">Es de tipo int</param>
        /// <param name="surename">Es de tipo string</param>
        public User(string name, string surename)
        {
            GetNextID();
            this.UserId= currentID;
            this.Name = name;
            this.Surename=surename;
        }
        /// <summary>
        /// El método dice si el usuario quiere jugar llama al lobby para que lo agregue a la lista
        /// </summary>
        public void WantToPlay()
        {
            Singleton<LobbyContainer>.Instance.AddItem(this);
        }
                         

        /// <summary>
        /// Constructor estático para inicializar el miembro estático, currentID. 
        /// Este se llama al constructor una vez, automáticamente, antes de cualquier instancia User se crea, o se hace referencia a currentID.
        /// </summary>
        static User() => currentID = 0;

        /// <summary>
        /// currentID es un campo estático. 
        /// </summary>
        /// <returns>Se incrementa cada vez que una nueva se crea una instancia de Person.</returns>

        protected int GetNextID() => ++currentID;

    }
}