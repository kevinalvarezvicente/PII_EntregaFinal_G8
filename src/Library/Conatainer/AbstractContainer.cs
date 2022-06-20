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
        }

        public void RemoveItem(T item)
        {
            if (this.ContainerList.Contains(item))
            {
                this.ContainerList.Remove(item);
            }
        }

        public List<T> GetContainer()
        {
            return ContainerList;
        }
    }
}