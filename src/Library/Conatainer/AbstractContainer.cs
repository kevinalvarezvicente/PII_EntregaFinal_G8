using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public abstract class AbstractContainer <T>
    {
        public List<T> ItemsList = new List<T>();
        public void AddItem(T item)
        {
            if(!this.ItemsList.Contains(item))
            {
                this.ItemsList.Add(item);
            }
        }

        public void RemoveItem(T item)
        {
            if (this.ItemsList.Contains(item))
            {
                this.ItemsList.Remove(item);
            }
        }

        public List<T> GetItemsInContainer()
        {
            return ItemsList;
        }
    }
}