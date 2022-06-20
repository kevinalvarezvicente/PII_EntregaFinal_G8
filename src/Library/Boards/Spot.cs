namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Spot
    {
        public int X {get;}
        public int Y {get;}
        public bool wasHit{get; set;}

        public Spot(int x, int y)
        {
            this.X=x;
            this.Y=y;
            this.wasHit=default;
        }
        public bool CompareUserPosition(int x, int y)
        {
           return this.X==x && this.Y==y;
        }
    }
}