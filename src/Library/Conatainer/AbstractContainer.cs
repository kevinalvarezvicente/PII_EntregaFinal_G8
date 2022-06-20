using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public abstract class AbstractContainer <T>
    {
       
        public List<T> ContainerList =  new List<T>();
        public void AddItem(T item)
        {
            if(!this.ContainerList.Contains(item))
            {
                this.ContainerList.Add(item);
            }
            else
            {
                throw new ContainerException($"El elemento ya está en la lista");
            }
        }

        public void RemoveItem(T item)
        {
            if (this.ContainerList.Contains(item))
            {
                this.ContainerList.Remove(item);
            }
            else
            {
                throw new ContainerException($"El elemento no está en la lista");
            }
        }

        public List<T> GetContainer()
        {
            return ContainerList;
        }
        /// <summary>
        /// Se vacia el contenedor para poder usarlo en los test 
        /// </summary>
        public void ClearContainer()
        {
            ContainerList.Clear();
        }
    }
}