using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase estatica para no tener que instanciar en cada momento
    /// </summary>
    public static class UsersContainer
    {
        /// <summary>
        /// Contenedor de todos los usuarios registrados
        /// </summary>
        /// <returns></returns>
        private static List<User> userscontainer = new List<User>();
        /// <summary>
        /// Añade al usuario luego de registrarlo. Método utilizado por Administrator
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(User user)
        {
            if(!userscontainer.Contains(user))
            {
                userscontainer.Add(user);
            }
            else
            {
                throw new ContainerException($"El elemento ya está en la lista");
            }

            
        }
        /// <summary>
        /// Permite tener acceso al contenedor de usuarios
        /// </summary>
        /// <value></value>
        public static List<User> usersContainer
        {
            get
            {
                return userscontainer;
            }
        }
        /// <summary>
        /// Hay opcion de eliminar usuario si éste lo desea
        /// </summary>
        /// <param name="user"></param>
        public static void RemoveUser(User user)
        {
            
            if(userscontainer.Contains(user))
            {
                userscontainer.Remove(user);
            }
            else
            {
                throw new ContainerException($"El elemento ya está en la lista");
            }
        }

        public static bool VerifyUserByID(long ID)
        {
            for (int i = 0; i<userscontainer.Count; i++)
            {
                if (ID==userscontainer[i].UserId)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}