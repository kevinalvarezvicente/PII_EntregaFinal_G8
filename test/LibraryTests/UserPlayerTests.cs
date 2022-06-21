using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Se hace test para los métodos de la clase Utilidades
    /// </summary>
    public class UserPlayerTests
    {
        /// <summary>
        /// Se testea el ID al registrar un nuevo usuario, dado que en otros tests tambien se registro usuarios esta sería la numero 23 y 24
        /// </summary>
        [Test]
        public void TestCurrentID()
        {
            User carol = new User("Carol","Glass");
            User tony = new User("Tony","Pereira");
            Assert.AreEqual(23 ,carol.UserId);
            Assert.AreEqual(24,tony.UserId);
        }
        /// <summary>
        /// Se testea el ID al registrar un nuevo usuario denuevo chequeando que funciona, dado que en otros tests tambien se registro usuarios esta sería la numero 25
        /// </summary>
        [Test]
        public void TestCurrentIDAgain()
        {
            User kevin = new User("Kevin","Alvarez");
            Assert.AreEqual(25,kevin.UserId);
        }
    }
}
