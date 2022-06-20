namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es subclase de Container pues hereda métodos y atributos y puede agregar otro
    /// </summary>
    public class LobbyContainer: Container<User>
    {
        /// <summary>
        /// Este método es agregado de la clase chequea que hayan suficiente cantidad de usuarios esperando para jugar
        /// </summary>
        /// <returns>Retorna un booleano tal que si hay mas de 2 usuarios retornará true</returns>
        public bool AreUsersToStartGame() 
        {
            if (ContainerList.Count>=2)
            {
                return true;
            }
            else
            {
                return false;
                
            }
        }        
    }
}