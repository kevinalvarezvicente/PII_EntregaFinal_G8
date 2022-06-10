namespace PII_ENTREGAFINAL_G8.src.Library
{
    public static class Swap
    {
        public static void Swaping<T>(ref T param1, ref T param2)
        {
            T temporal;
            temporal = param1;
            param1 = param2;
            param2 = temporal;
        }
    }
}
