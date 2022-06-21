using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase estatica para no tener que instanciar en cada momento
    /// </summary>
    public static class UsersContainer
    {
        private static List<User> userscontainer = new List<User>();

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
        public static List<User> usersContainer
        {
            get
            {
                return userscontainer;
            }
        }
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

        /*public static List<string> SearchUserByID(int ID)
        {
            for (int i = 0; i<userscontainer.Count; i++)
            {
                if (ID==userscontainer[i].UserId)
                {
                    List<string> list = new List<string>()
                                                {
                                                    userscontainer[i].Name,
                                                    userscontainer[i].Surename,
                                                };
                    return list;
                }
                else
                {
                    throw new ContainerException("No se ha encontrado el usuario");
                }
            }
        }*/
        
    }
}