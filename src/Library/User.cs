using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Class User guarda y trabaja con la información del usuario
    /// Es experta en la información del usuario
    /// Cumple (LCHC) Low Coupling and High Cohesion
    /// Hace lo mínimo necesario como almacenar la información del usuario y delega todo lo demás 
    /// Es altamente cohesiva porque lo poco que hace está sumamente relacionado, pero tiene muchas relaciones con otras clases, con lo cual va a estar muy acoplada.
    /// </summary>
    public class User
    {
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
        /// El constructor de Usuario crea una Lista de juegos del usuario
        /// </summary>
        /// <param name="userId">Es de tipo int</param>
        /// <param name="name">Es de tipo int</param>
        public User(int userId, string name)
        {
            this.UserId = userId;
            this.Name = name;
        }
        /// <summary>
        /// El método dice si el usuario quiere jugar llama al lobby para que lo agregue a la lista
        /// </summary>
        public void WantToPlay()
        {
            Singleton<LobbyContainer>.Instance.AddItem(this);
        }

    }
}