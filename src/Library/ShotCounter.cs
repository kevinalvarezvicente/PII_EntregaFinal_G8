namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Se crea una clase Abstracta para el contador ShotCounter de la que heredan
    /// La clase AbstractBoard tiene la responsabilidad de crear un contador de tiros.
    /// SRP: La única razón de cambio es si se desea agregar un método. 
    /// OCP (Open/Close Principle): Es abierta a la extension pero cerrada a la modificacion. Si el día de mañana, se quiere que agregar un contador que cuente cada vez que se dispara a una coordenada repetida se puede perfectamente agregando otra clase que herede de esta y modificando el método utilizado de AddShot con override.
    /// </summary>
    public abstract class ShotCounter
    {
        /// <summary>
        /// Atributo protected, pues es usado por las clases que hereden de ella
        /// </summary>
        protected int counter;
        /// <summary>
        /// Metodo de acceso al contador de tiros
        /// </summary>
        /// <value></value>
        public int Counter {get; protected set;}
        /// <summary>
        /// Método de clase abstracta que permite a cada contador de tiros sumar como desee
        /// </summary>
        public abstract void AddOneShot();


    }
}