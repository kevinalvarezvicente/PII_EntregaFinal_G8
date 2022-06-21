using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es una clase base para los siguientes contenedores.
    /// Se aplicará herencia permitiendo que las clases derivadas apliquen los métodos
    /// </summary>
    /// <typeparam name="T">Significa que todas las operaciones aceptarán cualquier objeto de las clases derivadas</typeparam>
    public abstract class Container <T>
    {
        /// <summary>
        /// No tiene un constructor de por sí pero creando el Container se crea una lista de tipo genérico.
        /// </summary>
        public List<T> containerList = Singleton<List<T>>.Instance;
        /// <summary>
        /// Operación genérica.
        /// </summary>
        /// <param name="item">Demuestra que se puede poner como argumento cualquier elemento </param>
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
        /// <summary>
        /// Operación genérica
        /// </summary>
        /// <param name="item">Acepta cualquier tipo</param>
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
        /// <summary>
        /// Es una operación genérica
        /// </summary>
        /// <returns>Retorna la lista de objetos que estén en el contenedor</returns>
        public List<T> ContainerList
        {
            get
            {
                return containerList;
            }
        }
    }
}