using System;
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
                Console.WriteLine("Se agrego el usuario a la lista");
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
        /// <param name="user">Recibe por parámetro un usuario para eliminar de la lista de usuarios</param>
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
        /// <summary>
        /// Verifica que el usuario este registrado
        /// </summary>
        /// <param name="ID">Recibe por parámetro el ID del usuario de telegram</param>
        /// <returns>Retorna verdadero o falso si el usuario esta registrado o no</returns>
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
        /// <summary>
        /// Obtiene el Usuario según ID
        /// </summary>
        /// <param name="ID">Recibe por parámetro el ID del usuario de telegram</param>
        /// <returns>Devuelve el usuario que concuerde con el ID o lanza una excepcion</returns>
        public static User GetUSerByID(long ID)
        {
            for (int i = 0; i<userscontainer.Count; i++)
            {   
                Console.WriteLine(userscontainer[i]);
                if (ID==userscontainer[i].UserId)
                {
                    
                    return userscontainer[i];
                }
            }
           throw new ContainerException("No se encontro user id");
        }
        
    }
}