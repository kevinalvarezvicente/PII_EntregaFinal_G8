using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase agregada por OCP
    /// </summary>
    public abstract class AbstractShip
    {
        private Dictionary<(int, int), bool> coordsDic;

        protected AbstractShip(int shipSize)
        {
            this.coordsDic = new Dictionary<(int, int), bool>();

        }

        public Dictionary<(int, int), bool> CoordsDict
        {
            get
            {
                return this.coordsDic;
            }
            private set
            {
                this.coordsDic = value;
            }
        }

        public abstract bool IsShipSinked();
    }
}


