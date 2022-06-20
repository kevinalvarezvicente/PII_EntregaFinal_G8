namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class LobbyContainer: AbstractContainer<User>
    {
        /// <summary>
        /// Este método chequea que hayan suficiente cantidad de usuarios esperando para jugar
        /// </summary>
        /// <returns> Retorna un booleano tal que si hay mas de 2 usuarios retornará true </returns>
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