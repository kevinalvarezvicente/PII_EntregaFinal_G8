namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase que implementa método AddOneShot de la clase abstracta ShotCounter
    /// Expert: experta en la informacion con la cantidad de tiros.
    /// SRP (Single Responsibility Principle): única responsabilidad es sumar 1 al contador de tiros a barcos. Tiene una única razon de cambio, pues tiene solo un método y no depende de otras clases que puedan llegar a afectarla.
    /// ISP (Interface segregation principle): La clase abstracta que implementa la utiliza. Una clase no debe implementar interfaz o clase abstracta que no utilice.
    /// LCHC: Hace lo mínimo necesario como almacenar la cantidad de tiros a barcos. Es altamente cohesiva porque lo poco que hace es utilizado por la clase Game pero tiene relaciones con otra clase que es abstracta, con lo cual va a estar muy poco acoplada.
    /// </summary>
    public class ShipShotCounter: ShotCounter
    {
        /// <summary>
        /// Método implementado de ShotCounter que suma un tiro a la cantidad de tiros a los barcos
        /// </summary>
        public override void AddOneShot()
        {
            Counter+=1;
        }

        

    }
}