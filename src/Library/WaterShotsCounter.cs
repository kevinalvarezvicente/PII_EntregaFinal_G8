namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase que hereda de la clase abstracta ShotCounter
    /// Expert: experta en la informacion con la cantidad de tiros al agua.
    /// SRP: única responsabilidad es sumar 1 al contador de tiros al agua. Tiene una única razon de cambio, pues tiene solo un método y no depende de otras clases que puedan llegar a afectarla.
    /// ISP (Interface segregation principle): La clase abstracta que implementa la utiliza. Una clase no debe implementar interfaz o clase abstracta que no utilice.
    /// LCHC: Hace lo mínimo necesario como almacenar la cantidad de tiros al agua. Es altamente cohesiva porque lo poco que hace es utilizado por la clase Game pero tiene relaciones con otra clase que es abstracta, con lo cual va a estar muy poco acoplada.
    /// </summary>
    public class WaterShotCounter: ShotCounter
    {
        /// <summary>
        /// Método implementado de ShotCounter que suma un tiro a la cantidad de tiros al agua
        /// </summary>
        public override void AddOneShot()
        {
            Counter+=1;
        }

        
    }
}